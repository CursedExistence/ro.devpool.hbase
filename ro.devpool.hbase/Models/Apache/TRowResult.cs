using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TRowResult : TBase, TAbstractBase
    {
        private byte[] _row;
        private Dictionary<byte[], TCell> _columns;
        private List<TColumn> _sortedColumns;
        public TRowResult.Isset __isset;

        public byte[] Row
        {
            get
            {
                return this._row;
            }
            set
            {
                this.__isset.row = true;
                this._row = value;
            }
        }

        public Dictionary<byte[], TCell> Columns
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

        public List<TColumn> SortedColumns
        {
            get
            {
                return this._sortedColumns;
            }
            set
            {
                this.__isset.sortedColumns = true;
                this._sortedColumns = value;
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
                                    this.Row = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.Map)
                                {
                                    this.Columns = new Dictionary<byte[], TCell>();
                                    TMap tmap = iprot.ReadMapBegin();
                                    for (int index1 = 0; index1 < tmap.Count; ++index1)
                                    {
                                        byte[] index2 = iprot.ReadBinary();
                                        TCell tcell = new TCell();
                                        tcell.Read(iprot);
                                        this.Columns[index2] = tcell;
                                    }
                                    iprot.ReadMapEnd();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
                                if (tfield.Type == TType.List)
                                {
                                    this.SortedColumns = new List<TColumn>();
                                    TList tlist = iprot.ReadListBegin();
                                    for (int index = 0; index < tlist.Count; ++index)
                                    {
                                        TColumn tcolumn = new TColumn();
                                        tcolumn.Read(iprot);
                                        this.SortedColumns.Add(tcolumn);
                                    }
                                    iprot.ReadListEnd();
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
                TStruct struc = new TStruct(nameof (TRowResult));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.Row != null && this.__isset.row)
                {
                    field.Name = "row";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Row);
                    oprot.WriteFieldEnd();
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    field.Name = "columns";
                    field.Type = TType.Map;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteMapBegin(new TMap(TType.String, TType.Struct, this.Columns.Count));
                    foreach (byte[] key in this.Columns.Keys)
                    {
                        oprot.WriteBinary(key);
                        this.Columns[key].Write(oprot);
                    }
                    oprot.WriteMapEnd();
                    oprot.WriteFieldEnd();
                }
                if (this.SortedColumns != null && this.__isset.sortedColumns)
                {
                    field.Name = "sortedColumns";
                    field.Type = TType.List;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteListBegin(new TList(TType.Struct, this.SortedColumns.Count));
                    foreach (TColumn sortedColumn in this.SortedColumns)
                        sortedColumn.Write(oprot);
                    oprot.WriteListEnd();
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
            StringBuilder stringBuilder = new StringBuilder("TRowResult(");
            bool flag = true;
            if (this.Row != null && this.__isset.row)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Row: ");
                stringBuilder.Append((object) this.Row);
            }
            if (this.Columns != null && this.__isset.columns)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Columns: ");
                stringBuilder.Append((object) this.Columns);
            }
            if (this.SortedColumns != null && this.__isset.sortedColumns)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("SortedColumns: ");
                stringBuilder.Append((object) this.SortedColumns);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool row;
            public bool columns;
            public bool sortedColumns;
        }
    }
}
