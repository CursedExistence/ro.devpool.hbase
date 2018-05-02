using System.Collections.Generic;
using System.Linq;
using ro.devpool.hbase.Connection;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Models.Apache;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Commands
{
    /// <summary>
    ///     TODO: 1) Implement full column descriptor
    ///     TODO: 2) Implement descriptors as map properties (maybe a migrationMap)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DdlCommand<TEntity>: IDdlCommand<TEntity> where TEntity : class
    {
        #region Constructors

        internal DdlCommand(ConnectionPool pool)
        {
            _pool = pool;
        }

        #endregion

        #region Private members

        private readonly byte[] _tableName;
      
        private readonly ConnectionPool _pool;

        #endregion

        #region Public Methods

        public IList<string> ListTables()
        {
            var client = _pool.GetClient();

            var tables = client.getTableNames().Select(x => x.GetString());

            _pool.ReleaseClient(client);

            return tables.ToList();
        }

        public void CreateTable(IList<HBaseColumnDescriptor> columnDescriptors)
        {
            var cols = columnDescriptors.Select(x => new ColumnDescriptor
            {
                Name = x.ColumnFamily.GetBytes(),
                MaxVersions = x.Versions == 0 ? 1 : x.Versions,
                Compression = x.Compression,
                InMemory = false
            }).ToList();
            var client = _pool.GetClient();

            client.createTable(_tableName, cols);

            _pool.ReleaseClient(client);
        }

        public IList<HBaseColumnDescriptor> GetTableDescriptors()
        {
            var client = _pool.GetClient();

            var columns = client.getColumnDescriptors(_tableName)
                .Select(x => new HBaseColumnDescriptor
                {
                    Compression = x.Value.Compression,
                    ColumnFamily = x.Value.Name.GetString(),
                    Versions = x.Value.MaxVersions
                });

            _pool.ReleaseClient(client);

            return columns.ToList();
        }

        public void Drop()
        {
            var client = _pool.GetClient();

            var tableList = client.getTableNames().Select(x => x.GetString());

            if (tableList.Contains(_tableName.GetString()))
            {
                if (client.isTableEnabled(_tableName))
                    client.disableTable(_tableName);

                client.deleteTable(_tableName);
            }

            _pool.ReleaseClient(client);
        }

        public void Truncate()
        {
            var client = _pool.GetClient();

            var tableDescription = client.getColumnDescriptors(_tableName).Select(x => x.Value).ToList();

            client.disableTable(_tableName);
            client.deleteTable(_tableName);

            client.createTable(_tableName, tableDescription);
            _pool.ReleaseClient(client);
        }

        public void Enable()
        {
            var client = _pool.GetClient();
            if (!client.isTableEnabled(_tableName))
                client.enableTable(_tableName);
            _pool.ReleaseClient(client);
        }

        public void Disable()
        {
            var client = _pool.GetClient();
            if (client.isTableEnabled(_tableName))
                client.disableTable(_tableName);
            _pool.ReleaseClient(client);
        }

        #endregion
    }
}