using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.test.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class PrefixFilterTest
    {
        [Fact]
        public void PrefixFilter_KeySet_Builds_OK()
        {
            var filter = new PrefixFilter();
            var key = "test";
            filter.Key(key);

            var build = filter.ToFilterBuild().Build();

            Assert.True(build.Equals($"PrefixFilter ('{key}')"));
        }

        [Fact]
        public void PrefixFilter_KeyNotSet_Validation_Fails()
        {
            var filter = new PrefixFilter();

            Assert.Throws<FilterException>(() => filter.ToFilterBuild().Validate());
        }

        [Fact]
        public void PrefixFilter_KeySet_Validates_OK()
        {
            var filter = new PrefixFilter();
            var key = "test";
            filter.Key(key);

            filter.ToFilterBuild().Validate();
        }

    }
}