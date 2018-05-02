using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TCell : TBase, TAbstractBase
    {
        private byte[] _value;
        private long _timestamp;
        public TCell.Isset __isset;

        public byte[] Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this.__isset.value = true;
                this._value = value;
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
                                    this.Value = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.I64)
                                {
                                    this.Timestamp = iprot.ReadI64();
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
                TStruct struc = new TStruct(nameof (TCell));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.Value != null && this.__isset.value)
                {
                    field.Name = "value";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Value);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.timestamp)
                {
                    field.Name = "timestamp";
                    field.Type = TType.I64;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(this.Timestamp);
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
            StringBuilder stringBuilder = new StringBuilder("TCell(");
            bool flag = true;
            if (this.Value != null && this.__isset.value)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Value: ");
                stringBuilder.Append((object) this.Value);
            }
            if (this.__isset.timestamp)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Timestamp: ");
                stringBuilder.Append(this.Timestamp);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool value;
            public bool timestamp;
        }
    }
}
