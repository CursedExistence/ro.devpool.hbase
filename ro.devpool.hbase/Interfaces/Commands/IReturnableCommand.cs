using System.Collections.Generic;

namespace ro.devpool.hbase.Interfaces.Commands
{
    /// <summary>
    ///     Base returnable command interface
    /// </summary>
    public interface IReturnableCommand<TEntity> where TEntity : class
    {
        TEntity SingleOrDefault();
        IList<TEntity> List();

        IList<string> RowKeys();
    }
}