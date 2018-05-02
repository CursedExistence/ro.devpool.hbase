using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.test.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class InclusiveStopFilterTest
    {

        [Fact]
        public void InclusiveStopFilter_Validates_Builds_Ok()
        {
            var key = "test";
            var expected = $"InclusiveStopFilter ('{key}')";

            var filter = new InclusiveStopFilter();
            filter.EndKey(key);

            var validation = filter.ToFilterBuild();

            validation.Validate();

            var build = validation.Build();
            Assert.Equal(expected, build);
        }

        [Fact]
        public void InclusiveStopFilter_Validation_Fails_KeyNotSet()
        {
            var filter = new InclusiveStopFilter();

            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }

        [Fact]
        public void InclusiveStopFilter_Validation_Fails_KeyExplicitNull()
        {
            var filter = new InclusiveStopFilter();
            filter.EndKey(null);

            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }

        [Fact]
        public void InclusiveStopFilter_Validation_Fails_KeyExplicitEmpty()
        {
            var filter = new InclusiveStopFilter();
            filter.EndKey("");

            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());
        }
    }
}