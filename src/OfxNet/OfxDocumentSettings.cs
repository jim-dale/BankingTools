namespace OfxNet;

using System;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "Not currently required.")]
public struct OfxDocumentSettings
{
    public readonly static OfxDocumentSettings Default = new()
    {
        TrimValues = true,
        TagComparer = StringComparer.CurrentCultureIgnoreCase
    };

    public bool TrimValues { get; set; }
    public StringComparer TagComparer { get; set; }
}
