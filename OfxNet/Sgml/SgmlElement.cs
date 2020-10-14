using System;
using System.Collections.Generic;
using System.Linq;

namespace OfxNet
{
    public class SgmlElement : IOfxElement
    {
        public string Name { get; }
        public string Value { get; }
        public string Text { get; }
        public SgmlElement Parent { get; }
        public IList<SgmlElement> Children { get; private set; }

        public SgmlElement(string name, string text)
            : this(name, null, text, null)
        {
        }

        public SgmlElement(string name, string text, SgmlElement parent)
            : this(name, null, text, parent)
        {
        }

        public SgmlElement(string name, string value, string text, SgmlElement parent)
        {
            Name = name;
            Value = value;
            Text = text;
            Parent = parent;
        }

        public SgmlElement AddChild(SgmlElement item)
        {
            if (Children is null)
            {
                Children = new List<SgmlElement>();
            }
            Children.Add(item);

            return item;
        }

        public IOfxElement Element(string name, StringComparer comparer)
        {
            return Children.SingleOrDefault(e => comparer.Equals(name, e.Name));
        }

        public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer)
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    if (comparer.Equals(name, child.Name))
                    {
                        yield return child;
                    }
                }
            }
        }
    }
}
