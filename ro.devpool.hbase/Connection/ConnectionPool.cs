using System.Collections.Concurrent;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Management;

namespace ro.devpool.hbase.Connection
{
    internal class ConnectionPool : IConnectionPool
    {
        /*
         * TODO: switch from permisive pool to restrictive pool with an x number of throttling
         */

        #region Constructors

        internal ConnectionPool(DIContainer container)
        {
            _container = container;
            _clients = new ConcurrentStack<IThriftClient>();
        }

        #endregion
        #region Constants

        private const int MAX_CONNECTIONS = 20;

        #endregion

        #region Private members

        private readonly ConcurrentStack<IThriftClient> _clients;
        private readonly DIContainer _container;
        #endregion

        #region Public methods

        public IThriftClient GetClient()
        {
            if (!_clients.TryPop(out var client)) client = _container.Retrieve<IThriftClient>();

            if (client.IsActive) return client;
            return GetClient();
        }

        public void ReleaseClient(IThriftClient client)
        {
            if (_clients.Count <= (client.Configuration.MaxInstances ?? MAX_CONNECTIONS))
            {
                _clients.Push(client);
            }
            else
            {
                client.Cleanup();
                client = null;
            }
        }

        #endregion
    }
}