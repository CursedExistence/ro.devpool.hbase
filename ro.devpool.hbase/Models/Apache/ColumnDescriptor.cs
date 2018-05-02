using System;
using System.Text;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    [Serializable]
    public class ColumnDescriptor : TBase, TAbstractBase
    {
        private byte[] _name;
        private int _maxVersions;
        private string _compression;
        private bool _inMemory;
        private string _bloomFilterType;
        private int _bloomFilterVectorSize;
        private int _bloomFilterNbHashes;
        private bool _blockCacheEnabled;
        private int _timeToLive;
        public ColumnDescriptor.Isset __isset;

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

        public int MaxVersions
        {
            get
            {
                return this._maxVersions;
            }
            set
            {
                this.__isset.maxVersions = true;
                this._maxVersions = value;
            }
        }

        public string Compression
        {
            get
            {
                return this._compression;
            }
            set
            {
                this.__isset.compression = true;
                this._compression = value;
            }
        }

        public bool InMemory
        {
            get
            {
                return this._inMemory;
            }
            set
            {
                this.__isset.inMemory = true;
                this._inMemory = value;
            }
        }

        public string BloomFilterType
        {
            get
            {
                return this._bloomFilterType;
            }
            set
            {
                this.__isset.bloomFilterType = true;
                this._bloomFilterType = value;
            }
        }

        public int BloomFilterVectorSize
        {
            get
            {
                return this._bloomFilterVectorSize;
            }
            set
            {
                this.__isset.bloomFilterVectorSize = true;
                this._bloomFilterVectorSize = value;
            }
        }

        public int BloomFilterNbHashes
        {
            get
            {
                return this._bloomFilterNbHashes;
            }
            set
            {
                this.__isset.bloomFilterNbHashes = true;
                this._bloomFilterNbHashes = value;
            }
        }

        public bool BlockCacheEnabled
        {
            get
            {
                return this._blockCacheEnabled;
            }
            set
            {
                this.__isset.blockCacheEnabled = true;
                this._blockCacheEnabled = value;
            }
        }

        public int TimeToLive
        {
            get
            {
                return this._timeToLive;
            }
            set
            {
                this.__isset.timeToLive = true;
                this._timeToLive = value;
            }
        }

        public ColumnDescriptor()
        {
            this._maxVersions = 3;
            this.__isset.maxVersions = true;
            this._compression = "NONE";
            this.__isset.compression = true;
            this._inMemory = false;
            this.__isset.inMemory = true;
            this._bloomFilterType = "NONE";
            this.__isset.bloomFilterType = true;
            this._bloomFilterVectorSize = 0;
            this.__isset.bloomFilterVectorSize = true;
            this._bloomFilterNbHashes = 0;
            this.__isset.bloomFilterNbHashes = true;
            this._blockCacheEnabled = false;
            this.__isset.blockCacheEnabled = true;
            this._timeToLive = -1;
            this.__isset.timeToLive = true;
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
                                    this.Name = iprot.ReadBinary();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 2:
                                if (tfield.Type == TType.I32)
                                {
                                    this.MaxVersions = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 3:
                                if (tfield.Type == TType.String)
                                {
                                    this.Compression = iprot.ReadString();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 4:
                                if (tfield.Type == TType.Bool)
                                {
                                    this.InMemory = iprot.ReadBool();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 5:
                                if (tfield.Type == TType.String)
                                {
                                    this.BloomFilterType = iprot.ReadString();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 6:
                                if (tfield.Type == TType.I32)
                                {
                                    this.BloomFilterVectorSize = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 7:
                                if (tfield.Type == TType.I32)
                                {
                                    this.BloomFilterNbHashes = iprot.ReadI32();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 8:
                                if (tfield.Type == TType.Bool)
                                {
                                    this.BlockCacheEnabled = iprot.ReadBool();
                                    break;
                                }
                                TProtocolUtil.Skip(iprot, tfield.Type);
                                break;
                            case 9:
                                if (tfield.Type == TType.I32)
                                {
                                    this.TimeToLive = iprot.ReadI32();
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
                TStruct struc = new TStruct(nameof (ColumnDescriptor));
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (this.Name != null && this.__isset.name)
                {
                    field.Name = "name";
                    field.Type = TType.String;
                    field.ID = (short) 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(this.Name);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.maxVersions)
                {
                    field.Name = "maxVersions";
                    field.Type = TType.I32;
                    field.ID = (short) 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.MaxVersions);
                    oprot.WriteFieldEnd();
                }
                if (this.Compression != null && this.__isset.compression)
                {
                    field.Name = "compression";
                    field.Type = TType.String;
                    field.ID = (short) 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(this.Compression);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.inMemory)
                {
                    field.Name = "inMemory";
                    field.Type = TType.Bool;
                    field.ID = (short) 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.InMemory);
                    oprot.WriteFieldEnd();
                }
                if (this.BloomFilterType != null && this.__isset.bloomFilterType)
                {
                    field.Name = "bloomFilterType";
                    field.Type = TType.String;
                    field.ID = (short) 5;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(this.BloomFilterType);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.bloomFilterVectorSize)
                {
                    field.Name = "bloomFilterVectorSize";
                    field.Type = TType.I32;
                    field.ID = (short) 6;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.BloomFilterVectorSize);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.bloomFilterNbHashes)
                {
                    field.Name = "bloomFilterNbHashes";
                    field.Type = TType.I32;
                    field.ID = (short) 7;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.BloomFilterNbHashes);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.blockCacheEnabled)
                {
                    field.Name = "blockCacheEnabled";
                    field.Type = TType.Bool;
                    field.ID = (short) 8;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(this.BlockCacheEnabled);
                    oprot.WriteFieldEnd();
                }
                if (this.__isset.timeToLive)
                {
                    field.Name = "timeToLive";
                    field.Type = TType.I32;
                    field.ID = (short) 9;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(this.TimeToLive);
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
            StringBuilder stringBuilder = new StringBuilder("ColumnDescriptor(");
            bool flag = true;
            if (this.Name != null && this.__isset.name)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Name: ");
                stringBuilder.Append((object) this.Name);
            }
            if (this.__isset.maxVersions)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("MaxVersions: ");
                stringBuilder.Append(this.MaxVersions);
            }
            if (this.Compression != null && this.__isset.compression)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("Compression: ");
                stringBuilder.Append(this.Compression);
            }
            if (this.__isset.inMemory)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("InMemory: ");
                stringBuilder.Append(this.InMemory);
            }
            if (this.BloomFilterType != null && this.__isset.bloomFilterType)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("BloomFilterType: ");
                stringBuilder.Append(this.BloomFilterType);
            }
            if (this.__isset.bloomFilterVectorSize)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("BloomFilterVectorSize: ");
                stringBuilder.Append(this.BloomFilterVectorSize);
            }
            if (this.__isset.bloomFilterNbHashes)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("BloomFilterNbHashes: ");
                stringBuilder.Append(this.BloomFilterNbHashes);
            }
            if (this.__isset.blockCacheEnabled)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                flag = false;
                stringBuilder.Append("BlockCacheEnabled: ");
                stringBuilder.Append(this.BlockCacheEnabled);
            }
            if (this.__isset.timeToLive)
            {
                if (!flag)
                    stringBuilder.Append(", ");
                stringBuilder.Append("TimeToLive: ");
                stringBuilder.Append(this.TimeToLive);
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        [Serializable]
        public struct Isset
        {
            public bool name;
            public bool maxVersions;
            public bool compression;
            public bool inMemory;
            public bool bloomFilterType;
            public bool bloomFilterVectorSize;
            public bool bloomFilterNbHashes;
            public bool blockCacheEnabled;
            public bool timeToLive;
        }
    }
}
