using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class SingleColumnValueFilter<TEntity> : IScanFilter, IScanFilterBuild where TEntity : class
    {
        private string _columnFamily;
        private string _columnName;
        private string _columnValue;
        private Comparator _comparator = Utils.Comparator.Substring;
        private ComparisonOperator _comparisonOperator = Utils.ComparisonOperator.Equal;
        private bool _filterIfColumnMissing = true;
        private bool _latestVersion = true;
        private readonly ClassMap _map;

        internal SingleColumnValueFilter(ClassMap map)
        {
            _map = map;
        }

        string IScanFilterBuild.Build()
        {
            return $"SingleColumnValueFilter ('{_columnFamily}','{_columnName}'," +
                   $"{_comparisonOperator.GetComparisonOperatorString()},'{_comparator.GetComparatorString()}{_columnValue}'," +
                   $"{_filterIfColumnMissing},{_latestVersion})";
        }

        void IScanFilterBuild.Validate()
        {
            if (_columnFamily.IsNullOrEmpty())
                throw new FilterException("[SingleColumnValueFilter] Column family cannot be null or empty!");
            if (_columnName.IsNullOrEmpty())
                throw new FilterException("[SingleColumnValueFilter] Column name cannot be null or empty!");
            if (_columnValue.IsNullOrEmpty())
                throw new FilterException("[SingleColumnValueFilter] Column value cannot be null!");
            if (!this.ValidateOperationForComparator(_comparator, _comparisonOperator))
                throw new FilterException(
                    $"Comparison operator: {_comparisonOperator.GetComparisonOperatorString()} not permitted on comparator: {_comparator.GetComparatorString()}");
        }


        #region Fluent

        public SingleColumnValueFilter<TEntity> Column<TSub>(Expression<Func<TEntity, TSub>> predicate)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);

            var map = visitor.ExposeMap();

            //if (maps.Count > 1)
            //    throw new FilterException($"[ColumnPrefixFilter] Expected 1 column from predicate, got {maps.Count}");

            //var map = maps.FirstOrDefault();

            _columnName = map?.ColumnName;
            _columnFamily = map?.ColumnFamily;

            return this;
        }

        /// <summary>
        /// In the case of IEnumerable we do not know the column name yet so this overload is used to solve the issue of the column name.
        /// </summary>
        /// <typeparam name="TSub"></typeparam>
        /// <param name="predicate">Selector</param>
        /// <param name="columnName">The column name</param>
        /// <returns></returns>
        public SingleColumnValueFilter<TEntity> Column<TSub>(Expression<Func<TEntity, IEnumerable<TSub>>> predicate, string columnName)
        {
            Column(predicate);
            _columnName = columnName;
   
            return this;
        }

        public SingleColumnValueFilter<TEntity> ColumnValue(object columnValue)
        {
            _columnValue = columnValue.ToString();
            return this;
        }

        public SingleColumnValueFilter<TEntity> Comparator(Comparator comparator)
        {
            _comparator = comparator;
            return this;
        }

        public SingleColumnValueFilter<TEntity> ComparisonOperator(ComparisonOperator comparisonOperator)
        {
            _comparisonOperator = comparisonOperator;
            return this;
        }

        public SingleColumnValueFilter<TEntity> FilterIfColumnMissing(bool filterIfColumnMissing)
        {
            _filterIfColumnMissing = filterIfColumnMissing;
            return this;
        }

        public SingleColumnValueFilter<TEntity> LatestVersion(bool latestVersion)
        {
            _latestVersion = latestVersion;
            return this;
        }

        #endregion
    }
}