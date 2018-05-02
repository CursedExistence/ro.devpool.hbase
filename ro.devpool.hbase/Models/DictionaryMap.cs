using System;
using ro.devpool.hbase.Interfaces.Mapping;

namespace ro.devpool.hbase.Models
{
    internal class DictionaryMap : IMap
    {
        public string ColumnFamily { get; set; }

        public string FullColumnFamily => $"{ColumnFamily}:";
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}