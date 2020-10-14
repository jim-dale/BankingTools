
namespace OfxNet
{
    public class SgmlDocument
    {
        public SgmlHeader Header { get; set; }
        public SgmlElement Root { get; set; }

        public static bool TryLoad(string path, out SgmlDocument result)
        {
            result = default;
            bool success = false;

            var header = new SgmlHeaderParser().TryGetHeader(path);
            if (header != default)
            {
                var encoding = header.GetEncoding();

                var root = new SgmlParser().Parse(path, encoding);

                result = new SgmlDocument
                {
                    Header = header,
                    Root = root
                };
                success = true;
            }

            return success;
        }
    }
}
