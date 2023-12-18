namespace OfxNet;

using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

/// <summary>
/// OFX SGML constants used during parsing.
/// </summary>
public static class SgmlConstants
{
    /// <summary>
    /// OFXHEADER specifies the version number of the Open Financial Exchange headers.
    /// </summary>
    public const string Header = "OFXHEADER";

    /// <summary>
    /// Specifies the content type, in this case OFXSGML.
    /// </summary>
    public const string DataHeader = "DATA";

    /// <summary>
    /// Specifies the version number of the Document Type Definition (DTD) used for parsing.
    /// </summary>
    public const string VersionHeader = "VERSION";

    /// <summary>
    /// Defines the type of application-level security, if any, that is used for the &lt;OFX&gt; block. The values for <c>SECURITY</c> can be <c>NONE</c> or <c>TYPE1</c>.
    /// </summary>
    public const string SecurityHeader = "SECURITY";

    /// <summary>
    /// Defines the text encoding used for character data. The values for ENCODING can be USASCII or UTF-8.
    /// </summary>
    public const string EncodingHeader = "ENCODING";

    /// <summary>
    /// Gets or sets the character set used for character data. The values for CHARSET may be ISO-8859-1 (Latin-1), 1252 (Windows Latin-1), or NONE.
    /// Any value specified here is likely to be ignored by an OFX client or server.
    /// </summary>
    public const string CharsetHeader = "CHARSET";

    /// <summary>
    /// Gets or sets the compression.
    /// </summary>
    /// <remarks>Not supported.</remarks>
    public const string CompressionHeader = "COMPRESSION";

    /// <summary>
    /// Gets or sets the unique identifier the last request and response that was received and processed by the client.
    /// </summary>
    public const string OldFileUIDHeader = "OLDFILEUID";

    /// <summary>
    /// Gets or sets the unique identifier for this request file.
    /// </summary>
    public const string NewFileUIDHeader = "NEWFILEUID";

    /// <summary>
    /// Regex pattern to parse OFX version header.
    /// </summary>
    public static readonly Regex HeaderVersionRegex = new(HeaderVersionRegexPattern, RegexOptions.IgnoreCase);

    /// <summary>
    /// Regex pattern for parsing OFX headers in the form <c>&lt;name&gt;:&lt;value&gt;</c>.
    /// </summary>
    public static readonly Regex HeaderRegex = new(HeaderRegexPattern, RegexOptions.IgnoreCase);

    /// <summary>
    /// Regex pattern to parse an opening tag.
    /// </summary>
    public static readonly Regex OpeningTagRegex = new(OpeningTagRegexPattern, RegexOptions.IgnoreCase);

    /// <summary>
    /// Regex pattern to parse a clsing tag.
    /// </summary>
    public static readonly Regex ClosingTagRegex = new(ClosingTagRegexPattern, RegexOptions.IgnoreCase);

    /// <summary>
    /// Regex pattern to parse a fully enclosed tag with a value e.g. <c>&lt;CODE&gt;0&lt;/CODE&gt;</c>.
    /// </summary>
    public static readonly Regex ValueFullTagRegex = new(ValueFullTagRegexPattern, RegexOptions.IgnoreCase);

    /// <summary>
    /// Regex pattern to parse a partial tag with a value e.g. <c>&lt;CODE&gt;0</c>.
    /// </summary>
    public static readonly Regex ValuePartialTagRegex = new(ValuePartialTagRegexPattern, RegexOptions.IgnoreCase);

    private const string HeaderRegexPrefix = "^";
    private const string HeaderRegexSeparator = @"\s*:\s*";
    private const string HeaderVersionRegexPattern = HeaderRegexPrefix + Header + HeaderRegexSeparator + @"(\d{3})" + @"\s*$";
    private const string HeaderRegexPattern = HeaderRegexPrefix + @"(\w+)" + HeaderRegexSeparator + @"(.+)" + @"$";

    private const string OpeningTagRegexPattern = @"^\s*<([\w\.]+)>\s*$";
    private const string ClosingTagRegexPattern = @"^\s*</([\w\.]+)>\s*$";
    private const string ValueFullTagRegexPattern = @"^\s*<([\w\.]+)>(.+)</([\w\.]+)>\s*$";
    private const string ValuePartialTagRegexPattern = @"^\s*<([\w\.]+)>(.+)$";
}
