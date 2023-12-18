namespace OfxNet.UnitTests;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SgmlOfxElementTests
{
    [TestMethod]
    public void GetRequiredChildElementAndChildExistsSucceeds()
    {
        SgmlElement sut = new("OFX", "<OFX>");
        SgmlElement expected = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

        IOfxElement? actual = sut.Element("Exists", StringComparer.OrdinalIgnoreCase);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetRequiredChildElementAndChildDoesNotExistReturnsNull()
    {
        SgmlElement sut = new("OFX", "<OFX>");
        _ = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

        IOfxElement? actual = sut.Element("NotExists", StringComparer.OrdinalIgnoreCase);

        Assert.IsNull(actual);
    }
}
