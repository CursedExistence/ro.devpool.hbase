using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.test.Mock;
using ro.devpool.hbase.test.Mock.Configuration;
using ro.devpool.hbase.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Filters
{
    public class FilterContextTest
    {
        private ClassMap _map;
        public FilterContextTest()
        {
            var configuration = new MockDomainObjectConfiguration();
            _map = configuration.ExposeClassMap();
        }
        [Theory, CombinatorialData]
        public void FilterContext_Compose_Valid(Composition composition)
        {
            var context = new FilterContext<MockDomainObject>(composition, _map);

            context.Compose(x =>
            {
                x.FirstKeyOnlyFilter();
                x.KeyOnlyFilter();
            }, composition);

            var expected = $"((FirstKeyOnlyFilter () {composition.GetCompositionString()} KeyOnlyFilter ()) {composition.GetCompositionString()} InclusiveStopFilter ('test'))";
          
            var f1 = context.InclusiveStopFilter();

            f1.EndKey("test");

            var val = context as IScanFilterBuild;

            Assert.NotNull(val);

            val.Validate();

            var actual = val.Build();
            Assert.Equal(expected, actual);
        }

        [Theory, CombinatorialData]
        public void FilterContext_Composition_returnsOk(Composition composition)
        {
            var expected = $"(FirstKeyOnlyFilter () {composition.GetCompositionString()} InclusiveStopFilter ('test'))";
            var context = new FilterContext<MockDomainObject>(composition, _map);

            var f1 = context.FirstKeyOnlyFilter();
            var f2 = context.InclusiveStopFilter();

            f2.EndKey("test");

            var val = context as IScanFilterBuild;

            Assert.NotNull(val);

            val.Validate();

            var actual = val.Build();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterContext_Returns_ColumnPrefixFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.ColumnPrefixFilter();

            Assert.IsType<ColumnPrefixFilter<MockDomainObject>>(filter);
        }


        [Fact]
        public void FilterContext_Returns_FirstKeyOnlyFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.FirstKeyOnlyFilter();

            Assert.IsType<FirstKeyOnlyFilter>(filter);
        }

        [Fact]
        public void FilterContext_Returns_InclusiveStopFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.InclusiveStopFilter();

            Assert.IsType<InclusiveStopFilter>(filter);
        }

        [Fact]
        public void FilterContext_Returns_KeyOnlyFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.KeyOnlyFilter();

            Assert.IsType<KeyOnlyFilter>(filter);
        }

        [Fact]
        public void FilterContext_Returns_PrefixFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.PrefixFilter();

            Assert.IsType<PrefixFilter>(filter);
        }

        [Fact]
        public void FilterContext_Returns_QualifierFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.QualifierFilter();

            Assert.IsType<QualifierFilter<MockDomainObject>>(filter);
        }

        [Fact]
        public void FilterContext_Returns_SingleColumnValueFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.SingleColumnValueFilter();

            Assert.IsType<SingleColumnValueFilter<MockDomainObject>>(filter);
        }

        [Fact]
        public void FilterContext_Returns_ValueFilter()
        {
            var context = new FilterContext<MockDomainObject>(Composition.And, _map);

            var filter = context.ValueFilter();

            Assert.IsType<ValueFilter>(filter);
        }
    }
}