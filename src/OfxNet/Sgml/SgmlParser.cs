﻿namespace OfxNet;

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
    private SgmlElement lastValueNode = SgmlElement.Empty;

    /// <summary>
    /// Parse the specified file as an SGML formatted OFX document.
    /// </summary>
    /// <param name="path">The complete file path to the document to be parsed.</param>
    /// <param name="encoding">The document <see cref="Encoding"/>.</param>
    /// <returns>The root SGML element.</returns>
    public SgmlElement Parse(string path, Encoding encoding)
    {
        using FileStream stream = File.OpenRead(path);

        return this.Parse(stream, encoding);
    }

    /// <summary>
    /// Parse the specified file as an SGML formatted OFX document.
    /// </summary>
    /// <param name="stream">The stream of the document to be parsed.</param>
    /// <param name="encoding">The document <see cref="Encoding"/>.</param>
    /// <returns>The root SGML element.</returns>
    public SgmlElement Parse(Stream stream, Encoding encoding)
    {
        using StreamReader reader = new(stream, encoding, leaveOpen: true);

        this.lineNumber = new SgmlHeaderParser().SkipToContent(reader);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            ++this.lineNumber;

            if (string.IsNullOrEmpty(line) == false)
            {
                var tags = line.Split("<");
                foreach (string tag in tags)
                {
                    if (string.IsNullOrWhiteSpace(tag) == false)
                    {
                        this.ProcessLine(Wellformed(tag));
                    }
                }
            }
        }

        return this.root;
    }

    private static string Wellformed(string tag)
    {
        if (tag.Contains('<', StringComparison.Ordinal) &&
            tag.Contains('>', StringComparison.Ordinal))
        {
            return tag;
        }
        else if (tag.Contains('>', StringComparison.Ordinal))
        {
            return "<" + tag;
        }
        else
        {
            return tag;
        }
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

        this.lastValueNode = this.currentNode.AddChild(new SgmlElement(tag, value, text, this.currentNode));
    }

    private void ProcessClosingTag(string tag)
    {
        string expectedTag = this.currentNode.Name;
        string expectedvalueTag = this.lastValueNode.Name;

        if (string.Equals(expectedTag, tag, StringComparison.OrdinalIgnoreCase))
        {
            this.currentNode = this.currentNode.Parent ?? this.root;
        }
        else if (string.Equals(expectedvalueTag, tag, StringComparison.OrdinalIgnoreCase))
        {
            // value node has closing tag, so we don't expect it anymore, current node does not change
            this.lastValueNode = SgmlElement.Empty;
        }
        else
        {
            throw new SgmlParseException($"Closing tag '{tag}' does not match opening tag '{expectedTag}' or '{expectedvalueTag}', line {this.lineNumber}.");
        }
    }
}
