using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.test.Mock;
using ro.devpool.hbase.test.Mock.Configuration;
using ro.devpool.hbase.test.Utils;
using ro.devpool.hbase.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class QualifierFilterTest
    {
        private readonly ClassMap _map;
        public QualifierFilterTest()
        {
            var configuration = new MockDomainObjectConfiguration();
            _map = configuration.ExposeClassMap();
        }

        [Theory, CombinatorialData]
        public void QualifierFilter_Validates_Ok(Comparator comparator, ComparisonOperator comparisonOperator, bool entity, bool emptyCol)
        {
            var filter = new QualifierFilter<MockDomainObject>(_map);
            filter.ComparisonOperator(comparisonOperator);
            filter.Comparator(comparator);

            var buildString = $"QualifierFilter ({comparisonOperator.GetComparisonOperatorString()},'{comparator.GetComparatorString()}:{(entity ? "Number" : "test")}' )";

            if (!emptyCol)
            {
                if (entity)
                    filter.Column(x => x.Number);
                else
                    filter.Column("test");
            }

            var validator = filter.ToFilterBuild();

            var isSpecialCase = filter.ValidateOperationForComparator(comparator, comparisonOperator);
            if (!isSpecialCase || emptyCol)
                Assert.Throws<FilterException>(() => validator.Validate());
            else
            {
                validator.Validate();

                Assert.Equal(buildString, validator.Build());
            }
  
        }
    }
}