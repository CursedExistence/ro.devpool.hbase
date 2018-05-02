using System;
using System.Linq.Expressions;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class ColumnPrefixFilter<TEntity> : IScanFilter, IScanFilterBuild where TEntity : class
    {
        private string _columnName;
        private readonly ClassMap _map;

        internal ColumnPrefixFilter(ClassMap map)
        {
            _map = map; //TODO check if filter works
        }

        string IScanFilterBuild.Build()
        {
            return $"ColumnPrefixFilter ('{_columnName}')";
        }

        void IScanFilterBuild.Validate()
        {
            if (_columnName.IsNullOrEmpty())
                throw new FilterException("[ColumnPrefixFilter] ColumnName is null or empty");
        }

        public void ColumnName(string columnName)
        {
            _columnName = columnName;
        }

        public void ColumnName(Expression<Func<TEntity, object>> predicate)
        {
            //todo: rework this as the visitor will always expose 1 map associated to the property
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);

            var map = visitor.ExposeMap();

            //if (maps.Count > 1)
            //    throw new FilterException($"[ColumnPrefixFilter] Expected 1 column from predicate, got {maps.Count}");

            //var map = maps.FirstOrDefault(); 

            _columnName = map?.ColumnName;
        }
    }
}