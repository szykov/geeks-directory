using Microsoft.AspNetCore.Http;

using System;
using System.Runtime.Serialization;

namespace GeeksDirectory.Domain.Classes
{
    public class LogicException : Exception
    {
        public LogicException() { }

        public LogicException(string message) : base(message) { }

        public LogicException(string message, Exception innerException) : base(message, innerException) { }

        protected LogicException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
    }
}
