using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface ITimestampCommand<TEntity> where TEntity : class
    {
        long Property<T>(Expression<Func<TEntity, T>> predicate) where T : class;
        long Property<TProperty>(Expression<Func<TEntity, TProperty>> predicate, string columnName);
       // long Property<TKey, TValue>(Expression<Func<TEntity, IDictionary<TKey, TValue>>> predicate, string columnName);
    }
}