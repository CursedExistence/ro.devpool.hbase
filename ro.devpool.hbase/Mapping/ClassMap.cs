using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Mapping
{
    /*
     * TODO: check if rowkey is set multiple times (rowkey or CompositeKey must be called once and cannot co-exist )
     */
    public abstract class ClassMap<TEntity> : BaseMap<TEntity> where TEntity : class
    {
        private ClassMap _map { get; }

        protected ClassMap()
        {
            _map = new ClassMap
            {
                Name = typeof(TEntity).Name,
                Type = typeof(TEntity)
            };
        }

        protected void Table(string tableName)
        {
            _map.TableName = tableName;
        }

        protected void Namespace(string @namespace)
        {
            _map.Namespace = @namespace;
        }

        internal ClassMap ExposeClassMap()
        {
            _map.Maps = ExposeMappers().Select(x => x.ExposeMap()).ToList();
            return _map;
        }

        protected void RowKey(Expression<Func<TEntity, string>> predicate)
        {
            ValidateRowKey(RowKeyKind.Simple);

            var prop = predicate.ExtractNameAndType();

            var map = new RowKeyMap
            {
                Name = prop.name,
                Type = prop.type
            };

            _map.RowKey = new RowKey(RowKeyKind.Simple, new List<RowKeyMap> {map});
        }

        protected void RowKey(Expression<Func<TEntity, ValueType>> predicate)
        {
            ValidateRowKey(RowKeyKind.Simple);

            var prop = predicate.ExtractNameAndType();

            var map = new RowKeyMap
            {
                Name = prop.name,
                Type = prop.type
            };

            _map.RowKey = new RowKey(RowKeyKind.Simple, new List<RowKeyMap> {map});
        }

        protected void CompositeKey(string separator, params Expression<Func<TEntity, object>>[] predicates)
        {
            ValidateRowKey(RowKeyKind.Composite);

            var maps = new List<RowKeyMap>();

            foreach (var predicate in predicates)
            {
                var prop = predicate.ExtractNameAndType();

                var map = new RowKeyMap
                {
                    Name = prop.name,
                    Type = prop.type
                };
                maps.Add(map);
            }

            _map.RowKey = new RowKey(RowKeyKind.Composite, maps, separator);
        }


        protected void CompositeKey(params Expression<Func<TEntity, object>>[] predicates)
        {
            CompositeKey("-", predicates);
        }

        private void ValidateRowKey(RowKeyKind kind)
        {
            if (_map.RowKey != null)
                throw new Exception($"Rowkey already set, you are trying to re-set it as {kind} !");
        }
    }
}