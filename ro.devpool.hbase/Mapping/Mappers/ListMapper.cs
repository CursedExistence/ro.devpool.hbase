using System;
using System.Linq.Expressions;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Mapping.Mappers
{
    public class ListMapper<TSubEntity> : IMapper where TSubEntity : class
    {
        private readonly ListMap _map;

        public ListMapper((string name, Type type) t)
        {
            _map = new ListMap
            {
                Name = t.name,
                Type = t.type
            };
        }


        IMap IMapper.ExposeMap()
        {
            return _map;
        }

        public void EntireCFAsObject(string columnFamily, Expression<Func<TSubEntity, object>> columnName,
            Expression<Func<TSubEntity, object>> columnValue)
        {
            _map.MappingStrategy = MappingStrategy.EntireCfAsObject;
            _map.ActingObjectType = typeof(TSubEntity);

            _map.ColumnName = columnName.ExtractNameAndType();
            _map.ColumnValue = columnValue.ExtractNameAndType();
            _map.ColumnFamily = columnFamily;
        }
    }
}