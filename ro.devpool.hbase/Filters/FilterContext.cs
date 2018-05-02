using System;
using System.Collections.Generic;
using System.Linq;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class FilterContext<TEntity> : IScanFilterBuild where TEntity : class
    {
        private readonly IList<IScanFilterBuild> _builds;
        private readonly Composition _composition;
        private readonly ClassMap _map;


        internal FilterContext(Composition composition, ClassMap map)
        {
            _builds = new List<IScanFilterBuild>();
            _composition = composition;
            _map = map;
        }

        string IScanFilterBuild.Build()
        {
            return _builds.Count > 0 ? $"({string.Join($" {_composition.GetCompositionString()} ", _builds.Select(x => x.Build()))})" : null;
        }

        void IScanFilterBuild.Validate()
        {
            foreach (var build in _builds) build.Validate();
        }

        public void Compose(Action<FilterContext<TEntity>> action, Composition composition = Composition.And)
        {
            var context = new FilterContext<TEntity>(composition, _map);
            action(context);

            _builds.Add(context);
        }

        public ColumnPrefixFilter<TEntity> ColumnPrefixFilter()
        {
            var filter = new ColumnPrefixFilter<TEntity>(_map);
            _builds.Add(filter);

            return filter;
        }

        public FirstKeyOnlyFilter FirstKeyOnlyFilter()
        {
            var filter = new FirstKeyOnlyFilter();
            _builds.Add(filter);

            return filter;
        }

        public InclusiveStopFilter InclusiveStopFilter()
        {
            var filter = new InclusiveStopFilter();
            _builds.Add(filter);

            return filter;
        }

        public KeyOnlyFilter KeyOnlyFilter()
        {
            var filter = new KeyOnlyFilter();
            _builds.Add(filter);
            return filter;
        }

        public PrefixFilter PrefixFilter()
        {
            var filter = new PrefixFilter();
            _builds.Add(filter);

            return filter;
        }

        public QualifierFilter<TEntity> QualifierFilter()
        {
            var filter = new QualifierFilter<TEntity>(_map);
            _builds.Add(filter);

            return filter;
        }

        public SingleColumnValueFilter<TEntity> SingleColumnValueFilter()
        {
            var filter = new SingleColumnValueFilter<TEntity>(_map);
            _builds.Add(filter);
            return filter;
        }

        public ValueFilter ValueFilter()
        {
            var filter = new ValueFilter();
            _builds.Add(filter);
            return filter;
        }
    }
}