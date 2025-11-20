namespace OfxNet;

using System;
using System.Collections.Generic;

/// <summary>
/// Interface for elements within an SGML or XML document.
/// </summary>
public interface IOfxElement
{
    /// <summary>
    /// Gets the name of the element as a string.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the value of the element as a string.
    /// </summary>
    string? Value { get; }

    /// <summary>
    /// Searches for the child element matching the name specified.
    /// </summary>
    /// <param name="name">The name of the child element.</param>
    /// <param name="comparer">The <see cref="StringComparer"/> to use to match the element name.</param>
    /// <returns>The child element if found, otherwise <see langword="null"/>.</returns>
    IOfxElement? Element(string name, StringComparer comparer);

    /// <summary>
    /// Searches for all the child elements matching the name specified.
    /// </summary>
    /// <param name="name">The name of the child elements.</param>
    /// <param name="comparer">The <see cref="StringComparer"/> to use to match the element name.</param>
    /// <returns>The collection of child elements if found, otherwise an empty collection.</returns>
    IEnumerable<IOfxElement> Elements(string name, StringComparer comparer);

    /// <summary>
    /// Searches for all the child elements matching any of the names specified.
    /// </summary>
    /// <param name="names">The names of the child elements.</param>
    /// <param name="comparer">The <see cref="StringComparer"/> to use to match the element names.</param>
    /// <returns>The collection of child elements if found, otherwise an empty collection.</returns>
    IEnumerable<IOfxElement> Elements(string[] names, StringComparer comparer);
}
