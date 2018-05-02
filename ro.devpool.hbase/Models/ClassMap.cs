using System;
using System.Collections.Generic;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Models
{
    internal class ClassMap : IMap
    {
        public string Namespace { get; set; }
        public string TableName { get; set; }

        public RowKey RowKey { get; set; }

        internal IList<IMap> Maps { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }

        public object Generator { get; set; }

        internal string GetNamespace()
        {
            return Namespace.IsNullOrEmpty() ? string.Empty : $"{Namespace}:";
        }
    }
}