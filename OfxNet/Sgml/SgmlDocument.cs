using System.Diagnostics.CodeAnalysis;

namespace OfxNet
{
    public class SgmlDocument
    {
        private SgmlDocument(SgmlHeader header, SgmlElement root)
        {
            Header = header;
            Root = root;
        }

        public SgmlHeader Header { get; set; }
        public SgmlElement Root { get; set; }

        public static bool TryLoad(string path, [NotNullWhen(true)] out SgmlDocument? result)
        {
            result = null;

            var header = new SgmlHeaderParser().TryGetHeader(path);
            if (header != default)
            {
                var encoding = header.GetEncoding();

                var root = new SgmlParser().Parse(path, encoding);
                if (root != SgmlElement.Empty)
                {
                    result = new SgmlDocument(header, root);
                }
            }

            return (result != null);
        }
    }
}
