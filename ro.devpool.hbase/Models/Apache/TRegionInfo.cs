using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class TRegionInfo : TBase, TAbstractBase
    {
        private byte[] _startKey;
        private byte[] _endKey;
        private long _id;
        private byte[] _name;
        private sbyte _version;
        private byte[] _serverName;
        private int _port;
        public TRegionInfo.Isset __isset;

        public byte[] StartKey
        {
            get
            {
                return this._startKey;
            }
            set
            {
                this.__isset.startKey = true;
                this._startKey = value;
            }
        }

        public byte[] EndKey
        {
            get
            {
                return this._endKey;
            }
            set
            {
                this.__isset.endKey = true;
                this._endKey = value;
            }
        }

        public long Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.__isset.id = true;
                this._id = value;
            }
        }

        public byte[] Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.__isset.name = true;
                this._name = value;
            }
        }

        public sbyte Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this.__isset.version = true;
                this._version = value;
            }
        }

        public byte[] ServerName
        {
            get
            {
                return this._serverName;
            }
            set
            {
                this.__isset.serverName = true;
                this._serverName = value;
            }
        }

        public int Port
        {
            get
            {
                return this._port;
            }
            set
            {
                this.__isset.port = true;
                this._port = value;
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
                                    this.StartKey = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.String)
                                {
                                    this.EndKey = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
                                if (tfield.Type == TType.I64)
                                {
                                    this.Id = iprot.ReadI64();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 4:
                                if (tfield.Type == TType.String)
                                {
                                    this.Name = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 5:
                                if (tfield.Type == TType.Byte)
                                {
                                    this.Version = iprot.ReadByte();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 6:
                                if (tfield.Type == TType.String)
                                {
                                    this.ServerName = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 7:
                                if (tfield.Type == TType.I32)
                                {
                                    this.Port = iprot.ReadI32();
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
                TStruct struc = new TStruct(nameof (TRegionInfo));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.StartKey != null && this.__isset.startKey)
                {
                    field.Name = "startKey";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.StartKey);
                    oprot.WriteFieldEnd();
                }
                if (this.EndKey != null && this.__isset.endKey)
                {
                    field.Name = "endKey";
                    field.Type = TType.String;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.EndKey);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.id)
                {
                    field.Name = "id";
                    field.Type = TType.I64;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(this.Id);
                    oprot.WriteFieldEnd();
                }
                if (this.Name != null && this.__isset.name)
                {
                    field.Name = "name";
                    field.Type = TType.String;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Name);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.version)
                {
                    field.Name = "version";
                    field.Type = TType.Byte;
                    field.ID = (short) 5;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteByte(this.Version);
                    oprot.WriteFieldEnd();
                }
                if (this.ServerName != null && this.__isset.serverName)
                {
                    field.Name = "serverName";
                    field.Type = TType.String;
                    field.ID = (short) 6;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.ServerName);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.port)
                {
                    field.Name = "port";
                    field.Type = TType.I32;
                    field.ID = (short) 7;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.Port);
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
            StringBuilder stringBuilder = new StringBuilder("TRegionInfo(");
            bool flag = true;
            if (this.StartKey != null && this.__isset.startKey)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("StartKey: ");
                stringBuilder.Append((object) this.StartKey);
            }
            if (this.EndKey != null && this.__isset.endKey)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("EndKey: ");
                stringBuilder.Append((object) this.EndKey);
            }
            if (this.__isset.id)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Id: ");
                stringBuilder.Append(this.Id);
            }
            if (this.Name != null && this.__isset.name)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Name: ");
                stringBuilder.Append((object) this.Name);
            }
            if (this.__isset.version)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Version: ");
                stringBuilder.Append(this.Version);
            }
            if (this.ServerName != null && this.__isset.serverName)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("ServerName: ");
                stringBuilder.Append((object) this.ServerName);
            }
            if (this.__isset.port)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("Port: ");
                stringBuilder.Append(this.Port);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool startKey;
            public bool endKey;
            public bool id;
            public bool name;
            public bool version;
            public bool serverName;
            public bool port;
        }
    }
}
