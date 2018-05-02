using System;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class AlreadyExists : TException, TBase, TAbstractBase
    {
        private string message;
        public AlreadyExists.Isset __isset;

        public new string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.__isset.message = true;
                this.message = value;
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
                        if ((int) tfield.ID == 1)
                        {
                            if (tfield.Type == TType.String)
                                this.Message = iprot.ReadString();
                            else
                                TProtocolUtil.Skip(iprot, tfield.Type);
                        }
                        else
                            TProtocolUtil.Skip(iprot, tfield.Type);
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
                TStruct struc = new TStruct(nameof (AlreadyExists));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.Message != null && this.__isset.message)
                {
                    field.Name = "message";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(this.Message);
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
            StringBuilder stringBuilder = new StringBuilder("AlreadyExists(");
            bool flag = true;
            if (this.Message != null && this.__isset.message)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Message: ");
                stringBuilder.Append(this.Message);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool message;
        }
    }
}
