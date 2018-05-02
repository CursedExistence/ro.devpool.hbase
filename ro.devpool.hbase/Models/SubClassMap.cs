using System;
using System.Collections.Generic;
using ro.devpool.hbase.Interfaces.Mapping;

namespace ro.devpool.hbase.Models
{
    internal class SubClassMap : IMap
    {
        public IList<IMapper> Mappers { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}