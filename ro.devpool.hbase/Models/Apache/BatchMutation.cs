using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class BatchMutation : TBase, TAbstractBase
    {
        private byte[] _row;
        private List<Mutation> _mutations;
        public BatchMutation.Isset __isset;

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

        public List<Mutation> Mutations
        {
            get
            {
                return this._mutations;
            }
            set
            {
                this.__isset.mutations = true;
                this._mutations = value;
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
                                if (tfield.Type == TType.List)
                                {
                                    this.Mutations = new List<Mutation>();
                                    TList tlist = iprot.ReadListBegin();
                                    for (int index = 0; index < tlist.Count; ++index)
                                    {
                                        Mutation mutation = new Mutation();
                                        mutation.Read(iprot);
                                        this.Mutations.Add(mutation);
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
                TStruct struc = new TStruct(nameof (BatchMutation));
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
                if (this.Mutations != null && this.__isset.mutations)
                {
                    field.Name = "mutations";
                    field.Type = TType.List;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteListBegin(new TList(TType.Struct, this.Mutations.Count));
                    foreach (Mutation mutation in this.Mutations)
                        mutation.Write(oprot);
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
            StringBuilder stringBuilder = new StringBuilder("BatchMutation(");
            bool flag = true;
            if (this.Row != null && this.__isset.row)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Row: ");
                stringBuilder.Append((object) this.Row);
            }
            if (this.Mutations != null && this.__isset.mutations)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Mutations: ");
                stringBuilder.Append((object) this.Mutations);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool row;
            public bool mutations;
        }
    }
}
