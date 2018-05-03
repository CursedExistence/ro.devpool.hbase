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
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Commands
{
    public class DeleteCommand<TEntity> : IDeleteCommand<TEntity> where TEntity : class
    {
        #region Private Members

        private readonly byte[] _tableName;
        
        private readonly List<TEntity> _entities = new List<TEntity>();
        private readonly List<string> _descriptors = new List<string>();
        private int _batchSize = 1000;
        private readonly ClassMap _map;
        private readonly IConnectionPool _pool;

        #endregion

        #region Constructors

        public DeleteCommand()
        {
            throw new Exception("Command not designed to be used this way");
        }

        internal DeleteCommand(IHBaseConfiguration configuration, IConnectionPool pool, ClassMap classMap)
        {
            _map = classMap;
            _pool = pool;

            _tableName = $"{classMap.GetNamespace()}{configuration.ThriftTablePrefix}{classMap.TableName}".GetBytes();
        }

        #endregion

        #region Fluent

        public IDeleteCommand<TEntity> SetBatchSize(int batchSize)
        {
            _batchSize = batchSize;
            return this;
        }

        public IDeleteCommand<TEntity> Entity(TEntity entity)
        {
            _entities.Add(entity);
            return this;
        }

        public IDeleteCommand<TEntity> Entities(IList<TEntity> entities)
        {
            _entities.AddRange(entities);
            return this;
        }

        public IDeleteCommand<TEntity> Entities(params TEntity[] entities)
        {
            _entities.AddRange(entities);
            return this;
        }

        public IDeleteCommand<TEntity> ExplicitColumn(Expression<Func<TEntity, object>> predicate)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);
            //var maps = visitor.ExposeMap().Select(x => x.FullColumnKey);
            _descriptors.Add(visitor.ExposeMap().FullColumnKey);
            return this;
        }

        public IDeleteCommand<TEntity> ExplicitColumns(params Expression<Func<TEntity, object>>[] predicates)
        {
            foreach (var predicate in predicates) ExplicitColumn(predicate);
            return this;
        }

        #endregion

        #region Command Execution

        public void Execute()
        {
            var client = _pool.GetClient();

            if (_descriptors.Count > 0)
            {
                var mutations = _descriptors.Select(x => new Mutation
                {
                    Column = x.GetBytes(),
                    IsDelete = true
                }).ToList();

                var batches = _entities.Select(x => new BatchMutation
                {
                    Row = RowkeyProcessor.ExtractFromEntity(x, _map.RowKey).GetBytes(),
                    Mutations = mutations
                }).ToList();

                batches.Split(_batchSize).ForEach(x => client.mutateRows(_tableName, x, null));
            }
            else
            {
                _entities.ForEach(x =>
                    client.deleteAllRow(_tableName, RowkeyProcessor.ExtractFromEntity(x, _map.RowKey).GetBytes(),
                        null));
            }

            _pool.ReleaseClient(client);
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