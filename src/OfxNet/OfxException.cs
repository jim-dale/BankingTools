namespace OfxNet;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Represents errors that occur during parsing OFX documents.
/// </summary>
[Serializable]
public sealed class OfxException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxException"/> class.
    /// </summary>
    public OfxException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OfxException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxException"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of the exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public OfxException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
