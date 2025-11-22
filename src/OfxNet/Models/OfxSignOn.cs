namespace OfxNet;

using System;

/// <summary>
/// Represents the sign-on information returned by an OFX server.
/// </summary>
public class OfxSignOn
{
    /// <summary>
    /// Gets or sets the status of the sign-on response.
    /// </summary>
    public OfxStatus? Status { get; set; }

    /// <summary>
    /// Gets or sets the server date and time of the sign-on response.
    /// </summary>
    public DateTimeOffset ServerDate { get; set; }

    /// <summary>
    /// Gets or sets the language code returned by the server.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Gets or sets the Intuit BID (Bank Identifier) returned by the server.
    /// </summary>
    public string? IntuBid { get; set; }
}
