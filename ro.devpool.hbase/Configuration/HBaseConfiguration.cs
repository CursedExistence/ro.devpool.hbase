using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Configuration
{
    public class HBaseConfiguration : IHBaseConfiguration, IConfigurationValidation
    {
        public void Validate()
        {
            if (ThriftHost.IsNullOrEmpty())
                this.CreateConfigurationException(x => x.ThriftHost);
            if (ThriftPort == 0)
                this.CreateConfigurationException(x => x.ThriftPort);
        }

        public string ThriftHost { get; set; }
        public int ThriftPort { get; set; }
        public string ThriftTablePrefix { get; set; }
        public double? ThriftTimeout { get; set; }

        // Connection Pool
        public int? MaxInstances { get; set; }
        public long SecondsToKeep { get; set; }
        public bool IsRestrictive { get; set; }
    }
}