namespace ro.devpool.hbase.Interfaces.Connection
{
    internal interface IConnectionPool
    {
        IThriftClient GetClient();
        void ReleaseClient(IThriftClient client);
    }
}