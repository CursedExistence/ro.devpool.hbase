using System;
using ro.devpool.hbase.Interfaces;

namespace ro.devpool.hbase.Utils
{
    public enum Comparator
    {
        Substring,
        Binary,
        BinaryPrefix,
        RegexString
    }

    public enum ComparisonOperator
    {
        Less,
        LessOrEqual,
        Equal,
        NotEqual,
        GreaterOrEqual,
        Greater,
        NoOp
    }

    public enum Composition
    {
        And,
        Or
    }

    internal static class FilterUtils
    {
        internal static bool ValidateOperationForComparator(this IScanFilter filter, Comparator comparator,
            ComparisonOperator comparisonOperator)
        {
            if (comparator == Comparator.RegexString || comparator == Comparator.Substring)
                return comparisonOperator == ComparisonOperator.Equal ||
                       comparisonOperator == ComparisonOperator.NotEqual;
            return true;
        }

        internal static string GetCompositionString(this Composition compositor)
        {
            switch (compositor)
            {
                case Composition.And:
                    return "AND";
                case Composition.Or:
                    return "OR";
                default:
                    throw new ArgumentOutOfRangeException(nameof(compositor), compositor, null);
            }
        }

        internal static string GetComparatorString(this Comparator comparator)
        {
            switch (comparator)
            {
                case Comparator.Substring:
                    return "substring:";
                case Comparator.Binary:
                    return "binary:";
                case Comparator.BinaryPrefix:
                    return "binaryprefix:";
                case Comparator.RegexString:
                    return "regexstring:";
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparator), comparator, null);
            }
        }

        internal static string GetComparisonOperatorString(this ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Less: return "<";
                case ComparisonOperator.LessOrEqual: return "<=";
                case ComparisonOperator.Equal: return "=";
                case ComparisonOperator.NotEqual: return "!=";
                case ComparisonOperator.GreaterOrEqual: return ">=";
                case ComparisonOperator.Greater: return ">";
                case ComparisonOperator.NoOp: return "";
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator), comparisonOperator, null);
            }
        }
    }
}