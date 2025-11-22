namespace OfxNet.IntegrationTests;

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfxNet.Investments;
using OfxNet.Investments.Securities;

[ExcludeFromCodeCoverage]
internal static class InvestmentSecurityAssertions
{
    // FullXxx properties match the values for the corresponding securities in
    // SampleInvestmentStatement_FullSecurities.ofx for use in the test
    // GetSecuritiesHandlesFullSecurities
    public static readonly OfxDebtSecurity FullDebtSecurity = new()
    {
        AssetClass = "Fixed Income",
        CallDate = new DateTimeOffset(2025, 12, 1, 0, 0, 0, TimeSpan.Zero),
        CallPrice = 101.00m,
        CallType = "Callable",
        CouponDate = new DateTimeOffset(2025, 11, 1, 0, 0, 0, TimeSpan.Zero),
        CouponFrequency = "Semiannual",
        CouponRate = 0.05m,
        Currency = new OfxCurrency(1, "USD"),
        DebtClass = "Corporate",
        DebtType = "Bond",
        FinancialInstitutionId = "FIBROKER4",
        Id = "DBT111111",
        IdType = "CUSIP",
        InstitutionAssetClass = "Corporate Bond",
        Name = "Corporate Bond 2030",
        MaturityDate = new DateTimeOffset(2030, 12, 31, 0, 0, 0, TimeSpan.Zero),
        Memo = "Debt Example",
        ParValue = 1000m,
        Rating = "AA",
        Price = 102.50m,
        PriceAsOfDate = new DateTimeOffset(2025, 10, 15, 0, 0, 0, TimeSpan.Zero),
        Ticker = "CBND30",
        YieldToCall = 0.048m,
        YieldToMaturity = 0.05m,
    };

