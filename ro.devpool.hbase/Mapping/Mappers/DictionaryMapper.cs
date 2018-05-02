using System;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Mapping.Mappers
{
    public class DictionaryMapper : IMapper
    {
        private readonly DictionaryMap _map;

        public DictionaryMapper((string name, Type type) t)
        {
            _map = new DictionaryMap
            {
                Name = t.name,
                Type = t.type
            };
        }

        IMap IMapper.ExposeMap()
        {
            return _map;
        }

        public void FromColumnFamily(string cf)
        {
            _map.ColumnFamily = cf;
        }
    }
}