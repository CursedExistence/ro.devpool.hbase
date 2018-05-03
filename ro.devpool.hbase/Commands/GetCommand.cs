using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Models.Apache;
using ro.devpool.hbase.Transform;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Commands
{
    public class GetCommand<TEntity> : IGetCommand<TEntity>
        where TEntity : class
    {
        private static List<byte[]> ConvertToByteArrays(IEnumerable<string> source)
        {
            return source.Select(x => x.GetBytes()).ToList();
        }

        #region Private members

        private readonly List<string> _rows;
        private readonly List<string> _columns;
        private readonly ClassMap _map;
        private readonly byte[] _tableName;
        private readonly IConnectionPool _pool;

        #endregion

        #region Constructors

        public GetCommand()
        {
            throw new Exception("Command not designed to be used this way");
        }

        internal GetCommand(IHBaseConfiguration configuration, IConnectionPool pool, ClassMap classMap)
        {
            _tableName = $"{classMap.GetNamespace()}{configuration.ThriftTablePrefix}{classMap.TableName}".GetBytes();
            _columns = new List<string>();
            _rows = new List<string>();
            _map = classMap;
            _pool = pool;
        }

        #endregion

        #region Fluent

        public IGetCommand<TEntity> Row(string row)
        {
            _rows.Add(row);
            return this;
        }

        public IGetCommand<TEntity> Rows(IList<string> rows)
        {
            _rows.AddRange(rows);
            return this;
        }

        public IGetCommand<TEntity> Rows(params string[] rows)
        {
            _rows.AddRange(rows);
            return this;
        }

        public IGetCommand<TEntity> Column(Expression<Func<TEntity, object>> predicate)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);

            //var maps = visitor.ExposeMap();
            //foreach (var map in maps) _columns.Add(map.FullColumnKey);
            _columns.Add(visitor.ExposeMap().FullColumnKey);

            return this;
        }


        public IGetCommand<TEntity> Columns(params Expression<Func<TEntity, object>>[] predicates)
        {
            foreach (var predicate in predicates) Column(predicate);
            return this;
        }

        #endregion

        #region Command Execution

        private List<TRowResult> ExtractResult()
        {
            var cols = ConvertToByteArrays(_columns.Distinct());
            var rows = ConvertToByteArrays(_rows);

            var client = _pool.GetClient();
            var data = client.getRowsWithColumns(_tableName, rows.Count > 0 ? rows : null, cols.Count > 0 ? cols : null,
                null);
            _pool.ReleaseClient(client);
            return data;
        }


        public IList<string> RowKeys() => ExtractResult().Select(x => x.Row.GetString()).ToList();

        public Task<IList<string>> RowKeysAsync() => RowKeysAsync(CancellationToken.None);
        public Task<IList<string>> RowKeysAsync(CancellationToken cancellationToken) => Task.Run<IList<string>>(() => ExtractResult().Select(x => x.Row.GetString()).ToList(),cancellationToken);
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

            if (result.Count == 0) return new List<TEntity>();
            var generator = new EntityGenerator<TEntity>(_map);


            return generator.BuildEntities(result);
        }

        public async Task<TEntity> SingleOrDefaultAsync()
        {
            return await SingleOrDefaultAsync(CancellationToken.None);
        }

        public async Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken)
        {
            // Cannot spawn an IO-Bound task because internal thrift limitation (does not expose any IO bound methods)
            return await Task.Run(() =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var cols = ConvertToByteArrays(_columns);
                    var rows = ConvertToByteArrays(_rows);
                    var client = _pool.GetClient();
                    var data = client.getRowsWithColumns(_tableName, rows.Count > 0 ? rows : null,
                        cols.Count > 0 ? cols : null, null);
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
                    var cols = ConvertToByteArrays(_columns);
                    var rows = ConvertToByteArrays(_rows);
                    var client = _pool.GetClient();
                    var data = client.getRowsWithColumns(_tableName, rows.Count > 0 ? rows : null,
                        cols.Count > 0 ? cols : null, null);
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