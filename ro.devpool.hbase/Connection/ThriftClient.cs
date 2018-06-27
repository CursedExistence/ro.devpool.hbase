using System;
using System.Collections.Generic;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Models.Apache;
using Thrift.Protocol;
using Thrift.Transport;

namespace ro.devpool.hbase.Connection
{
    internal sealed class ThriftClient : IThriftClient
    {
        #region Constants

        private const int DEFAULT_TIMEOUT = 30;

        #endregion

        #region Constructor

        internal ThriftClient(IHBaseConfiguration configuration)
        {
            Configuration = configuration;


            _thriftSocket = new TSocket(Configuration.ThriftHost, Configuration.ThriftPort);

            _thriftTransport = new TBufferedTransport(_thriftSocket);
            _thriftProtocol = new TBinaryProtocol(_thriftTransport);
            var thriftClient = new Hbase.Client(_thriftProtocol);

            _thriftTransport.Open();
            _connection = thriftClient;


            _timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds +
                         (Configuration.ThriftTimeout ?? DEFAULT_TIMEOUT);
        }

        #endregion

        #region Public Members

        public bool IsActive => DetermineIsActive();

        public IHBaseConfiguration Configuration { get; }

        #endregion

        #region Private members

        private Hbase.Client _connection { get; }

        private readonly double _timestamp;

        private readonly TSocket _thriftSocket;
        private readonly TBufferedTransport _thriftTransport;
        private readonly TBinaryProtocol _thriftProtocol;

        #endregion

        #region Private Methods

        private bool DetermineIsActive()
        {
                    return DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds <=
                           _timestamp;
        }

        #endregion

        #region Public Methods

        public void Cleanup()
        {
            if (_thriftTransport != null)
            {
                _thriftTransport.Close();
                _thriftTransport.Dispose();
            }

            _thriftSocket?.Close();

            _thriftSocket?.Dispose();

            _thriftProtocol?.Dispose();

            _connection?.Dispose();
        }


        public void enableTable(byte[] tableName)
        {
            _connection.enableTable(tableName);
        }

        public void disableTable(byte[] tableName)
        {
            _connection.disableTable(tableName);
        }

        public bool isTableEnabled(byte[] tableName)
        {
            return _connection.isTableEnabled(tableName);
        }

        public void compact(byte[] tableNameOrRegionName)
        {
            _connection.compact(tableNameOrRegionName);
        }

        public void majorCompact(byte[] tableNameOrRegionName)
        {
            _connection.majorCompact(tableNameOrRegionName);
        }

        public List<byte[]> getTableNames()
        {
            return _connection.getTableNames();
        }

        public Dictionary<byte[], ColumnDescriptor> getColumnDescriptors(byte[] tableName)
        {
            return _connection.getColumnDescriptors(tableName);
        }

        public List<TRegionInfo> getTableRegions(byte[] tableName)
        {
            return _connection.getTableRegions(tableName);
        }

        public void createTable(byte[] tableName, List<ColumnDescriptor> columnFamilies)
        {
            _connection.createTable(tableName, columnFamilies);
        }

        public void deleteTable(byte[] tableName)
        {
            _connection.deleteTable(tableName);
        }

        public List<TCell> get(byte[] tableName, byte[] row, byte[] column,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.get(tableName, row, column, attributes);
        }

        public List<TCell> getVer(byte[] tableName, byte[] row, byte[] column, int numVersions,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getVer(tableName, row, column, numVersions, attributes);
        }

        public List<TCell> getVerTs(byte[] tableName, byte[] row, byte[] column, long timestamp,
            int numVersions, Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getVerTs(tableName, row, column, timestamp, numVersions, attributes);
        }

        public List<TRowResult> getRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRow(tableName, row, attributes);
        }

        public List<TRowResult> getRowWithColumns(byte[] tableName, byte[] row, List<byte[]> columns,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowWithColumns(tableName, row, columns, attributes);
        }

        public List<TRowResult> getRowTs(byte[] tableName, byte[] row, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowTs(tableName, row, timestamp, attributes);
        }

        public List<TRowResult> getRowWithColumnsTs(byte[] tableName, byte[] row, List<byte[]> columns,
            long timestamp, Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowWithColumnsTs(tableName, row, columns, timestamp, attributes);
        }

        public List<TRowResult> getRows(byte[] tableName, List<byte[]> rows,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRows(tableName, rows, attributes);
        }

