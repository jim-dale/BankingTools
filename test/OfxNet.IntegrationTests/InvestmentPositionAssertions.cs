namespace OfxNet.IntegrationTests;

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfxNet.Investments;
using OfxNet.Investments.Positions;

[ExcludeFromCodeCoverage]
internal static class InvestmentPositionAssertions
{
    // FullXxx properties match the values for the corresponding positions in
    // SampleInvestmentStatement_FullTransactions.ofx for use in the test
    // GetSecuritiesHandlesFullSecurities
    public static readonly OfxDebtPosition FullDebtPosition = new()
    {
        Currency = new(1, "USD"),
        HeldInAcct = "CASH",
        Security = new OfxSecurityId()
        {
            Id = "FAKECUSIPDEBT",
            IdType = "CUSIP",
        },
        MarketValue = 750,
        Memo = "Test debt position",
        PositionType = "LONG",
        PriceAsOfDate = new DateTimeOffset(2025, 11, 14, 16, 0, 0, 0, TimeSpan.Zero),
        UnitPrice = 25,
        Units = 30,
    };

    public static readonly OfxMutualFundPosition FullMutualFundPosition = new()
    {
        Currency = new(1, "USD"),
        HeldInAcct = "CASH",
        Security = new OfxSecurityId()
        {
            Id = "FAKECUSIPMF",
            IdType = "CUSIP",
        },
        MarketValue = 750,
        Memo = "Test mutual fund position",
        PositionType = "LONG",
        PriceAsOfDate = new DateTimeOffset(2025, 11, 14, 16, 0, 0, 0, TimeSpan.Zero),
        ReinvestCapitalGains = "Y",
        ReinvestDividends = "Y",
        UnitPrice = 25,
        Units = 30,
        UnitsStreet = 5,
        UnitsUser = 10,
    };

    public static readonly OfxOptionPosition FullOptionPosition = new()
    {
        Currency = new(1, "USD"),
        HeldInAcct = "CASH",
        Security = new OfxSecurityId()
        {
            Id = "FAKECUSIPOPTION",
            IdType = "CUSIP",
        },
        MarketValue = 750,
        Memo = "Test option position",
        PositionType = "LONG",
        PriceAsOfDate = new DateTimeOffset(2025, 11, 14, 16, 0, 0, 0, TimeSpan.Zero),
        Secured = "Y",
        UnitPrice = 25,
        Units = 30,
    };

    public static readonly OfxOtherPosition FullOtherPosition = new()
    {
        Currency = new(1, "USD"),
        HeldInAcct = "CASH",
        Security = new OfxSecurityId()
        {
            Id = "FAKECUSIPOTHER",
            IdType = "CUSIP",
        },
        MarketValue = 750,
        Memo = "Test other position",
        PositionType = "LONG",
        PriceAsOfDate = new DateTimeOffset(2025, 11, 14, 16, 0, 0, 0, TimeSpan.Zero),
        UnitPrice = 25,
        Units = 30,
    };

    public static readonly OfxStockPosition FullStockPosition = new()
    {
        Currency = new(1, "USD"),
        HeldInAcct = "CASH",
        Security = new OfxSecurityId()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        MarketValue = 750,
        Memo = "Test stock position",
        PositionType = "LONG",
        PriceAsOfDate = new DateTimeOffset(2025, 11, 14, 16, 0, 0, 0, TimeSpan.Zero),
        ReinvestDividends = "Y",
        UnitPrice = 25,
        Units = 30,
        UnitsStreet = 0,
        UnitsUser = 100,
    };

    public static void AssertInvestmentPosition(OfxInvestmentPosition expected, OfxInvestmentPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxInvestmentPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxInvestmentPosition should not be null.");

        // Currency
        if (expected.Currency is not null || actual.Currency is not null)
        {
            Assert.IsNotNull(actual.Currency, "CURRENCY should not be null when expected is not null.");
            Assert.AreEqual(
                expected.Currency?.Rate,
                actual.Currency?.Rate,
                "CURRENCY.RATE does not match expected value.");
            Assert.AreEqual(
                expected.Currency?.Symbol,
                actual.Currency?.Symbol,
                "CURRENCY.SYMBOL does not match expected value.");
        }

        // HeldInAcct
        Assert.AreEqual(
            expected.HeldInAcct,
            actual.HeldInAcct,
            "HELDINACCT does not match expected value.");

        // MarketValue
        Assert.AreEqual(
            expected.MarketValue,
            actual.MarketValue,
            "MKTVAL does not match expected value.");

        // Memo
        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        // PositionType
        Assert.AreEqual(
            expected.PositionType,
            actual.PositionType,
            "POSTYPE does not match expected value.");

        // PriceAsOfDate
        Assert.AreEqual(
            expected.PriceAsOfDate,
            actual.PriceAsOfDate,
            "DTPRICEASOF does not match expected value.");

        // Security (required)
        Assert.IsNotNull(actual.Security, "SECID should not be null.");
        Assert.IsNotNull(expected.Security, "Expected SECID should not be null.");
        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");
        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        // UnitPrice
        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        // Units
        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertDebtPosition(OfxDebtPosition expected, OfxDebtPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxDebtPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxDebtPosition should not be null.");
        AssertInvestmentPosition(expected, actual);
    }

    public static void AssertMutualFundPosition(OfxMutualFundPosition expected, OfxMutualFundPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxMutualFundPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxMutualFundPosition should not be null.");
        AssertInvestmentPosition(expected, actual);

        // UnitsStreet
        Assert.AreEqual(
            expected.UnitsStreet,
            actual.UnitsStreet,
            "UNITSSTREET does not match expected value.");

        // UnitsUser
        Assert.AreEqual(
            expected.UnitsUser,
            actual.UnitsUser,
            "UNITSUSER does not match expected value.");

        // ReinvestDividends
        Assert.AreEqual(
            expected.ReinvestDividends,
            actual.ReinvestDividends,
            "REINVDIV does not match expected value.");

        // ReinvestCapitalGains
        Assert.AreEqual(
            expected.ReinvestCapitalGains,
            actual.ReinvestCapitalGains,
            "REINVCG does not match expected value.");
    }

    public static void AssertOptionPosition(OfxOptionPosition expected, OfxOptionPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxOptionPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxOptionPosition should not be null.");
        AssertInvestmentPosition(expected, actual);

        // Secured
        Assert.AreEqual(
            expected.Secured,
            actual.Secured,
            "SECURED does not match expected value.");
    }

    public static void AssertOtherPosition(OfxOtherPosition expected, OfxOtherPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxOtherPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxOtherPosition should not be null.");
        AssertInvestmentPosition(expected, actual);
    }

    public static void AssertStockPosition(OfxStockPosition expected, OfxStockPosition actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxStockPosition should not be null.");
        Assert.IsNotNull(expected, "Expected OfxStockPosition should not be null.");
        AssertInvestmentPosition(expected, actual);

        // UnitsStreet
        Assert.AreEqual(
            expected.UnitsStreet,
            actual.UnitsStreet,
            "UNITSSTREET does not match expected value.");

        // UnitsUser
        Assert.AreEqual(
            expected.UnitsUser,
            actual.UnitsUser,
            "UNITSUSER does not match expected value.");

        // ReinvestDividends
        Assert.AreEqual(
            expected.ReinvestDividends,
            actual.ReinvestDividends,
            "REINVDIV does not match expected value.");
    }
}
