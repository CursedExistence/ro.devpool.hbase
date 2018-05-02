using System.Collections.Generic;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Interfaces.Commands
{
    public interface IDdlCommand<TEntity> where TEntity : class
    {
        IList<string> ListTables();
        void CreateTable(IList<HBaseColumnDescriptor> columnDescriptors);
        IList<HBaseColumnDescriptor> GetTableDescriptors();
        void Drop();
        void Truncate();
        void Enable();
        void Disable();
    }
}