using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TScan : TBase, TAbstractBase
    {
        private byte[] _startRow;
        private byte[] _stopRow;
        private long _timestamp;
        private List<byte[]> _columns;
        private int _caching;
        private byte[] _filterString;
        private int _batchSize;
        private bool _sortColumns;
        private bool _reversed;
        public TScan.Isset __isset;

        public byte[] StartRow
        {
            get
            {
                return this._startRow;
            }
            set
            {
                this.__isset.startRow = true;
                this._startRow = value;
            }
        }

        public byte[] StopRow
        {
            get
            {
                return this._stopRow;
            }
            set
            {
                this.__isset.stopRow = true;
                this._stopRow = value;
            }
        }

        public long Timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                this.__isset.timestamp = true;
                this._timestamp = value;
            }
        }

        public List<byte[]> Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                this.__isset.columns = true;
                this._columns = value;
            }
        }

        public int Caching
        {
            get
            {
                return this._caching;
            }
            set
            {
                this.__isset.caching = true;
                this._caching = value;
            }
        }

        public byte[] FilterString
        {
            get
            {
                return this._filterString;
            }
            set
            {
                this.__isset.filterString = true;
                this._filterString = value;
            }
        }

        public int BatchSize
        {
            get
            {
                return this._batchSize;
            }
            set
            {
                this.__isset.batchSize = true;
                this._batchSize = value;
            }
        }

        public bool SortColumns
        {
            get
            {
                return this._sortColumns;
            }
            set
            {
                this.__isset.sortColumns = true;
                this._sortColumns = value;
            }
        }

        public bool Reversed
        {
            get
            {
                return this._reversed;
            }
            set
            {
                this.__isset.reversed = true;
                this._reversed = value;
            }
        }

        public void Read(TProtocol iprot)
        {
            iprot.IncrementRecursionDepth();
            try
            {
                iprot.ReadStructBegin();
                while (true)
                {
                    TField tfield = iprot.ReadFieldBegin();
                    if (tfield.Type != TType.Stop)
                    {
                        switch (tfield.ID)
                        {
                            case 1:
                                if (tfield.Type == TType.String)
                                {
                                    this.StartRow = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.String)
                                {
                                    this.StopRow = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
                                if (tfield.Type == TType.I64)
                                {
                                    this.Timestamp = iprot.ReadI64();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 4:
                                if (tfield.Type == TType.List)
                                {
                                    this.Columns = new List<byte[]>();
                                    TList tlist = iprot.ReadListBegin();
                                    for (int index = 0; index < tlist.Count; ++index)
                                        this.Columns.Add(iprot.ReadBinary());
                                    iprot.ReadListEnd();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 5:
                                if (tfield.Type == TType.I32)
                                {
                                    this.Caching = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 6:
                                if (tfield.Type == TType.String)
                                {
                                    this.FilterString = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 7:
                                if (tfield.Type == TType.I32)
                                {
                                    this.BatchSize = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 8:
                                if (tfield.Type == TType.Bool)
                                {
                                    this.SortColumns = iprot.ReadBool();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 9:
                                if (tfield.Type == TType.Bool)
                                {
                                    this.Reversed = iprot.ReadBool();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    else
                        break;
                }
                iprot.ReadStructEnd();
            }
            finally
            {
                iprot.DecrementRecursionDepth();
            }
        }

        public void Write(TProtocol oprot)
        {
            oprot.IncrementRecursionDepth();
            try
            {
                TStruct struc = new TStruct(nameof (TScan));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.StartRow != null && this.__isset.startRow)
                {
                    field.Name = "startRow";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.StartRow);
                    oprot.WriteFieldEnd();
                }
                if (this.StopRow != null && this.__isset.stopRow)
                {
                    field.Name = "stopRow";
                    field.Type = TType.String;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.StopRow);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.timestamp)
                {
                    field.Name = "timestamp";
                    field.Type = TType.I64;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(this.Timestamp);
                    oprot.WriteFieldEnd();
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    field.Name = "columns";
                    field.Type = TType.List;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                    foreach (byte[] column in this.Columns)
                        oprot.WriteBinary(column);
                    oprot.WriteListEnd();
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.caching)
                {
                    field.Name = "caching";
                    field.Type = TType.I32;
                    field.ID = (short) 5;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.Caching);
                    oprot.WriteFieldEnd();
                }
                if (this.FilterString != null && this.__isset.filterString)
                {
                    field.Name = "filterString";
                    field.Type = TType.String;
                    field.ID = (short) 6;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.FilterString);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.batchSize)
                {
                    field.Name = "batchSize";
                    field.Type = TType.I32;
                    field.ID = (short) 7;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.BatchSize);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.sortColumns)
                {
                    field.Name = "sortColumns";
                    field.Type = TType.Bool;
                    field.ID = (short) 8;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.SortColumns);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.reversed)
                {
                    field.Name = "reversed";
                    field.Type = TType.Bool;
                    field.ID = (short) 9;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.Reversed);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }
            finally
            {
                oprot.DecrementRecursionDepth();
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("TScan(");
            bool flag = true;
            if (this.StartRow != null && this.__isset.startRow)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("StartRow: ");
                stringBuilder.Append((object) this.StartRow);
            }
            if (this.StopRow != null && this.__isset.stopRow)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("StopRow: ");
                stringBuilder.Append((object) this.StopRow);
            }
            if (this.__isset.timestamp)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Timestamp: ");
                stringBuilder.Append(this.Timestamp);
            }
            if (this.Columns != null && this.__isset.columns)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Columns: ");
                stringBuilder.Append((object) this.Columns);
            }
            if (this.__isset.caching)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Caching: ");
                stringBuilder.Append(this.Caching);
            }
            if (this.FilterString != null && this.__isset.filterString)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("FilterString: ");
                stringBuilder.Append((object) this.FilterString);
            }
            if (this.__isset.batchSize)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("BatchSize: ");
                stringBuilder.Append(this.BatchSize);
            }
            if (this.__isset.sortColumns)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("SortColumns: ");
                stringBuilder.Append(this.SortColumns);
            }
            if (this.__isset.reversed)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Reversed: ");
                stringBuilder.Append(this.Reversed);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool startRow;
            public bool stopRow;
            public bool timestamp;
            public bool columns;
            public bool caching;
            public bool filterString;
            public bool batchSize;
            public bool sortColumns;
            public bool reversed;
        }
    }
}
