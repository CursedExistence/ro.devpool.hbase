using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace ro.devpool.hbase.Models.Apache {
    public class Hbase
    {
        public interface Iface
        {
            void enableTable(byte[] tableName);

            void disableTable(byte[] tableName);

            bool isTableEnabled(byte[] tableName);

            void compact(byte[] tableNameOrRegionName);

            void majorCompact(byte[] tableNameOrRegionName);

            List<byte[]> getTableNames();

            Dictionary<byte[], ColumnDescriptor> getColumnDescriptors(byte[] tableName);

            List<TRegionInfo> getTableRegions(byte[] tableName);

            void createTable(byte[] tableName, List<ColumnDescriptor> columnFamilies);

            void deleteTable(byte[] tableName);

            List<TCell> get(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes);

            List<TCell> getVer(byte[] tableName, byte[] row, byte[] column, int numVersions, Dictionary<byte[], byte[]> attributes);

            List<TCell> getVerTs(byte[] tableName, byte[] row, byte[] column, long timestamp, int numVersions, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowWithColumns(byte[] tableName, byte[] row, List<byte[]> columns, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowWithColumnsTs(byte[] tableName, byte[] row, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRows(byte[] tableName, List<byte[]> rows, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowsWithColumns(byte[] tableName, List<byte[]> rows, List<byte[]> columns, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowsTs(byte[] tableName, List<byte[]> rows, long timestamp, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> getRowsWithColumnsTs(byte[] tableName, List<byte[]> rows, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes);

            void mutateRow(byte[] tableName, byte[] row, List<Mutation> mutations, Dictionary<byte[], byte[]> attributes);

            void mutateRowTs(byte[] tableName, byte[] row, List<Mutation> mutations, long timestamp, Dictionary<byte[], byte[]> attributes);

            void mutateRows(byte[] tableName, List<BatchMutation> rowBatches, Dictionary<byte[], byte[]> attributes);

            void mutateRowsTs(byte[] tableName, List<BatchMutation> rowBatches, long timestamp, Dictionary<byte[], byte[]> attributes);

            long atomicIncrement(byte[] tableName, byte[] row, byte[] column, long value);

            void deleteAll(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes);

            void deleteAllTs(byte[] tableName, byte[] row, byte[] column, long timestamp, Dictionary<byte[], byte[]> attributes);

            void deleteAllRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes);

            void increment(TIncrement increment);

            void incrementRows(List<TIncrement> increments);

            void deleteAllRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes);

            int scannerOpenWithScan(byte[] tableName, TScan scan, Dictionary<byte[], byte[]> attributes);

            int scannerOpen(byte[] tableName, byte[] startRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes);

            int scannerOpenWithStop(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes);

            int scannerOpenWithPrefix(byte[] tableName, byte[] startAndPrefix, List<byte[]> columns, Dictionary<byte[], byte[]> attributes);

            int scannerOpenTs(byte[] tableName, byte[] startRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes);

            int scannerOpenWithStopTs(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes);

            List<TRowResult> scannerGet(int id);

            List<TRowResult> scannerGetList(int id, int nbRows);

            void scannerClose(int id);

            List<TCell> getRowOrBefore(byte[] tableName, byte[] row, byte[] family);

            TRegionInfo getRegionInfo(byte[] row);

            List<TCell> append(TAppend append);

            bool checkAndPut(byte[] tableName, byte[] row, byte[] column, byte[] value, Mutation mput, Dictionary<byte[], byte[]> attributes);
        }

        public class Client : IDisposable, Hbase.Iface
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

            public void enableTable(byte[] tableName)
            {
                this.send_enableTable(tableName);
                this.recv_enableTable();
            }

            public void send_enableTable(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("enableTable", TMessageType.Call, this.seqid_));
                new Hbase.enableTable_args() { TableName = tableName }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_enableTable()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.enableTable_result enableTableResult = new Hbase.enableTable_result();
                enableTableResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (enableTableResult.__isset.io)
                    throw enableTableResult.Io;
            }

            public void disableTable(byte[] tableName)
            {
                this.send_disableTable(tableName);
                this.recv_disableTable();
            }

            public void send_disableTable(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("disableTable", TMessageType.Call, this.seqid_));
                new Hbase.disableTable_args()
                {
                    TableName = tableName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_disableTable()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.disableTable_result disableTableResult = new Hbase.disableTable_result();
                disableTableResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (disableTableResult.__isset.io)
                    throw disableTableResult.Io;
            }

            public bool isTableEnabled(byte[] tableName)
            {
                this.send_isTableEnabled(tableName);
                return this.recv_isTableEnabled();
            }

            public void send_isTableEnabled(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("isTableEnabled", TMessageType.Call, this.seqid_));
                new Hbase.isTableEnabled_args()
                {
                    TableName = tableName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public bool recv_isTableEnabled()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.isTableEnabled_result tableEnabledResult = new Hbase.isTableEnabled_result();
                tableEnabledResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (tableEnabledResult.__isset.success)
                    return tableEnabledResult.Success;
                if (tableEnabledResult.__isset.io)
                    throw tableEnabledResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "isTableEnabled failed: unknown result");
            }

            public void compact(byte[] tableNameOrRegionName)
            {
                this.send_compact(tableNameOrRegionName);
                this.recv_compact();
            }

            public void send_compact(byte[] tableNameOrRegionName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("compact", TMessageType.Call, this.seqid_));
                new Hbase.compact_args()
                {
                    TableNameOrRegionName = tableNameOrRegionName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_compact()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.compact_result compactResult = new Hbase.compact_result();
                compactResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (compactResult.__isset.io)
                    throw compactResult.Io;
            }

            public void majorCompact(byte[] tableNameOrRegionName)
            {
                this.send_majorCompact(tableNameOrRegionName);
                this.recv_majorCompact();
            }

            public void send_majorCompact(byte[] tableNameOrRegionName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("majorCompact", TMessageType.Call, this.seqid_));
                new Hbase.majorCompact_args()
                {
                    TableNameOrRegionName = tableNameOrRegionName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_majorCompact()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.majorCompact_result majorCompactResult = new Hbase.majorCompact_result();
                majorCompactResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (majorCompactResult.__isset.io)
                    throw majorCompactResult.Io;
            }

            public List<byte[]> getTableNames()
            {
                this.send_getTableNames();
                return this.recv_getTableNames();
            }

            public void send_getTableNames()
            {
                this.oprot_.WriteMessageBegin(new TMessage("getTableNames", TMessageType.Call, this.seqid_));
                new Hbase.getTableNames_args().Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<byte[]> recv_getTableNames()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getTableNames_result tableNamesResult = new Hbase.getTableNames_result();
                tableNamesResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (tableNamesResult.__isset.success)
                    return tableNamesResult.Success;
                if (tableNamesResult.__isset.io)
                    throw tableNamesResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getTableNames failed: unknown result");
            }

            public Dictionary<byte[], ColumnDescriptor> getColumnDescriptors(byte[] tableName)
            {
                this.send_getColumnDescriptors(tableName);
                return this.recv_getColumnDescriptors();
            }

            public void send_getColumnDescriptors(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getColumnDescriptors", TMessageType.Call, this.seqid_));
                new Hbase.getColumnDescriptors_args()
                {
                    TableName = tableName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public Dictionary<byte[], ColumnDescriptor> recv_getColumnDescriptors()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getColumnDescriptors_result descriptorsResult = new Hbase.getColumnDescriptors_result();
                descriptorsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (descriptorsResult.__isset.success)
                    return descriptorsResult.Success;
                if (descriptorsResult.__isset.io)
                    throw descriptorsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getColumnDescriptors failed: unknown result");
            }

            public List<TRegionInfo> getTableRegions(byte[] tableName)
            {
                this.send_getTableRegions(tableName);
                return this.recv_getTableRegions();
            }

            public void send_getTableRegions(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getTableRegions", TMessageType.Call, this.seqid_));
                new Hbase.getTableRegions_args()
                {
                    TableName = tableName
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRegionInfo> recv_getTableRegions()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getTableRegions_result tableRegionsResult = new Hbase.getTableRegions_result();
                tableRegionsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (tableRegionsResult.__isset.success)
                    return tableRegionsResult.Success;
                if (tableRegionsResult.__isset.io)
                    throw tableRegionsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getTableRegions failed: unknown result");
            }

            public void createTable(byte[] tableName, List<ColumnDescriptor> columnFamilies)
            {
                this.send_createTable(tableName, columnFamilies);
                this.recv_createTable();
            }

            public void send_createTable(byte[] tableName, List<ColumnDescriptor> columnFamilies)
            {
                this.oprot_.WriteMessageBegin(new TMessage("createTable", TMessageType.Call, this.seqid_));
                new Hbase.createTable_args()
                {
                    TableName = tableName,
                    ColumnFamilies = columnFamilies
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_createTable()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.createTable_result createTableResult = new Hbase.createTable_result();
                createTableResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (createTableResult.__isset.io)
                    throw createTableResult.Io;
                if (createTableResult.__isset.ia)
                    throw createTableResult.Ia;
                if (createTableResult.__isset.exist)
                    throw createTableResult.Exist;
            }

            public void deleteTable(byte[] tableName)
            {
                this.send_deleteTable(tableName);
                this.recv_deleteTable();
            }

            public void send_deleteTable(byte[] tableName)
            {
                this.oprot_.WriteMessageBegin(new TMessage("deleteTable", TMessageType.Call, this.seqid_));
                new Hbase.deleteTable_args() { TableName = tableName }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_deleteTable()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.deleteTable_result deleteTableResult = new Hbase.deleteTable_result();
                deleteTableResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (deleteTableResult.__isset.io)
                    throw deleteTableResult.Io;
            }

            public List<TCell> get(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes)
            {
                this.send_get(tableName, row, column, attributes);
                return this.recv_get();
            }

            public void send_get(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("get", TMessageType.Call, this.seqid_));
                new Hbase.get_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TCell> recv_get()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.get_result getResult = new Hbase.get_result();
                getResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getResult.__isset.success)
                    return getResult.Success;
                if (getResult.__isset.io)
                    throw getResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "get failed: unknown result");
            }

            public List<TCell> getVer(byte[] tableName, byte[] row, byte[] column, int numVersions, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getVer(tableName, row, column, numVersions, attributes);
                return this.recv_getVer();
            }

            public void send_getVer(byte[] tableName, byte[] row, byte[] column, int numVersions, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getVer", TMessageType.Call, this.seqid_));
                new Hbase.getVer_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    NumVersions = numVersions,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TCell> recv_getVer()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getVer_result getVerResult = new Hbase.getVer_result();
                getVerResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getVerResult.__isset.success)
                    return getVerResult.Success;
                if (getVerResult.__isset.io)
                    throw getVerResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getVer failed: unknown result");
            }

            public List<TCell> getVerTs(byte[] tableName, byte[] row, byte[] column, long timestamp, int numVersions, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getVerTs(tableName, row, column, timestamp, numVersions, attributes);
                return this.recv_getVerTs();
            }

            public void send_getVerTs(byte[] tableName, byte[] row, byte[] column, long timestamp, int numVersions, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getVerTs", TMessageType.Call, this.seqid_));
                new Hbase.getVerTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Timestamp = timestamp,
                    NumVersions = numVersions,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TCell> recv_getVerTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getVerTs_result getVerTsResult = new Hbase.getVerTs_result();
                getVerTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getVerTsResult.__isset.success)
                    return getVerTsResult.Success;
                if (getVerTsResult.__isset.io)
                    throw getVerTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getVerTs failed: unknown result");
            }

            public List<TRowResult> getRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRow(tableName, row, attributes);
                return this.recv_getRow();
            }

            public void send_getRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRow", TMessageType.Call, this.seqid_));
                new Hbase.getRow_args()
                {
                    TableName = tableName,
                    Row = row,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRow()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRow_result getRowResult = new Hbase.getRow_result();
                getRowResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getRowResult.__isset.success)
                    return getRowResult.Success;
                if (getRowResult.__isset.io)
                    throw getRowResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRow failed: unknown result");
            }

            public List<TRowResult> getRowWithColumns(byte[] tableName, byte[] row, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowWithColumns(tableName, row, columns, attributes);
                return this.recv_getRowWithColumns();
            }

            public void send_getRowWithColumns(byte[] tableName, byte[] row, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowWithColumns", TMessageType.Call, this.seqid_));
                new Hbase.getRowWithColumns_args()
                {
                    TableName = tableName,
                    Row = row,
                    Columns = columns,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowWithColumns()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowWithColumns_result withColumnsResult = new Hbase.getRowWithColumns_result();
                withColumnsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withColumnsResult.__isset.success)
                    return withColumnsResult.Success;
                if (withColumnsResult.__isset.io)
                    throw withColumnsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowWithColumns failed: unknown result");
            }

            public List<TRowResult> getRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowTs(tableName, row, timestamp, attributes);
                return this.recv_getRowTs();
            }

            public void send_getRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowTs", TMessageType.Call, this.seqid_));
                new Hbase.getRowTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowTs_result getRowTsResult = new Hbase.getRowTs_result();
                getRowTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getRowTsResult.__isset.success)
                    return getRowTsResult.Success;
                if (getRowTsResult.__isset.io)
                    throw getRowTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowTs failed: unknown result");
            }

            public List<TRowResult> getRowWithColumnsTs(byte[] tableName, byte[] row, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowWithColumnsTs(tableName, row, columns, timestamp, attributes);
                return this.recv_getRowWithColumnsTs();
            }

            public void send_getRowWithColumnsTs(byte[] tableName, byte[] row, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowWithColumnsTs", TMessageType.Call, this.seqid_));
                new Hbase.getRowWithColumnsTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Columns = columns,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowWithColumnsTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowWithColumnsTs_result withColumnsTsResult = new Hbase.getRowWithColumnsTs_result();
                withColumnsTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withColumnsTsResult.__isset.success)
                    return withColumnsTsResult.Success;
                if (withColumnsTsResult.__isset.io)
                    throw withColumnsTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowWithColumnsTs failed: unknown result");
            }

            public List<TRowResult> getRows(byte[] tableName, List<byte[]> rows, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRows(tableName, rows, attributes);
                return this.recv_getRows();
            }

            public void send_getRows(byte[] tableName, List<byte[]> rows, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRows", TMessageType.Call, this.seqid_));
                new Hbase.getRows_args()
                {
                    TableName = tableName,
                    Rows = rows,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRows()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRows_result getRowsResult = new Hbase.getRows_result();
                getRowsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getRowsResult.__isset.success)
                    return getRowsResult.Success;
                if (getRowsResult.__isset.io)
                    throw getRowsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRows failed: unknown result");
            }

            public List<TRowResult> getRowsWithColumns(byte[] tableName, List<byte[]> rows, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowsWithColumns(tableName, rows, columns, attributes);
                return this.recv_getRowsWithColumns();
            }

            public void send_getRowsWithColumns(byte[] tableName, List<byte[]> rows, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowsWithColumns", TMessageType.Call, this.seqid_));
                new Hbase.getRowsWithColumns_args()
                {
                    TableName = tableName,
                    Rows = rows,
                    Columns = columns,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowsWithColumns()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowsWithColumns_result withColumnsResult = new Hbase.getRowsWithColumns_result();
                withColumnsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withColumnsResult.__isset.success)
                    return withColumnsResult.Success;
                if (withColumnsResult.__isset.io)
                    throw withColumnsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowsWithColumns failed: unknown result");
            }

            public List<TRowResult> getRowsTs(byte[] tableName, List<byte[]> rows, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowsTs(tableName, rows, timestamp, attributes);
                return this.recv_getRowsTs();
            }

            public void send_getRowsTs(byte[] tableName, List<byte[]> rows, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowsTs", TMessageType.Call, this.seqid_));
                new Hbase.getRowsTs_args()
                {
                    TableName = tableName,
                    Rows = rows,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowsTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowsTs_result getRowsTsResult = new Hbase.getRowsTs_result();
                getRowsTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (getRowsTsResult.__isset.success)
                    return getRowsTsResult.Success;
                if (getRowsTsResult.__isset.io)
                    throw getRowsTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowsTs failed: unknown result");
            }

            public List<TRowResult> getRowsWithColumnsTs(byte[] tableName, List<byte[]> rows, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_getRowsWithColumnsTs(tableName, rows, columns, timestamp, attributes);
                return this.recv_getRowsWithColumnsTs();
            }

            public void send_getRowsWithColumnsTs(byte[] tableName, List<byte[]> rows, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowsWithColumnsTs", TMessageType.Call, this.seqid_));
                new Hbase.getRowsWithColumnsTs_args()
                {
                    TableName = tableName,
                    Rows = rows,
                    Columns = columns,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_getRowsWithColumnsTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowsWithColumnsTs_result withColumnsTsResult = new Hbase.getRowsWithColumnsTs_result();
                withColumnsTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withColumnsTsResult.__isset.success)
                    return withColumnsTsResult.Success;
                if (withColumnsTsResult.__isset.io)
                    throw withColumnsTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowsWithColumnsTs failed: unknown result");
            }

            public void mutateRow(byte[] tableName, byte[] row, List<Mutation> mutations, Dictionary<byte[], byte[]> attributes)
            {
                this.send_mutateRow(tableName, row, mutations, attributes);
                this.recv_mutateRow();
            }

            public void send_mutateRow(byte[] tableName, byte[] row, List<Mutation> mutations, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("mutateRow", TMessageType.Call, this.seqid_));
                new Hbase.mutateRow_args()
                {
                    TableName = tableName,
                    Row = row,
                    Mutations = mutations,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_mutateRow()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.mutateRow_result mutateRowResult = new Hbase.mutateRow_result();
                mutateRowResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (mutateRowResult.__isset.io)
                    throw mutateRowResult.Io;
                if (mutateRowResult.__isset.ia)
                    throw mutateRowResult.Ia;
            }

            public void mutateRowTs(byte[] tableName, byte[] row, List<Mutation> mutations, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_mutateRowTs(tableName, row, mutations, timestamp, attributes);
                this.recv_mutateRowTs();
            }

            public void send_mutateRowTs(byte[] tableName, byte[] row, List<Mutation> mutations, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("mutateRowTs", TMessageType.Call, this.seqid_));
                new Hbase.mutateRowTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Mutations = mutations,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_mutateRowTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.mutateRowTs_result mutateRowTsResult = new Hbase.mutateRowTs_result();
                mutateRowTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (mutateRowTsResult.__isset.io)
                    throw mutateRowTsResult.Io;
                if (mutateRowTsResult.__isset.ia)
                    throw mutateRowTsResult.Ia;
            }

            public void mutateRows(byte[] tableName, List<BatchMutation> rowBatches, Dictionary<byte[], byte[]> attributes)
            {
                this.send_mutateRows(tableName, rowBatches, attributes);
                this.recv_mutateRows();
            }

            public void send_mutateRows(byte[] tableName, List<BatchMutation> rowBatches, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("mutateRows", TMessageType.Call, this.seqid_));
                new Hbase.mutateRows_args()
                {
                    TableName = tableName,
                    RowBatches = rowBatches,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_mutateRows()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.mutateRows_result mutateRowsResult = new Hbase.mutateRows_result();
                mutateRowsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (mutateRowsResult.__isset.io)
                    throw mutateRowsResult.Io;
                if (mutateRowsResult.__isset.ia)
                    throw mutateRowsResult.Ia;
            }

            public void mutateRowsTs(byte[] tableName, List<BatchMutation> rowBatches, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_mutateRowsTs(tableName, rowBatches, timestamp, attributes);
                this.recv_mutateRowsTs();
            }

            public void send_mutateRowsTs(byte[] tableName, List<BatchMutation> rowBatches, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("mutateRowsTs", TMessageType.Call, this.seqid_));
                new Hbase.mutateRowsTs_args()
                {
                    TableName = tableName,
                    RowBatches = rowBatches,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_mutateRowsTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.mutateRowsTs_result mutateRowsTsResult = new Hbase.mutateRowsTs_result();
                mutateRowsTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (mutateRowsTsResult.__isset.io)
                    throw mutateRowsTsResult.Io;
                if (mutateRowsTsResult.__isset.ia)
                    throw mutateRowsTsResult.Ia;
            }

            public long atomicIncrement(byte[] tableName, byte[] row, byte[] column, long value)
            {
                this.send_atomicIncrement(tableName, row, column, value);
                return this.recv_atomicIncrement();
            }

            public void send_atomicIncrement(byte[] tableName, byte[] row, byte[] column, long value)
            {
                this.oprot_.WriteMessageBegin(new TMessage("atomicIncrement", TMessageType.Call, this.seqid_));
                new Hbase.atomicIncrement_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Value = value
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public long recv_atomicIncrement()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.atomicIncrement_result atomicIncrementResult = new Hbase.atomicIncrement_result();
                atomicIncrementResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (atomicIncrementResult.__isset.success)
                    return atomicIncrementResult.Success;
                if (atomicIncrementResult.__isset.io)
                    throw atomicIncrementResult.Io;
                if (atomicIncrementResult.__isset.ia)
                    throw atomicIncrementResult.Ia;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "atomicIncrement failed: unknown result");
            }

            public void deleteAll(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes)
            {
                this.send_deleteAll(tableName, row, column, attributes);
                this.recv_deleteAll();
            }

            public void send_deleteAll(byte[] tableName, byte[] row, byte[] column, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("deleteAll", TMessageType.Call, this.seqid_));
                new Hbase.deleteAll_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_deleteAll()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.deleteAll_result deleteAllResult = new Hbase.deleteAll_result();
                deleteAllResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (deleteAllResult.__isset.io)
                    throw deleteAllResult.Io;
            }

            public void deleteAllTs(byte[] tableName, byte[] row, byte[] column, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_deleteAllTs(tableName, row, column, timestamp, attributes);
                this.recv_deleteAllTs();
            }

            public void send_deleteAllTs(byte[] tableName, byte[] row, byte[] column, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("deleteAllTs", TMessageType.Call, this.seqid_));
                new Hbase.deleteAllTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_deleteAllTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.deleteAllTs_result deleteAllTsResult = new Hbase.deleteAllTs_result();
                deleteAllTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (deleteAllTsResult.__isset.io)
                    throw deleteAllTsResult.Io;
            }

            public void deleteAllRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
            {
                this.send_deleteAllRow(tableName, row, attributes);
                this.recv_deleteAllRow();
            }

            public void send_deleteAllRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("deleteAllRow", TMessageType.Call, this.seqid_));
                new Hbase.deleteAllRow_args()
                {
                    TableName = tableName,
                    Row = row,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_deleteAllRow()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.deleteAllRow_result deleteAllRowResult = new Hbase.deleteAllRow_result();
                deleteAllRowResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (deleteAllRowResult.__isset.io)
                    throw deleteAllRowResult.Io;
            }

            public void increment(TIncrement increment)
            {
                this.send_increment(increment);
                this.recv_increment();
            }

            public void send_increment(TIncrement increment)
            {
                this.oprot_.WriteMessageBegin(new TMessage(nameof (increment), TMessageType.Call, this.seqid_));
                new Hbase.increment_args() { Increment = increment }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_increment()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.increment_result incrementResult = new Hbase.increment_result();
                incrementResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (incrementResult.__isset.io)
                    throw incrementResult.Io;
            }

            public void incrementRows(List<TIncrement> increments)
            {
                this.send_incrementRows(increments);
                this.recv_incrementRows();
            }

            public void send_incrementRows(List<TIncrement> increments)
            {
                this.oprot_.WriteMessageBegin(new TMessage("incrementRows", TMessageType.Call, this.seqid_));
                new Hbase.incrementRows_args()
                {
                    Increments = increments
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_incrementRows()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.incrementRows_result incrementRowsResult = new Hbase.incrementRows_result();
                incrementRowsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (incrementRowsResult.__isset.io)
                    throw incrementRowsResult.Io;
            }

            public void deleteAllRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_deleteAllRowTs(tableName, row, timestamp, attributes);
                this.recv_deleteAllRowTs();
            }

            public void send_deleteAllRowTs(byte[] tableName, byte[] row, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("deleteAllRowTs", TMessageType.Call, this.seqid_));
                new Hbase.deleteAllRowTs_args()
                {
                    TableName = tableName,
                    Row = row,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_deleteAllRowTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.deleteAllRowTs_result deleteAllRowTsResult = new Hbase.deleteAllRowTs_result();
                deleteAllRowTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (deleteAllRowTsResult.__isset.io)
                    throw deleteAllRowTsResult.Io;
            }

            public int scannerOpenWithScan(byte[] tableName, TScan scan, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpenWithScan(tableName, scan, attributes);
                return this.recv_scannerOpenWithScan();
            }

            public void send_scannerOpenWithScan(byte[] tableName, TScan scan, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpenWithScan", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpenWithScan_args()
                {
                    TableName = tableName,
                    Scan = scan,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpenWithScan()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpenWithScan_result openWithScanResult = new Hbase.scannerOpenWithScan_result();
                openWithScanResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (openWithScanResult.__isset.success)
                    return openWithScanResult.Success;
                if (openWithScanResult.__isset.io)
                    throw openWithScanResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpenWithScan failed: unknown result");
            }

            public int scannerOpen(byte[] tableName, byte[] startRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpen(tableName, startRow, columns, attributes);
                return this.recv_scannerOpen();
            }

            public void send_scannerOpen(byte[] tableName, byte[] startRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpen", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpen_args()
                {
                    TableName = tableName,
                    StartRow = startRow,
                    Columns = columns,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpen()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpen_result scannerOpenResult = new Hbase.scannerOpen_result();
                scannerOpenResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (scannerOpenResult.__isset.success)
                    return scannerOpenResult.Success;
                if (scannerOpenResult.__isset.io)
                    throw scannerOpenResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpen failed: unknown result");
            }

            public int scannerOpenWithStop(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpenWithStop(tableName, startRow, stopRow, columns, attributes);
                return this.recv_scannerOpenWithStop();
            }

            public void send_scannerOpenWithStop(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpenWithStop", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpenWithStop_args()
                {
                    TableName = tableName,
                    StartRow = startRow,
                    StopRow = stopRow,
                    Columns = columns,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpenWithStop()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpenWithStop_result openWithStopResult = new Hbase.scannerOpenWithStop_result();
                openWithStopResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (openWithStopResult.__isset.success)
                    return openWithStopResult.Success;
                if (openWithStopResult.__isset.io)
                    throw openWithStopResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpenWithStop failed: unknown result");
            }

            public int scannerOpenWithPrefix(byte[] tableName, byte[] startAndPrefix, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpenWithPrefix(tableName, startAndPrefix, columns, attributes);
                return this.recv_scannerOpenWithPrefix();
            }

            public void send_scannerOpenWithPrefix(byte[] tableName, byte[] startAndPrefix, List<byte[]> columns, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpenWithPrefix", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpenWithPrefix_args()
                {
                    TableName = tableName,
                    StartAndPrefix = startAndPrefix,
                    Columns = columns,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpenWithPrefix()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpenWithPrefix_result withPrefixResult = new Hbase.scannerOpenWithPrefix_result();
                withPrefixResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withPrefixResult.__isset.success)
                    return withPrefixResult.Success;
                if (withPrefixResult.__isset.io)
                    throw withPrefixResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpenWithPrefix failed: unknown result");
            }

            public int scannerOpenTs(byte[] tableName, byte[] startRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpenTs(tableName, startRow, columns, timestamp, attributes);
                return this.recv_scannerOpenTs();
            }

            public void send_scannerOpenTs(byte[] tableName, byte[] startRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpenTs", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpenTs_args()
                {
                    TableName = tableName,
                    StartRow = startRow,
                    Columns = columns,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpenTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpenTs_result scannerOpenTsResult = new Hbase.scannerOpenTs_result();
                scannerOpenTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (scannerOpenTsResult.__isset.success)
                    return scannerOpenTsResult.Success;
                if (scannerOpenTsResult.__isset.io)
                    throw scannerOpenTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpenTs failed: unknown result");
            }

            public int scannerOpenWithStopTs(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.send_scannerOpenWithStopTs(tableName, startRow, stopRow, columns, timestamp, attributes);
                return this.recv_scannerOpenWithStopTs();
            }

            public void send_scannerOpenWithStopTs(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns, long timestamp, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerOpenWithStopTs", TMessageType.Call, this.seqid_));
                new Hbase.scannerOpenWithStopTs_args()
                {
                    TableName = tableName,
                    StartRow = startRow,
                    StopRow = stopRow,
                    Columns = columns,
                    Timestamp = timestamp,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public int recv_scannerOpenWithStopTs()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerOpenWithStopTs_result withStopTsResult = new Hbase.scannerOpenWithStopTs_result();
                withStopTsResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (withStopTsResult.__isset.success)
                    return withStopTsResult.Success;
                if (withStopTsResult.__isset.io)
                    throw withStopTsResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerOpenWithStopTs failed: unknown result");
            }

            public List<TRowResult> scannerGet(int id)
            {
                this.send_scannerGet(id);
                return this.recv_scannerGet();
            }

            public void send_scannerGet(int id)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerGet", TMessageType.Call, this.seqid_));
                new Hbase.scannerGet_args() { Id = id }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_scannerGet()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerGet_result scannerGetResult = new Hbase.scannerGet_result();
                scannerGetResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (scannerGetResult.__isset.success)
                    return scannerGetResult.Success;
                if (scannerGetResult.__isset.io)
                    throw scannerGetResult.Io;
                if (scannerGetResult.__isset.ia)
                    throw scannerGetResult.Ia;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerGet failed: unknown result");
            }

            public List<TRowResult> scannerGetList(int id, int nbRows)
            {
                this.send_scannerGetList(id, nbRows);
                return this.recv_scannerGetList();
            }

            public void send_scannerGetList(int id, int nbRows)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerGetList", TMessageType.Call, this.seqid_));
                new Hbase.scannerGetList_args()
                {
                    Id = id,
                    NbRows = nbRows
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TRowResult> recv_scannerGetList()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerGetList_result scannerGetListResult = new Hbase.scannerGetList_result();
                scannerGetListResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (scannerGetListResult.__isset.success)
                    return scannerGetListResult.Success;
                if (scannerGetListResult.__isset.io)
                    throw scannerGetListResult.Io;
                if (scannerGetListResult.__isset.ia)
                    throw scannerGetListResult.Ia;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "scannerGetList failed: unknown result");
            }

            public void scannerClose(int id)
            {
                this.send_scannerClose(id);
                this.recv_scannerClose();
            }

            public void send_scannerClose(int id)
            {
                this.oprot_.WriteMessageBegin(new TMessage("scannerClose", TMessageType.Call, this.seqid_));
                new Hbase.scannerClose_args() { Id = id }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public void recv_scannerClose()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.scannerClose_result scannerCloseResult = new Hbase.scannerClose_result();
                scannerCloseResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (scannerCloseResult.__isset.io)
                    throw scannerCloseResult.Io;
                if (scannerCloseResult.__isset.ia)
                    throw scannerCloseResult.Ia;
            }

            public List<TCell> getRowOrBefore(byte[] tableName, byte[] row, byte[] family)
            {
                this.send_getRowOrBefore(tableName, row, family);
                return this.recv_getRowOrBefore();
            }

            public void send_getRowOrBefore(byte[] tableName, byte[] row, byte[] family)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRowOrBefore", TMessageType.Call, this.seqid_));
                new Hbase.getRowOrBefore_args()
                {
                    TableName = tableName,
                    Row = row,
                    Family = family
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TCell> recv_getRowOrBefore()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRowOrBefore_result rowOrBeforeResult = new Hbase.getRowOrBefore_result();
                rowOrBeforeResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (rowOrBeforeResult.__isset.success)
                    return rowOrBeforeResult.Success;
                if (rowOrBeforeResult.__isset.io)
                    throw rowOrBeforeResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRowOrBefore failed: unknown result");
            }

            public TRegionInfo getRegionInfo(byte[] row)
            {
                this.send_getRegionInfo(row);
                return this.recv_getRegionInfo();
            }

            public void send_getRegionInfo(byte[] row)
            {
                this.oprot_.WriteMessageBegin(new TMessage("getRegionInfo", TMessageType.Call, this.seqid_));
                new Hbase.getRegionInfo_args() { Row = row }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public TRegionInfo recv_getRegionInfo()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.getRegionInfo_result regionInfoResult = new Hbase.getRegionInfo_result();
                regionInfoResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (regionInfoResult.__isset.success)
                    return regionInfoResult.Success;
                if (regionInfoResult.__isset.io)
                    throw regionInfoResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getRegionInfo failed: unknown result");
            }

            public List<TCell> append(TAppend append)
            {
                this.send_append(append);
                return this.recv_append();
            }

            public void send_append(TAppend append)
            {
                this.oprot_.WriteMessageBegin(new TMessage(nameof (append), TMessageType.Call, this.seqid_));
                new Hbase.append_args() { Append = append }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public List<TCell> recv_append()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.append_result appendResult = new Hbase.append_result();
                appendResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (appendResult.__isset.success)
                    return appendResult.Success;
                if (appendResult.__isset.io)
                    throw appendResult.Io;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "append failed: unknown result");
            }

            public bool checkAndPut(byte[] tableName, byte[] row, byte[] column, byte[] value, Mutation mput, Dictionary<byte[], byte[]> attributes)
            {
                this.send_checkAndPut(tableName, row, column, value, mput, attributes);
                return this.recv_checkAndPut();
            }

            public void send_checkAndPut(byte[] tableName, byte[] row, byte[] column, byte[] value, Mutation mput, Dictionary<byte[], byte[]> attributes)
            {
                this.oprot_.WriteMessageBegin(new TMessage("checkAndPut", TMessageType.Call, this.seqid_));
                new Hbase.checkAndPut_args()
                {
                    TableName = tableName,
                    Row = row,
                    Column = column,
                    Value = value,
                    Mput = mput,
                    Attributes = attributes
                }.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
                this.oprot_.Transport.Flush();
            }

            public bool recv_checkAndPut()
            {
                if (this.iprot_.ReadMessageBegin().Type == TMessageType.Exception)
                {
                    TApplicationException tapplicationException = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw tapplicationException;
                }
                Hbase.checkAndPut_result checkAndPutResult = new Hbase.checkAndPut_result();
                checkAndPutResult.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (checkAndPutResult.__isset.success)
                    return checkAndPutResult.Success;
                if (checkAndPutResult.__isset.io)
                    throw checkAndPutResult.Io;
                if (checkAndPutResult.__isset.ia)
                    throw checkAndPutResult.Ia;
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "checkAndPut failed: unknown result");
            }
        }

        public class Processor : TProcessor
        {
            protected Dictionary<string, Hbase.Processor.ProcessFunction> processMap_ = new Dictionary<string, Hbase.Processor.ProcessFunction>();
            private Hbase.Iface iface_;

            public Processor(Hbase.Iface iface)
            {
                this.iface_ = iface;
                this.processMap_["enableTable"] = new Hbase.Processor.ProcessFunction(this.enableTable_Process);
                this.processMap_["disableTable"] = new Hbase.Processor.ProcessFunction(this.disableTable_Process);
                this.processMap_["isTableEnabled"] = new Hbase.Processor.ProcessFunction(this.isTableEnabled_Process);
                this.processMap_["compact"] = new Hbase.Processor.ProcessFunction(this.compact_Process);
                this.processMap_["majorCompact"] = new Hbase.Processor.ProcessFunction(this.majorCompact_Process);
                this.processMap_["getTableNames"] = new Hbase.Processor.ProcessFunction(this.getTableNames_Process);
                this.processMap_["getColumnDescriptors"] = new Hbase.Processor.ProcessFunction(this.getColumnDescriptors_Process);
                this.processMap_["getTableRegions"] = new Hbase.Processor.ProcessFunction(this.getTableRegions_Process);
                this.processMap_["createTable"] = new Hbase.Processor.ProcessFunction(this.createTable_Process);
                this.processMap_["deleteTable"] = new Hbase.Processor.ProcessFunction(this.deleteTable_Process);
                this.processMap_["get"] = new Hbase.Processor.ProcessFunction(this.get_Process);
                this.processMap_["getVer"] = new Hbase.Processor.ProcessFunction(this.getVer_Process);
                this.processMap_["getVerTs"] = new Hbase.Processor.ProcessFunction(this.getVerTs_Process);
                this.processMap_["getRow"] = new Hbase.Processor.ProcessFunction(this.getRow_Process);
                this.processMap_["getRowWithColumns"] = new Hbase.Processor.ProcessFunction(this.getRowWithColumns_Process);
                this.processMap_["getRowTs"] = new Hbase.Processor.ProcessFunction(this.getRowTs_Process);
                this.processMap_["getRowWithColumnsTs"] = new Hbase.Processor.ProcessFunction(this.getRowWithColumnsTs_Process);
                this.processMap_["getRows"] = new Hbase.Processor.ProcessFunction(this.getRows_Process);
                this.processMap_["getRowsWithColumns"] = new Hbase.Processor.ProcessFunction(this.getRowsWithColumns_Process);
                this.processMap_["getRowsTs"] = new Hbase.Processor.ProcessFunction(this.getRowsTs_Process);
                this.processMap_["getRowsWithColumnsTs"] = new Hbase.Processor.ProcessFunction(this.getRowsWithColumnsTs_Process);
                this.processMap_["mutateRow"] = new Hbase.Processor.ProcessFunction(this.mutateRow_Process);
                this.processMap_["mutateRowTs"] = new Hbase.Processor.ProcessFunction(this.mutateRowTs_Process);
                this.processMap_["mutateRows"] = new Hbase.Processor.ProcessFunction(this.mutateRows_Process);
                this.processMap_["mutateRowsTs"] = new Hbase.Processor.ProcessFunction(this.mutateRowsTs_Process);
                this.processMap_["atomicIncrement"] = new Hbase.Processor.ProcessFunction(this.atomicIncrement_Process);
                this.processMap_["deleteAll"] = new Hbase.Processor.ProcessFunction(this.deleteAll_Process);
                this.processMap_["deleteAllTs"] = new Hbase.Processor.ProcessFunction(this.deleteAllTs_Process);
                this.processMap_["deleteAllRow"] = new Hbase.Processor.ProcessFunction(this.deleteAllRow_Process);
                this.processMap_["increment"] = new Hbase.Processor.ProcessFunction(this.increment_Process);
                this.processMap_["incrementRows"] = new Hbase.Processor.ProcessFunction(this.incrementRows_Process);
                this.processMap_["deleteAllRowTs"] = new Hbase.Processor.ProcessFunction(this.deleteAllRowTs_Process);
                this.processMap_["scannerOpenWithScan"] = new Hbase.Processor.ProcessFunction(this.scannerOpenWithScan_Process);
                this.processMap_["scannerOpen"] = new Hbase.Processor.ProcessFunction(this.scannerOpen_Process);
                this.processMap_["scannerOpenWithStop"] = new Hbase.Processor.ProcessFunction(this.scannerOpenWithStop_Process);
                this.processMap_["scannerOpenWithPrefix"] = new Hbase.Processor.ProcessFunction(this.scannerOpenWithPrefix_Process);
                this.processMap_["scannerOpenTs"] = new Hbase.Processor.ProcessFunction(this.scannerOpenTs_Process);
                this.processMap_["scannerOpenWithStopTs"] = new Hbase.Processor.ProcessFunction(this.scannerOpenWithStopTs_Process);
                this.processMap_["scannerGet"] = new Hbase.Processor.ProcessFunction(this.scannerGet_Process);
                this.processMap_["scannerGetList"] = new Hbase.Processor.ProcessFunction(this.scannerGetList_Process);
                this.processMap_["scannerClose"] = new Hbase.Processor.ProcessFunction(this.scannerClose_Process);
                this.processMap_["getRowOrBefore"] = new Hbase.Processor.ProcessFunction(this.getRowOrBefore_Process);
                this.processMap_["getRegionInfo"] = new Hbase.Processor.ProcessFunction(this.getRegionInfo_Process);
                this.processMap_["append"] = new Hbase.Processor.ProcessFunction(this.append_Process);
                this.processMap_["checkAndPut"] = new Hbase.Processor.ProcessFunction(this.checkAndPut_Process);
            }

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage tmessage = iprot.ReadMessageBegin();
                    Hbase.Processor.ProcessFunction processFunction;
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

            public void enableTable_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.enableTable_args enableTableArgs = new Hbase.enableTable_args();
                enableTableArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.enableTable_result enableTableResult = new Hbase.enableTable_result();
                try
                {
                    this.iface_.enableTable(enableTableArgs.TableName);
                }
                catch (IOError ex)
                {
                    enableTableResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("enableTable", TMessageType.Reply, seqid));
                enableTableResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void disableTable_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.disableTable_args disableTableArgs = new Hbase.disableTable_args();
                disableTableArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.disableTable_result disableTableResult = new Hbase.disableTable_result();
                try
                {
                    this.iface_.disableTable(disableTableArgs.TableName);
                }
                catch (IOError ex)
                {
                    disableTableResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("disableTable", TMessageType.Reply, seqid));
                disableTableResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void isTableEnabled_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.isTableEnabled_args tableEnabledArgs = new Hbase.isTableEnabled_args();
                tableEnabledArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.isTableEnabled_result tableEnabledResult = new Hbase.isTableEnabled_result();
                try
                {
                    tableEnabledResult.Success = this.iface_.isTableEnabled(tableEnabledArgs.TableName);
                }
                catch (IOError ex)
                {
                    tableEnabledResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("isTableEnabled", TMessageType.Reply, seqid));
                tableEnabledResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void compact_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.compact_args compactArgs = new Hbase.compact_args();
                compactArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.compact_result compactResult = new Hbase.compact_result();
                try
                {
                    this.iface_.compact(compactArgs.TableNameOrRegionName);
                }
                catch (IOError ex)
                {
                    compactResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("compact", TMessageType.Reply, seqid));
                compactResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void majorCompact_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.majorCompact_args majorCompactArgs = new Hbase.majorCompact_args();
                majorCompactArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.majorCompact_result majorCompactResult = new Hbase.majorCompact_result();
                try
                {
                    this.iface_.majorCompact(majorCompactArgs.TableNameOrRegionName);
                }
                catch (IOError ex)
                {
                    majorCompactResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("majorCompact", TMessageType.Reply, seqid));
                majorCompactResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getTableNames_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                new Hbase.getTableNames_args().Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getTableNames_result tableNamesResult = new Hbase.getTableNames_result();
                try
                {
                    tableNamesResult.Success = this.iface_.getTableNames();
                }
                catch (IOError ex)
                {
                    tableNamesResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getTableNames", TMessageType.Reply, seqid));
                tableNamesResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getColumnDescriptors_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getColumnDescriptors_args columnDescriptorsArgs = new Hbase.getColumnDescriptors_args();
                columnDescriptorsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getColumnDescriptors_result descriptorsResult = new Hbase.getColumnDescriptors_result();
                try
                {
                    descriptorsResult.Success = this.iface_.getColumnDescriptors(columnDescriptorsArgs.TableName);
                }
                catch (IOError ex)
                {
                    descriptorsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getColumnDescriptors", TMessageType.Reply, seqid));
                descriptorsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getTableRegions_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getTableRegions_args tableRegionsArgs = new Hbase.getTableRegions_args();
                tableRegionsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getTableRegions_result tableRegionsResult = new Hbase.getTableRegions_result();
                try
                {
                    tableRegionsResult.Success = this.iface_.getTableRegions(tableRegionsArgs.TableName);
                }
                catch (IOError ex)
                {
                    tableRegionsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getTableRegions", TMessageType.Reply, seqid));
                tableRegionsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void createTable_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.createTable_args createTableArgs = new Hbase.createTable_args();
                createTableArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.createTable_result createTableResult = new Hbase.createTable_result();
                try
                {
                    this.iface_.createTable(createTableArgs.TableName, createTableArgs.ColumnFamilies);
                }
                catch (IOError ex)
                {
                    createTableResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    createTableResult.Ia = ex;
                }
                catch (AlreadyExists ex)
                {
                    createTableResult.Exist = ex;
                }
                oprot.WriteMessageBegin(new TMessage("createTable", TMessageType.Reply, seqid));
                createTableResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void deleteTable_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.deleteTable_args deleteTableArgs = new Hbase.deleteTable_args();
                deleteTableArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.deleteTable_result deleteTableResult = new Hbase.deleteTable_result();
                try
                {
                    this.iface_.deleteTable(deleteTableArgs.TableName);
                }
                catch (IOError ex)
                {
                    deleteTableResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("deleteTable", TMessageType.Reply, seqid));
                deleteTableResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void get_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.get_args getArgs = new Hbase.get_args();
                getArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.get_result getResult = new Hbase.get_result();
                try
                {
                    getResult.Success = this.iface_.get(getArgs.TableName, getArgs.Row, getArgs.Column, getArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("get", TMessageType.Reply, seqid));
                getResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getVer_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getVer_args getVerArgs = new Hbase.getVer_args();
                getVerArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getVer_result getVerResult = new Hbase.getVer_result();
                try
                {
                    getVerResult.Success = this.iface_.getVer(getVerArgs.TableName, getVerArgs.Row, getVerArgs.Column, getVerArgs.NumVersions, getVerArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getVerResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getVer", TMessageType.Reply, seqid));
                getVerResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getVerTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getVerTs_args getVerTsArgs = new Hbase.getVerTs_args();
                getVerTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getVerTs_result getVerTsResult = new Hbase.getVerTs_result();
                try
                {
                    getVerTsResult.Success = this.iface_.getVerTs(getVerTsArgs.TableName, getVerTsArgs.Row, getVerTsArgs.Column, getVerTsArgs.Timestamp, getVerTsArgs.NumVersions, getVerTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getVerTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getVerTs", TMessageType.Reply, seqid));
                getVerTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRow_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRow_args getRowArgs = new Hbase.getRow_args();
                getRowArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRow_result getRowResult = new Hbase.getRow_result();
                try
                {
                    getRowResult.Success = this.iface_.getRow(getRowArgs.TableName, getRowArgs.Row, getRowArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getRowResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRow", TMessageType.Reply, seqid));
                getRowResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowWithColumns_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowWithColumns_args rowWithColumnsArgs = new Hbase.getRowWithColumns_args();
                rowWithColumnsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowWithColumns_result withColumnsResult = new Hbase.getRowWithColumns_result();
                try
                {
                    withColumnsResult.Success = this.iface_.getRowWithColumns(rowWithColumnsArgs.TableName, rowWithColumnsArgs.Row, rowWithColumnsArgs.Columns, rowWithColumnsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withColumnsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowWithColumns", TMessageType.Reply, seqid));
                withColumnsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowTs_args getRowTsArgs = new Hbase.getRowTs_args();
                getRowTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowTs_result getRowTsResult = new Hbase.getRowTs_result();
                try
                {
                    getRowTsResult.Success = this.iface_.getRowTs(getRowTsArgs.TableName, getRowTsArgs.Row, getRowTsArgs.Timestamp, getRowTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getRowTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowTs", TMessageType.Reply, seqid));
                getRowTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowWithColumnsTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowWithColumnsTs_args withColumnsTsArgs = new Hbase.getRowWithColumnsTs_args();
                withColumnsTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowWithColumnsTs_result withColumnsTsResult = new Hbase.getRowWithColumnsTs_result();
                try
                {
                    withColumnsTsResult.Success = this.iface_.getRowWithColumnsTs(withColumnsTsArgs.TableName, withColumnsTsArgs.Row, withColumnsTsArgs.Columns, withColumnsTsArgs.Timestamp, withColumnsTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withColumnsTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowWithColumnsTs", TMessageType.Reply, seqid));
                withColumnsTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRows_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRows_args getRowsArgs = new Hbase.getRows_args();
                getRowsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRows_result getRowsResult = new Hbase.getRows_result();
                try
                {
                    getRowsResult.Success = this.iface_.getRows(getRowsArgs.TableName, getRowsArgs.Rows, getRowsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getRowsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRows", TMessageType.Reply, seqid));
                getRowsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowsWithColumns_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowsWithColumns_args rowsWithColumnsArgs = new Hbase.getRowsWithColumns_args();
                rowsWithColumnsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowsWithColumns_result withColumnsResult = new Hbase.getRowsWithColumns_result();
                try
                {
                    withColumnsResult.Success = this.iface_.getRowsWithColumns(rowsWithColumnsArgs.TableName, rowsWithColumnsArgs.Rows, rowsWithColumnsArgs.Columns, rowsWithColumnsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withColumnsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowsWithColumns", TMessageType.Reply, seqid));
                withColumnsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowsTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowsTs_args getRowsTsArgs = new Hbase.getRowsTs_args();
                getRowsTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowsTs_result getRowsTsResult = new Hbase.getRowsTs_result();
                try
                {
                    getRowsTsResult.Success = this.iface_.getRowsTs(getRowsTsArgs.TableName, getRowsTsArgs.Rows, getRowsTsArgs.Timestamp, getRowsTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    getRowsTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowsTs", TMessageType.Reply, seqid));
                getRowsTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowsWithColumnsTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowsWithColumnsTs_args withColumnsTsArgs = new Hbase.getRowsWithColumnsTs_args();
                withColumnsTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowsWithColumnsTs_result withColumnsTsResult = new Hbase.getRowsWithColumnsTs_result();
                try
                {
                    withColumnsTsResult.Success = this.iface_.getRowsWithColumnsTs(withColumnsTsArgs.TableName, withColumnsTsArgs.Rows, withColumnsTsArgs.Columns, withColumnsTsArgs.Timestamp, withColumnsTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withColumnsTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowsWithColumnsTs", TMessageType.Reply, seqid));
                withColumnsTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void mutateRow_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.mutateRow_args mutateRowArgs = new Hbase.mutateRow_args();
                mutateRowArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.mutateRow_result mutateRowResult = new Hbase.mutateRow_result();
                try
                {
                    this.iface_.mutateRow(mutateRowArgs.TableName, mutateRowArgs.Row, mutateRowArgs.Mutations, mutateRowArgs.Attributes);
                }
                catch (IOError ex)
                {
                    mutateRowResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    mutateRowResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("mutateRow", TMessageType.Reply, seqid));
                mutateRowResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void mutateRowTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.mutateRowTs_args mutateRowTsArgs = new Hbase.mutateRowTs_args();
                mutateRowTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.mutateRowTs_result mutateRowTsResult = new Hbase.mutateRowTs_result();
                try
                {
                    this.iface_.mutateRowTs(mutateRowTsArgs.TableName, mutateRowTsArgs.Row, mutateRowTsArgs.Mutations, mutateRowTsArgs.Timestamp, mutateRowTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    mutateRowTsResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    mutateRowTsResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("mutateRowTs", TMessageType.Reply, seqid));
                mutateRowTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void mutateRows_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.mutateRows_args mutateRowsArgs = new Hbase.mutateRows_args();
                mutateRowsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.mutateRows_result mutateRowsResult = new Hbase.mutateRows_result();
                try
                {
                    this.iface_.mutateRows(mutateRowsArgs.TableName, mutateRowsArgs.RowBatches, mutateRowsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    mutateRowsResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    mutateRowsResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("mutateRows", TMessageType.Reply, seqid));
                mutateRowsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void mutateRowsTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.mutateRowsTs_args mutateRowsTsArgs = new Hbase.mutateRowsTs_args();
                mutateRowsTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.mutateRowsTs_result mutateRowsTsResult = new Hbase.mutateRowsTs_result();
                try
                {
                    this.iface_.mutateRowsTs(mutateRowsTsArgs.TableName, mutateRowsTsArgs.RowBatches, mutateRowsTsArgs.Timestamp, mutateRowsTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    mutateRowsTsResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    mutateRowsTsResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("mutateRowsTs", TMessageType.Reply, seqid));
                mutateRowsTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void atomicIncrement_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.atomicIncrement_args atomicIncrementArgs = new Hbase.atomicIncrement_args();
                atomicIncrementArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.atomicIncrement_result atomicIncrementResult = new Hbase.atomicIncrement_result();
                try
                {
                    atomicIncrementResult.Success = this.iface_.atomicIncrement(atomicIncrementArgs.TableName, atomicIncrementArgs.Row, atomicIncrementArgs.Column, atomicIncrementArgs.Value);
                }
                catch (IOError ex)
                {
                    atomicIncrementResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    atomicIncrementResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("atomicIncrement", TMessageType.Reply, seqid));
                atomicIncrementResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void deleteAll_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.deleteAll_args deleteAllArgs = new Hbase.deleteAll_args();
                deleteAllArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.deleteAll_result deleteAllResult = new Hbase.deleteAll_result();
                try
                {
                    this.iface_.deleteAll(deleteAllArgs.TableName, deleteAllArgs.Row, deleteAllArgs.Column, deleteAllArgs.Attributes);
                }
                catch (IOError ex)
                {
                    deleteAllResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("deleteAll", TMessageType.Reply, seqid));
                deleteAllResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void deleteAllTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.deleteAllTs_args deleteAllTsArgs = new Hbase.deleteAllTs_args();
                deleteAllTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.deleteAllTs_result deleteAllTsResult = new Hbase.deleteAllTs_result();
                try
                {
                    this.iface_.deleteAllTs(deleteAllTsArgs.TableName, deleteAllTsArgs.Row, deleteAllTsArgs.Column, deleteAllTsArgs.Timestamp, deleteAllTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    deleteAllTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("deleteAllTs", TMessageType.Reply, seqid));
                deleteAllTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void deleteAllRow_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.deleteAllRow_args deleteAllRowArgs = new Hbase.deleteAllRow_args();
                deleteAllRowArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.deleteAllRow_result deleteAllRowResult = new Hbase.deleteAllRow_result();
                try
                {
                    this.iface_.deleteAllRow(deleteAllRowArgs.TableName, deleteAllRowArgs.Row, deleteAllRowArgs.Attributes);
                }
                catch (IOError ex)
                {
                    deleteAllRowResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("deleteAllRow", TMessageType.Reply, seqid));
                deleteAllRowResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void increment_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.increment_args incrementArgs = new Hbase.increment_args();
                incrementArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.increment_result incrementResult = new Hbase.increment_result();
                try
                {
                    this.iface_.increment(incrementArgs.Increment);
                }
                catch (IOError ex)
                {
                    incrementResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("increment", TMessageType.Reply, seqid));
                incrementResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void incrementRows_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.incrementRows_args incrementRowsArgs = new Hbase.incrementRows_args();
                incrementRowsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.incrementRows_result incrementRowsResult = new Hbase.incrementRows_result();
                try
                {
                    this.iface_.incrementRows(incrementRowsArgs.Increments);
                }
                catch (IOError ex)
                {
                    incrementRowsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("incrementRows", TMessageType.Reply, seqid));
                incrementRowsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void deleteAllRowTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.deleteAllRowTs_args deleteAllRowTsArgs = new Hbase.deleteAllRowTs_args();
                deleteAllRowTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.deleteAllRowTs_result deleteAllRowTsResult = new Hbase.deleteAllRowTs_result();
                try
                {
                    this.iface_.deleteAllRowTs(deleteAllRowTsArgs.TableName, deleteAllRowTsArgs.Row, deleteAllRowTsArgs.Timestamp, deleteAllRowTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    deleteAllRowTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("deleteAllRowTs", TMessageType.Reply, seqid));
                deleteAllRowTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpenWithScan_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpenWithScan_args openWithScanArgs = new Hbase.scannerOpenWithScan_args();
                openWithScanArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpenWithScan_result openWithScanResult = new Hbase.scannerOpenWithScan_result();
                try
                {
                    openWithScanResult.Success = this.iface_.scannerOpenWithScan(openWithScanArgs.TableName, openWithScanArgs.Scan, openWithScanArgs.Attributes);
                }
                catch (IOError ex)
                {
                    openWithScanResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpenWithScan", TMessageType.Reply, seqid));
                openWithScanResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpen_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpen_args scannerOpenArgs = new Hbase.scannerOpen_args();
                scannerOpenArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpen_result scannerOpenResult = new Hbase.scannerOpen_result();
                try
                {
                    scannerOpenResult.Success = this.iface_.scannerOpen(scannerOpenArgs.TableName, scannerOpenArgs.StartRow, scannerOpenArgs.Columns, scannerOpenArgs.Attributes);
                }
                catch (IOError ex)
                {
                    scannerOpenResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpen", TMessageType.Reply, seqid));
                scannerOpenResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpenWithStop_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpenWithStop_args openWithStopArgs = new Hbase.scannerOpenWithStop_args();
                openWithStopArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpenWithStop_result openWithStopResult = new Hbase.scannerOpenWithStop_result();
                try
                {
                    openWithStopResult.Success = this.iface_.scannerOpenWithStop(openWithStopArgs.TableName, openWithStopArgs.StartRow, openWithStopArgs.StopRow, openWithStopArgs.Columns, openWithStopArgs.Attributes);
                }
                catch (IOError ex)
                {
                    openWithStopResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpenWithStop", TMessageType.Reply, seqid));
                openWithStopResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpenWithPrefix_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpenWithPrefix_args openWithPrefixArgs = new Hbase.scannerOpenWithPrefix_args();
                openWithPrefixArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpenWithPrefix_result withPrefixResult = new Hbase.scannerOpenWithPrefix_result();
                try
                {
                    withPrefixResult.Success = this.iface_.scannerOpenWithPrefix(openWithPrefixArgs.TableName, openWithPrefixArgs.StartAndPrefix, openWithPrefixArgs.Columns, openWithPrefixArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withPrefixResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpenWithPrefix", TMessageType.Reply, seqid));
                withPrefixResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpenTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpenTs_args scannerOpenTsArgs = new Hbase.scannerOpenTs_args();
                scannerOpenTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpenTs_result scannerOpenTsResult = new Hbase.scannerOpenTs_result();
                try
                {
                    scannerOpenTsResult.Success = this.iface_.scannerOpenTs(scannerOpenTsArgs.TableName, scannerOpenTsArgs.StartRow, scannerOpenTsArgs.Columns, scannerOpenTsArgs.Timestamp, scannerOpenTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    scannerOpenTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpenTs", TMessageType.Reply, seqid));
                scannerOpenTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerOpenWithStopTs_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerOpenWithStopTs_args openWithStopTsArgs = new Hbase.scannerOpenWithStopTs_args();
                openWithStopTsArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerOpenWithStopTs_result withStopTsResult = new Hbase.scannerOpenWithStopTs_result();
                try
                {
                    withStopTsResult.Success = this.iface_.scannerOpenWithStopTs(openWithStopTsArgs.TableName, openWithStopTsArgs.StartRow, openWithStopTsArgs.StopRow, openWithStopTsArgs.Columns, openWithStopTsArgs.Timestamp, openWithStopTsArgs.Attributes);
                }
                catch (IOError ex)
                {
                    withStopTsResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerOpenWithStopTs", TMessageType.Reply, seqid));
                withStopTsResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerGet_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerGet_args scannerGetArgs = new Hbase.scannerGet_args();
                scannerGetArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerGet_result scannerGetResult = new Hbase.scannerGet_result();
                try
                {
                    scannerGetResult.Success = this.iface_.scannerGet(scannerGetArgs.Id);
                }
                catch (IOError ex)
                {
                    scannerGetResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    scannerGetResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerGet", TMessageType.Reply, seqid));
                scannerGetResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerGetList_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerGetList_args scannerGetListArgs = new Hbase.scannerGetList_args();
                scannerGetListArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerGetList_result scannerGetListResult = new Hbase.scannerGetList_result();
                try
                {
                    scannerGetListResult.Success = this.iface_.scannerGetList(scannerGetListArgs.Id, scannerGetListArgs.NbRows);
                }
                catch (IOError ex)
                {
                    scannerGetListResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    scannerGetListResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerGetList", TMessageType.Reply, seqid));
                scannerGetListResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void scannerClose_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.scannerClose_args scannerCloseArgs = new Hbase.scannerClose_args();
                scannerCloseArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.scannerClose_result scannerCloseResult = new Hbase.scannerClose_result();
                try
                {
                    this.iface_.scannerClose(scannerCloseArgs.Id);
                }
                catch (IOError ex)
                {
                    scannerCloseResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    scannerCloseResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("scannerClose", TMessageType.Reply, seqid));
                scannerCloseResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRowOrBefore_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRowOrBefore_args getRowOrBeforeArgs = new Hbase.getRowOrBefore_args();
                getRowOrBeforeArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRowOrBefore_result rowOrBeforeResult = new Hbase.getRowOrBefore_result();
                try
                {
                    rowOrBeforeResult.Success = this.iface_.getRowOrBefore(getRowOrBeforeArgs.TableName, getRowOrBeforeArgs.Row, getRowOrBeforeArgs.Family);
                }
                catch (IOError ex)
                {
                    rowOrBeforeResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRowOrBefore", TMessageType.Reply, seqid));
                rowOrBeforeResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void getRegionInfo_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.getRegionInfo_args getRegionInfoArgs = new Hbase.getRegionInfo_args();
                getRegionInfoArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.getRegionInfo_result regionInfoResult = new Hbase.getRegionInfo_result();
                try
                {
                    regionInfoResult.Success = this.iface_.getRegionInfo(getRegionInfoArgs.Row);
                }
                catch (IOError ex)
                {
                    regionInfoResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("getRegionInfo", TMessageType.Reply, seqid));
                regionInfoResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void append_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.append_args appendArgs = new Hbase.append_args();
                appendArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.append_result appendResult = new Hbase.append_result();
                try
                {
                    appendResult.Success = this.iface_.append(appendArgs.Append);
                }
                catch (IOError ex)
                {
                    appendResult.Io = ex;
                }
                oprot.WriteMessageBegin(new TMessage("append", TMessageType.Reply, seqid));
                appendResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void checkAndPut_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Hbase.checkAndPut_args checkAndPutArgs = new Hbase.checkAndPut_args();
                checkAndPutArgs.Read(iprot);
                iprot.ReadMessageEnd();
                Hbase.checkAndPut_result checkAndPutResult = new Hbase.checkAndPut_result();
                try
                {
                    checkAndPutResult.Success = this.iface_.checkAndPut(checkAndPutArgs.TableName, checkAndPutArgs.Row, checkAndPutArgs.Column, checkAndPutArgs.Value, checkAndPutArgs.Mput, checkAndPutArgs.Attributes);
                }
                catch (IOError ex)
                {
                    checkAndPutResult.Io = ex;
                }
                catch (IllegalArgument ex)
                {
                    checkAndPutResult.Ia = ex;
                }
                oprot.WriteMessageBegin(new TMessage("checkAndPut", TMessageType.Reply, seqid));
                checkAndPutResult.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
        }

        [Serializable]
        public class enableTable_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.enableTable_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (enableTable_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("enableTable_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class enableTable_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.enableTable_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (enableTable_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("enableTable_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class disableTable_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.disableTable_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (disableTable_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("disableTable_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class disableTable_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.disableTable_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (disableTable_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("disableTable_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class isTableEnabled_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.isTableEnabled_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (isTableEnabled_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("isTableEnabled_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class isTableEnabled_result : TBase, TAbstractBase
        {
            private bool _success;
            private IOError _io;
            public Hbase.isTableEnabled_result.Isset __isset;

            public bool Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.Bool)
                                    {
                                        this.Success = iprot.ReadBool();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (isTableEnabled_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.Bool;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBool(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("isTableEnabled_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class compact_args : TBase, TAbstractBase
        {
            private byte[] _tableNameOrRegionName;
            public Hbase.compact_args.Isset __isset;

            public byte[] TableNameOrRegionName
            {
                get
                {
                    return this._tableNameOrRegionName;
                }
                set
                {
                    this.__isset.tableNameOrRegionName = true;
                    this._tableNameOrRegionName = value;
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
                                    this.TableNameOrRegionName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (compact_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableNameOrRegionName != null && this.__isset.tableNameOrRegionName)
                    {
                        field.Name = "tableNameOrRegionName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableNameOrRegionName);
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
                StringBuilder stringBuilder = new StringBuilder("compact_args(");
                bool flag = true;
                if (this.TableNameOrRegionName != null && this.__isset.tableNameOrRegionName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableNameOrRegionName: ");
                    stringBuilder.Append((object) this.TableNameOrRegionName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableNameOrRegionName;
            }
        }

        [Serializable]
        public class compact_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.compact_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (compact_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("compact_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class majorCompact_args : TBase, TAbstractBase
        {
            private byte[] _tableNameOrRegionName;
            public Hbase.majorCompact_args.Isset __isset;

            public byte[] TableNameOrRegionName
            {
                get
                {
                    return this._tableNameOrRegionName;
                }
                set
                {
                    this.__isset.tableNameOrRegionName = true;
                    this._tableNameOrRegionName = value;
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
                                    this.TableNameOrRegionName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (majorCompact_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableNameOrRegionName != null && this.__isset.tableNameOrRegionName)
                    {
                        field.Name = "tableNameOrRegionName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableNameOrRegionName);
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
                StringBuilder stringBuilder = new StringBuilder("majorCompact_args(");
                bool flag = true;
                if (this.TableNameOrRegionName != null && this.__isset.tableNameOrRegionName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableNameOrRegionName: ");
                    stringBuilder.Append((object) this.TableNameOrRegionName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableNameOrRegionName;
            }
        }

        [Serializable]
        public class majorCompact_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.majorCompact_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (majorCompact_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("majorCompact_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class getTableNames_args : TBase, TAbstractBase
        {
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
                            int id = (int) tfield.ID;
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
                    TStruct struc = new TStruct(nameof (getTableNames_args));
                    oprot.WriteStructBegin(struc);
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
                StringBuilder stringBuilder = new StringBuilder("getTableNames_args(");
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }
        }

        [Serializable]
        public class getTableNames_result : TBase, TAbstractBase
        {
            private List<byte[]> _success;
            private IOError _io;
            public Hbase.getTableNames_result.Isset __isset;

            public List<byte[]> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Success.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getTableNames_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.String, this.Success.Count));
                            foreach (byte[] b in this.Success)
                                oprot.WriteBinary(b);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getTableNames_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getColumnDescriptors_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.getColumnDescriptors_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (getColumnDescriptors_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("getColumnDescriptors_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class getColumnDescriptors_result : TBase, TAbstractBase
        {
            private Dictionary<byte[], ColumnDescriptor> _success;
            private IOError _io;
            public Hbase.getColumnDescriptors_result.Isset __isset;

            public Dictionary<byte[], ColumnDescriptor> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Success = new Dictionary<byte[], ColumnDescriptor>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index1 = 0; index1 < tmap.Count; ++index1)
                                        {
                                            byte[] index2 = iprot.ReadBinary();
                                            ColumnDescriptor columnDescriptor = new ColumnDescriptor();
                                            columnDescriptor.Read(iprot);
                                            this.Success[index2] = columnDescriptor;
                                        }
                                        iprot.ReadMapEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getColumnDescriptors_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.Map;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteMapBegin(new TMap(TType.String, TType.Struct, this.Success.Count));
                            foreach (byte[] key in this.Success.Keys)
                            {
                                oprot.WriteBinary(key);
                                this.Success[key].Write(oprot);
                            }
                            oprot.WriteMapEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getColumnDescriptors_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getTableRegions_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.getTableRegions_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (getTableRegions_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("getTableRegions_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class getTableRegions_result : TBase, TAbstractBase
        {
            private List<TRegionInfo> _success;
            private IOError _io;
            public Hbase.getTableRegions_result.Isset __isset;

            public List<TRegionInfo> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRegionInfo>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRegionInfo tregionInfo = new TRegionInfo();
                                            tregionInfo.Read(iprot);
                                            this.Success.Add(tregionInfo);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getTableRegions_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRegionInfo tregionInfo in this.Success)
                                tregionInfo.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getTableRegions_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class createTable_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<ColumnDescriptor> _columnFamilies;
            public Hbase.createTable_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<ColumnDescriptor> ColumnFamilies
            {
                get
                {
                    return this._columnFamilies;
                }
                set
                {
                    this.__isset.columnFamilies = true;
                    this._columnFamilies = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.ColumnFamilies = new List<ColumnDescriptor>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            ColumnDescriptor columnDescriptor = new ColumnDescriptor();
                                            columnDescriptor.Read(iprot);
                                            this.ColumnFamilies.Add(columnDescriptor);
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
                    TStruct struc = new TStruct(nameof (createTable_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.ColumnFamilies != null && this.__isset.columnFamilies)
                    {
                        field.Name = "columnFamilies";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.ColumnFamilies.Count));
                        foreach (ColumnDescriptor columnFamily in this.ColumnFamilies)
                            columnFamily.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("createTable_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.ColumnFamilies != null && this.__isset.columnFamilies)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("ColumnFamilies: ");
                    stringBuilder.Append((object) this.ColumnFamilies);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool columnFamilies;
            }
        }

        [Serializable]
        public class createTable_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            private AlreadyExists _exist;
            public Hbase.createTable_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
                }
            }

            public AlreadyExists Exist
            {
                get
                {
                    return this._exist;
                }
                set
                {
                    this.__isset.exist = true;
                    this._exist = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Exist = new AlreadyExists();
                                        this.Exist.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (createTable_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia)
                    {
                        if (this.Ia != null)
                        {
                            field.Name = "Ia";
                            field.Type = TType.Struct;
                            field.ID = (short) 2;
                            oprot.WriteFieldBegin(field);
                            this.Ia.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.exist && this.Exist != null)
                    {
                        field.Name = "Exist";
                        field.Type = TType.Struct;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        this.Exist.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("createTable_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                if (this.Exist != null && this.__isset.exist)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Exist: ");
                    stringBuilder.Append(this.Exist == null ? "<null>" : this.Exist.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
                public bool exist;
            }
        }

        [Serializable]
        public class deleteTable_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            public Hbase.deleteTable_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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
                                    this.TableName = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (deleteTable_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                StringBuilder stringBuilder = new StringBuilder("deleteTable_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
            }
        }

        [Serializable]
        public class deleteTable_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.deleteTable_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (deleteTable_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("deleteTable_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class get_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.get_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (get_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("get_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool attributes;
            }
        }

        [Serializable]
        public class get_result : TBase, TAbstractBase
        {
            private List<TCell> _success;
            private IOError _io;
            public Hbase.get_result.Isset __isset;

            public List<TCell> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TCell>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TCell tcell = new TCell();
                                            tcell.Read(iprot);
                                            this.Success.Add(tcell);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (get_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TCell tcell in this.Success)
                                tcell.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("get_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getVer_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private int _numVersions;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getVer_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public int NumVersions
            {
                get
                {
                    return this._numVersions;
                }
                set
                {
                    this.__isset.numVersions = true;
                    this._numVersions = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.NumVersions = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getVer_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.numVersions)
                    {
                        field.Name = "numVersions";
                        field.Type = TType.I32;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.NumVersions);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getVer_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.__isset.numVersions)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("NumVersions: ");
                    stringBuilder.Append(this.NumVersions);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool numVersions;
                public bool attributes;
            }
        }

        [Serializable]
        public class getVer_result : TBase, TAbstractBase
        {
            private List<TCell> _success;
            private IOError _io;
            public Hbase.getVer_result.Isset __isset;

            public List<TCell> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TCell>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TCell tcell = new TCell();
                                            tcell.Read(iprot);
                                            this.Success.Add(tcell);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getVer_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TCell tcell in this.Success)
                                tcell.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getVer_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getVerTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private long _timestamp;
            private int _numVersions;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getVerTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public int NumVersions
            {
                get
                {
                    return this._numVersions;
                }
                set
                {
                    this.__isset.numVersions = true;
                    this._numVersions = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.NumVersions = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 6:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getVerTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.numVersions)
                    {
                        field.Name = "numVersions";
                        field.Type = TType.I32;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.NumVersions);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 6;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getVerTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.__isset.numVersions)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("NumVersions: ");
                    stringBuilder.Append(this.NumVersions);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool timestamp;
                public bool numVersions;
                public bool attributes;
            }
        }

        [Serializable]
        public class getVerTs_result : TBase, TAbstractBase
        {
            private List<TCell> _success;
            private IOError _io;
            public Hbase.getVerTs_result.Isset __isset;

            public List<TCell> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TCell>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TCell tcell = new TCell();
                                            tcell.Read(iprot);
                                            this.Success.Add(tcell);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getVerTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TCell tcell in this.Success)
                                tcell.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getVerTs_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRow_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRow_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRow_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRow_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRow_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRow_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRow_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRow_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowWithColumns_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private List<byte[]> _columns;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowWithColumns_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowWithColumns_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowWithColumns_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool columns;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowWithColumns_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowWithColumns_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowWithColumns_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowWithColumns_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowTs_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowTs_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowTs_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowWithColumnsTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private List<byte[]> _columns;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowWithColumnsTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowWithColumnsTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowWithColumnsTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool columns;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowWithColumnsTs_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowWithColumnsTs_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowWithColumnsTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowWithColumnsTs_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRows_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<byte[]> _rows;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRows_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<byte[]> Rows
            {
                get
                {
                    return this._rows;
                }
                set
                {
                    this.__isset.rows = true;
                    this._rows = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Rows = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Rows.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRows_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Rows != null && this.__isset.rows)
                    {
                        field.Name = "rows";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Rows.Count));
                        foreach (byte[] row in this.Rows)
                            oprot.WriteBinary(row);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRows_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Rows != null && this.__isset.rows)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Rows: ");
                    stringBuilder.Append((object) this.Rows);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rows;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRows_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRows_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRows_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRows_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowsWithColumns_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<byte[]> _rows;
            private List<byte[]> _columns;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowsWithColumns_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<byte[]> Rows
            {
                get
                {
                    return this._rows;
                }
                set
                {
                    this.__isset.rows = true;
                    this._rows = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Rows = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Rows.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowsWithColumns_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Rows != null && this.__isset.rows)
                    {
                        field.Name = "rows";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Rows.Count));
                        foreach (byte[] row in this.Rows)
                            oprot.WriteBinary(row);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowsWithColumns_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Rows != null && this.__isset.rows)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Rows: ");
                    stringBuilder.Append((object) this.Rows);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rows;
                public bool columns;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowsWithColumns_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowsWithColumns_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowsWithColumns_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowsWithColumns_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowsTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<byte[]> _rows;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowsTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<byte[]> Rows
            {
                get
                {
                    return this._rows;
                }
                set
                {
                    this.__isset.rows = true;
                    this._rows = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Rows = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Rows.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowsTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Rows != null && this.__isset.rows)
                    {
                        field.Name = "rows";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Rows.Count));
                        foreach (byte[] row in this.Rows)
                            oprot.WriteBinary(row);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowsTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Rows != null && this.__isset.rows)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Rows: ");
                    stringBuilder.Append((object) this.Rows);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rows;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowsTs_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowsTs_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowsTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowsTs_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRowsWithColumnsTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<byte[]> _rows;
            private List<byte[]> _columns;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.getRowsWithColumnsTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<byte[]> Rows
            {
                get
                {
                    return this._rows;
                }
                set
                {
                    this.__isset.rows = true;
                    this._rows = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Rows = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Rows.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (getRowsWithColumnsTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Rows != null && this.__isset.rows)
                    {
                        field.Name = "rows";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Rows.Count));
                        foreach (byte[] row in this.Rows)
                            oprot.WriteBinary(row);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("getRowsWithColumnsTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Rows != null && this.__isset.rows)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Rows: ");
                    stringBuilder.Append((object) this.Rows);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rows;
                public bool columns;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class getRowsWithColumnsTs_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            public Hbase.getRowsWithColumnsTs_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowsWithColumnsTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowsWithColumnsTs_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class mutateRow_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private List<Mutation> _mutations;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.mutateRow_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (mutateRow_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Mutations != null && this.__isset.mutations)
                    {
                        field.Name = "mutations";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.Mutations.Count));
                        foreach (Mutation mutation in this.Mutations)
                            mutation.Write(oprot);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("mutateRow_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
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
                    flag = false;
                    stringBuilder.Append("Mutations: ");
                    stringBuilder.Append((object) this.Mutations);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool mutations;
                public bool attributes;
            }
        }

        [Serializable]
        public class mutateRow_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.mutateRow_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (mutateRow_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("mutateRow_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class mutateRowTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private List<Mutation> _mutations;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.mutateRowTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                case 4:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (mutateRowTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Mutations != null && this.__isset.mutations)
                    {
                        field.Name = "mutations";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.Mutations.Count));
                        foreach (Mutation mutation in this.Mutations)
                            mutation.Write(oprot);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("mutateRowTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
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
                    flag = false;
                    stringBuilder.Append("Mutations: ");
                    stringBuilder.Append((object) this.Mutations);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool mutations;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class mutateRowTs_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.mutateRowTs_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (mutateRowTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("mutateRowTs_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class mutateRows_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<BatchMutation> _rowBatches;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.mutateRows_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<BatchMutation> RowBatches
            {
                get
                {
                    return this._rowBatches;
                }
                set
                {
                    this.__isset.rowBatches = true;
                    this._rowBatches = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.RowBatches = new List<BatchMutation>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            BatchMutation batchMutation = new BatchMutation();
                                            batchMutation.Read(iprot);
                                            this.RowBatches.Add(batchMutation);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (mutateRows_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.RowBatches != null && this.__isset.rowBatches)
                    {
                        field.Name = "rowBatches";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.RowBatches.Count));
                        foreach (BatchMutation rowBatch in this.RowBatches)
                            rowBatch.Write(oprot);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("mutateRows_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.RowBatches != null && this.__isset.rowBatches)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("RowBatches: ");
                    stringBuilder.Append((object) this.RowBatches);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rowBatches;
                public bool attributes;
            }
        }

        [Serializable]
        public class mutateRows_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.mutateRows_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (mutateRows_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("mutateRows_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class mutateRowsTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private List<BatchMutation> _rowBatches;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.mutateRowsTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public List<BatchMutation> RowBatches
            {
                get
                {
                    return this._rowBatches;
                }
                set
                {
                    this.__isset.rowBatches = true;
                    this._rowBatches = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.RowBatches = new List<BatchMutation>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            BatchMutation batchMutation = new BatchMutation();
                                            batchMutation.Read(iprot);
                                            this.RowBatches.Add(batchMutation);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (mutateRowsTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.RowBatches != null && this.__isset.rowBatches)
                    {
                        field.Name = "rowBatches";
                        field.Type = TType.List;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.RowBatches.Count));
                        foreach (BatchMutation rowBatch in this.RowBatches)
                            rowBatch.Write(oprot);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("mutateRowsTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.RowBatches != null && this.__isset.rowBatches)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("RowBatches: ");
                    stringBuilder.Append((object) this.RowBatches);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool rowBatches;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class mutateRowsTs_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.mutateRowsTs_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (mutateRowsTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("mutateRowsTs_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class atomicIncrement_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private long _value;
            public Hbase.atomicIncrement_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public long Value
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
                                    if (tfield.Type == TType.String)
                                    {
                                        this.TableName = iprot.ReadBinary();
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
                                        this.Value = iprot.ReadI64();
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
                    TStruct struc = new TStruct(nameof (atomicIncrement_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.value)
                    {
                        field.Name = "value";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Value);
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
                StringBuilder stringBuilder = new StringBuilder("atomicIncrement_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.__isset.value)
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
                public bool tableName;
                public bool row;
                public bool column;
                public bool value;
            }
        }

        [Serializable]
        public class atomicIncrement_result : TBase, TAbstractBase
        {
            private long _success;
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.atomicIncrement_result.Isset __isset;

            public long Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                case 0:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Success = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (atomicIncrement_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I64;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("atomicIncrement_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class deleteAll_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.deleteAll_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (deleteAll_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("deleteAll_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool attributes;
            }
        }

        [Serializable]
        public class deleteAll_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.deleteAll_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (deleteAll_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("deleteAll_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class deleteAllTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.deleteAllTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (deleteAllTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class deleteAllTs_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.deleteAllTs_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (deleteAllTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllTs_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class deleteAllRow_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.deleteAllRow_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (deleteAllRow_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllRow_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool attributes;
            }
        }

        [Serializable]
        public class deleteAllRow_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.deleteAllRow_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (deleteAllRow_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllRow_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class increment_args : TBase, TAbstractBase
        {
            private TIncrement _increment;
            public Hbase.increment_args.Isset __isset;

            public TIncrement Increment
            {
                get
                {
                    return this._increment;
                }
                set
                {
                    this.__isset.increment = true;
                    this._increment = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Increment = new TIncrement();
                                    this.Increment.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (increment_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.Increment != null && this.__isset.increment)
                    {
                        field.Name = "increment";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Increment.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("increment_args(");
                bool flag = true;
                if (this.Increment != null && this.__isset.increment)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Increment: ");
                    stringBuilder.Append(this.Increment == null ? "<null>" : this.Increment.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool increment;
            }
        }

        [Serializable]
        public class increment_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.increment_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (increment_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("increment_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class incrementRows_args : TBase, TAbstractBase
        {
            private List<TIncrement> _increments;
            public Hbase.incrementRows_args.Isset __isset;

            public List<TIncrement> Increments
            {
                get
                {
                    return this._increments;
                }
                set
                {
                    this.__isset.increments = true;
                    this._increments = value;
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
                                if (tfield.Type == TType.List)
                                {
                                    this.Increments = new List<TIncrement>();
                                    TList tlist = iprot.ReadListBegin();
                                    for (int index = 0; index < tlist.Count; ++index)
                                    {
                                        TIncrement tincrement = new TIncrement();
                                        tincrement.Read(iprot);
                                        this.Increments.Add(tincrement);
                                    }
                                    iprot.ReadListEnd();
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
                    TStruct struc = new TStruct(nameof (incrementRows_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.Increments != null && this.__isset.increments)
                    {
                        field.Name = "increments";
                        field.Type = TType.List;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.Struct, this.Increments.Count));
                        foreach (TIncrement increment in this.Increments)
                            increment.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("incrementRows_args(");
                bool flag = true;
                if (this.Increments != null && this.__isset.increments)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Increments: ");
                    stringBuilder.Append((object) this.Increments);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool increments;
            }
        }

        [Serializable]
        public class incrementRows_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.incrementRows_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (incrementRows_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("incrementRows_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class deleteAllRowTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.deleteAllRowTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (deleteAllRowTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllRowTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class deleteAllRowTs_result : TBase, TAbstractBase
        {
            private IOError _io;
            public Hbase.deleteAllRowTs_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Io = new IOError();
                                    this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (deleteAllRowTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("deleteAllRowTs_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpenWithScan_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private TScan _scan;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpenWithScan_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public TScan Scan
            {
                get
                {
                    return this._scan;
                }
                set
                {
                    this.__isset.scan = true;
                    this._scan = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Scan = new TScan();
                                        this.Scan.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithScan_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Scan != null && this.__isset.scan)
                    {
                        field.Name = "scan";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Scan.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithScan_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Scan != null && this.__isset.scan)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Scan: ");
                    stringBuilder.Append(this.Scan == null ? "<null>" : this.Scan.ToString());
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool scan;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpenWithScan_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpenWithScan_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithScan_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithScan_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpen_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _startRow;
            private List<byte[]> _columns;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpen_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public byte[] StartRow
            {
                get
                {
                    return this._startRow;
                }
                set
                {
                    this.__isset.startRow = true;
                    this._startRow = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StartRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpen_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StartRow != null && this.__isset.startRow)
                    {
                        field.Name = "startRow";
                        field.Type = TType.String;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StartRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpen_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.StartRow != null && this.__isset.startRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StartRow: ");
                    stringBuilder.Append((object) this.StartRow);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool startRow;
                public bool columns;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpen_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpen_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpen_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpen_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpenWithStop_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _startRow;
            private byte[] _stopRow;
            private List<byte[]> _columns;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpenWithStop_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public byte[] StartRow
            {
                get
                {
                    return this._startRow;
                }
                set
                {
                    this.__isset.startRow = true;
                    this._startRow = value;
                }
            }

            public byte[] StopRow
            {
                get
                {
                    return this._stopRow;
                }
                set
                {
                    this.__isset.stopRow = true;
                    this._stopRow = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StartRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StopRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithStop_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StartRow != null && this.__isset.startRow)
                    {
                        field.Name = "startRow";
                        field.Type = TType.String;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StartRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StopRow != null && this.__isset.stopRow)
                    {
                        field.Name = "stopRow";
                        field.Type = TType.String;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StopRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithStop_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.StartRow != null && this.__isset.startRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StartRow: ");
                    stringBuilder.Append((object) this.StartRow);
                }
                if (this.StopRow != null && this.__isset.stopRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StopRow: ");
                    stringBuilder.Append((object) this.StopRow);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool startRow;
                public bool stopRow;
                public bool columns;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpenWithStop_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpenWithStop_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithStop_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithStop_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpenWithPrefix_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _startAndPrefix;
            private List<byte[]> _columns;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpenWithPrefix_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public byte[] StartAndPrefix
            {
                get
                {
                    return this._startAndPrefix;
                }
                set
                {
                    this.__isset.startAndPrefix = true;
                    this._startAndPrefix = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StartAndPrefix = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithPrefix_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StartAndPrefix != null && this.__isset.startAndPrefix)
                    {
                        field.Name = "startAndPrefix";
                        field.Type = TType.String;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StartAndPrefix);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithPrefix_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.StartAndPrefix != null && this.__isset.startAndPrefix)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StartAndPrefix: ");
                    stringBuilder.Append((object) this.StartAndPrefix);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool startAndPrefix;
                public bool columns;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpenWithPrefix_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpenWithPrefix_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithPrefix_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithPrefix_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpenTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _startRow;
            private List<byte[]> _columns;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpenTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public byte[] StartRow
            {
                get
                {
                    return this._startRow;
                }
                set
                {
                    this.__isset.startRow = true;
                    this._startRow = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StartRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpenTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StartRow != null && this.__isset.startRow)
                    {
                        field.Name = "startRow";
                        field.Type = TType.String;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StartRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.StartRow != null && this.__isset.startRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StartRow: ");
                    stringBuilder.Append((object) this.StartRow);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool startRow;
                public bool columns;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpenTs_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpenTs_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpenTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenTs_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerOpenWithStopTs_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _startRow;
            private byte[] _stopRow;
            private List<byte[]> _columns;
            private long _timestamp;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.scannerOpenWithStopTs_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
                }
            }

            public byte[] StartRow
            {
                get
                {
                    return this._startRow;
                }
                set
                {
                    this.__isset.startRow = true;
                    this._startRow = value;
                }
            }

            public byte[] StopRow
            {
                get
                {
                    return this._stopRow;
                }
                set
                {
                    this.__isset.stopRow = true;
                    this._stopRow = value;
                }
            }

            public List<byte[]> Columns
            {
                get
                {
                    return this._columns;
                }
                set
                {
                    this.__isset.columns = true;
                    this._columns = value;
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

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StartRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 3:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.StopRow = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 4:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Columns = new List<byte[]>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                            this.Columns.Add(iprot.ReadBinary());
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 5:
                                    if (tfield.Type == TType.I64)
                                    {
                                        this.Timestamp = iprot.ReadI64();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 6:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithStopTs_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StartRow != null && this.__isset.startRow)
                    {
                        field.Name = "startRow";
                        field.Type = TType.String;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StartRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.StopRow != null && this.__isset.stopRow)
                    {
                        field.Name = "stopRow";
                        field.Type = TType.String;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.StopRow);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Columns != null && this.__isset.columns)
                    {
                        field.Name = "columns";
                        field.Type = TType.List;
                        field.ID = (short) 4;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteListBegin(new TList(TType.String, this.Columns.Count));
                        foreach (byte[] column in this.Columns)
                            oprot.WriteBinary(column);
                        oprot.WriteListEnd();
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.timestamp)
                    {
                        field.Name = "timestamp";
                        field.Type = TType.I64;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(this.Timestamp);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 6;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithStopTs_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.StartRow != null && this.__isset.startRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StartRow: ");
                    stringBuilder.Append((object) this.StartRow);
                }
                if (this.StopRow != null && this.__isset.stopRow)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("StopRow: ");
                    stringBuilder.Append((object) this.StopRow);
                }
                if (this.Columns != null && this.__isset.columns)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Columns: ");
                    stringBuilder.Append((object) this.Columns);
                }
                if (this.__isset.timestamp)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Timestamp: ");
                    stringBuilder.Append(this.Timestamp);
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool startRow;
                public bool stopRow;
                public bool columns;
                public bool timestamp;
                public bool attributes;
            }
        }

        [Serializable]
        public class scannerOpenWithStopTs_result : TBase, TAbstractBase
        {
            private int _success;
            private IOError _io;
            public Hbase.scannerOpenWithStopTs_result.Isset __isset;

            public int Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.Success = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerOpenWithStopTs_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.I32;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerOpenWithStopTs_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class scannerGet_args : TBase, TAbstractBase
        {
            private int _id;
            public Hbase.scannerGet_args.Isset __isset;

            public int Id
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
                                    this.Id = iprot.ReadI32();
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
                    TStruct struc = new TStruct(nameof (scannerGet_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.id)
                    {
                        field.Name = "id";
                        field.Type = TType.I32;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Id);
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
                StringBuilder stringBuilder = new StringBuilder("scannerGet_args(");
                bool flag = true;
                if (this.__isset.id)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Id: ");
                    stringBuilder.Append(this.Id);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool id;
            }
        }

        [Serializable]
        public class scannerGet_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.scannerGet_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerGet_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerGet_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class scannerGetList_args : TBase, TAbstractBase
        {
            private int _id;
            private int _nbRows;
            public Hbase.scannerGetList_args.Isset __isset;

            public int Id
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

            public int NbRows
            {
                get
                {
                    return this._nbRows;
                }
                set
                {
                    this.__isset.nbRows = true;
                    this._nbRows = value;
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
                                        this.Id = iprot.ReadI32();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.I32)
                                    {
                                        this.NbRows = iprot.ReadI32();
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
                    TStruct struc = new TStruct(nameof (scannerGetList_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.id)
                    {
                        field.Name = "id";
                        field.Type = TType.I32;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Id);
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.nbRows)
                    {
                        field.Name = "nbRows";
                        field.Type = TType.I32;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.NbRows);
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
                StringBuilder stringBuilder = new StringBuilder("scannerGetList_args(");
                bool flag = true;
                if (this.__isset.id)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Id: ");
                    stringBuilder.Append(this.Id);
                }
                if (this.__isset.nbRows)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("NbRows: ");
                    stringBuilder.Append(this.NbRows);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool id;
                public bool nbRows;
            }
        }

        [Serializable]
        public class scannerGetList_result : TBase, TAbstractBase
        {
            private List<TRowResult> _success;
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.scannerGetList_result.Isset __isset;

            public List<TRowResult> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TRowResult>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TRowResult trowResult = new TRowResult();
                                            trowResult.Read(iprot);
                                            this.Success.Add(trowResult);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerGetList_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TRowResult trowResult in this.Success)
                                trowResult.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerGetList_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class scannerClose_args : TBase, TAbstractBase
        {
            private int _id;
            public Hbase.scannerClose_args.Isset __isset;

            public int Id
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
                                    this.Id = iprot.ReadI32();
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
                    TStruct struc = new TStruct(nameof (scannerClose_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.id)
                    {
                        field.Name = "id";
                        field.Type = TType.I32;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Id);
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
                StringBuilder stringBuilder = new StringBuilder("scannerClose_args(");
                bool flag = true;
                if (this.__isset.id)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Id: ");
                    stringBuilder.Append(this.Id);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool id;
            }
        }

        [Serializable]
        public class scannerClose_result : TBase, TAbstractBase
        {
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.scannerClose_result.Isset __isset;

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (scannerClose_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("scannerClose_result(");
                bool flag = true;
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool io;
                public bool ia;
            }
        }

        [Serializable]
        public class getRowOrBefore_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _family;
            public Hbase.getRowOrBefore_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public byte[] Family
            {
                get
                {
                    return this._family;
                }
                set
                {
                    this.__isset.family = true;
                    this._family = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                        this.Family = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (getRowOrBefore_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Family != null && this.__isset.family)
                    {
                        field.Name = "family";
                        field.Type = TType.String;
                        field.ID = (short) 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.Family);
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
                StringBuilder stringBuilder = new StringBuilder("getRowOrBefore_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
                }
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                if (this.Family != null && this.__isset.family)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Family: ");
                    stringBuilder.Append((object) this.Family);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool family;
            }
        }

        [Serializable]
        public class getRowOrBefore_result : TBase, TAbstractBase
        {
            private List<TCell> _success;
            private IOError _io;
            public Hbase.getRowOrBefore_result.Isset __isset;

            public List<TCell> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TCell>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TCell tcell = new TCell();
                                            tcell.Read(iprot);
                                            this.Success.Add(tcell);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRowOrBefore_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TCell tcell in this.Success)
                                tcell.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRowOrBefore_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class getRegionInfo_args : TBase, TAbstractBase
        {
            private byte[] _row;
            public Hbase.getRegionInfo_args.Isset __isset;

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
                                    this.Row = iprot.ReadBinary();
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
                    TStruct struc = new TStruct(nameof (getRegionInfo_args));
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
                StringBuilder stringBuilder = new StringBuilder("getRegionInfo_args(");
                bool flag = true;
                if (this.Row != null && this.__isset.row)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Row: ");
                    stringBuilder.Append((object) this.Row);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool row;
            }
        }

        [Serializable]
        public class getRegionInfo_result : TBase, TAbstractBase
        {
            private TRegionInfo _success;
            private IOError _io;
            public Hbase.getRegionInfo_result.Isset __isset;

            public TRegionInfo Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Success = new TRegionInfo();
                                        this.Success.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (getRegionInfo_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.Struct;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            this.Success.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("getRegionInfo_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success == null ? "<null>" : this.Success.ToString());
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class append_args : TBase, TAbstractBase
        {
            private TAppend _append;
            public Hbase.append_args.Isset __isset;

            public TAppend Append
            {
                get
                {
                    return this._append;
                }
                set
                {
                    this.__isset.append = true;
                    this._append = value;
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
                                if (tfield.Type == TType.Struct)
                                {
                                    this.Append = new TAppend();
                                    this.Append.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (append_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.Append != null && this.__isset.append)
                    {
                        field.Name = "append";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Append.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("append_args(");
                bool flag = true;
                if (this.Append != null && this.__isset.append)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Append: ");
                    stringBuilder.Append(this.Append == null ? "<null>" : this.Append.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool append;
            }
        }

        [Serializable]
        public class append_result : TBase, TAbstractBase
        {
            private List<TCell> _success;
            private IOError _io;
            public Hbase.append_result.Isset __isset;

            public List<TCell> Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
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
                                case 0:
                                    if (tfield.Type == TType.List)
                                    {
                                        this.Success = new List<TCell>();
                                        TList tlist = iprot.ReadListBegin();
                                        for (int index = 0; index < tlist.Count; ++index)
                                        {
                                            TCell tcell = new TCell();
                                            tcell.Read(iprot);
                                            this.Success.Add(tcell);
                                        }
                                        iprot.ReadListEnd();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (append_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        if (this.Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.List;
                            field.ID = (short) 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteListBegin(new TList(TType.Struct, this.Success.Count));
                            foreach (TCell tcell in this.Success)
                                tcell.Write(oprot);
                            oprot.WriteListEnd();
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.io && this.Io != null)
                    {
                        field.Name = "Io";
                        field.Type = TType.Struct;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        this.Io.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("append_result(");
                bool flag = true;
                if (this.Success != null && this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append((object) this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
            }
        }

        [Serializable]
        public class checkAndPut_args : TBase, TAbstractBase
        {
            private byte[] _tableName;
            private byte[] _row;
            private byte[] _column;
            private byte[] _value;
            private Mutation _mput;
            private Dictionary<byte[], byte[]> _attributes;
            public Hbase.checkAndPut_args.Isset __isset;

            public byte[] TableName
            {
                get
                {
                    return this._tableName;
                }
                set
                {
                    this.__isset.tableName = true;
                    this._tableName = value;
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

            public Mutation Mput
            {
                get
                {
                    return this._mput;
                }
                set
                {
                    this.__isset.mput = true;
                    this._mput = value;
                }
            }

            public Dictionary<byte[], byte[]> Attributes
            {
                get
                {
                    return this._attributes;
                }
                set
                {
                    this.__isset.attributes = true;
                    this._attributes = value;
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
                                        this.TableName = iprot.ReadBinary();
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
                                case 5:
                                    if (tfield.Type == TType.String)
                                    {
                                        this.Value = iprot.ReadBinary();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 6:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Mput = new Mutation();
                                        this.Mput.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 7:
                                    if (tfield.Type == TType.Map)
                                    {
                                        this.Attributes = new Dictionary<byte[], byte[]>();
                                        TMap tmap = iprot.ReadMapBegin();
                                        for (int index = 0; index < tmap.Count; ++index)
                                            this.Attributes[iprot.ReadBinary()] = iprot.ReadBinary();
                                        iprot.ReadMapEnd();
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
                    TStruct struc = new TStruct(nameof (checkAndPut_args));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.TableName != null && this.__isset.tableName)
                    {
                        field.Name = "tableName";
                        field.Type = TType.String;
                        field.ID = (short) 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.TableName);
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
                    if (this.Value != null && this.__isset.value)
                    {
                        field.Name = "value";
                        field.Type = TType.String;
                        field.ID = (short) 5;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.Value);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Mput != null && this.__isset.mput)
                    {
                        field.Name = "mput";
                        field.Type = TType.Struct;
                        field.ID = (short) 6;
                        oprot.WriteFieldBegin(field);
                        this.Mput.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                    if (this.Attributes != null && this.__isset.attributes)
                    {
                        field.Name = "attributes";
                        field.Type = TType.Map;
                        field.ID = (short) 7;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, this.Attributes.Count));
                        foreach (byte[] key in this.Attributes.Keys)
                        {
                            oprot.WriteBinary(key);
                            oprot.WriteBinary(this.Attributes[key]);
                        }
                        oprot.WriteMapEnd();
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
                StringBuilder stringBuilder = new StringBuilder("checkAndPut_args(");
                bool flag = true;
                if (this.TableName != null && this.__isset.tableName)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("TableName: ");
                    stringBuilder.Append((object) this.TableName);
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
                if (this.Value != null && this.__isset.value)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Value: ");
                    stringBuilder.Append((object) this.Value);
                }
                if (this.Mput != null && this.__isset.mput)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Mput: ");
                    stringBuilder.Append(this.Mput == null ? "<null>" : this.Mput.ToString());
                }
                if (this.Attributes != null && this.__isset.attributes)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Attributes: ");
                    stringBuilder.Append((object) this.Attributes);
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool tableName;
                public bool row;
                public bool column;
                public bool value;
                public bool mput;
                public bool attributes;
            }
        }

        [Serializable]
        public class checkAndPut_result : TBase, TAbstractBase
        {
            private bool _success;
            private IOError _io;
            private IllegalArgument _ia;
            public Hbase.checkAndPut_result.Isset __isset;

            public bool Success
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

            public IOError Io
            {
                get
                {
                    return this._io;
                }
                set
                {
                    this.__isset.io = true;
                    this._io = value;
                }
            }

            public IllegalArgument Ia
            {
                get
                {
                    return this._ia;
                }
                set
                {
                    this.__isset.ia = true;
                    this._ia = value;
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
                                case 0:
                                    if (tfield.Type == TType.Bool)
                                    {
                                        this.Success = iprot.ReadBool();
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 1:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Io = new IOError();
                                        this.Io.Read(iprot);
                                        break;
                                    }
                                    TProtocolUtil.Skip(iprot, tfield.Type);
                                    break;
                                case 2:
                                    if (tfield.Type == TType.Struct)
                                    {
                                        this.Ia = new IllegalArgument();
                                        this.Ia.Read(iprot);
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
                    TStruct struc = new TStruct(nameof (checkAndPut_result));
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.__isset.success)
                    {
                        field.Name = "Success";
                        field.Type = TType.Bool;
                        field.ID = (short) 0;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBool(this.Success);
                        oprot.WriteFieldEnd();
                    }
                    else if (this.__isset.io)
                    {
                        if (this.Io != null)
                        {
                            field.Name = "Io";
                            field.Type = TType.Struct;
                            field.ID = (short) 1;
                            oprot.WriteFieldBegin(field);
                            this.Io.Write(oprot);
                            oprot.WriteFieldEnd();
                        }
                    }
                    else if (this.__isset.ia && this.Ia != null)
                    {
                        field.Name = "Ia";
                        field.Type = TType.Struct;
                        field.ID = (short) 2;
                        oprot.WriteFieldBegin(field);
                        this.Ia.Write(oprot);
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
                StringBuilder stringBuilder = new StringBuilder("checkAndPut_result(");
                bool flag = true;
                if (this.__isset.success)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Success: ");
                    stringBuilder.Append(this.Success);
                }
                if (this.Io != null && this.__isset.io)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    flag = false;
                    stringBuilder.Append("Io: ");
                    stringBuilder.Append(this.Io == null ? "<null>" : this.Io.ToString());
                }
                if (this.Ia != null && this.__isset.ia)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    stringBuilder.Append("Ia: ");
                    stringBuilder.Append(this.Ia == null ? "<null>" : this.Ia.ToString());
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            [Serializable]
            public struct Isset
            {
                public bool success;
                public bool io;
                public bool ia;
            }
        }
    }
}
