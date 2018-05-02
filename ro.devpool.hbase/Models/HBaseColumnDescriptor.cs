namespace ro.devpool.hbase.Models
{
    public struct HBaseColumnDescriptor
    {
        /// <summary>
        ///     Name of HBase Table ColumnFamily
        /// </summary>
        public string ColumnFamily { get; set; }

        /// <summary>
        ///     Versions of HBase Table Column to be kept
        /// </summary>
        public int Versions { get; set; }

        /// <summary>
        ///     Compression of HBase Table Column
        /// </summary>
        public string Compression { get; set; }
    }
}