namespace OfxNet;

/// <summary>
/// The OFX SGML header.
/// </summary>
public class SgmlHeader
{
    /// <summary>
    /// Gets or sets the OFX header version.
    /// </summary>
    public OfxVersion HeaderVersion { get; set; }

    /// <summary>
    /// Gets or sets the content type, e.g. <c>OFXSGML</c>.
    /// </summary>
    public string? Data { get; set; }

    /// <summary>
    /// Gets or sets the version number of the Document Type Definition (DTD) used for parsing.
    /// </summary>
    public OfxVersion Version { get; set; }

    /// <summary>
    /// Gets or sets the type of application-level security, if any, that is used for the <c>&lt;OFX&gt;</c> block.
    /// </summary>
    public string? Security { get; set; }

    /// <summary>
    /// Gets or sets the text encoding used for character data. The values for ENCODING can be USASCII or UTF-8.
    /// </summary>
    public string? Encoding { get; set; }

    /// <summary>
    /// Gets or sets the character set used for character data. The values for CHARSET may be ISO-8859-1 (Latin-1), 1252 (Windows Latin-1), or NONE.
    /// Any value specified here is likely to be ignored by an OFX client or server.
    /// </summary>
    public string? Charset { get; set; }

    /// <summary>
    /// Gets or sets the compression.
    /// </summary>
    /// <remarks>Not supported.</remarks>
    public string? Compression { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for this request file.
    /// </summary>
    public string? NewFileUid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier the last request and response that was received and processed by the client.
    /// </summary>
    public string? OldFileUid { get; set; }
}
