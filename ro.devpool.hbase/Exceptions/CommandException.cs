using System;
using System.Runtime.Serialization;

namespace ro.devpool.hbase.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException() { }

        public CommandException(string message) : base(message) { }

        public CommandException(string message, Exception innerException) : base(message, innerException) { }

        protected CommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}