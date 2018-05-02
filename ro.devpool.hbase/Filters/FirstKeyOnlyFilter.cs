using ro.devpool.hbase.Interfaces;

namespace ro.devpool.hbase.Filters
{
    public class FirstKeyOnlyFilter : IScanFilter, IScanFilterBuild
    {
        string IScanFilterBuild.Build()
        {
            return "FirstKeyOnlyFilter ()";
        }

        void IScanFilterBuild.Validate()
        {
            // nothing to validate
        }
    }
}