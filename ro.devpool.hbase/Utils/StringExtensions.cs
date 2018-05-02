using System;
using System.Text;

namespace ro.devpool.hbase.Utils
{
    internal static class StringExtensions
    {
        public static string RemoveCf(this string source, string cf)
        {
            return source.Remove(0, cf.Length + 1);
        }

        public static byte[] GetBytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static byte[] GetBytesOrDefault(this string source)
        {
            try
            {
                return source.GetBytes();
            }
            catch
            {
                return default(byte[]);
            }
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }
    }
}