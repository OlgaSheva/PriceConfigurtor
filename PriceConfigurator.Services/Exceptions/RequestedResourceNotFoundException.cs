using System;
using System.Runtime.Serialization;

namespace PriceConfigurator.Services.Exceptions
{
    /// <summary>
    /// Request resource not fount exception.
    /// </summary>
    [Serializable]
    public class RequestedResourceNotFoundException : Exception
    {
        public RequestedResourceNotFoundException()
        {
        }

        public RequestedResourceNotFoundException(string message)
            : base(message)
        {
        }

        public RequestedResourceNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected RequestedResourceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
