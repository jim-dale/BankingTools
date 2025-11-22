namespace OfxNet;

/// <summary>
/// Represents a payee in an OFX transaction, including name, address, and contact information.
/// </summary>
public class OfxPayee
{
    /// <summary>
    /// Gets or sets the name of the payee.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the first line of the payee's address.
    /// </summary>
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Gets or sets the second line of the payee's address.
    /// </summary>
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Gets or sets the third line of the payee's address.
    /// </summary>
    public string? AddressLine3 { get; set; }

    /// <summary>
    /// Gets or sets the city of the payee's address.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state of the payee's address.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the postal code of the payee's address.
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the country of the payee's address.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the payee.
    /// </summary>
    public string? PhoneNumber { get; set; }
}
