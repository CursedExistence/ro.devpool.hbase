using System;
using System.Linq.Expressions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IScanCommand<TEntity>: IReturnableCommand<TEntity>, IReturnableCommandAsync<TEntity> where TEntity : class
    {
        IScanCommand<TEntity> Filter(Action<FilterContext<TEntity>> action,
            Composition composition = Composition.And);

        IScanCommand<TEntity> FetchColumns(params Expression<Func<TEntity, object>>[] predicates);
        IScanCommand<TEntity> StartFrom(string startKey);
        IScanCommand<TEntity> EndTo(string endKey);
        IScanCommand<TEntity> ReverseResults();
        IScanCommand<TEntity> WithLimit(int limit);
    }
}