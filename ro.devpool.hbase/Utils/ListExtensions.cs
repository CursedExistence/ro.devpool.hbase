using System;
using System.Collections.Generic;

namespace ro.devpool.hbase.Utils
{
    internal static class ListExtensions
    {
        public static List<List<T>> Split<T>(this List<T> source, int cunkSize = 100000)
        {
            var list = new List<List<T>>();

            for (var i = 0; i < source.Count; i += cunkSize)
                list.Add(source.GetRange(i, Math.Min(cunkSize, source.Count - i)));

            return list;
        }

        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (var element in source)
                target.Add(element);
        }
    }
}