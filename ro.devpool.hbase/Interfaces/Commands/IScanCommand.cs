using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ro.devpool.hbase.Filters;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IScanCommand<TEntity>: IReturnableCommand<TEntity>, IReturnableCommandAsync<TEntity> where TEntity : class
    {
        IScanCommand<TEntity> Filter(Action<FilterContext<TEntity>> action,
            Composition composition = Composition.And);

        IScanCommand<TEntity> FetchColumns<T>(params Expression<Func<TEntity, T>>[] predicates);

        IScanCommand<TEntity> FetchColumns<T>(Expression<Func<TEntity, IEnumerable<T>>> predicate, params string[] columns);
        IScanCommand<TEntity> StartFrom(string startKey);
        IScanCommand<TEntity> EndTo(string endKey);
        IScanCommand<TEntity> ReverseResults();
        IScanCommand<TEntity> WithLimit(int limit);
    }
}