using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Models.Apache;
using ro.devpool.hbase.Transform;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Commands
{
    public class ScanCommand<TEntity> : IScanCommand<TEntity> where TEntity : class
    {
        #region Private Methods

        private TScan PrepareScan()
        {
            var scan = new TScan { Reversed = _isReversed };

            if (_filter != null)
            {
                _filter.Validate();
                var filter = _filter.Build();

                Debug.WriteLine($"Executed Filter: {filter}");
                
                scan.FilterString = filter.GetBytesOrDefault();
            }

            if (!_startKey.IsNullOrEmpty()) scan.StartRow = _startKey.GetBytes();

            if (!_endKey.IsNullOrEmpty()) scan.StopRow = _endKey.GetBytes();

            if (_columns != null) scan.Columns = _columns.Select(x => x.GetBytes()).ToList();
            return scan;
        }

        private List<TRowResult> ExtractResult()
        {
            var scan = PrepareScan();
            var client = _pool.GetClient();
            var scanner = client.scannerOpenWithScan(_tableName, scan, new Dictionary<byte[], byte[]>());

            var data = client.scannerGetList(scanner, _limit);
            client.scannerClose(scanner);
            _pool.ReleaseClient(client);
            return data;
        }

        #endregion

        #region Private members

        private readonly byte[] _tableName;
        
        private readonly IList<string> _columns = new List<string>();
        private string _startKey;
        private string _endKey;
        private bool _isReversed;
        private int _limit = 100000;
        private IScanFilterBuild _filter;
        private readonly ClassMap _map;
        private readonly IConnectionPool _pool;

        #endregion

        #region Constructors

        public ScanCommand()
        {
            throw new Exception("Command not designed to be used this way");
        }

        internal ScanCommand(IHBaseConfiguration configuration, IConnectionPool pool, ClassMap map)
        {
            _tableName = $"{map.GetNamespace()}{configuration.ThriftTablePrefix}{map.TableName}".GetBytes();
            
            _map = map;
            _pool = pool;
        }

        #endregion

        #region Fluent

        public IScanCommand<TEntity> Filter(Action<FilterContext<TEntity>> action,
            Composition composition = Composition.And)
        {
            if (_filter != null)
                throw new FilterException(
                    "Filter already set!, if composition required please use Compose() from the FilterContext or use x => { x.filter1; x.filter2 } to add more filters.");

            var context = new FilterContext<TEntity>(composition, _map);
            action(context);

            _filter = context;

            return this;
        }

        public IScanCommand<TEntity> FetchColumns(params Expression<Func<TEntity, object>>[] predicates)
        {
            foreach (var predicate in predicates)
            {
                var visitor = new MapVisitor(_map);
                visitor.Visit(predicate);

                //var maps = visitor.ExposeMap();
                //foreach (var map in maps) _columns.Add(map.FullColumnKey);
                _columns.Add(visitor.ExposeMap().FullColumnKey);
            }

            return this;
        }

        public IScanCommand<TEntity> StartFrom(string startKey)
        {
            _startKey = startKey;
            return this;
        }

        public IScanCommand<TEntity> EndTo(string endKey)
        {
            _endKey = endKey;
            return this;
        }

        public IScanCommand<TEntity> ReverseResults()
        {
            _isReversed = true;
            return this;
        }

        public IScanCommand<TEntity> WithLimit(int limit)
        {
            _limit = limit;
            return this;
        }

        #endregion

        #region Command Execution

        public IList<string> RowKeys() => ExtractResult().Select(x => x.Row.GetString()).ToList();
        public Task<IList<string>> RowKeysAsync() => RowKeysAsync(CancellationToken.None);
        public Task<IList<string>> RowKeysAsync(CancellationToken cancellationToken) => Task.Run<IList<string>>(() => ExtractResult().Select(x => x.Row.GetString()).ToList(), cancellationToken);

        public TEntity SingleOrDefault()
        {
            var result = ExtractResult();

            if (result.Count > 1) throw new Exception($"Expected 1 result, got {result.Count}");
            if (result.Count == 0) return default(TEntity);

            var generator = new EntityGenerator<TEntity>(_map);

            return generator.BuildEntity(result.Single());
        }

        public IList<TEntity> List()
        {
            var result = ExtractResult();
            var generator = new EntityGenerator<TEntity>(_map);
            return generator.BuildEntities(result);
        }

        public async Task<TEntity> SingleOrDefaultAsync()
        {
            return await SingleOrDefaultAsync(CancellationToken.None);
        }


        public async Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var scan = PrepareScan();
                    var client = _pool.GetClient();
                    var scanner = client.scannerOpenWithScan(_tableName, scan, null);
                    var data = client.scannerGetList(scanner, _limit);
                    _pool.ReleaseClient(client);
                    return data;
                }, cancellationToken)
                .ContinueWith(x =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (x.Result.Count > 1) throw new Exception($"Expected 1 result, got {x.Result.Count}");
                    if (x.Result.Count == 0) return default(TEntity);
                    var generator = new EntityGenerator<TEntity>(_map);

                    return generator.BuildEntity(x.Result.Single());
                }, cancellationToken);
        }

        public async Task<IList<TEntity>> ListAsync()
        {
            return await ListAsync(CancellationToken.None);
        }


        public async Task<IList<TEntity>> ListAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var scan = PrepareScan();
                    var client = _pool.GetClient();
                    var scanner = client.scannerOpenWithScan(_tableName, scan, new Dictionary<byte[], byte[]>());
                    var data = client.scannerGetList(scanner, _limit);
                    _pool.ReleaseClient(client);
                    return data;
                }, cancellationToken)
                .ContinueWith(x =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (x.Result.Count == 0) return new List<TEntity>();
                    var generator = new EntityGenerator<TEntity>(_map);

                    return generator.BuildEntities(x.Result);
                }, cancellationToken);
        }

        #endregion
    }
}