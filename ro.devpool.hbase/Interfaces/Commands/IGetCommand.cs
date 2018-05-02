using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IGetCommand<TEntity> : IReturnableCommand<TEntity>, IReturnableCommandAsync<TEntity> where TEntity : class
    {
        IGetCommand<TEntity> Row(string row);
        IGetCommand<TEntity> Rows(IList<string> rows);
        IGetCommand<TEntity> Rows(params string[] rows);
        IGetCommand<TEntity> Column(Expression<Func<TEntity, object>> predicate);
        IGetCommand<TEntity> Columns(params Expression<Func<TEntity, object>>[] predicates);
    }
}