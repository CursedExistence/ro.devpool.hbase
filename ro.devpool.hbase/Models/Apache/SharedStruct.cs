using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class SharedStruct : TBase, TAbstractBase
    {
        private int _key;
        private string _value;
        public SharedStruct.Isset __isset;

        public int Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this.__isset.key = true;
                this._key = value;
            }
        }

        public string Value
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
                                if (tfield.Type == TType.I32)
                                {
                                    this.Key = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.String)
                                {
                                    this.Value = iprot.ReadString();
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
                TStruct struc = new TStruct(nameof (SharedStruct));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.__isset.key)
                {
                    field.Name = "key";
                    field.Type = TType.I32;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.Key);
                    oprot.WriteFieldEnd();
                }
                if (this.Value != null && this.__isset.value)
                {
                    field.Name = "value";
                    field.Type = TType.String;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(this.Value);
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
            StringBuilder stringBuilder = new StringBuilder("SharedStruct(");
            bool flag = true;
            if (this.__isset.key)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Key: ");
                stringBuilder.Append(this.Key);
            }
            if (this.Value != null && this.__isset.value)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Value: ");
                stringBuilder.Append(this.Value);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool key;
            public bool value;
        }
    }
}
