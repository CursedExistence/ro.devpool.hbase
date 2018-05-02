using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ro.devpool.hbase.Utils
{
    internal static class ExpressionExtensions
    {
        public static (string name, Type type) ExtractNameAndType<TIn, TOut>(this Expression<Func<TIn, TOut>> predicate)
        {
            MemberExpression memberExpression = null;

            if (predicate.Body.NodeType == ExpressionType.Convert)
                memberExpression = ((UnaryExpression) predicate.Body).Operand as MemberExpression;
            else if (predicate.Body.NodeType == ExpressionType.MemberAccess)
                memberExpression = predicate.Body as MemberExpression;

            if (memberExpression == null) throw new ArgumentException("Not a member access", "expression");

            var propinfo = memberExpression.Member as PropertyInfo;
            return (propinfo.Name, propinfo.PropertyType);
        }
    }
}