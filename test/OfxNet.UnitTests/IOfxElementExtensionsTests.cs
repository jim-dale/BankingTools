namespace OfxNet.UnitTests;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
[ExcludeFromCodeCoverage]
public class IOfxElementExtensionsTests
{
    [TestMethod]
    public void GetDateTimeOffsetReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        var expected = DateTimeOffset.Parse("2001-02-03 12:34", CultureInfo.CurrentCulture);

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(OfxConstants.DateTimeFormats[3], CultureInfo.CurrentCulture),
                parent: element));

        DateTimeOffset actual = element.GetDateTimeOffset(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {nameof(DateTimeOffset)} should be returned.");
    }

    [TestMethod]
    public void GetDateTimeOffsetThrowsIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.ThrowsException<OfxException>(
            () => element.GetDateTimeOffset("missing child", OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not present.");
    }

    [TestMethod]
    public void GetDateTimeOffsetThrowsIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.ThrowsException<OfxException>(
            () => element.GetDateTimeOffset(testProperty, OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not parseable.");
    }

    [TestMethod]
    public void GetElementReturnsElementIfChildElementPresent()
    {
        string expectedName = "Property";
        string expectedValue = "Some random text";

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: expectedName,
                text: string.Empty,
                value: expectedValue,
                parent: element));

        IOfxElement actual = element.GetElement(expectedName, OfxDocumentSettings.Default);

        Assert.IsNotNull(
            actual,
            $"No {nameof(IOfxElement)} should be returned if it is present.");

        Assert.AreEqual(
            expectedName,
            actual.Name,
            $"The returned {nameof(IOfxElement)} should have the expected {nameof(IOfxElement.Name)}.");

        Assert.AreEqual(
            expectedValue,
            actual.Value,
            $"The returned {nameof(IOfxElement)} should have the expected {nameof(IOfxElement.Value)}.");
    }

    [TestMethod]
    public void GetElementThrowsIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.ThrowsException<OfxException>(
            () => element.GetElement("missing child", OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not present.");
    }

    [TestMethod]
    public void GetDecimalReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        decimal expected = 42;

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(CultureInfo.CurrentCulture),
                parent: element));

        decimal actual = element.GetDecimal(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {typeof(int)} should be returned.");
    }

    [TestMethod]
    public void GetDecimalThrowsIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.ThrowsException<OfxException>(
            () => element.GetDecimal("missing child", OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not present.");
    }

    [TestMethod]
    public void GetDecimalThrowsIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.ThrowsException<OfxException>(
            () => element.GetDecimal(testProperty, OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not parseable.");
    }

    [TestMethod]
    public void GetIntReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        int expected = 42;

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(CultureInfo.CurrentCulture),
                parent: element));

        int actual = element.GetInt(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {typeof(int)} should be returned.");
    }

    [TestMethod]
    public void GetIntThrowsIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.ThrowsException<OfxException>(
            () => element.GetInt("missing child", OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not present.");
    }

    [TestMethod]
    public void GetIntThrowsIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.ThrowsException<OfxException>(
            () => element.GetInt(testProperty, OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not parseable.");
    }

    [TestMethod]
    public void GetStringReturnsValueIfChildElementIsPresent()
    {
        string testProperty = "Property";
        string expected = "valid string";

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected,
                parent: element));

        string actual = element.GetString(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {nameof(SgmlElement.Value)} should be returned.");
    }

    [TestMethod]
    public void GetStringThrowsIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.ThrowsException<OfxException>(
            () => element.GetString("missing child", OfxDocumentSettings.Default),
            $"A {nameof(OfxException)} should be thrown if the child element is not present.");
    }

    [TestMethod]
    public void TryEnumerateElementsReturnsElementsIfChildElementsPresent()
    {
        string expectedName = "Property";
        int expectedCount = 3;

        SgmlElement element = new("Base", "<Base>");

        for (int i = 0; i < expectedCount; i++)
        {
            element.AddChild(
                new SgmlElement(
                    name: expectedName,
                    text: string.Empty,
                    value: $"child {i}",
                    parent: element));
        }

        element.AddChild(
            new SgmlElement(
                name: "some other child name",
                text: string.Empty,
                value: "element should not be in return count",
                parent: element));

        IEnumerable<IOfxElement> actual = element.TryEnumeratElements(expectedName, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expectedCount,
            actual.Count(),
            $"{expectedCount} child elements should be returned.");
    }

    [TestMethod]
    public void TryEnumerateElementsReturnsEmptyEnumerationIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.AreEqual(
            0,
            element.TryEnumeratElements("missing child", OfxDocumentSettings.Default).Count(),
            $"No {nameof(IOfxElement)}s should be returned if no child elements are not present.");
    }

    [TestMethod]
    public void TryEnumerateElementsReturnsElementsWithAnyName()
    {
        string[] elementsToFind = ["element1", "element2"];

        SgmlElement element = new("Base", "<Base>");

        foreach (var child in elementsToFind)
        {
            element.AddChild(
                new SgmlElement(
                    name: child,
                    text: string.Empty,
                    value: $"Child named {child}",
                    parent: element));
        }

        element.AddChild(
            new SgmlElement(
                name: "some other child name",
                text: string.Empty,
                value: "element should not be in return count",
                parent: element));

        IEnumerable<IOfxElement> actual = element.TryEnumeratElements(elementsToFind, OfxDocumentSettings.Default);

        Assert.AreEqual(
            elementsToFind.Length,
            actual.Count(),
            $"{elementsToFind.Length} child elements should be returned.");
    }

    [TestMethod]
    public void TryGetDateTimeOffsetReturnsNullIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.IsNull(
            element.TryGetDateTimeOffset("missing child", OfxDocumentSettings.Default),
            $"No {nameof(DateTimeOffset)} should be returned if the child element is not present.");
    }

    [TestMethod]
    public void TryGetDateTimeOffsetReturnsNullIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.IsNull(
            element.TryGetDateTimeOffset(testProperty, OfxDocumentSettings.Default),
            $"No {nameof(DateTimeOffset)} should be returned if the child element is not parseable.");
    }

    [TestMethod]
    public void TryGetDateTimeOffsetReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        var expected = DateTimeOffset.Parse("2025-10-12 13:05", CultureInfo.CurrentCulture);

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(OfxConstants.DateTimeFormats[3], CultureInfo.CurrentCulture),
                parent: element));

        DateTimeOffset? actual = element.TryGetDateTimeOffset(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {nameof(DateTimeOffset)} should be returned.");
    }

    [TestMethod]
    public void TryGetDecimalReturnsNullIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.IsNull(
            element.TryGetDecimal("missing child", OfxDocumentSettings.Default),
            $"No {typeof(decimal)} should be returned if the child element is not present.");
    }

    [TestMethod]
    public void TryGetDecimalReturnsNullIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.IsNull(
            element.TryGetDecimal(testProperty, OfxDocumentSettings.Default),
            $"No {typeof(decimal)} should be returned if the child element is not parseable.");
    }

    [TestMethod]
    public void TryGetDecimalReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        decimal expected = 42;

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(CultureInfo.CurrentCulture),
                parent: element));

        decimal? actual = element.TryGetDecimal(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {typeof(decimal)} should be returned.");
    }

    [TestMethod]
    public void TryGetElementReturnsElementIfChildElementPresent()
    {
        string expectedName = "Property";
        string expectedValue = "Some random text";

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: expectedName,
                text: string.Empty,
                value: expectedValue,
                parent: element));

        IOfxElement? actual = element.TryGetElement(expectedName, OfxDocumentSettings.Default);

        Assert.IsNotNull(
            actual,
            $"No {nameof(IOfxElement)} should be returned if it is present.");

        Assert.AreEqual(
            expectedName,
            actual.Name,
            $"The returned {nameof(IOfxElement)} should have the expected {nameof(IOfxElement.Name)}.");

        Assert.AreEqual(
            expectedValue,
            actual.Value,
            $"The returned {nameof(IOfxElement)} should have the expected {nameof(IOfxElement.Value)}.");
    }

    [TestMethod]
    public void TryGetElementReturnsNullIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.IsNull(
            element.TryGetElement("missing child", OfxDocumentSettings.Default),
            $"No {nameof(IOfxElement)} should be returned if the child element is not present.");
    }

    [TestMethod]
    public void TryGetIntReturnsNullIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.IsNull(
            element.TryGetInt("missing child", OfxDocumentSettings.Default),
            $"No {typeof(int)} should be returned if the child element is not present.");
    }

    [TestMethod]
    public void TryGetIntReturnsNullIfChildElementNotParseable()
    {
        string testProperty = "Property";
        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: "This is not parseable",
                parent: element));

        Assert.IsNull(
            element.TryGetInt(testProperty, OfxDocumentSettings.Default),
            $"No {typeof(int)} should be returned if the child element is not parseable.");
    }

    [TestMethod]
    public void TryGetIntReturnsValueIfChildElementPresentAndParseable()
    {
        string testProperty = "Property";
        int expected = 42;

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected.ToString(CultureInfo.CurrentCulture),
                parent: element));

        int? actual = element.TryGetInt(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {typeof(int)} should be returned.");
    }

    [TestMethod]
    public void TryGetStringReturnsNullIfChildElementMissing()
    {
        SgmlElement element = new("Base", "<Base>");

        Assert.IsNull(
            element.TryGetString("missing child", OfxDocumentSettings.Default),
            $"No {typeof(string)} should be returned if the child element is not present.");
    }

    [TestMethod]
    public void TryGetStringReturnsValueIfChildElementIsPresent()
    {
        string testProperty = "Property";
        string expected = "valid string";

        SgmlElement element = new("Base", "<Base>");
        element.AddChild(
            new SgmlElement(
                name: testProperty,
                text: string.Empty,
                value: expected,
                parent: element));

        string? actual = element.TryGetString(testProperty, OfxDocumentSettings.Default);

        Assert.AreEqual(
            expected,
            actual,
            $"The expected {nameof(SgmlElement.Value)} should be returned.");
    }
}
