﻿using ro.devpool.hbase.Filters;
using ro.devpool.hbase.test.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class FirstKeyOnlyFilterTest
    {
        [Fact]
        public void FirstKeyOnlyFilterTest_Validates_Builds_Ok()
        {
            var expected = "FirstKeyOnlyFilter ()";

            var filter = new FirstKeyOnlyFilter();

            var validation = filter.ToFilterBuild();
            validation.Validate();
            var build = validation.Build();

            Assert.Equal(expected, build);

        }
    }
}