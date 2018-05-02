using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces;
using ro.devpool.hbase.Utils;

namespace ro.devpool.hbase.Filters
{
    public class PrefixFilter : IScanFilter, IScanFilterBuild
    {
        private string _key;

        string IScanFilterBuild.Build()
        {
            return $"PrefixFilter ('{_key}')";
        }

        void IScanFilterBuild.Validate()
        {
            if (_key.IsNullOrEmpty())
                throw new FilterException($"[PrefixFilter] Key is null or empty!");
        }

        public void Key(string key)
        {
            _key = key;
        }
    }
}