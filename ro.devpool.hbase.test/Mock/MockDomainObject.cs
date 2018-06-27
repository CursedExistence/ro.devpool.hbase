using System.Collections.Generic;

namespace ro.devpool.hbase.test.Mock
{
    public class MockDomainObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public MockSubclass Address { get; set; }
        public int Number { get; set; }

        public IList<MockListObject> RandomList { get; set; }
        public IDictionary<string, MockListObject> RandomDictionary { get; set; }
        public IEnumerable<MockListObject> RandomEnumerable { get; set; }
        public IEnumerable<KeyValuePair<string, MockListObject>> FakeDictionary { get; set; }
    }
}