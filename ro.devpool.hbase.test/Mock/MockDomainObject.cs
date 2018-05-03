using System.Collections.Generic;

namespace ro.devpool.hbase.test.Mock
{
    public class MockDomainObject
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public MockSubclass Address { get; set; }
        public virtual int Number { get; set; }

        public IList<MockListObject> RandomList { get; set; }
        public IDictionary<string, MockListObject> RandomDictionary { get; set; }
        public IEnumerable<MockListObject> RandomEnumerable { get; set; }
        public IEnumerable<KeyValuePair<string, MockListObject>> FakeDictionary { get; set; }
    }
}