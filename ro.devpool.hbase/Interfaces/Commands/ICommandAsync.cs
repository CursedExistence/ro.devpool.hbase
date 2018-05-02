using System.Threading;
using System.Threading.Tasks;

namespace ro.devpool.hbase.Interfaces.Commands
{
    /// <summary>
    ///     Base command interface for the async context
    /// </summary>
    public interface ICommandAsync
    {
        /// <summary>
        ///     Executes a command against a data client in an asynchronous matter
        /// </summary>
        /// <returns>An awaitable void</returns>
        Task ExecuteAsync();

        /// <summary>
        ///     Executes a command against a data client in an asynchronous matter
        /// </summary>
        /// <param name="cancellationToken"> A cancellation token.</param>
        /// <returns>An awaitable void</returns>
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}