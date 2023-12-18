namespace OfxNet;

/// <summary>
/// Base class inherited by the different bank account types.
/// </summary>
public class OfxAccount
{
    /// <summary>
    /// Gets or sets the account number.
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the checksum.
    /// </summary>
    public string? Checksum { get; set; }
}
