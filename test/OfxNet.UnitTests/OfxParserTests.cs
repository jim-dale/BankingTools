namespace OfxNet.UnitTests;

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class OfxParserTests
{
    [TestMethod]
    public void ParseInteger_WithNull_ReturnsExpectedValue()
    {
        (bool NullOrWhiteSpace, bool NotInteger, int Value) actual = OfxParser.ParseInteger(null);

        Assert.AreEqual((true, false, default(int)), actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(IntegerParserTestData), DynamicDataSourceType.Property)]
    public void ParseInteger_WithString_ReturnsExpectedValue(string str, (bool NullOrEmpty, bool NotInteger, int Value) expected)
    {
        (bool NullOrWhiteSpace, bool NotInteger, int Value) actual = OfxParser.ParseInteger(str);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ParseDecimal_WithNull_ReturnsExpectedValue()
    {
        (bool NullOrWhiteSpace, bool NotDecimal, decimal Value) actual = OfxParser.ParseDecimal(null);

        Assert.AreEqual((true, false, default(decimal)), actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(DecimalParserTestData), DynamicDataSourceType.Property)]
    public void ParseDecimal_WithString_ReturnsExpectedValue(string str, (bool NullOrEmpty, bool NotDecimal, decimal Value) expected)
    {
        (bool NullOrWhiteSpace, bool NotDecimal, decimal Value) actual = OfxParser.ParseDecimal(str);

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(OfxDateTimeTestData), DynamicDataSourceType.Property)]
    public void ParseDateTime_WithValidString_ReturnsCorrectDateTime(string str, DateTimeOffset expected)
    {
        DateTimeOffset actual = OfxParser.ParseDateTime(str);

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(OfxAccountTypeTestData), DynamicDataSourceType.Property)]
    public void ParseOfxAccountType_WithValidString_ReturnsExpectedValue(string str, OfxAccountType expected)
    {
        OfxAccountType actual = OfxParser.ParseAccountType(str);

        Assert.AreEqual(expected, actual);
    }

    private static IEnumerable<object[]> IntegerParserTestData
    {
        get
        {
            yield return new object[] { string.Empty, (true, false, default(int)) };
            yield return new object[] { "   ", (true, false, default(int)) };
            yield return new object[] { "Forty One", (false, true, default(int)) };
            yield return new object[] { "41.98", (false, true, default(int)) };
            yield return new object[] { "48", (false, false, 48) };
        }
    }

    private static IEnumerable<object[]> DecimalParserTestData
    {
        get
        {
            yield return new object[] { string.Empty, (true, false, default(decimal)) };
            yield return new object[] { "   ", (true, false, default(decimal)) };
            yield return new object[] { "Forty One", (false, true, default(decimal)) };
            yield return new object[] { "41.98", (false, false, 41.98M) };
        }
    }

    private static IEnumerable<object?[]> OfxAccountTypeTestData
    {
        get
        {
            yield return new object?[] { "MONEYMRKT", OfxAccountType.MONEYMRKT };
            yield return new object?[] { null, OfxAccountType.NotSet };
            yield return new object?[] { "NotValid", OfxAccountType.NotSet };
        }
    }

    private static IEnumerable<object[]> OfxDateTimeTestData
    {
        get
        {
            yield return new object[] { "20150602100000.000[-4:EDT]", new DateTimeOffset(2015, 6, 2, 10, 0, 0, new TimeSpan(-4, 0, 0)) };
            yield return new object[] { "199610291120", new DateTimeOffset(1996, 10, 29, 11, 20, 0, new TimeSpan(0, 0, 0)) };
            yield return new object[] { "19961005132200.124[-5:EST]", new DateTimeOffset(1996, 10, 5, 13, 22, 0, 124, new TimeSpan(-5, 0, 0)) };
            yield return new object[] { "20131205100000[-03:EST]", new DateTimeOffset(2013, 12, 5, 10, 0, 0, new TimeSpan(-3, 0, 0)) };
        }
    }
}
