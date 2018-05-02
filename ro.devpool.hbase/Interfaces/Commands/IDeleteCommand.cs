using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IDeleteCommand<TEntity> : ICommand, ICommandAsync where TEntity : class
    {
        IDeleteCommand<TEntity> SetBatchSize(int batchSize);
        IDeleteCommand<TEntity> Entity(TEntity entity);
        IDeleteCommand<TEntity> Entities(IList<TEntity> entities);
        IDeleteCommand<TEntity> Entities(params TEntity[] entities);
        IDeleteCommand<TEntity> ExplicitColumn(Expression<Func<TEntity, object>> predicate);
        IDeleteCommand<TEntity> ExplicitColumns(params Expression<Func<TEntity, object>>[] predicates);
    }
}