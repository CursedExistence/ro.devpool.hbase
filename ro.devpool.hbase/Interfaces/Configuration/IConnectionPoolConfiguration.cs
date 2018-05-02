namespace ro.devpool.hbase.Interfaces.Configuration
{
    public interface IConnectionPoolConfiguration
    {
        int? MaxInstances { get; set; }
        long SecondsToKeep { get; set; }
        bool IsRestrictive { get; set; }
    }
}