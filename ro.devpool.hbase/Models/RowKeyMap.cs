using System;
using ro.devpool.hbase.Interfaces.Mapping;

namespace ro.devpool.hbase.Models
{
    internal class RowKeyMap : IMap
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}