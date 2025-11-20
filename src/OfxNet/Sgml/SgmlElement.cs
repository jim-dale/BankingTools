namespace OfxNet;

using System;
using System.Collections.Generic;
using System.Linq;

public class SgmlElement : IOfxElement
{
    public static readonly SgmlElement Empty = new(string.Empty, string.Empty);

    public SgmlElement(string name, string text)
        : this(name, null, text, null)
    {
    }

    public SgmlElement(string name, string text, SgmlElement parent)
        : this(name, null, text, parent)
    {
    }

    public SgmlElement(string name, string? value, string text, SgmlElement? parent)
    {
        this.Name = name;
        this.Value = value;
        this.Text = text;
        this.Parent = parent;
    }

    /// <inheritdoc/>
    public string Name { get; }

    public string? Value { get; }

    public string Text { get; }

    public SgmlElement? Parent { get; }

    public IList<SgmlElement>? Children { get; private set; }

    public SgmlElement AddChild(SgmlElement item)
    {
        this.Children ??= new List<SgmlElement>();
        this.Children.Add(item);

        return item;
    }

    public IOfxElement? Element(string name, StringComparer comparer)
    {
        return this.Children?.SingleOrDefault(e => comparer.Equals(name, e.Name));
    }

    public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer)
    {
        ArgumentNullException.ThrowIfNull(comparer);

        if (this.Children != null)
        {
            foreach (SgmlElement child in this.Children)
            {
                if (comparer.Equals(name, child.Name))
                {
                    yield return child;
                }
            }
        }
    }

    /// <inheritdoc/>
    public IEnumerable<IOfxElement> Elements(string[] names, StringComparer comparer)
    {
        HashSet<string> namesHash = new(names, comparer);

        ArgumentNullException.ThrowIfNull(comparer);

        if (this.Children != null)
        {
            foreach (SgmlElement child in this.Children)
            {
                if (namesHash.Contains(child.Name))
                {
                    yield return child;
                }
            }
        }
    }
}
