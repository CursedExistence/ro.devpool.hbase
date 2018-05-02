using System;
using ro.devpool.hbase.Interfaces.Mapping;

namespace ro.devpool.hbase.Models
{
    internal enum MappingStrategy
    {
        EntireCfAsObject,
        RegexColumnsAsObject,
        ColumnAsList
    }

    internal class ListMap : IMap
    {
        public MappingStrategy MappingStrategy { get; set; }

        public Type ActingObjectType { get; set; }

        public string ColumnFamily { get; set; }

        public (string name, Type type) ColumnName { get; set; }
        public (string name, Type type) ColumnValue { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}