        public List<TRowResult> getRowsWithColumns(byte[] tableName, List<byte[]> rows, List<byte[]> columns,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowsWithColumns(tableName, rows, columns, attributes);
        }

        public List<TRowResult> getRowsTs(byte[] tableName, List<byte[]> rows, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowsTs(tableName, rows, timestamp, attributes);
        }

        public List<TRowResult> getRowsWithColumnsTs(byte[] tableName, List<byte[]> rows, List<byte[]> columns,
            long timestamp, Dictionary<byte[], byte[]> attributes)
        {
            return _connection.getRowsWithColumnsTs(tableName, rows, columns, timestamp, attributes);
        }

        public void mutateRow(byte[] tableName, byte[] row, List<Mutation> mutations,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.mutateRow(tableName, row, mutations, attributes);
        }

        public void mutateRowTs(byte[] tableName, byte[] row, List<Mutation> mutations, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.mutateRowTs(tableName, row, mutations, timestamp, attributes);
        }

        public void mutateRows(byte[] tableName, List<BatchMutation> rowBatches,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.mutateRows(tableName, rowBatches, attributes);
        }

        public void mutateRowsTs(byte[] tableName, List<BatchMutation> rowBatches, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.mutateRowsTs(tableName, rowBatches, timestamp, attributes);
        }

        public long atomicIncrement(byte[] tableName, byte[] row, byte[] column, long value)
        {
            return _connection.atomicIncrement(tableName, row, column, value);
        }

        public void deleteAll(byte[] tableName, byte[] row, byte[] column,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.deleteAll(tableName, row, column, attributes);
        }

        public void deleteAllTs(byte[] tableName, byte[] row, byte[] column, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.deleteAllTs(tableName, row, column, timestamp, attributes);
        }

        public void deleteAllRow(byte[] tableName, byte[] row, Dictionary<byte[], byte[]> attributes)
        {
            _connection.deleteAllRow(tableName, row, attributes);
        }

        public void increment(TIncrement increment)
        {
            _connection.increment(increment);
        }

        public void incrementRows(List<TIncrement> increments)
        {
            _connection.incrementRows(increments);
        }

        public void deleteAllRowTs(byte[] tableName, byte[] row, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            _connection.deleteAllRowTs(tableName, row, timestamp, attributes);
        }

        public int scannerOpenWithScan(byte[] tableName, TScan scan, Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpenWithScan(tableName, scan, attributes);
        }

        public int scannerOpen(byte[] tableName, byte[] startRow, List<byte[]> columns,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpen(tableName, startRow, columns, attributes);
        }

        public int scannerOpenWithStop(byte[] tableName, byte[] startRow, byte[] stopRow, List<byte[]> columns,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpenWithStop(tableName, startRow, stopRow, columns, attributes);
        }

        public int scannerOpenWithPrefix(byte[] tableName, byte[] startAndPrefix, List<byte[]> columns,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpenWithPrefix(tableName, startAndPrefix, columns, attributes);
        }

        public int scannerOpenTs(byte[] tableName, byte[] startRow, List<byte[]> columns, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpenTs(tableName, startRow, columns, timestamp, attributes);
        }

        public int scannerOpenWithStopTs(byte[] tableName, byte[] startRow, byte[] stopRow,
            List<byte[]> columns, long timestamp,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.scannerOpenWithStopTs(tableName, startRow, stopRow, columns, timestamp, attributes);
        }

        public List<TRowResult> scannerGet(int id)
        {
            return _connection.scannerGet(id);
        }

        public List<TRowResult> scannerGetList(int id, int nbRows)
        {
            return _connection.scannerGetList(id, nbRows);
        }

        public void scannerClose(int id)
        {
            _connection.scannerGet(id);
        }

        public List<TCell> getRowOrBefore(byte[] tableName, byte[] row, byte[] family)
        {
            return _connection.getRowOrBefore(tableName, row, family);
        }

        public TRegionInfo getRegionInfo(byte[] row)
        {
            return _connection.getRegionInfo(row);
        }

        public List<TCell> append(TAppend append)
        {
            return _connection.append(append);
        }

        public bool checkAndPut(byte[] tableName, byte[] row, byte[] column, byte[] value, Mutation mput,
            Dictionary<byte[], byte[]> attributes)
        {
            return _connection.checkAndPut(tableName, row, column, value, mput, attributes);
        }

        #endregion
    }
}