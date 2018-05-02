using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Management;
using ro.devpool.hbase.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Interfaces
{
    public interface IHBaseSessionFactory 
    {
        #region Configuration

        /// <summary>
        ///     Accepts a <see cref="IHBaseConfiguration" /> objects to configure the session factory
        /// </summary>
        /// <param name="configuration">A <see cref="IHBaseConfiguration" /></param>
        /// <returns>Fluent return of self</returns>
        IHBaseSessionFactory Configure(IHBaseConfiguration configuration);

        #endregion

        #region Mapping

        IHBaseSessionFactory Map<TEntity>(ClassMap<TEntity> classMap) where TEntity : class;

        #endregion

        #region Session

        /// <summary>
        ///     Builds a <see cref="IHBaseSession" /> with the configured <see cref="IHBaseConfiguration" />
        /// </summary>
        /// <returns>A <see cref="IHBaseSession" /></returns>
        IHBaseSession BuildSession();

        #endregion
    }

    internal interface IHbaseSessionFactoryContext
    {
        DIContainer Container { get; }
        ClassMap GetMap<TEntity>() where TEntity : class;
    }
}