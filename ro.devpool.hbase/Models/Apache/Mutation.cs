using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class Mutation : TBase, TAbstractBase
    {
        private bool _isDelete;
        private byte[] _column;
        private byte[] _value;
        private bool _writeToWAL;
        public Mutation.Isset __isset;

        public bool IsDelete
        {
            get
            {
                return this._isDelete;
            }
            set
            {
                this.__isset.isDelete = true;
                this._isDelete = value;
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

        public bool WriteToWAL
        {
            get
            {
                return this._writeToWAL;
            }
            set
            {
                this.__isset.writeToWAL = true;
                this._writeToWAL = value;
            }
        }

        public Mutation()
        {
            this._isDelete = false;
            this.__isset.isDelete = true;
            this._writeToWAL = true;
            this.__isset.writeToWAL = true;
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
                                if (tfield.Type == TType.Bool)
                                {
                                    this.IsDelete = iprot.ReadBool();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.String)
                                {
                                    this.Column = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
                                if (tfield.Type == TType.String)
                                {
                                    this.Value = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 4:
                                if (tfield.Type == TType.Bool)
                                {
                                    this.WriteToWAL = iprot.ReadBool();
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
                TStruct struc = new TStruct(nameof (Mutation));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.__isset.isDelete)
                {
                    field.Name = "isDelete";
                    field.Type = TType.Bool;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.IsDelete);
                    oprot.WriteFieldEnd();
                }
                if (this.Column != null && this.__isset.column)
                {
                    field.Name = "column";
                    field.Type = TType.String;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Column);
                    oprot.WriteFieldEnd();
                }
                if (this.Value != null && this.__isset.value)
                {
                    field.Name = "value";
                    field.Type = TType.String;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Value);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.writeToWAL)
                {
                    field.Name = "writeToWAL";
                    field.Type = TType.Bool;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.WriteToWAL);
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
            StringBuilder stringBuilder = new StringBuilder("Mutation(");
            bool flag = true;
            if (this.__isset.isDelete)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("IsDelete: ");
                stringBuilder.Append(this.IsDelete);
            }
            if (this.Column != null && this.__isset.column)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Column: ");
                stringBuilder.Append((object) this.Column);
            }
            if (this.Value != null && this.__isset.value)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Value: ");
                stringBuilder.Append((object) this.Value);
            }
            if (this.__isset.writeToWAL)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("WriteToWAL: ");
                stringBuilder.Append(this.WriteToWAL);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool isDelete;
            public bool column;
            public bool value;
            public bool writeToWAL;
        }
    }
}
