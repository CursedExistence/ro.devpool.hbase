namespace ro.devpool.hbase.Interfaces.Configuration
{
    public interface IHBaseConnectionConfiguration
    {
        string ThriftHost { get; set; }
        int ThriftPort { get; set; }
        string ThriftTablePrefix { get; set; }
        double? ThriftTimeout { get; set; }
    }
}