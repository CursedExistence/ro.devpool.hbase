using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TColumn : TBase, TAbstractBase
    {
        private byte[] _columnName;
        private TCell _cell;
        public TColumn.Isset __isset;

        public byte[] ColumnName
        {
            get
            {
                return this._columnName;
            }
            set
            {
                this.__isset.columnName = true;
                this._columnName = value;
            }
        }

        public TCell Cell
        {
            get
            {
                return this._cell;
            }
            set
            {
                this.__isset.cell = true;
                this._cell = value;
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
                                    this.ColumnName = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Cell = new TCell();
                                    this.Cell.Read(iprot);
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
                TStruct struc = new TStruct(nameof (TColumn));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.ColumnName != null && this.__isset.columnName)
                {
                    field.Name = "columnName";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.ColumnName);
                    oprot.WriteFieldEnd();
                }
                if (this.Cell != null && this.__isset.cell)
                {
                    field.Name = "cell";
                    field.Type = TType.Struct;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    this.Cell.Write(oprot);
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
            StringBuilder stringBuilder = new StringBuilder("TColumn(");
            bool flag = true;
            if (this.ColumnName != null && this.__isset.columnName)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("ColumnName: ");
                stringBuilder.Append((object) this.ColumnName);
            }
            if (this.Cell != null && this.__isset.cell)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Cell: ");
                stringBuilder.Append(this.Cell == null ? "<null>" : this.Cell.ToString());
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool columnName;
            public bool cell;
        }
    }
}
