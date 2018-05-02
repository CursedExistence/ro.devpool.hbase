using System.Collections.Generic;

namespace ro.devpool.hbase.Interfaces.Proxy
{
    internal interface ITimestamp
    {
        void Set(Dictionary<string, long> field);
        Dictionary<string, long> Get();
    }
}