using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace OfxNet
{
    /// <summary>
    /// The XElementAdapter provides a IOfxElement interface for built-in XElement objects.
    /// </summary>
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "Not currently required.")]
    
    public struct XElementAdapter : IOfxElement
    {
        private readonly XElement _element;

        public XElementAdapter(XElement element)
        {
            _element = element;
        }

        public string Value => _element.Value;

        IOfxElement IOfxElement.Element(string name, StringComparer comparer)
        {
            var element = (from e in _element.Elements()
                           where comparer.Equals(name, e.Name.LocalName)
                           select e)
                         .FirstOrDefault();

            return (element is null) ? (IOfxElement)null : new XElementAdapter(element);
        }

        public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer)
        {
            return from element in _element.Elements()
                   where comparer.Equals(name, element.Name.LocalName)
                   select new XElementAdapter(element) as IOfxElement;
        }
    }
}
