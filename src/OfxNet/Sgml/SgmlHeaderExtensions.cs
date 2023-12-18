namespace OfxNet;

using System;
using System.Text;

/// <summary>
/// <see cref="SgmlHeader"/> extension methods.
/// </summary>
public static partial class SgmlHeaderExtensions
{
    /// <summary>
    /// Gets the character encoding for the remaining data in the document from the SGML header.
    /// </summary>
    /// <param name="item">The SGML header object.</param>
    /// <returns>The character enconding.</returns>
    public static Encoding GetEncoding(this SgmlHeader item)
    {
        ArgumentNullException.ThrowIfNull(item);

        Encoding result = Encoding.Default;

        if (string.Equals("USASCII", item.Encoding, StringComparison.OrdinalIgnoreCase))
        {
            if (string.Equals("1252", item.Charset, StringComparison.OrdinalIgnoreCase))
            {
                result = Encoding.GetEncoding(1252);
            }
            else if (string.Equals("ISO-8859-1", item.Charset, StringComparison.OrdinalIgnoreCase))
            {
                result = Encoding.GetEncoding("iso-8859-1");
            }
            else if (string.Equals("NONE", item.Charset, StringComparison.OrdinalIgnoreCase))
            {
                result = Encoding.GetEncoding("us-ascii");
            }
            else if (item.Charset is not null)
            {
                try
                {
                    result = Encoding.GetEncoding(item.Charset);
                }
                catch (ArgumentException)
                {
                }
            }
        }
        else if (string.Equals("UTF-8", item.Encoding, StringComparison.OrdinalIgnoreCase))
        {
            result = Encoding.UTF8;
        }

        return result;
    }
}
