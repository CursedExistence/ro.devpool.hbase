using System;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Mapping.Mappers
{
    public class PrimitiveMapper : IMapper
    {
        private readonly PropertyMap _map;

        public PrimitiveMapper((string propertyName, Type type) t)
        {
            _map = new PropertyMap
            {
                Name = t.propertyName,
                Type = t.type
            };
        }

        IMap IMapper.ExposeMap()
        {
            return _map;
        }

        public PrimitiveMapper FromColumnFamily(string columnFamily)
        {
            _map.ColumnFamily = columnFamily;
            return this;
        }

        public void WithColumn(string columnName)
        {
            _map.ColumnName = columnName;
        }
    }
}