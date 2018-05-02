using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Models.Apache;

namespace ro.devpool.hbase.Interfaces.Connection
{
    public interface IThriftClient : Hbase.Iface
    {
        /// <summary>
        ///     True if a connection exists and False if it expired
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        ///     The configuration for the client
        /// </summary>
        IHBaseConfiguration Configuration { get; }

        /// <summary>
        ///     Cleanup method that releases the resources.
        /// </summary>
        void Cleanup();
    }
}