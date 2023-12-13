namespace OfxNet;

using System;
using System.Collections.Generic;

public interface IOfxElement
{
    public string? Value { get; }
    public IOfxElement? Element(string name, StringComparer comparer);
    public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer);
}
