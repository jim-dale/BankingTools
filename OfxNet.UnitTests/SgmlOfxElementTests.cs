using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//public string? Value { get; }
//public IOfxElement? Element(string name, StringComparer comparer);
//public IEnumerable<IOfxElement> Elements(string name, StringComparer comparer);
namespace OfxNet.UnitTests
{
    [TestClass]
    public class SgmlOfxElementTests
    {
        [TestMethod]
        public void GetRequiredChildElement_AndChildExists_Succeeds()
        {
            var sut = new SgmlElement("OFX", "<OFX>");
            var expected = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

            var actual = sut.Element("Exists", StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRequiredChildElement_AndChildDoesNotExist_ReturnsNull()
        {
            var sut = new SgmlElement("OFX", "<OFX>");
            _ = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

            var actual = sut.Element("NotExists", StringComparer.OrdinalIgnoreCase);

            Assert.IsNull(actual);
        }
    }
}
