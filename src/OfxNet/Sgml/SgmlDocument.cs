namespace OfxNet;

using System.Diagnostics.CodeAnalysis;
using System.Text;

public class SgmlDocument
{
    private SgmlDocument(SgmlHeader header, SgmlElement root)
    {
        this.Header = header;
        this.Root = root;
    }

    public SgmlHeader Header { get; set; }

    public SgmlElement Root { get; set; }

    public static bool TryLoad(string path, [NotNullWhen(true)] out SgmlDocument? result)
    {
        using FileStream stream = File.OpenRead(path);

        return TryLoad(stream, out result);
    }

    public static bool TryLoad(Stream stream, [NotNullWhen(true)] out SgmlDocument? result)
    {
        result = null;

        SgmlHeader? header = new SgmlHeaderParser().TryGetHeader(stream);
        if (header != default)
        {
            Encoding encoding = header.GetEncoding();

            SgmlElement root = new SgmlParser().Parse(stream, encoding);
            if (root != SgmlElement.Empty)
            {
                result = new SgmlDocument(header, root);
            }
        }

        return result != null;
    }
}
