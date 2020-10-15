using System;
using System.Text;

namespace OfxNet
{
    public static partial class SgmlHeaderExtensions
    {
        public static Encoding GetEncoding(this SgmlHeader item)
        {
            var result = Encoding.Default;

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
                else
                {
                    try
                    {
                        result = Encoding.GetEncoding(item.Charset);
                    }
#pragma warning disable CA1031 // Justification - this is the exact exception thrown
                    catch (ArgumentException)
                    {
                    }
#pragma warning restore CA1031
                }
            }
            else if (string.Equals("UTF-8", item.Encoding, StringComparison.OrdinalIgnoreCase))
            {
                result = Encoding.UTF8;
            }

            return result;
        }
    }
}
