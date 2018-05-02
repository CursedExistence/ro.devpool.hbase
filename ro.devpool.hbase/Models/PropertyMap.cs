using System;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Models
{
    internal class PropertyMap : IMap
    {
        public string ColumnFamily { get; set; }
        public string ColumnName { get; set; }

        public string FullColumnKey => !ColumnName.IsNullOrEmpty() ? $"{ColumnFamily}:{ColumnName}" : $"{ColumnFamily}:";
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}