using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Mapping.Mappers;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Mapping
{
    public class BaseMap<TEntity> where TEntity : class
    {
        private readonly IList<IMapper> _mappers;

        protected BaseMap()
        {
            _mappers = new List<IMapper>();
        }

        protected PrimitiveMapper Property(Expression<Func<TEntity, ValueType>> predicate)
        {
            var mapper = new PrimitiveMapper(predicate.ExtractNameAndType());
            _mappers.Add(mapper);
            return mapper;
        }

        protected PrimitiveMapper Property(Expression<Func<TEntity, string>> predicate)
        {
            var mapper = new PrimitiveMapper(predicate.ExtractNameAndType());
            _mappers.Add(mapper);
            return mapper;
        }

        protected ReferenceMapper Property(Expression<Func<TEntity, object>> predicate)
        {
            var mapper = new ReferenceMapper(predicate.ExtractNameAndType());

            _mappers.Add(mapper);
            return mapper;
        }

        //protected ListMapper<T> Property<T>(Expression<Func<TEntity, IList<T>>> predicate) where T : class
        //{
        //    var mapper = new ListMapper<T>(predicate.ExtractNameAndType());

        //    _mappers.Add(mapper);
        //    return mapper;
        //}

        protected ListMapper<T> Property<T>(Expression<Func<TEntity, IEnumerable<T>>> predicate) where T : class
        {
            var mapper = new ListMapper<T>(predicate.ExtractNameAndType());

            _mappers.Add(mapper);
            return mapper;
        }

        protected DictionaryMapper Property(Expression<Func<TEntity, IDictionary<string, string>>> predicate)
        {
            var mapper = new DictionaryMapper(predicate.ExtractNameAndType());

            _mappers.Add(mapper);
            return mapper;
        }

        protected DictionaryMapper Property<TValue>(Expression<Func<TEntity, IDictionary<string, TValue>>> predicate)
        {
            var mapper = new DictionaryMapper(predicate.ExtractNameAndType());

            _mappers.Add(mapper);
            return mapper;
        }

        protected DictionaryMapper Property<TKey, TValue>(
            Expression<Func<TEntity, IDictionary<TKey, TValue>>> predicate)
        {
            var mapper = new DictionaryMapper(predicate.ExtractNameAndType());

            _mappers.Add(mapper);
            return mapper;
        }


        internal IList<IMapper> ExposeMappers()
        {
            return _mappers;
        }
    }
}