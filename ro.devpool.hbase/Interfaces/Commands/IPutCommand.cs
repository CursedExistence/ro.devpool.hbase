using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IPutCommand<TEntity> : ICommand, ICommandAsync where TEntity : class
    {
        IPutCommand<TEntity> Entity(TEntity entity);
       IPutCommand<TEntity> Entities(IList<TEntity> entities);
        IPutCommand<TEntity> Entities(params TEntity[] entities);

        IPutCommand<TEntity> ExplicitColumn(Expression<Func<TEntity, object>> predicate);
        IPutCommand<TEntity> ExplicitColumns(params Expression<Func<TEntity, object>>[] predicates);
        IPutCommand<TEntity> SetBatchSize(int batchSize);
    }
}