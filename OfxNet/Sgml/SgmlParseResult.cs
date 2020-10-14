
namespace OfxNet
{
    internal class SgmlParseResult
    {
        internal SgmlTagType TagType { get; set; }
        internal string Tag { get; set; }
        internal string Value { get; set; }

        internal SgmlParseResult(SgmlTagType tagType, string tag)
            : this(tagType, tag, null)
        {
        }

        internal SgmlParseResult(SgmlTagType tagType, string tag, string value)
        {
            TagType = tagType;
            Tag = tag;
            Value = value;
        }
    }
}
