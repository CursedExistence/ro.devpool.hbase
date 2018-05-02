using System;
using System.Runtime.Serialization;

namespace ro.devpool.hbase.Exceptions
{
    public class SessionFactoryConfigurationException : Exception
    {
        public SessionFactoryConfigurationException() { }

        public SessionFactoryConfigurationException(string message) : base(message) { }

        public SessionFactoryConfigurationException(string message, Exception innerException) : base(message,
            innerException) { }

        protected SessionFactoryConfigurationException(SerializationInfo info, StreamingContext context) : base(info,
            context) { }
    }
}