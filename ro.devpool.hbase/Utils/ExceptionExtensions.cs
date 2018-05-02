using System;
using System.Linq.Expressions;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces.Configuration;

namespace ro.devpool.hbase.Utils
{
    internal static class ExceptionExtensions
    {
        public static void CreateConfigurationException<TValidation>(this TValidation validation,
            Expression<Func<TValidation, object>> predicate) where TValidation : IConfigurationValidation
        {
            var name = predicate.Body as MemberExpression;
            throw new ConfigurationException(
                $"Validation failed for configuration object: {typeof(TValidation).Name} on property: {name?.Member.Name}");
        }
    }
}