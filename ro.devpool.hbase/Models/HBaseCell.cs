using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Models
{
    internal struct HBaseCell
    {
        public long Timestamp { get; set; }
        public byte[] Value { get; set; }

        public string ValueString
        {
            get => Value.GetString();
            set => Value = value.GetBytes();
        }

        public string RowKey { get; set; }
        public string FullColumnName { get; set; }

        public HBaseCell(string rowKey, string fullColumnName, byte[] value, long timestamp)
        {
            FullColumnName = fullColumnName;
            Value = value;
            Timestamp = timestamp;
            RowKey = rowKey;
        }

        public static implicit operator byte[](HBaseCell cell)
        {
            return cell.Value;
        }

        public static implicit operator string(HBaseCell cell)
        {
            return cell.Value.GetString();
        }
    }
}