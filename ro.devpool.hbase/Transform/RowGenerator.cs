using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMember;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Transform
{
    internal class RowGenerator<TEntity> where TEntity : class
    {
        public IList<HBaseCell> Serialize(ClassMap map, TEntity entity, IList<string> descriptors)
        {
            var accessor = ObjectAccessor.Create(entity);

            var key = RowkeyProcessor.ExtractFromEntity(entity, map.RowKey, accessor);
            
            return ProcessMap(map, accessor, key, descriptors);
        }

        public IEnumerable<HBaseCell> Serialize(ClassMap map, IEnumerable<TEntity> entities, IList<string> descriptors)
        {
            var cells = new ConcurrentBag<IEnumerable<HBaseCell>>();

            Parallel.ForEach(entities, entity => { cells.Add(Serialize(map, entity, descriptors)); });

            return cells.SelectMany(x => x);
        }

        private IList<HBaseCell> ProcessMap(IMap map, ObjectAccessor accessor, string key, IList<string> descriptors)
        {
            var cells = new List<HBaseCell>();

            switch (map)
            {
                case ClassMap classMap:
                    cells.AddRange(ProcessClassMap(classMap, accessor, key, descriptors));
                    break;
                case DictionaryMap dictionaryMap:
                    cells.AddRange(ProcessDictionaryMap(dictionaryMap, accessor, key, descriptors));
                    break;
                case ListMap listMap:
                    cells.AddRange(ProcessListMap(listMap, accessor, key, descriptors));
                    break;
                case PropertyMap propertyMap:
                    var cell = ProcessPropertyMap(propertyMap, accessor, key, descriptors);
                    if (cell != null)
                        cells.Add(cell.Value);
                    break;
                case SubClassMap subClassMap:
                    cells.AddRange(ProcessSubclassMap(subClassMap, accessor, key, descriptors));
                    break;
            }

            return cells;
        }

        private IEnumerable<HBaseCell> ProcessClassMap(ClassMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            var output = new ConcurrentBag<IEnumerable<HBaseCell>>();
            Parallel.ForEach(map.Maps, subMap => { output.Add(ProcessMap(subMap, accessor, key, descriptors)); });

            return output.SelectMany(x => x);
        }

        private HBaseCell? ProcessPropertyMap(PropertyMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            if ((descriptors.Count > 0 && descriptors.Contains(map.FullColumnKey)) || descriptors.Count == 0)
                return new HBaseCell
                {
                    FullColumnName = map.FullColumnKey,
                    ValueString = accessor[map.Name]?.ToString(),
                    RowKey = key
                };

            return null;
        }

        private IEnumerable<HBaseCell> ProcessSubclassMap(SubClassMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            var maps = map.Mappers.Select(x => x.ExposeMap());
            var target = accessor[map.Name];
            var acc = ObjectAccessor.Create(target);

            var cells = new ConcurrentBag<IEnumerable<HBaseCell>>();

            Parallel.ForEach(maps, subMap => { cells.Add(ProcessMap(subMap, acc, key, descriptors)); });

            return cells.SelectMany(x => x);
        }

        private IEnumerable<HBaseCell> ProcessListMap(ListMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            var output = new List<HBaseCell>();

            switch (map.MappingStrategy)
            {
                case MappingStrategy.EntireCfAsObject:
                    output.AddRange(ProcessCfAsObject(map, accessor, key, descriptors));
                    break;
                case MappingStrategy.RegexColumnsAsObject:
                    break;
                case MappingStrategy.ColumnAsList:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return output;
        }

        private IEnumerable<HBaseCell> ProcessCfAsObject(ListMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            if (!(accessor[map.Name] is IList target))
                return new List<HBaseCell>();

            var acc = TypeAccessor.Create(map.ActingObjectType);
            var list = new ConcurrentBag<HBaseCell>();

            Parallel.ForEach((IEnumerable<object>) target, item =>
            {
                var fullName = $"{map.ColumnFamily}:{acc[item, map.ColumnName.name]}";
                if ((descriptors.Count > 0 && descriptors.Contains(fullName)) || descriptors.Count == 0)
                    list.Add(new HBaseCell
                    {
                        FullColumnName = fullName,
                        ValueString = acc[item, map.ColumnValue.name].ToString(),
                        RowKey = key
                    });
            });

            return list;
        }

        private IEnumerable<HBaseCell> ProcessDictionaryMap(DictionaryMap map, ObjectAccessor accessor, string key,
            IList<string> descriptors)
        {
            if (!(accessor[map.Name] is IDictionary target)) // prob fail
                return new List<HBaseCell>();

            var output = new ConcurrentBag<HBaseCell>();
            Parallel.ForEach((IList<object>) target.Keys, dk =>
            {
                var fullName = $"{map.ColumnFamily}:{dk}";

                if ((descriptors.Count > 0 && descriptors.Contains(fullName)) || descriptors.Count == 0)
                    output.Add(new HBaseCell
                    {
                        FullColumnName = fullName,
                        ValueString = target[dk].ToString(),
                        RowKey = key
                    });
            });
            return output;
        }
    }
}