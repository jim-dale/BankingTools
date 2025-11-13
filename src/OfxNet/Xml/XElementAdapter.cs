namespace OfxNet;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// The XElementAdapter provides a IOfxElement interface for built-in XElement objects.
/// </summary>
[SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "Not currently required.")]
public readonly struct XElementAdapter : IOfxElement
{
    private readonly XElement element;

    public XElementAdapter(XElement element)
    {
        this.element = element;
    }

    /// <inheritdoc/>
    public string Name => this.element.Name.LocalName;

    public string Value => this.element.Value;

    IOfxElement? IOfxElement.Element(string name, StringComparer comparer)
    {
        XElement? element = (from e in this.element.Elements()
                       where comparer.Equals(name, e.Name.LocalName)
                       select e)
                     .FirstOrDefault();

        return (element is null) ? null : new XElementAdapter(element);
    }

    public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer)
    {
        return from element in this.element.Elements()
               where comparer.Equals(name, element.Name.LocalName)
               select new XElementAdapter(element) as IOfxElement;
    }

    /// <inheritdoc/>
    public IEnumerable<IOfxElement> Elements(string[] names, StringComparer comparer)
    {
        HashSet<string> namesHash = new(names, comparer);

        return from element in this.element.Elements()
               where namesHash.Contains(element.Name.LocalName)
               select new XElementAdapter(element) as IOfxElement;
    }
}
