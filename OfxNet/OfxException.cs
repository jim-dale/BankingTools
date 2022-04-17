using System;
using System.Runtime.Serialization;

namespace OfxNet
{
    [Serializable]
    internal class OfxException : Exception
    {
        public OfxException()
        {
        }

        public OfxException(string? message) : base(message)
        {
        }

        public OfxException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OfxException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}