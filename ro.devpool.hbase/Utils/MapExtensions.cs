using System.Collections.Generic;
using System.Linq;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Utils
{
    internal static class MapExtensions
    {
        public static IList<PropertyMap> ExtractPropertyMaps(this IMap map)
        {
            var maps = new List<PropertyMap>();

            switch (map)
            {
                case PropertyMap propertyMap:
                    maps.Add(propertyMap);
                    break;
                case SubClassMap subclassMap:
                    var intmaps = subclassMap.Mappers.Select(x => x.ExposeMap());

                    foreach (var intmap in intmaps) maps.AddRange(intmap.ExtractPropertyMaps());

                    break;
                case ListMap listMap:
                    var t = new PropertyMap
                    {
                        ColumnFamily = listMap.ColumnFamily,
                        //ColumnName = listMap.ColumnName.name,
                        Name = listMap.Name,
                        Type = listMap.Type
                    };
                    maps.Add(t);
                    break;
            }

            return maps;
        }
    }
}