namespace OfxNet;

/// <summary>
/// Specifies the type of SGML tag encountered in parsing.
/// </summary>
internal enum SgmlTagType
{
    /// <summary>
    /// Represents an opening tag, e.g., &lt;TAG&gt;.
    /// </summary>
    OpeningTag = 0,

    /// <summary>
    /// Represents a value tag, which contains the value between tags.
    /// </summary>
    ValueTag = 1,

    /// <summary>
    /// Represents a closing tag, e.g., &lt;/TAG&gt;.
    /// </summary>
    ClosingTag = 2,
}
