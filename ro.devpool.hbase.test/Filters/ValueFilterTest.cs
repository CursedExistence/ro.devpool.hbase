using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.test.Utils;
using ro.devpool.hbase.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class ValueFilterTest
    {
        [Theory, CombinatorialData]
        public void ValueFilter_Builds_Ok([CombinatorialValues(1.0f, 2.0d, 3L, 4, "test")] object value, ComparisonOperator comparisonOperator, Comparator comparator)
        {
            var expected = $"ValueFilter ({comparisonOperator.GetComparisonOperatorString()},'{comparator.GetComparatorString()}{value}')";

            var filter = new ValueFilter();

            filter.Comparator(comparator);
            filter.ComparisonOperator(comparisonOperator);
            filter.Value(value);
            var validator = filter.ToFilterBuild();


            var build = validator.Build();

            Assert.Equal(expected, build);
        }

        [Theory, CombinatorialData]
        public void ValueFilter_Validates_Ok(ComparisonOperator comparison, Comparator comparator)
        {
            var filter = new ValueFilter();
            filter.Comparator(comparator);
            filter.ComparisonOperator(comparison);
            filter.Value("test");

            var validator = filter.ToFilterBuild();

            var isSpecialCase = filter.ValidateOperationForComparator(comparator, comparison);

            if (!isSpecialCase)
                Assert.Throws<FilterException>(() => validator.Validate());
            else
                validator.Validate();
        }

        [Fact]
        public void ValueFilter_Validation_Fail_Value_Empty()
        {
            var filter = new ValueFilter();

            var validation = filter.ToFilterBuild();

            Assert.Throws<FilterException>(() => validation.Validate());

        }
    }
}