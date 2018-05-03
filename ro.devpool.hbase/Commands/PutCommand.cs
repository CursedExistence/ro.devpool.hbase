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
    public class PutCommand<TEntity> : IPutCommand<TEntity> where TEntity : class
    {
        #region Private Members

        private int _batchSize = 1000;
        private readonly byte[] _tableName;
        private readonly ClassMap _map;
        private readonly IList<TEntity> _entities;
        private readonly IList<string> _descriptors;
        private readonly IConnectionPool _pool;

        #endregion

        #region Constructors

        internal PutCommand(IHBaseConfiguration configuration, IConnectionPool pool, ClassMap classMap)
        {
            _tableName = $"{classMap.GetNamespace()}{configuration.ThriftTablePrefix}{classMap.TableName}".GetBytes();
            _map = classMap;
            _entities = new List<TEntity>();
            _descriptors = new List<string>();
            _pool = pool;
        }

        public PutCommand()
        {
            throw new Exception("Command not designed to be used this way");
        }

        #endregion

        #region Fluent

        public IPutCommand<TEntity> Entity(TEntity entity)
        {
            _entities.Add(entity);
            return this;
        }

        public IPutCommand<TEntity> Entities(IList<TEntity> entities)
        {
            _entities.AddRange(entities);
            return this;
        }

        public IPutCommand<TEntity> Entities(params TEntity[] entities)
        {
            _entities.AddRange(entities);
            return this;
        }

        public IPutCommand<TEntity> ExplicitColumn(Expression<Func<TEntity, object>> predicate)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);

            //var maps = visitor.ExposeMap().Select(x => x.FullColumnKey);
            _descriptors.Add(visitor.ExposeMap().FullColumnKey);
            return this;
        }

        public IPutCommand<TEntity> ExplicitColumns(params Expression<Func<TEntity, object>>[] predicates)
        {
            foreach (var predicate in predicates) ExplicitColumn(predicate);
            return this;
        }

        public IPutCommand<TEntity> SetBatchSize(int batchSize)
        {
            _batchSize = batchSize;
            return this;
        }

        #endregion

        #region Command Execution

        public void Execute()
        {
            var client = _pool.GetClient();

            var dataAdapter = new RowGenerator<TEntity>();

            var mutations = dataAdapter.Serialize(_map, _entities, _descriptors)
                .GroupBy(x => x.RowKey)
                .Select(x => new BatchMutation // try paralelizing this
                {
                    Row = x.Key.GetBytes(),
                    Mutations = x.Select(m => new Mutation
                    {
                        Value = m.Value,
                        Column = m.FullColumnName.GetBytes()
                    }).ToList()
                }).ToList();

            mutations.Split(_batchSize).ForEach(x => client.mutateRows(_tableName, x, null));

            _pool.ReleaseClient(client);

            _entities.Clear(); // dereference in case of hanging
        }

        public async Task ExecuteAsync()
        {
            await ExecuteAsync(CancellationToken.None);
        }


        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => Execute(), cancellationToken);
        }

        #endregion
    }
}