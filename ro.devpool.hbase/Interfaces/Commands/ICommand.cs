namespace ro.devpool.hbase.Interfaces.Commands
{
    /// <summary>
    ///     Base command interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Executes a command against a data client
        /// </summary>
        void Execute();
    }
}