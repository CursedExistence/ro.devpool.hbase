namespace ro.devpool.hbase.Interfaces.Proxy
{
    internal interface IActivator<out TEntity> where TEntity:class
    {
        TEntity Activate();
    }
}