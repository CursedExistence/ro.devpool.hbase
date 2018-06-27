using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Proxy;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Commands
{
    public class TimestampCommand<TEntity> : ITimestampCommand<TEntity> where TEntity : class
    {
        private readonly TEntity _entity;
        private readonly ClassMap _map;

        internal TimestampCommand(TEntity entity, ClassMap map)
        {
            _entity = entity;
            _map = map;
        }

        public long Property<T>(Expression<Func<TEntity, T>> predicate) where T:class
        {
            return Property(predicate, string.Empty);
        }

        public long Property<TProperty>(Expression<Func<TEntity, TProperty>> predicate, string columnName)
        {
            var visitor = new MapVisitor(_map);
            visitor.Visit(predicate);
            var key = visitor.ExposeMap().FullColumnKey;
            return GetTs($"{key}{columnName}");
        }
        //public long Property<TKey,TValue>(Expression<Func<TEntity, IDictionary<TKey,TValue>>> predicate, string columnName)
        //{
        //    return Property(predicate, string.Empty);
        //}

        private long GetTs(string key)
        {
            var ts = _entity as ITimestamp;
            var dict = ts.Get();
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            else return 0; // throw exception here
        }
    }
}