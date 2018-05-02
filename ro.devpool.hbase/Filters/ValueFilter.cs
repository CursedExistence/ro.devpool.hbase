using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class ValueFilter : IScanFilter, IScanFilterBuild
    {
        private Comparator _comparator = Utils.Comparator.Substring;
        private ComparisonOperator _comparisonOperator = Utils.ComparisonOperator.Equal;
        private string _value;

        string IScanFilterBuild.Build()
        {
            return
                $"ValueFilter ({_comparisonOperator.GetComparisonOperatorString()},'{_comparator.GetComparatorString()}{_value}')";
        }

        void IScanFilterBuild.Validate()
        {
            if (_value.IsNullOrEmpty())
                throw new FilterException("[ValueFilter] Value cannot be null or empty!");

            if (!this.ValidateOperationForComparator(_comparator,_comparisonOperator))
                throw new FilterException(
                    $"Comparison operator: {_comparisonOperator.GetComparisonOperatorString()} not permitted on comparator: {_comparator.GetComparatorString()}");
        }

        public ValueFilter ComparisonOperator(ComparisonOperator comparisonOperator)
        {
            _comparisonOperator = comparisonOperator;
            return this;
        }

        public ValueFilter Comparator(Comparator comparator)
        {
            _comparator = comparator;
            return this;
        }

        public ValueFilter Value(object value)
        {
            _value = value.ToString();
            return this;
        }
    }
}