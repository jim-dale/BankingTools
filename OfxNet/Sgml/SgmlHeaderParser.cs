using System;
using System.IO;
using System.Text;

namespace OfxNet
{
    public class SgmlHeaderParser
    {
        private int _lineNumber;

        public SgmlHeader TryGetHeader(string path)
        {
            using var stream = new StreamReader(path, Encoding.ASCII);

            var headerVersion = TryGetOfxHeaderVersion(stream);

            return (headerVersion == OfxVersion.HeaderV1) ? GetHeader(stream, headerVersion) : default;
        }

        public int SkipToContent(TextReader reader)
        {
            SkipNoneContentLines(reader);

            ReadHeaders(reader, (line) => false);

            return _lineNumber;
        }

        #region Private methods
        private OfxVersion TryGetOfxHeaderVersion(TextReader reader)
        {
            var result = OfxVersion.InvalidHeader;

            SkipNoneContentLines(reader);

            ReadHeaders(reader, (line) =>
            {
                // First header must be the OFX version header e.g. 'OFXHEADER:100'
                var match = SgmlConstants.HeaderVersionRegex.Match(line);
                if (match.Success)
                {
                    result = OfxParser.TryParseVersion(match.Groups[1].Value);
                }

                return true;
            });

            return result;
        }

        private SgmlHeader GetHeader(TextReader reader, OfxVersion headerVersion)
        {
            var result = new SgmlHeader
            {
                HeaderVersion = headerVersion
            };

            ReadHeaders(reader, (line) =>
            {
                var match = SgmlConstants.HeaderRegex.Match(line);
                if (match.Success)
                {
                    var name = match.Groups[1].Value.ToUpperInvariant();
                    var value = match.Groups[2].Value.Trim();

                    _ = TrySetHeaderValue(result, name, value);
                }
                else
                {
                    throw new SgmlParseException("Invalid format while parsing OFX headers, line number " + _lineNumber + ".");
                }

                return false;
            });

            return result;
        }

        private void SkipNoneContentLines(TextReader reader)
        {
            int nextChar;   // When Peek returns -1 it is the end of the stream
            while ((nextChar = reader.Peek()) != -1)
            {
                // OFX headers all start with a normal ASCII letter. Anything else
                // stop processing.
                if (char.IsWhiteSpace((char)nextChar) == false)
                {
                    break;
                }

                _ = reader.ReadLine();
                ++_lineNumber;
            }
        }

        private void ReadHeaders(TextReader reader, Func<string, bool> processLine)
        {
            int nextChar;   // When Peek returns -1 it is the end of the stream
            while ((nextChar = reader.Peek()) != -1)
            {
                // OFX headers all start with a normal ASCII letter.
                // Anything else - stop processing.
                if (char.IsLetter((char)nextChar) == false)
                {
                    break;
                }

                string line = reader.ReadLine();
                ++_lineNumber;

                if (processLine.Invoke(line))
                {
                    break;
                }
            }
        }

        private bool TrySetHeaderValue(SgmlHeader item, string name, string value)
        {
            bool result = true;

            switch (name)
            {
                case SgmlConstants.DataHeader:
                    item.Data = value;
                    break;
                case SgmlConstants.VersionHeader:
                    item.Version = OfxParser.ParseVersion(value);
                    break;
                case SgmlConstants.SecurityHeader:
                    item.Security = value;
                    break;
                case SgmlConstants.EncodingHeader:
                    item.Encoding = value;
                    break;
                case SgmlConstants.CharsetHeader:
                    item.Charset = value;
                    break;
                case SgmlConstants.CompressionHeader:
                    item.Compression = value;
                    break;
                case SgmlConstants.OldFileUIDHeader:
                    item.OldFileUid = value;
                    break;
                case SgmlConstants.NewFileUIDHeader:
                    item.NewFileUid = value;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }
        #endregion
    }
}
