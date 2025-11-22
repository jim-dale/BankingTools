namespace OfxNet;

using System;

/// <summary>
/// Represents an account balance as reported in an OFX (Open Financial Exchange) statement, including the balance
/// amount and the date it was calculated.
/// </summary>
/// <remarks>This class provides the balance information typically found in the <c>BALAMT</c> and <c>DTASOF</c>
/// fields of an OFX response. It is commonly used to convey the current or available balance for a financial account as
/// of a specific date.</remarks>
public class OfxAccountBalance
{
    /// <summary>Gets or sets the balance value (<c>VALUE</c>).</summary>
    public decimal Balance { get; set; }

    /// <summary>Gets or sets the date the balance was calculated (<c>DTASOF</c>).</summary>
    public DateTimeOffset DateAsOf { get; set; }
}
