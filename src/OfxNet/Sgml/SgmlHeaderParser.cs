namespace OfxNet;

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Implements methods to parse an OFX SGML header.
/// </summary>
public class SgmlHeaderParser
{
    private int lineNumber;

    public SgmlHeader? TryGetHeader(string path)
    {
        using StreamReader stream = new (path, Encoding.ASCII);

        OfxVersion headerVersion = this.TryGetOfxHeaderVersion(stream);

        return (headerVersion == OfxVersion.HeaderV1) ? this.GetHeader(stream, headerVersion) : default;
    }

    public int SkipToContent(TextReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        this.SkipNoneContentLines(reader);

        this.ReadHeaders(reader, (line) => false);

        return this.lineNumber;
    }

    private static bool TrySetHeaderValue(SgmlHeader item, string name, string value)
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

    private OfxVersion TryGetOfxHeaderVersion(TextReader reader)
    {
        OfxVersion result = OfxVersion.InvalidHeader;

        this.SkipNoneContentLines(reader);

        this.ReadHeaders(reader, (line) =>
        {
            // First header must be the OFX version header e.g. 'OFXHEADER:100'
            Match match = SgmlConstants.HeaderVersionRegex.Match(line);
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
        var result = new SgmlHeader()
        {
            HeaderVersion = headerVersion,
        };

        this.ReadHeaders(reader, (line) =>
        {
            Match match = SgmlConstants.HeaderRegex.Match(line);
            if (match.Success)
            {
                string name = match.Groups[1].Value.ToUpperInvariant();
                string value = match.Groups[2].Value.Trim();

                _ = TrySetHeaderValue(result, name, value);
            }
            else
            {
                throw new SgmlParseException("Invalid format while parsing OFX headers, line number " + this.lineNumber + ".");
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
            ++this.lineNumber;
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

            string? line = reader.ReadLine();
            if (line is null)
            {
                // EOF
                break;
            }

            ++this.lineNumber;

            if (processLine.Invoke(line))
            {
                break;
            }
        }
    }
}
