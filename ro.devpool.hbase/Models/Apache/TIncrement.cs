using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TIncrement : TBase, TAbstractBase
    {
        private byte[] _table;
        private byte[] _row;
        private byte[] _column;
        private long _ammount;
        public TIncrement.Isset __isset;

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

        public byte[] Column
        {
            get
            {
                return this._column;
            }
            set
            {
                this.__isset.column = true;
                this._column = value;
            }
        }

        public long Ammount
        {
            get
            {
                return this._ammount;
            }
            set
            {
                this.__isset.ammount = true;
                this._ammount = value;
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
                                if (tfield.Type == TType.String)
                                {
                                    this.Column = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 4:
                                if (tfield.Type == TType.I64)
                                {
                                    this.Ammount = iprot.ReadI64();
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
                TStruct struc = new TStruct(nameof (TIncrement));
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
                if (this.Column != null && this.__isset.column)
                {
                    field.Name = "column";
                    field.Type = TType.String;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Column);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.ammount)
                {
                    field.Name = "ammount";
                    field.Type = TType.I64;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(this.Ammount);
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
            StringBuilder stringBuilder = new StringBuilder("TIncrement(");
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
            if (this.Column != null && this.__isset.column)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Column: ");
                stringBuilder.Append((object) this.Column);
            }
            if (this.__isset.ammount)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Ammount: ");
                stringBuilder.Append(this.Ammount);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool table;
            public bool row;
            public bool column;
            public bool ammount;
        }
    }
}
