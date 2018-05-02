using System;
using System.Linq;
using System.Threading.Tasks;
using FastMember;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Utils
{
    internal class RowkeyProcessor
    {
        public static string ExtractFromEntity<TEntity>(TEntity entity, RowKey key, ObjectAccessor accessor = null)
        {
            if (accessor == null)
                accessor = ObjectAccessor.Create(entity);

            var components = key.Components.Select(rowkeyComponent => key.IncludePropertyNameInSerialization
                    ? $"{rowkeyComponent.Name}-{accessor[rowkeyComponent.Name].ToString()}"
                    : accessor[rowkeyComponent.Name].ToString())
                .ToList();

            return string.Join(key.Separator, components);
        }

        public static void PopulateEntity<TEntity>(TEntity entity, RowKey keyMap, byte[] key, ObjectAccessor accessor = null)
        {
            if(accessor ==null)
                accessor = ObjectAccessor.Create(entity);

            if(key == null)
                throw new ArgumentNullException(nameof(key));

            if (keyMap.RowKeyKind == RowKeyKind.Simple)
            {
                accessor[keyMap.Components.First().Name] = key.GetString();
            }
            else
            {
                var splits = key.GetString().Split(keyMap.Separator.ToCharArray());
                if (keyMap.Components.Count != splits.Length)
                    throw new Exception(
                        $"Inconsistent key, expected {keyMap.Components.Count} parts, got {splits.Length}");

                Parallel.For(0, splits.Length, i =>
                {
                    var map = keyMap.Components[i];
                    var data = splits[i];
                    accessor[map.Name] = Convert.ChangeType(data, map.Type);
                });
            }
        }
    }
}