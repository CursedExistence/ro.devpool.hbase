using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.test.Mock;
using ro.devpool.hbase.test.Mock.Configuration;
using ro.devpool.hbase.test.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class ColumnPrefixFilterTest
    {
        private readonly ClassMap _map;

        public ColumnPrefixFilterTest()
        {
            var configuration = new MockDomainObjectConfiguration();
            _map = configuration.ExposeClassMap();
        }


        [Fact]
        public void ColumnPrefixFilter_ValuePredicate_Validates_Builds_OK()
        {
            var filter = new ColumnPrefixFilter<MockDomainObject>(_map);

            filter.ColumnName(x => x.Name);

            var expected = $"ColumnPrefixFilter ('{Maps.MockDomainObject.NameColumn}')";
            var validation = filter.ToFilterBuild();

            validation.Validate();

            Assert.Equal(expected, validation.Build());
        }

        [Fact]
        public void ColumnPrefixFilter_ValueSet_Builds_OK()
        {
            var filter = new ColumnPrefixFilter<MockDomainObject>(_map);

            filter.ColumnName(Maps.MockDomainObject.NameColumn);

            var expected = $"ColumnPrefixFilter ('{Maps.MockDomainObject.NameColumn}')";
            var validation = filter.ToFilterBuild();

            Assert.Equal(expected, validation.Build());
        }

        [Fact]
        public void ColumnPrefixFilter_ValueNotSet_ValidationFails()
        {
            var filter = new ColumnPrefixFilter<MockDomainObject>(_map);

            Assert.Throws<FilterException>(() => filter.ToFilterBuild().Validate());
        }

        [Fact]
        public void ColumnPrefixFilter_MapNull_RaisesException()
        {
            var filter = new ColumnPrefixFilter<MockDomainObject>(null);

            Assert.Throws<MappingException>(() => filter.ColumnName(x => x.Address.Number));
        }

    }
}