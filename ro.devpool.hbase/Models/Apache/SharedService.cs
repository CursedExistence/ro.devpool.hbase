using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    public class SharedService
    {
        public interface Iface
        {
            SharedStruct getStruct(int key);
        }

        public class Client : IDisposable, SharedService.Iface
        {
            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected int seqid_;
            private bool _IsDisposed;

            public Client(TProtocol prot)
                : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                this.iprot_ = iprot;
                this.oprot_ = oprot;
            }

            public TProtocol InputProtocol
            {
                get
                {
                    return this.iprot_;
                }
            }

            public TProtocol OutputProtocol
            {
                get
                {
                    return this.oprot_;
                }
            }

            public void Dispose()
            {
                this.Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!this._IsDisposed && disposing)
                {
                    if (this.iprot_ != null)
                        this.iprot_.Dispose();
                    if (this.oprot_ != null)
                        this.oprot_.Dispose();
                }
                this._IsDisposed = true;
            }

            public SharedStruct getStruct(int key)
            {
                this.send_getStruct(key);
                return this.recv_getStruct();
            }

            public void send_getStruct(int key)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getStruct", TMessageType.Call, this.seqid_));
                new SharedService.getStruct_args() { Key = key }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public SharedStruct recv_getStruct()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                SharedService.getStruct_result getStructResult = new SharedService.getStruct_result();
                getStructResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getStructResult.__isset.success)
                    return getStructResult.Success;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getStruct failed: unknown result");
            }
        }

        public class Processor : TProcessor
        {
            protected Dictionary<string, SharedService.Processor.ProcessFunction> processMap_ = new Dictionary<string, SharedService.Processor.ProcessFunction>();
            private readonly SharedService.Iface iface_;

            public Processor(SharedService.Iface iface)
            {
                this.iface_ = iface;
                this.processMap_["getStruct"] = new SharedService.Processor.ProcessFunction(this.getStruct_Process);
            }

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage tmessage = iprot.ReadMessageBegin();
                    SharedService.Processor.ProcessFunction processFunction;
                    this.processMap_.TryGetValue(tmessage.Name, out processFunction);
                    if (processFunction == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException tapplicationException = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + tmessage.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(tmessage.Name, TMessageType.Exception, tmessage.SeqID));
                        tapplicationException.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    processFunction(tmessage.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void getStruct_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                SharedService.getStruct_args getStructArgs = new SharedService.getStruct_args();
                getStructArgs.Read(iprot);
                iprot.ReadMessageEnd();
                SharedService.getStruct_result getStructResult = new SharedService.getStruct_result();
                getStructResult.Success = this.iface_.getStruct(getStructArgs.Key);
                oprot.WriteMessageBegin(new TMessage("getStruct", TMessageType.Reply, seqid));
                getStructResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
        }

        [Serializable]
        public class getStruct_args : TBase, TAbstractBase
        {
            private int _key;
            public SharedService.getStruct_args.Isset __isset;

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
                                if (tfield.Type == TType.I32)
                                    this.Key = iprot.ReadI32();
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
                    TStruct struc = new TStruct(nameof (getStruct_args));
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
                StringBuilder stringBuilder = new StringBuilder("getStruct_args(");
                bool flag = true;
                if (this.__isset.key)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Key: ");
                    stringBuilder.Append(this.Key);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool key;
            }
        }

        [Serializable]
        public class getStruct_result : TBase, TAbstractBase
        {
            private SharedStruct _success;
            public SharedService.getStruct_result.Isset __isset;

            public SharedStruct Success
            {
                get
                {
                    return this._success;
                }
                set
                {
                    this.__isset.success = true;
                    this._success = value;
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
                            if ((int) tfield.ID == 0)
                            {
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Success = new SharedStruct();
                                    this.Success.Read(iprot);
                                }
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
                    TStruct struc = new TStruct(nameof (getStruct_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success && this.Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        this.Success.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getStruct_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success == null ? "<null>" : this.Success.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
            }
        }
    }
}
