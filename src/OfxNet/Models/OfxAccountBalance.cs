namespace OfxNet;

using System;

public class OfxAccountBalance
{
    /// <summary>Gets the balance value (<c>VALUE</c>).</summary>
    public decimal Balance { get; set; }

    /// <summary>Gets the date the balance was calculated (<c>DTASOF</c>).</summary>
    public DateTimeOffset DateAsOf { get; set; }
}
