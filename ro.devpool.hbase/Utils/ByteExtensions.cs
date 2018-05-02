using System;
using System.Text;

namespace ro.devpool.hbase.Utils
{
    internal static class ByteExtensions
    {
        public static string GetString(this byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }

        public static bool StartsWith(this byte[] source, byte[] target)
        {
            var isTrue = false;

            for (var i = 0; i < target.Length; i++)
            {
                isTrue = target[i] == source[i];
            }

            return isTrue;
        }
    }
}