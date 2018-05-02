using System;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Management;

namespace ro.devpool.hbase
{
    public class HBaseSession : IHBaseSession
    {
        private readonly IHbaseSessionFactoryContext _context;
        private readonly IHBaseConfiguration _hbaseConfiguration;
        private readonly DIContainer _container;

        internal HBaseSession(IHBaseConfiguration configuration, IHbaseSessionFactoryContext context)
        {
            _hbaseConfiguration = configuration;
            SessionId = Guid.NewGuid().ToString("N");
            _context = context;
            _container = context.Container;
        }

        public string SessionId { get; }

        public IScanCommand<TEntity> Scan<TEntity>() where TEntity : class
        {
            return _container.Retrieve<IScanCommand<TEntity>>(_context.GetMap<TEntity>());
        }

        public IGetCommand<TEntity> Get<TEntity>() where TEntity : class
        {
            return _container.Retrieve<IGetCommand<TEntity>>(_context.GetMap<TEntity>());
        }

        public IPutCommand<TEntity> Put<TEntity>() where TEntity : class
        {
            return _container.Retrieve<IPutCommand<TEntity>>(_context.GetMap<TEntity>());
        }

        public IDeleteCommand<TEntity> Delete<TEntity>() where TEntity : class
        {
            return _container.Retrieve<IDeleteCommand<TEntity>>(_context.GetMap<TEntity>());
        }

        public IDdlCommand<TEntity> DDL<TEntity>() where TEntity : class
        {
            return _container.Retrieve<IDdlCommand<TEntity>>();
        }

        public ITimestampCommand<TEntity> Timestamp<TEntity>(TEntity entity) where TEntity : class
        {
            return _container.Retrieve<ITimestampCommand<TEntity>>(entity, _context.GetMap<TEntity>());
        }
    }
}