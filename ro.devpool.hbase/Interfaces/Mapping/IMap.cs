using System;

namespace ro.devpool.hbase.Interfaces.Mapping
{
    internal interface IMap
    {
        string Name { get; set; }
        Type Type { get; set; }
    }
}