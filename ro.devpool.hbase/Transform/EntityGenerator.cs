using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FastMember;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Interfaces.Proxy;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Models.Apache;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Transform
{
    internal class EntityGenerator<TEntity> where TEntity : class
    {
        private readonly IActivator<TEntity> _activator;
        private readonly ClassMap _map;

        internal EntityGenerator(ClassMap map)
        {
            _map = map;
            if (!(map.Generator is IActivator<TEntity> gen))
                throw new Exception($"Cannot generate object of type {map.Name}");

            _activator = gen;
        }

        public TEntity BuildEntity(TRowResult input)
        {

            var target = _activator.Activate();
            var accessor = ObjectAccessor.Create(target);

            var timestamps = new ConcurrentDictionary<string, long>();


            ProcessMap(_map, accessor, input.Columns, timestamps);
            RowkeyProcessor.PopulateEntity(target, _map.RowKey, input.Row, accessor);

            if (target is ITimestamp ts)
                ts.Set(new Dictionary<string, long>(timestamps));

            return target;
        }
        public IList<TEntity> BuildEntities(List<TRowResult> input)
        {
            var entities = new ConcurrentBag<TEntity>();

            Parallel.ForEach(input, row => { entities.Add(BuildEntity(row)); });

            return entities.ToList();
        }

        private object GenerateValue(Type type, string value)
        {
            return Convert.ChangeType(value, type);
        }

        private void ProcessMap(IMap map, ObjectAccessor accessor, Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {
            switch (map)
            {
                case ClassMap classMap:
                    ProcessClassMap(classMap, accessor, input, ts);
                    return;
                case PropertyMap propertyMap:
                    ProcessPropertyMap(propertyMap, accessor, input, ts);
                    return;
                case SubClassMap subClassMap:
                    ProcessSubClassMap(subClassMap, accessor, input, ts);
                    return;
                case ListMap listMap:
                    ProcessListMap(listMap, accessor, input, ts);
                    return;
                case DictionaryMap dictionaryMap:
                    ProcessDictionaryMap(dictionaryMap, accessor, input, ts);
                    return;

                default:
                    return;
            }
        }

        private void ProcessClassMap(ClassMap map, ObjectAccessor accessor,
            Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts) // move to baseclass
        {
            Parallel.ForEach(map.Maps, subMap => { ProcessMap(subMap, accessor, input, ts); });
        }

        private void ProcessPropertyMap(PropertyMap map, ObjectAccessor accessor, Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {

            var cell = input.SingleOrDefault(x => x.Key.SequenceEqual(map.FullColumnKey.GetBytes())).Value;

            if (cell == null)
                return;

            accessor[map.Name] = GenerateValue(map.Type, cell.Value.GetString());
            ts.TryAdd(map.FullColumnKey, cell.Timestamp);
        }

        private void ProcessSubClassMap(SubClassMap map, ObjectAccessor accessor, Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {
            var target = Activator.CreateInstance(map.Type);
            var targetAccessor = ObjectAccessor.Create(target);

            Parallel.ForEach(map.Mappers.Select(x => x.ExposeMap()),
                subMap => { ProcessMap(subMap, targetAccessor, input, ts); });

            accessor[map.Name] = target;
        }

        private void ProcessListMap(ListMap map, ObjectAccessor accessor, Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {
            switch (map.MappingStrategy)
            {
                case MappingStrategy.EntireCfAsObject:
                    EntireCfAsObject(map, accessor, input, ts);
                    break;
                case MappingStrategy.RegexColumnsAsObject:
                    break;
                case MappingStrategy.ColumnAsList:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ProcessDictionaryMap(DictionaryMap map, ObjectAccessor accessor,
            Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {

            var targetedCells = input.Where(x => x.Key.StartsWith(map.FullColumnFamily.GetBytes()));
            var genericParams = map.Type.GetGenericArguments();

            if (genericParams.Length > 2)
                throw new Exception($"Expected 2 type params, got {genericParams.Length}");

            var type = typeof(Dictionary<,>).MakeGenericType(genericParams);
            var obj = (IDictionary)Activator.CreateInstance(type);

            foreach (var column in targetedCells) //TODO: Paralelize this (protip: make a concurrent dictionary from the interface!!)
            {
                var key = TypeDescriptor.GetConverter(genericParams.First());
                var value = TypeDescriptor.GetConverter(genericParams.Last());

                obj.Add(key.ConvertFromString(column.Key.GetString().RemoveCf(map.ColumnFamily)), value.ConvertFromString(column.Value.Value.GetString()));

                ts.TryAdd(column.Key.GetString(), column.Value.Timestamp);
            }
        }

        private void EntireCfAsObject(ListMap map, ObjectAccessor accessor, Dictionary<byte[], TCell> input, ConcurrentDictionary<string, long> ts)
        {
            var targetedCells = input.Where(x => x.Key.StartsWith(map.ColumnFamily.GetBytes()));

            var ltype = typeof(List<>).MakeGenericType(map.ActingObjectType);

            var list = (IList)Activator.CreateInstance(ltype);

            foreach (var targetedCell in targetedCells) //TODO: paralelize this?
            {
                var target = Activator.CreateInstance(map.ActingObjectType);
                var targetAccessor = ObjectAccessor.Create(target);


                targetAccessor[map.ColumnName.name] =
                    GenerateValue(map.ColumnName.type, targetedCell.Key.GetString().RemoveCf(map.ColumnFamily));
                targetAccessor[map.ColumnValue.name] =
                    GenerateValue(map.ColumnValue.type, targetedCell.Value.Value.GetString());

                ts.TryAdd(targetedCell.Key.GetString(), targetedCell.Value.Timestamp);

                //TODO: HOOK for timestamp 

                list.Add(target);
            }

            accessor[map.Name] = list;
        }
    }
}