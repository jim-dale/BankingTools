using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OfxNet.UnitTests
{
    [TestClass]
    public class OfxParserTests
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void ParseDateTime_WithValidString_ReturnsCorrectDateTime(string str, DateTimeOffset expected)
        {
            var actual = OfxParser.ParseDateTime(str);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> Data
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
}
