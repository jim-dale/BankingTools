namespace OfxNet;

using System;
using System.Runtime.Serialization;

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
