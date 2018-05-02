using System;
using System.Runtime.Serialization;

namespace ro.devpool.hbase.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException() { }

        //public ConfigurationException(TConfig config, Func<TConfig,string> predicate): base($"")
        //{
        //}

        public ConfigurationException(string message) : base(message) { }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException) { }

        protected ConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}