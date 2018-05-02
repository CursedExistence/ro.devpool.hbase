using System;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Mapping.Mappers
{
    public class ReferenceMapper : IMapper
    {
        private readonly SubClassMap _map;

        public ReferenceMapper((string name, Type type) t)
        {
            _map = new SubClassMap
            {
                Name = t.name,
                Type = t.type
            };
        }

        IMap IMapper.ExposeMap()
        {
            return _map;
        }

        public void WithSubclassMap<TEntity>(SubClassMap<TEntity> mapperInstance) where TEntity : class
        {
            _map.Mappers = mapperInstance.ExposeMappers();
        }
    }
}