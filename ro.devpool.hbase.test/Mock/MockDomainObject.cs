using System.Collections.Generic;

namespace ro.devpool.hbase.test.Mock
{
    public class MockDomainObject
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public MockSubclass Address { get; set; }
        public virtual int Number { get; set; }

        public IList<MockDomainObject> RandomList { get; set; }
        public IDictionary<string,MockDomainObject> RandomDictionary { get; set; }
        public IEnumerable<MockDomainObject> RandomEnumerable { get; set; }
        public IEnumerable<KeyValuePair<string, MockDomainObject>> FakeDictionary { get; set; }
    }
}