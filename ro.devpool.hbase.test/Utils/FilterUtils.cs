using ro.devpool.hbase.Interfaces;

namespace ro.devpool.hbase.test.Utils
{
    internal static class FilterUtils
    {
        public static IScanFilterBuild ToFilterBuild(this IScanFilter filter)
        {
            return filter as IScanFilterBuild;
        }
    }
}