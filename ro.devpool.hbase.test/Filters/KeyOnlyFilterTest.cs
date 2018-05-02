using ro.devpool.hbase.Filters;
using ro.devpool.hbase.test.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class KeyOnlyFilterTest
    {
        [Fact]
        public void eyOnlyFilterTest_Validates_Builds_Ok()
        {
            var expected = "KeyOnlyFilter ()";

            var filter = new KeyOnlyFilter();

            var validation = filter.ToFilterBuild();
            validation.Validate();
            var build = validation.Build();

            Assert.Equal(expected, build);

        }
    }
}