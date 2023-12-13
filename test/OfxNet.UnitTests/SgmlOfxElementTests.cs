namespace OfxNet.UnitTests;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SgmlOfxElementTests
{
    [TestMethod]
    public void GetRequiredChildElement_AndChildExists_Succeeds()
    {
        SgmlElement sut = new("OFX", "<OFX>");
        SgmlElement expected = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

        IOfxElement? actual = sut.Element("Exists", StringComparer.OrdinalIgnoreCase);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetRequiredChildElement_AndChildDoesNotExist_ReturnsNull()
    {
        SgmlElement sut = new("OFX", "<OFX>");
        _ = sut.AddChild(new SgmlElement("Exists", string.Empty, sut));

        IOfxElement? actual = sut.Element("NotExists", StringComparer.OrdinalIgnoreCase);

        Assert.IsNull(actual);
    }
}
