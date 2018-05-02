using System.Collections.Generic;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.test.Mock;
using ro.devpool.hbase.test.Mock.Configuration;
using ro.devpool.hbase.test.Utils;
using ro.devpool.hbase.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class SingleColumnValueFilterTest
    {
        private readonly ClassMap _map;

        public SingleColumnValueFilterTest()
        {
            var config = new MockDomainObjectConfiguration();
            _map = config.ExposeClassMap();
        }

        [Theory, CombinatorialData]
        public void SingleColumnValueFilter_Builds_OK([CombinatorialValues(1.0f, 2.0d, 3L, 4, "test")] object value,Comparator comparator, ComparisonOperator comparison, bool latest, bool filterIfMissing)
        {
            var expected = $"SingleColumnValueFilter ('{Maps.MockDomainObject.TestColumnFamily}','{Maps.MockDomainObject.NameColumn}',{comparison.GetComparisonOperatorString()}," +
                           $"'{comparator.GetComparatorString()}{value}',{filterIfMissing},{latest})";

            var filter = new SingleColumnValueFilter<MockDomainObject>(_map);

            filter.ComparisonOperator(comparison);
            filter.Comparator(comparator);

            filter.Column(x => x.Name);
            filter.ColumnValue(value);
            filter.FilterIfColumnMissing(filterIfMissing);
            filter.LatestVersion(latest);

            var validation = filter.ToFilterBuild();

            var build = validation.Build();

            Assert.Equal(expected, build);

        }
        [Theory, CombinatorialData]
        public void SingleColumnValueFilter_Validates_OK(Comparator comparator, ComparisonOperator comparison, bool latest, bool filterIfMissing)
        {
            var value = "test";
            var filter = new SingleColumnValueFilter<MockDomainObject>(_map);


            filter.ComparisonOperator(comparison);
            filter.Comparator(comparator);

            filter.Column(x => x.Name);
            filter.ColumnValue(value);
            filter.FilterIfColumnMissing(filterIfMissing);
            filter.LatestVersion(latest);

            var validation = filter.ToFilterBuild();

            var isSpecialCase = filter.ValidateOperationForComparator(comparator, comparison);

            if (!isSpecialCase)
                Assert.Throws<FilterException>(() => validation.Validate());
            else
                validation.Validate();
        }

        [Fact]
        public void SingleColumnValueFilter_NullMap_Validation_Throws_Exception()
        {
            var filter = new SingleColumnValueFilter<MockDomainObject>(null);
            
            Assert.Throws<MappingException>(() => filter.Column(x => x.Name));
        }
        [Fact]
        public void SingleColumnValueFilter_NoCF_Validation_Throws_FilterException()
        {

            var map = new ClassMap()
            {
                Maps = new List<IMap>()
                {
                    new PropertyMap()
                    {
                        ColumnName = Maps.MockDomainObject.NameColumn,
                        Name = nameof(MockDomainObject.Name),
                        Type = typeof(MockDomainObject)
                    }
                }
            };

            var filter = new SingleColumnValueFilter<MockDomainObject>(map);

            filter.Column(x => x.Name);
            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }

        [Fact]
        public void SingleColumnValueFilter_NoColumn_Validation_Throws_FilterException()
        {

            var map = new ClassMap()
            {
                Maps = new List<IMap>()
                {
                    new PropertyMap()
                    {
                        ColumnFamily = Maps.MockDomainObject.TestColumnFamily,
                        Name = nameof(MockDomainObject.Name),
                        Type = typeof(MockDomainObject)
                    }
                }
            };

            var filter = new SingleColumnValueFilter<MockDomainObject>(map);
            filter.Column(x => x.Name);
            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }
        [Fact]
        public void SingleColumnValueFilter_NoValue_Validation_Throws_FilterException()
        {
            var filter = new SingleColumnValueFilter<MockDomainObject>(_map);
            filter.Column(x => x.Name);


            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }

        [Fact]
        public void SingleColumnValueFilter_Column_Enumerable_Validation_Ok()
        {
            var filter = new SingleColumnValueFilter<MockDomainObject>(_map);

            filter.Column(x=> x.RandomList,"bla");
            filter.ColumnValue("test");

            var validation = filter.ToFilterBuild();

            validation.Validate();
            
        }
    }
}