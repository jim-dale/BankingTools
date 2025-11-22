namespace OfxNet;

using System;

[Serializable]
public class SgmlParseException : Exception
{
    public SgmlParseException()
    {
    }

    public SgmlParseException(string message)
        : base(message)
    {
    }

    public SgmlParseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
