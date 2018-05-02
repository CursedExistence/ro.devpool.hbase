using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TAppend : TBase, TAbstractBase
    {
        private byte[] _table;
        private byte[] _row;
        private List<byte[]> _columns;
        private List<byte[]> _values;
        public TAppend.Isset __isset;

        public byte[] Table
        {
            get
            {
                return this._table;
            }
            set
            {
                this.__isset.table = true;
                this._table = value;
            }
        }

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

        public List<byte[]> Values
        {
            get
            {
                return this._values;
            }
            set
            {
                this.__isset.values = true;
                this._values = value;
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
                                    this.Table = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.String)
                                {
                                    this.Row = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
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
                            case 4:
                                if (tfield.Type == TType.List)
                                {
                                    this.Values = new List<byte[]>();
                                    TList tlist = iprot.ReadListBegin();
                                    for (int index = 0; index < tlist.Count; ++index)
                                        this.Values.Add(iprot.ReadBinary());
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
                TStruct struc = new TStruct(nameof (TAppend));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.Table != null && this.__isset.table)
                {
                    field.Name = "table";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Table);
                    oprot.WriteFieldEnd();
                }
                if (this.Row != null && this.__isset.row)
                {
                    field.Name = "row";
                    field.Type = TType.String;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Row);
                    oprot.WriteFieldEnd();
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    field.Name = "columns";
                    field.Type = TType.List;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                    foreach (byte[] column in this.Columns)
                        oprot.WriteBinary(column);
                    oprot.WriteListEnd();
                    oprot.WriteFieldEnd();
                }
                if (this.Values != null && this.__isset.values)
                {
                    field.Name = "values";
                    field.Type = TType.List;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteListBegin(new TList(TType.String, this.Values.Count));
                    foreach (byte[] b in this.Values)
                        oprot.WriteBinary(b);
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
            StringBuilder stringBuilder = new StringBuilder("TAppend(");
            bool flag = true;
            if (this.Table != null && this.__isset.table)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Table: ");
                stringBuilder.Append((object) this.Table);
            }
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
            if (this.Values != null && this.__isset.values)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Values: ");
                stringBuilder.Append((object) this.Values);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool table;
            public bool row;
            public bool columns;
            public bool values;
        }
    }
}
