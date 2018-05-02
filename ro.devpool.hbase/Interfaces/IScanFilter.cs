using ro.devpool.hbase.Exceptions;

namespace ro.devpool.hbase.Interfaces
{
    internal interface IScanFilterBuild
    {
        /// <summary>
        ///     Builds a <see cref="IScanFilter" /> into a filterString compatible with the HBase Thrift filter.
        /// </summary>
        /// <returns>The generated filterString</returns>
        string Build();

        /// <summary>
        ///     Validation method for a <see cref="IScanFilter" />. This method has to THROW <see cref="FilterException" /> if
        ///     validation fails
        /// </summary>
        void Validate();
    }

    public interface IScanFilter { }
}