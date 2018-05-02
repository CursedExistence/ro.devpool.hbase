using System;
using System.Linq.Expressions;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class QualifierFilter<TEntity> : IScanFilter, IScanFilterBuild where TEntity : class
    {
        private Comparator _comparator = Utils.Comparator.Substring;
        private ComparisonOperator _comparisonOperator = Utils.ComparisonOperator.Equal;
        private readonly ClassMap _map;
        private string _columnName;

        internal QualifierFilter(ClassMap map)
        {
            _map = map;
            
            //TODO CHECK FILTER
        }

        string IScanFilterBuild.Build()
        {
            return
                $"QualifierFilter ({_comparisonOperator.GetComparisonOperatorString()},'{_comparator.GetComparatorString()}:{_columnName}' )";
        }

        void IScanFilterBuild.Validate()
        {
            if (_columnName.IsNullOrEmpty())
                throw new FilterException("[QualifierFilter] Column name cannot be null or empty!");

            if (!this.ValidateOperationForComparator(_comparator, _comparisonOperator))
                throw new FilterException(
                    $"Comparison operator: {_comparisonOperator.GetComparisonOperatorString()} not permitted on comparator: {_comparator.GetComparatorString()}");
        }

        public QualifierFilter<TEntity> Comparator(Comparator comparator)
        {
            _comparator = comparator;
            return this;
        }

        public QualifierFilter<TEntity> ComparisonOperator(ComparisonOperator comparisonOperator)
        {
            _comparisonOperator = comparisonOperator;
            return this;
        }

        public QualifierFilter<TEntity> Column(Expression<Func<TEntity, object>> predicate)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);

            var map = visitor.ExposeMap();

            //if (maps.Count > 1)
            //    throw new FilterException($"[ColumnPrefixFilter] Expected 1 column from predicate, got {maps.Count}");

            //var map = maps.FirstOrDefault();

            _columnName = map?.ColumnName;
            return this;
        }

        public QualifierFilter<TEntity> Column(string columnName)
        {
            _columnName = columnName;
            return this;
        }
    }
}