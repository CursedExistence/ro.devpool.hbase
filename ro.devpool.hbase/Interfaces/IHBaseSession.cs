using ro.devpool.hbase.Commands;
using ro.devpool.hbase.Interfaces.Commands;

namespace ro.devpool.hbase.Interfaces
{
    public interface IHBaseSession
    {
        /// <summary>
        ///     Session Identifier
        /// </summary>
        string SessionId { get; }

        /// <summary>
        ///     Returns a scan command instance
        /// </summary>
        /// <param name="tableName">The targeted table</param>
        /// <returns>A <see cref="IScanCommand" /></returns>
        IScanCommand<TEntity> Scan<TEntity>() where TEntity : class;

        /// <summary>
        ///     Returns a get command instance
        /// </summary>
        /// <param name="tableName">The targeted table</param>
        /// <returns>A <see cref="IGetCommand" /></returns>
        IGetCommand<TEntity> Get<TEntity>() where TEntity : class;

        /// <summary>
        ///     Returns a put command instance
        /// </summary>
        /// <param name="tableName">The targeted table</param>
        /// <returns>A <see cref="IPutCommand" /></returns>
        IPutCommand<TEntity> Put<TEntity>() where TEntity : class;

        /// <summary>
        ///     Returns a delete command instance
        /// </summary>
        /// <param name="tableName">The targeted table</param>
        /// <returns>A <see cref="IDeleteCommand" /></returns>
        IDeleteCommand<TEntity> Delete<TEntity>() where TEntity : class;

        /// <summary>
        ///     Returns a ddl command instance
        /// </summary>
        /// <param name="tableName">The targeted table</param>
        /// <returns>A <see cref="IDdlCommand" /></returns>
        IDdlCommand<TEntity> DDL<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets a TimestampCommand instance for retrieving timestamps of properties
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        ITimestampCommand<TEntity> Timestamp<TEntity>(TEntity entity) where TEntity : class;
    }
}