    public static readonly OfxMutualFundSecurity FullMutualFundSecurity = new()
    {
        Currency = new OfxCurrency(1, "USD"),
        FinancialInstitutionId = "FIBROKER1",
        Id = "MF123456",
        IdType = "CUSIP",
        InstitutionAssetClasses =
        [
            new OfxAssetClassPortion { AssetClass = "Domestic Equity", Percent = 60m },
            new OfxAssetClassPortion { AssetClass = "International Equity",  Percent = 40m },
        ],
        Memo = "Mutual Fund Example",
        MutualFundAssetClasses =
        [
            new() { AssetClass = "Equity", Percent = 70m },
            new() { AssetClass = "Bond", Percent = 30m },
        ],
        MutualFundType = "Growth",
        Name = "Global Equity Fund",
        Price = 25.75m,
        PriceAsOfDate = new DateTimeOffset(2025, 10, 15, 0, 0, 0, TimeSpan.Zero),
        Rating = "AAA",
        Ticker = "GEQF",
        Yield = 0.045m,
        YieldAsOfDate = new DateTimeOffset(2025, 10, 1, 0, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxOptionSecurity FullOptionSecurity = new()
    {
        AssetClass = "Derivative",
        Currency = new OfxCurrency(1, "USD"),
        ExpirationDate = new DateTimeOffset(2025, 12, 31, 0, 0, 0, TimeSpan.Zero),
        FinancialInstitutionId = "FIBROKER3",
        Id = "OPT555555",
        IdType = "CUSIP",
        InstitutionAssetClass = "Equity Option",
        Memo = "Option Example",
        Name = "TechCorp Call Option",
        OptionType = "CALL",
        Price = 5.25m,
        PriceAsOfDate = new DateTimeOffset(2025, 10, 15, 0, 0, 0, TimeSpan.Zero),
        Rating = "Speculative",
        Security = new OfxSecurityId() { Id = "STK987654", IdType = "CUSIP" },
        SharesPerContract = 100,
        StrikePrice = 120.00m,
        Ticker = "TCORP-CALL",
    };

    public static readonly OfxOtherSecurity FullOtherSecurity = new OfxOtherSecurity
    {
        AssetClass = "Alternative",
        Currency = new OfxCurrency(1, "USD"),
        FinancialInstitutionId = "FIBROKER5",
        Id = "OTH222222",
        IdType = "CUSIP",
        InstitutionAssetClass = "Commodities",
        Memo = "Other Security Example",
        Name = "Commodity Future",
        Price = 75.00m,
        PriceAsOfDate = new DateTimeOffset(2025, 10, 15, 0, 0, 0, TimeSpan.Zero),
        Rating = "High Risk",
        Ticker = "CMDFUT",
        TypeDescription = "Commodity Future Contract",
    };

    public static readonly OfxStockSecurity FullStockSecurity = new OfxStockSecurity
    {
        AssetClass = "Equity",
        Currency = new OfxCurrency(1, "USD"),
        FinancialInstitutionId = "FIBROKER2",
        Id = "STK987654",
        IdType = "CUSIP",
        InstitutionAssetClass = "Technology",
        Memo = "Stock Example",
        Name = "TechCorp Inc.",
        Price = 150.00m,
        PriceAsOfDate = new DateTimeOffset(2025, 10, 15, 0, 0, 0, TimeSpan.Zero),
        Rating = "A",
        StockType = "Common",
        Ticker = "TCORP",
        Yield = 0.02m,
        YieldAsOfDate = new DateTimeOffset(2025, 10, 1, 0, 0, 0, TimeSpan.Zero),
    };

    public static void AssertSecurity(OfxSecurity expected, OfxSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxSecurity should not be null.");

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

        // FinancialInstitutionId (FIID)
        Assert.AreEqual(
            expected.FinancialInstitutionId,
            actual.FinancialInstitutionId,
            "FIID does not match expected value.");

        // Memo
        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        // Name (required)
        Assert.IsNotNull(actual.Name, "SECNAME should not be null.");
        Assert.AreEqual(
            expected.Name,
            actual.Name,
            "SECNAME does not match expected value.");

        // Price (UNITPRICE)
        Assert.AreEqual(
            expected.Price,
            actual.Price,
            "UNITPRICE does not match expected value.");

        // PriceAsOfDate (DTASOF)
        Assert.AreEqual(
            expected.PriceAsOfDate,
            actual.PriceAsOfDate,
            "DTASOF does not match expected value.");

        // Rating
        Assert.AreEqual(
            expected.Rating,
            actual.Rating,
            "RATING does not match expected value.");

        // Ticker
        Assert.AreEqual(
            expected.Ticker,
            actual.Ticker,
            "TICKER does not match expected value.");

        // SecurityId (inherited from OfxSecurityId)
        Assert.IsNotNull(actual.Id, "SECID.UNIQUEID should not be null.");
        Assert.AreEqual(
            expected.Id,
            actual.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.IsNotNull(actual.IdType, "SECID.UNIQUEIDTYPE should not be null.");
        Assert.AreEqual(
            expected.IdType,
            actual.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");
    }

    public static void AssertDebtSecurity(OfxDebtSecurity expected, OfxDebtSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxDebtSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxDebtSecurity should not be null.");
        AssertSecurity(expected, actual);

        // AssetClass
        Assert.AreEqual(
            expected.AssetClass,
            actual.AssetClass,
            "ASSETCLASS does not match expected value.");

        // CallDate
        Assert.AreEqual(
            expected.CallDate,
            actual.CallDate,
            "DTCALL does not match expected value.");

        // CallPrice
        Assert.AreEqual(
            expected.CallPrice,
            actual.CallPrice,
            "CALLPRICE does not match expected value.");

        // CallType
        Assert.AreEqual(
            expected.CallType,
            actual.CallType,
            "CALLTYPE does not match expected value.");

        // CouponDate
        Assert.AreEqual(
            expected.CouponDate,
            actual.CouponDate,
            "DTCOUPON does not match expected value.");

        // CouponFrequency
        Assert.AreEqual(
            expected.CouponFrequency,
            actual.CouponFrequency,
            "COUPONFREQ does not match expected value.");

        // CouponRate
        Assert.AreEqual(
            expected.CouponRate,
            actual.CouponRate,
            "COUPONRT does not match expected value.");

        // DebtClass
        Assert.AreEqual(
            expected.DebtClass,
            actual.DebtClass,
            "DEBTCLASS does not match expected value.");

        // DebtType (required)
        Assert.IsNotNull(actual.DebtType, "DEBTTYPE should not be null.");
        Assert.AreEqual(
            expected.DebtType,
            actual.DebtType,
            "DEBTTYPE does not match expected value.");

        // InstitutionAssetClass
        Assert.AreEqual(
            expected.InstitutionAssetClass,
            actual.InstitutionAssetClass,
            "FIASSETCLASS does not match expected value.");

        // MaturityDate
        Assert.AreEqual(
            expected.MaturityDate,
            actual.MaturityDate,
            "DTMAT does not match expected value.");

        // ParValue (required)
        Assert.IsNotNull(actual.ParValue, "PARVALUE should not be null.");
        Assert.AreEqual(
            expected.ParValue,
            actual.ParValue,
            "PARVALUE does not match expected value.");

        // YieldToCall
        Assert.AreEqual(
            expected.YieldToCall,
            actual.YieldToCall,
            "YIELDTOCALL does not match expected value.");

        // YieldToMaturity
        Assert.AreEqual(
            expected.YieldToMaturity,
            actual.YieldToMaturity,
            "YIELDTOMAT does not match expected value.");
    }

    public static void AssertMutualFundSecurity(OfxMutualFundSecurity expected, OfxMutualFundSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxMutualFundSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxMutualFundSecurity should not be null.");
        AssertSecurity(expected, actual);

        // MutualFundType
        Assert.AreEqual(
            expected.MutualFundType,
            actual.MutualFundType,
            "MFTYPE does not match expected value.");

        // Yield
        Assert.AreEqual(
            expected.Yield,
            actual.Yield,
            "YIELD does not match expected value.");

        // YieldAsOfDate
        Assert.AreEqual(
            expected.YieldAsOfDate,
            actual.YieldAsOfDate,
            "DTYIELDASOF does not match expected value.");

        // MutualFundAssetClasses
        if (expected.MutualFundAssetClasses is not null || actual.MutualFundAssetClasses is not null)
        {
            Assert.IsNotNull(actual.MutualFundAssetClasses, "MFASSETCLASS should not be null when expected is not null.");
            Assert.AreEqual(
                expected.MutualFundAssetClasses?.Count,
                actual.MutualFundAssetClasses?.Count,
                "MFASSETCLASS count does not match expected value.");

            if (expected.MutualFundAssetClasses is not null && actual.MutualFundAssetClasses is not null)
            {
                for (int i = 0; i < expected.MutualFundAssetClasses.Count; i++)
                {
                    Assert.AreEqual(
                        expected.MutualFundAssetClasses[i].AssetClass,
                        actual.MutualFundAssetClasses[i].AssetClass,
                        $"MFASSETCLASS[{i}].ASSETCLASS does not match expected value.");

                    Assert.AreEqual(
                        expected.MutualFundAssetClasses[i].Percent,
                        actual.MutualFundAssetClasses[i].Percent,
                        $"MFASSETCLASS[{i}].PERCENT does not match expected value.");
                }
            }
        }

        // InstitutionAssetClasses
        if (expected.InstitutionAssetClasses is not null || actual.InstitutionAssetClasses is not null)
        {
            Assert.IsNotNull(actual.InstitutionAssetClasses, "FIMFASSETCLASS should not be null when expected is not null.");
            Assert.AreEqual(
                expected.InstitutionAssetClasses?.Count,
                actual.InstitutionAssetClasses?.Count,
                "FIMFASSETCLASS count does not match expected value.");

            if (expected.InstitutionAssetClasses is not null && actual.InstitutionAssetClasses is not null)
            {
                for (int i = 0; i < expected.InstitutionAssetClasses.Count; i++)
                {
                    Assert.AreEqual(
                        expected.InstitutionAssetClasses[i].AssetClass,
                        actual.InstitutionAssetClasses[i].AssetClass,
                        $"FIMFASSETCLASS[{i}].FIASSETCLASS does not match expected value.");

                    Assert.AreEqual(
                        expected.InstitutionAssetClasses[i].Percent,
                        actual.InstitutionAssetClasses[i].Percent,
                        $"FIMFASSETCLASS[{i}].PERCENT does not match expected value.");
                }
            }
        }
    }

    public static void AssertOptionSecurity(OfxOptionSecurity expected, OfxOptionSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxOptionSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxOptionSecurity should not be null.");
        AssertSecurity(expected, actual);

        // AssetClass
        Assert.AreEqual(
            expected.AssetClass,
            actual.AssetClass,
            "ASSETCLASS does not match expected value.");

        // ExpirationDate (required)
        Assert.IsNotNull(actual.ExpirationDate, "DTEXPIRE should not be null.");
        Assert.AreEqual(
            expected.ExpirationDate,
            actual.ExpirationDate,
            "DTEXPIRE does not match expected value.");

        // InstitutionAssetClass
        Assert.AreEqual(
            expected.InstitutionAssetClass,
            actual.InstitutionAssetClass,
            "FIASSETCLASS does not match expected value.");

        // OptionType (required)
        Assert.IsNotNull(actual.OptionType, "OPTTYPE should not be null.");
        Assert.AreEqual(
            expected.OptionType,
            actual.OptionType,
            "OPTTYPE does not match expected value.");

        // Security (optional nested OfxSecurityId)
        if (expected.Security is not null || actual.Security is not null)
        {
            Assert.IsNotNull(actual.Security, "SECID should not be null when expected is not null.");
            Assert.AreEqual(
                expected.Security?.Id,
                actual.Security?.Id,
                "SECID.UNIQUEID does not match expected value.");
            Assert.AreEqual(
                expected.Security?.IdType,
                actual.Security?.IdType,
                "SECID.UNIQUEIDTYPE does not match expected value.");
        }

        // SharesPerContract (required)
        Assert.AreEqual(
            expected.SharesPerContract,
            actual.SharesPerContract,
            "SHPERCTRCT does not match expected value.");

        // StrikePrice (required)
        Assert.AreEqual(
            expected.StrikePrice,
            actual.StrikePrice,
            "STRIKEPRICE does not match expected value.");
    }

    public static void AssertOtherSecurity(OfxOtherSecurity expected, OfxOtherSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxOtherSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxOtherSecurity should not be null.");
        AssertSecurity(expected, actual);

        // AssetClass
        Assert.AreEqual(
            expected.AssetClass,
            actual.AssetClass,
            "ASSETCLASS does not match expected value.");

        // InstitutionAssetClass
        Assert.AreEqual(
            expected.InstitutionAssetClass,
            actual.InstitutionAssetClass,
            "FIASSETCLASS does not match expected value.");

        // TypeDescription
        Assert.AreEqual(
            expected.TypeDescription,
            actual.TypeDescription,
            "TYPEDESC does not match expected value.");
    }

    public static void AssertStockSecurity(OfxStockSecurity expected, OfxStockSecurity actual)
    {
        Assert.IsNotNull(actual, "Parsed OfxStockSecurity should not be null.");
        Assert.IsNotNull(expected, "Expected OfxStockSecurity should not be null.");
        AssertSecurity(expected, actual);

        // AssetClass
        Assert.AreEqual(
            expected.AssetClass,
            actual.AssetClass,
            "ASSETCLASS does not match expected value.");

        // InstitutionAssetClass
        Assert.AreEqual(
            expected.InstitutionAssetClass,
            actual.InstitutionAssetClass,
            "FIASSETCLASS does not match expected value.");

        // StockType
        Assert.AreEqual(
            expected.StockType,
            actual.StockType,
            "STOCKTYPE does not match expected value.");

        // Yield
        Assert.AreEqual(
            expected.Yield,
            actual.Yield,
            "YIELD does not match expected value.");

        // YieldAsOfDate
        Assert.AreEqual(
            expected.YieldAsOfDate,
            actual.YieldAsOfDate,
            "DTYIELDASOF does not match expected value.");
    }
}
