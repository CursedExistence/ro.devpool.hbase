using ro.devpool.hbase.Mapping;
using ro.devpool.hbase.test.Utils;

namespace ro.devpool.hbase.test.Mock.Configuration
{
    public class MockDomainObjectConfiguration : ClassMap<MockDomainObject>
    {
        public MockDomainObjectConfiguration()
        {
            Namespace(Maps.MockDomainObject.Namespace);
            Table(Maps.MockDomainObject.TableName);
            RowKey(x=> x.Name);
            Property(x => x.Name).FromColumnFamily(Maps.MockDomainObject.TestColumnFamily).WithColumn(Maps.MockDomainObject.NameColumn);
            Property(x => x.Age).FromColumnFamily(Maps.MockDomainObject.TestColumnFamily).WithColumn(Maps.MockDomainObject.AgeColumn);
         //   Property(x => x.Age).FromColumnFamily(Maps.MockDomainObject.TestColumnFamily).WithColumn(Maps.MockDomainObject.AgeColumn);
            Property(x => x.Address).WithSubclassMap(new MockSubclassConfiguration());
            Property(x => x.Number).FromColumnFamily(Maps.MockDomainObject.TestColumnFamily).WithColumn("Number");

            Property(x => x.RandomList).EntireCFAsObject(Maps.MockDomainObject.ListColumnFamily, k => k.Column, v => v.Value);
           // Property(x=> x.RandomDictionary).FromColumnFamily(Maps.MockDomainObject.TestColumnFamily);
           // Property(x=> x.RandomEnumerable).EntireCFAsObject(Maps.MockDomainObject.TestColumnFamily, k => k.Name, v => v.Age);
        }
    }
}