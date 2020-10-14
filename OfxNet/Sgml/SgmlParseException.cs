using System;
using System.Runtime.Serialization;

namespace OfxNet
{
    [Serializable]
    public class SgmlParseException : Exception
    {
        public SgmlParseException()
        {
        }

        public SgmlParseException(string message) : base(message)
        {
        }

        public SgmlParseException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SgmlParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
