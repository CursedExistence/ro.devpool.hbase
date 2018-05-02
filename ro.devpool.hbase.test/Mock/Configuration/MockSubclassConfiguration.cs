using ro.devpool.hbase.Mapping;
using ro.devpool.hbase.test.Utils;

namespace ro.devpool.hbase.test.Mock.Configuration
{
    public class MockSubclassConfiguration : SubClassMap<MockSubclass>
    {
        public MockSubclassConfiguration()
        {
            Property(x=> x.Street).FromColumnFamily(Maps.MockSubclassObject.ColumnFamily).WithColumn(Maps.MockSubclassObject.StreetColumn);
            Property(x=> x.Number).FromColumnFamily(Maps.MockSubclassObject.ColumnFamily).WithColumn(Maps.MockSubclassObject.NumberColumn);
        }
    }
}