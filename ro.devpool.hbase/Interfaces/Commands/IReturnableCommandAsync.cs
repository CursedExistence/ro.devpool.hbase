using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ro.devpool.hbase.Interfaces.Commands
{
    /// <summary>
    ///     Base command interface for the async context
    /// </summary>
    public interface IReturnableCommandAsync<TEntity> where TEntity : class
    {
        Task<TEntity> SingleOrDefaultAsync();
        Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken);

        Task<IList<TEntity>> ListAsync();
        Task<IList<TEntity>> ListAsync(CancellationToken cancellationToken);

        Task<IList<string>> RowKeysAsync();
        Task<IList<string>> RowKeysAsync(CancellationToken cancellationToken);
    }
}