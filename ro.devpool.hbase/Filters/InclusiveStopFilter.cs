using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class InclusiveStopFilter : IScanFilter, IScanFilterBuild
    {
        private string _endKey;


        string IScanFilterBuild.Build()
        {
            return $"InclusiveStopFilter ('{_endKey}')";
        }

        void IScanFilterBuild.Validate()
        {
            if (_endKey.IsNullOrEmpty())
                throw new FilterException("[InclusiveStopFilter] End key cannot be null or empty");
        }

        public void EndKey(string endKey)
        {
            _endKey = endKey;
        }
    }
}