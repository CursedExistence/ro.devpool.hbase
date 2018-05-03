using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ro.devpool.hbase.Commands;
using ro.devpool.hbase.Connection;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Management;
using ro.devpool.hbase.Mapping;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Transform;

[assembly:InternalsVisibleTo("ro.devpool.hbase.test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace ro.devpool.hbase
{
    public class HBaseSessionFactory : IHBaseSessionFactory, IHbaseSessionFactoryContext
    {
        private IHBaseConfiguration _configuration;
        private readonly IList<ClassMap> _maps = new List<ClassMap>();
        private readonly ProxyGenerator _generator;

        DIContainer IHbaseSessionFactoryContext.Container => _container;

        private readonly DIContainer _container = new DIContainer();


        public HBaseSessionFactory()
        {
            var connectionPool = new ConnectionPool(_container);
            _generator = new ProxyGenerator();

            _container.Register(() => _configuration);
            _container.Register<IHbaseSessionFactoryContext>(() => this);
            _container.Register<IHBaseSession, HBaseSession>(ConstructionMode.Internal);
            _container.Register<IConnectionPool>(() => connectionPool, ConstructionMode.Internal);
            _container.Register<IThriftClient, ThriftClient>(ConstructionMode.Internal);
            _container.Register(typeof(IScanCommand<>),typeof(ScanCommand<>), ConstructionMode.Internal);
            _container.Register(typeof(IGetCommand<>),typeof(GetCommand<>), ConstructionMode.Internal);
            _container.Register(typeof(IPutCommand<>),typeof(PutCommand<>), ConstructionMode.Internal);
            _container.Register(typeof(IDeleteCommand<>),typeof(DeleteCommand<>), ConstructionMode.Internal);
            _container.Register(typeof(IDdlCommand<>),typeof(DdlCommand<>), ConstructionMode.Internal);
            _container.Register(typeof(ITimestampCommand<>),typeof(TimestampCommand<>), ConstructionMode.Internal);
        }

        public IHBaseSessionFactory Configure(IHBaseConfiguration configuration)
        {
            _configuration = configuration;
            return this;
        }

        public IHBaseSessionFactory Map<TEntity>(ClassMap<TEntity> classMap) where TEntity : class
        {
            var map = classMap.ExposeClassMap();
            map.Generator = _generator.ProduceGenerator<TEntity>();
            _maps.Add(map);

            return this;
        }

        public IHBaseSession BuildSession()
        {
            ValidateConfiguration(_configuration);

            return _container.Retrieve<IHBaseSession>();
        }

        ClassMap IHbaseSessionFactoryContext.GetMap<TEntity>()
        {
            var type = typeof(TEntity);

            var map = _maps.SingleOrDefault(x => x.Type == type);
            if (map == null)
                throw new Exception($"no map found for type {type.Name}");
            return map;
        }

        private void ValidateConfiguration(IHBaseConfiguration config)
        {
            if (config == null)
                throw new SessionFactoryConfigurationException("Invalid configuration");

            if (!(config is IConfigurationValidation validation))
                throw new SessionFactoryConfigurationException(
                    "Configuration object needs to be cast to IConfigurationValidation");

            validation.Validate();
        }


    }
}