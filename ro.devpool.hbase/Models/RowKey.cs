using System.Collections.Generic;

namespace ro.devpool.hbase.Models
{
    internal enum RowKeyKind
    {
        Simple,
        Composite
    }

    internal class RowKey
    {
        public RowKeyKind RowKeyKind { get; set; }
        public string Separator { get; set; }
        public bool IncludePropertyNameInSerialization { get; set; }

        public IList<RowKeyMap> Components { get; }

        internal RowKey(RowKeyKind kind, IList<RowKeyMap> components, string separator = "-")
        {
            RowKeyKind = kind;
            Separator = separator;
            Components = components;
        }
    }
}