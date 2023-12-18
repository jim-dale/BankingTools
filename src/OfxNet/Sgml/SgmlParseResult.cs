namespace OfxNet;

internal sealed class SgmlParseResult
{
    internal SgmlParseResult(SgmlTagType tagType, string tag)
        : this(tagType, tag, null)
    {
    }

    internal SgmlParseResult(SgmlTagType tagType, string tag, string? value)
    {
        this.TagType = tagType;
        this.Tag = tag;
        this.Value = value;
    }

    internal SgmlTagType TagType { get; set; }

    internal string Tag { get; set; }

    internal string? Value { get; set; }
}
