namespace OfxNet;

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Class to parse SGML formatted OFX documents.
/// </summary>
public class SgmlParser
{
    private int lineNumber;
    private SgmlElement root = SgmlElement.Empty;
    private SgmlElement currentNode = SgmlElement.Empty;

    /// <summary>
    /// Parse teh specified file as an SGML formatted OFX document.
    /// </summary>
    /// <param name="path">The complete file path to the document to be parsed.</param>
    /// <param name="encoding">The document <see cref="Encoding"/>.</param>
    /// <returns>The root SGML element.</returns>
    public SgmlElement Parse(string path, Encoding encoding)
    {
        using StreamReader reader = new(path, encoding);

        this.lineNumber = new SgmlHeaderParser().SkipToContent(reader);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            ++this.lineNumber;

            if (string.IsNullOrWhiteSpace(line) == false)
            {
                this.ProcessLine(line);
            }
        }

        return this.root;
    }

    private static SgmlParseResult? TryParseOpeningTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.OpeningTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 2)
        {
            result = new SgmlParseResult(SgmlTagType.OpeningTag, match.Groups[1].Value);
        }

        return result;
    }

    private static SgmlParseResult? TryParseLine(string line)
    {
        SgmlParseResult? result = TryParseOpeningTag(line);
        if (result == default)
        {
            result = TryParseClosingTag(line);
        }

        if (result == default)
        {
            result = TryParseValueFullTag(line);
        }

        if (result == default)
        {
            result = TryParseValuePartialTag(line);
        }

        return result;
    }

    private static SgmlParseResult? TryParseClosingTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ClosingTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 2)
        {
            result = new SgmlParseResult(SgmlTagType.ClosingTag, match.Groups[1].Value);
        }

        return result;
    }

    private static SgmlParseResult? TryParseValueFullTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ValueFullTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 4)
        {
            result = new SgmlParseResult(SgmlTagType.ValueTag, match.Groups[1].Value, match.Groups[2].Value);
        }

        return result;
    }

    private static SgmlParseResult? TryParseValuePartialTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ValuePartialTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 3)
        {
            result = new SgmlParseResult(SgmlTagType.ValueTag, match.Groups[1].Value, match.Groups[2].Value);
        }

        return result;
    }

    private static string? GetValue(string? value)
    {
        return WebUtility.HtmlDecode(value);
    }

    private void ProcessLine(string text)
    {
        SgmlParseResult? parseResult = TryParseLine(text);
        if (parseResult == null)
        {
            throw new SgmlParseException("Invalid OFX SGML, line " + this.lineNumber + ".");
        }
        else
        {
            switch (parseResult.TagType)
            {
                case SgmlTagType.OpeningTag:
                    this.ProcessOpeningTag(parseResult.Tag, text);
                    break;
                case SgmlTagType.ValueTag:
                    this.ProcessValueTag(parseResult.Tag, parseResult.Value, text);
                    break;
                case SgmlTagType.ClosingTag:
                    this.ProcessClosingTag(parseResult.Tag);
                    break;
                default:
                    break;
            }
        }
    }

    private void ProcessOpeningTag(string tag, string text)
    {
        if (this.root == SgmlElement.Empty)
        {
            this.root = new SgmlElement(tag, text);
            this.currentNode = this.root;
        }
        else
        {
            this.currentNode = this.currentNode.AddChild(new SgmlElement(tag, text, this.currentNode));
        }
    }

    private void ProcessValueTag(string tag, string? value, string text)
    {
        value = GetValue(value);

        this.currentNode.AddChild(new SgmlElement(tag, value, text, this.currentNode));
    }

    private void ProcessClosingTag(string tag)
    {
        string expectedTag = this.currentNode.Name;
        if (string.Equals(expectedTag, tag, StringComparison.OrdinalIgnoreCase) == false)
        {
            throw new SgmlParseException($"Closing tag '{tag}' does not match opening tag '{expectedTag}', line {this.lineNumber}.");
        }

        this.currentNode = this.currentNode.Parent ?? this.root;
    }
}
