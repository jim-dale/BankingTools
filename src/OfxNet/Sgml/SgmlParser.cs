namespace OfxNet;

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

public class SgmlParser
{
    private int _lineNumber;
    private SgmlElement _root = SgmlElement.Empty;
    private SgmlElement _currentNode = SgmlElement.Empty;

    public SgmlElement Parse(string path, Encoding encoding)
    {
        using StreamReader reader = new(path, encoding);

        _lineNumber = new SgmlHeaderParser().SkipToContent(reader);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            ++_lineNumber;

            if (string.IsNullOrWhiteSpace(line) == false)
            {
                ProcessLine(line);
            }
        }

        return _root;
    }

    #region Private methods
    private void ProcessLine(string text)
    {
        SgmlParseResult? parseResult = TryParseLine(text);
        if (parseResult == null)
        {
            throw new SgmlParseException("Invalid OFX SGML, line " + _lineNumber + ".");
        }
        else
        {
            switch (parseResult.TagType)
            {
                case SgmlTagType.OpeningTag:
                    ProcessOpeningTag(parseResult.Tag, text);
                    break;
                case SgmlTagType.ValueTag:
                    ProcessValueTag(parseResult.Tag, parseResult.Value, text);
                    break;
                case SgmlTagType.ClosingTag:
                    ProcessClosingTag(parseResult.Tag);
                    break;
                default:
                    break;
            }
        }
    }

    private void ProcessOpeningTag(string tag, string text)
    {
        if (_root == SgmlElement.Empty)
        {
            _root = new SgmlElement(tag, text);
            _currentNode = _root;
        }
        else
        {
            _currentNode = _currentNode.AddChild(new SgmlElement(tag, text, _currentNode));
        }
    }

    private void ProcessValueTag(string tag, string? value, string text)
    {
        value = GetValue(value);

        _currentNode.AddChild(new SgmlElement(tag, value, text, _currentNode));
    }

    private void ProcessClosingTag(string tag)
    {
        string expectedTag = _currentNode.Name;
        if (string.Equals(expectedTag, tag, StringComparison.CurrentCultureIgnoreCase) == false)
        {
            throw new SgmlParseException($"Closing tag '{tag}' does not match opening tag '{expectedTag}', line {_lineNumber}.");
        }

        _currentNode = _currentNode.Parent ?? _root;
    }

    private SgmlParseResult? TryParseLine(string line)
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

    private SgmlParseResult? TryParseOpeningTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.OpeningTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 2)
        {
            result = new SgmlParseResult(SgmlTagType.OpeningTag, match.Groups[1].Value);
        }
        return result;
    }

    private SgmlParseResult? TryParseClosingTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ClosingTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 2)
        {
            result = new SgmlParseResult(SgmlTagType.ClosingTag, match.Groups[1].Value);
        }
        return result;
    }

    private SgmlParseResult? TryParseValueFullTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ValueFullTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 4)
        {
            result = new SgmlParseResult(SgmlTagType.ValueTag, match.Groups[1].Value, match.Groups[2].Value);
        }
        return result;
    }

    private SgmlParseResult? TryParseValuePartialTag(string line)
    {
        SgmlParseResult? result = default;

        Match match = SgmlConstants.ValuePartialTagRegex.Match(line);
        if (match.Success && match.Groups.Count == 3)
        {
            result = new SgmlParseResult(SgmlTagType.ValueTag, match.Groups[1].Value, match.Groups[2].Value);
        }
        return result;
    }

    private string? GetValue(string? value)
    {
        return WebUtility.HtmlDecode(value);
    }

    #endregion
}
