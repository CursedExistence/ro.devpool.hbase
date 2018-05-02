using ro.devpool.hbase.Interfaces;

namespace ro.devpool.hbase.Filters
{
    public class KeyOnlyFilter : IScanFilter, IScanFilterBuild
    {
        string IScanFilterBuild.Build()
        {
            return "KeyOnlyFilter ()";
        }

        void IScanFilterBuild.Validate()
        {
            // nothing to validate
        }
    }
}