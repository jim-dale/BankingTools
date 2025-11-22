namespace OfxNet.IntegrationTests;

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfxNet.Investments.Transactions;

[ExcludeFromCodeCoverage]
internal static class InvestmentTransactionAssertions
{
    // FullXxxTransaction properties match the values for the corresponding transactions
    // in the same fileSampleInvestmentStatement_AllFullTransactionTypes.ofx for use in
    // the test ParseInvestmentStatementsHandlesFullTransactions
    public static readonly OfxBuyDebt FullBuyDebtTransaction = new()
    {
        AccruedInterest = 10m,
        Commission = 5m,
        Currency = new(1m, "USD"),
        Fees = 0.5m,
        InstitutionId = "BUYDEBT001",
        Load = 0,
        Markup = 2,
        Memo = "Buy Debt Example",
        OriginalCurrency = new(1m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPDEBT",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 2, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV001",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 1,
        Total = -1000,
        TradeDate = new DateTimeOffset(2025, 10, 1, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 100,
        Units = 10,
    };

    public static readonly OfxBuyMutualFund FullBuyMutualFundTransaction = new()
    {
        BuyType = "BUY",
        Commission = 2m,
        Currency = new(1m, "USD"),
        Fees = 0.25m,
        InstitutionId = "BUYMF001",
        Load = 1,
        Markup = 1,
        Memo = "Buy MF Example",
        OriginalCurrency = new(1m, "USD"),
        RelatedInstitutionId = "REL001",
        Security = new()
        {
            Id = "FAKECUSIPMF",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 3, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV002",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0.5m,
        Total = -1000,
        TradeDate = new DateTimeOffset(2025, 10, 2, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 50m,
        Units = 20,
    };

    public static readonly OfxBuyOption FullBuyOptionTransaction = new()
    {
        Commission = 1m,
        Currency = new(1m, "USD"),
        Fees = 0.1m,
        InstitutionId = "BUYOPT001",
        Load = 0,
        Markup = 0.5m,
        Memo = "Buy Option Example",
        OptionBuyType = "BUYTOOPEN",
        OriginalCurrency = new(1m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPOPT",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 4, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV003",
        SharesPerContract = 100,
        SubAccountFund = "CASH",
        SubAccountSecurity = "MARGIN",
        Taxes = 0.2m,
        Total = -50,
        TradeDate = new DateTimeOffset(2025, 10, 3, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 10,
        Units = 5,
    };

    public static readonly OfxBuyOther FullBuyOtherTransaction = new()
    {
        Commission = 0m,
        Currency = new(1.0m, "USD"),
        Fees = 0m,
        InstitutionId = "BUYOTHER001",
        Load = 0m,
        Markup = 0m,
        Memo = "Buy Other Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPOTH",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 5, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV004",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0m,
        Total = -200m,
        TradeDate = new DateTimeOffset(2025, 10, 4, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 200m,
        Units = 1m,
    };

    public static readonly OfxBuyStock FullBuyStockTransaction = new()
    {
        BuyType = "BUY",
        Commission = 1m,
        Currency = new(1.0m, "USD"),
        Fees = 0.25m,
        InstitutionId = "BUYSTOCK001",
        Load = 0m,
        Markup = 0m,
        Memo = "Buy Stock Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 6, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV005",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0.5m,
        Total = -300m,
        TradeDate = new DateTimeOffset(2025, 10, 5, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 30m,
        Units = 10m,
    };

    public static readonly OfxCapitalReturn FullCapitalReturnTransaction = new()
    {
        Currency = new(1.0m, "USD"),
        InstitutionId = "RETOFCAP001",
        Memo = "Return of Capital Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 14, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV013",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Total = 100m,
        TradeDate = new DateTimeOffset(2025, 10, 13, 16, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxIncome FullIncomeTransaction = new()
    {
        Currency = new(1.0m, "USD"),
        IncomeType = "DIV",
        InstitutionId = "INCOME001",
        Memo = "Dividend Income Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 8, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV007",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        TaxExempt = "N",
        Total = 25m,
        TradeDate = new DateTimeOffset(2025, 10, 7, 16, 0, 0, TimeSpan.Zero),
        Withholding = 5m,
    };

    public static readonly OfxInvestmentExpense FullInvestmentExpenseTransaction = new()
    {
        Currency = new(1.0m, "USD"),
        InstitutionId = "INVEXPENSE001",
        Memo = "Investment Expense Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPEXP",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 10, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV008",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Total = -10m,
        TradeDate = new DateTimeOffset(2025, 10, 9, 16, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxJournalFund FullJournalFundTransaction = new()
    {
        InstitutionId = "JRNLFUND001",
        Memo = "Journal Fund Example",
        SettlementDate = new DateTimeOffset(2025, 10, 12, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV009",
        SubAccountFrom = "JRNLFUNDFROM",
        SubAccountTo = "JRNLFUNDTO",
        Total = 500m,
        TradeDate = new DateTimeOffset(2025, 10, 11, 16, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxJournalSecurity FullJournalSecurityTransaction = new()
    {
        InstitutionId = "JRNLSEC001",
        Memo = "Journal Security Example",
        Security = new()
        {
            Id = "FAKECUSIPSEC",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 13, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV010",
        SubAccountFrom = "JRNLSECFROM",
        SubAccountTo = "JRNLSECTO",
        TradeDate = new DateTimeOffset(2025, 10, 12, 16, 0, 0, TimeSpan.Zero),
        Units = 50m,
    };

    public static readonly OfxMarginInterest FullMarginInterestTransaction = new()
    {
        Currency = new(1.0m, "USD"),
        InstitutionId = "MARGININT001",
        Memo = "Margin Interest Example",
        OriginalCurrency = new(1.0m, "USD"),
        SettlementDate = new DateTimeOffset(2025, 10, 15, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV011",
        SubAccountFund = "MARGININTERESTTO",
        Total = 20m,
        TradeDate = new DateTimeOffset(2025, 10, 14, 16, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxOptionClosure FullOptionClosureTransaction = new()
    {
        Gain = 50m,
        InstitutionId = "CLOSUREOPT001",
        Memo = "Option Closure Example",
        OptAction = "EXERCISE",
        RelatedInstitutionId = "REL002",
        Security = new()
        {
            Id = "FAKECUSIPOPT",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 16, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV006",
        SharesPerContract = 100,
        SubAccountSecurity = "MARGIN",
        TradeDate = new DateTimeOffset(2025, 10, 15, 16, 0, 0, TimeSpan.Zero),
        Units = 2m,
    };

    public static readonly OfxReinvest FullReinvestTransaction = new()
    {
        Commission = 1m,
        Currency = new(1.0m, "USD"),
        Fees = 0.25m,
        IncomeType = "DIV",
        InstitutionId = "REINVEST001",
        Load = 0m,
        Memo = "Reinvest Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPMF",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 17, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV012",
        SubAccountSecurity = "CASH",
        TaxExempt = "N",
        Taxes = 0.5m,
        Total = 100m,
        TradeDate = new DateTimeOffset(2025, 10, 16, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 20m,
        Units = 1.25m,
    };

    public static readonly OfxSellDebt FullSellDebtTransaction = new()
    {
        AccruedInterest = 10m,
        Commission = 2m,
        Currency = new(1.0m, "USD"),
        Fees = 0.25m,
        InstitutionId = "SELLDEBT001",
        Load = 0m,
        Memo = "Sell Debt Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPDEBT",
            IdType = "CUSIP",
        },
        SellReason = "MATURITY",
        SettlementDate = new DateTimeOffset(2025, 10, 19, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV014",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0.5m,
        Total = 550m,
        TradeDate = new DateTimeOffset(2025, 10, 18, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 110m,
        Units = -5m,
    };

    public static readonly OfxSellMutualFund FullSellMutualFundTransaction = new()
    {
        AverageCostBasis = 500m,
        Commission = 1m,
        Currency = new(1.0m, "USD"),
        Fees = 0.1m,
        InstitutionId = "SELLMF001",
        Load = 0m,
        Memo = "Sell Mutual Fund Example",
        OriginalCurrency = new(1.0m, "USD"),
        RelatedInstitutionId = "REL003",
        Security = new()
        {
            Id = "FAKECUSIPMF",
            IdType = "CUSIP",
        },
        SellType = "SELL",
        SettlementDate = new DateTimeOffset(2025, 10, 20, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV015",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0.25m,
        Total = 550m,
        TradeDate = new DateTimeOffset(2025, 10, 19, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 55m,
        Units = -10m,
    };

    public static readonly OfxSellOption FullSellOptionTransaction = new()
    {
        Commission = 1m,
        Currency = new(1.0m, "USD"),
        Fees = 0.1m,
        InstitutionId = "SELLOPT001",
        Load = 0m,
        Memo = "Sell Option Example",
        OptionSellType = "SELLTOOPEN",
        OriginalCurrency = new(1.0m, "USD"),
        RelatedInstitutionId = "REL004",
        RelationType = "COVERED",
        Secured = "Y",
        Security = new()
        {
            Id = "FAKECUSIPOPT",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 21, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV016",
        SharesPerContract = 100,
        SubAccountFund = "CASH",
        SubAccountSecurity = "MARGIN",
        Taxes = 0.25m,
        Total = 75m,
        TradeDate = new DateTimeOffset(2025, 10, 20, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 15m,
        Units = 5m,
    };

    public static readonly OfxSellOther FullSellOtherTransaction = new()
    {
        Commission = 0m,
        Currency = new(1.0m, "USD"),
        Fees = 0m,
        InstitutionId = "SELLOTHER001",
        Load = 0m,
        Memo = "Sell Other Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPOTH",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 22, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV017",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 0m,
        Total = 250m,
        TradeDate = new DateTimeOffset(2025, 10, 21, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 250m,
        Units = 1m,
    };

    public static readonly OfxSellStock FullSellStockTransaction = new()
    {
        Commission = 2m,
        Currency = new(1.0m, "USD"),
        Fees = 0.25m,
        InstitutionId = "SELLSTOCK001",
        Load = 0m,
        Memo = "Sell Stock Example",
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SellType = "SELL",
        SettlementDate = new DateTimeOffset(2025, 10, 23, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV018",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        Taxes = 1m,
        Total = 1000m,
        TradeDate = new DateTimeOffset(2025, 10, 22, 16, 0, 0, TimeSpan.Zero),
        UnitPrice = 40m,
        Units = 25m,
    };

    public static readonly OfxSplit FullSplitTransaction = new()
    {
        Currency = new(1.0m, "USD"),
        Denominator = 1,
        FractionalCash = 0.5m,
        InstitutionId = "SPLIT001",
        Memo = "Split Example",
        NewUnits = 100m,
        Numerator = 2,
        OldUnits = 50m,
        OriginalCurrency = new(1.0m, "USD"),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 24, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV019",
        SubAccountFund = "CASH",
        SubAccountSecurity = "CASH",
        TradeDate = new DateTimeOffset(2025, 10, 23, 16, 0, 0, TimeSpan.Zero),
    };

    public static readonly OfxTransfer FullTransferTransaction = new()
    {
        AverageCostBasis = 100m,
        InstitutionId = "TRANSFER001",
        Memo = "Transfer Example",
        InvestmentAccountFrom = new()
        {
            AccountNumber = "ACC99999",
            BrokerId = "testbroker.com",
        },
        PositionType = "LONG",
        PurchaseDate = new DateTimeOffset(2025, 9, 1, 16, 0, 0, TimeSpan.Zero),
        Security = new()
        {
            Id = "FAKECUSIPSTK",
            IdType = "CUSIP",
        },
        SettlementDate = new DateTimeOffset(2025, 10, 25, 16, 0, 0, TimeSpan.Zero),
        ServerId = "SRV020",
        SubAccountSecurity = "CASH",
        TradeDate = new DateTimeOffset(2025, 10, 24, 16, 0, 0, TimeSpan.Zero),
        TransferAction = "IN",
        UnitPrice = 25m,
        Units = 100m,
    };

    // Per transaction type assert helpers to keep long assert chains out of the tests
    public static void AssertBuyDebtTransaction(OfxBuyDebt expected, OfxBuyDebt actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxBuyDebt should not be null.");

        Assert.AreEqual(
            expected.AccruedInterest,
            actual.AccruedInterest,
            "ACCRDINT does not match expected value.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Markup,
            actual.Markup,
            "MARKUP does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertBuyMutualFundTransaction(OfxBuyMutualFund expected, OfxBuyMutualFund actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxBuyMutualFund should not be null.");

        Assert.AreEqual(
            expected.BuyType,
            actual.BuyType,
            "BUYTYPE does not match expected value.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Markup,
            actual.Markup,
            "MARKUP does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.RelatedInstitutionId,
            actual.RelatedInstitutionId,
            "RELFITID does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertBuyOptionTransaction(OfxBuyOption expected, OfxBuyOption actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxBuyOption should not be null.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Markup,
            actual.Markup,
            "MARKUP does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.OptionBuyType,
            actual.OptionBuyType,
            "OPTBUYTYPE does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SharesPerContract,
            actual.SharesPerContract,
            "SHPERCTRCT does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertBuyOtherTransaction(OfxBuyOther expected, OfxBuyOther actual)
    {
        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Markup,
            actual.Markup,
            "MARKUP does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertBuyStockTransaction(OfxBuyStock expected, OfxBuyStock actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxBuyStock should not be null.");

        Assert.AreEqual(
            expected.BuyType,
            actual.BuyType,
            "BUYTYPE does not match expected value.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Markup,
            actual.Markup,
            "MARKUP does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertCapitalReturnTransaction(OfxCapitalReturn expected, OfxCapitalReturn actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxCapitalReturn should not be null.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");
    }

    public static void AssertIncomeTransaction(OfxIncome expected, OfxIncome actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxIncome should not be null.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.IncomeType,
            actual.IncomeType,
            "INCOMETYPE does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TaxExempt,
            actual.TaxExempt,
            "TAXEXEMPT does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.Withholding,
            actual.Withholding,
            "WITHHOLDING does not match expected value.");
    }

    public static void AssertInvestmentExpenseTransaction(OfxInvestmentExpense expected, OfxInvestmentExpense actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxInvestmentExpense should not be null.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");
    }

    public static void AssertJournalFundTransaction(OfxJournalFund expected, OfxJournalFund actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxJournalFund should not be null.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFrom,
            actual.SubAccountFrom,
            "SUBACCTFROM does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountTo,
            actual.SubAccountTo,
            "SUBACCTTO does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");
    }

    public static void AssertJournalSecurityTransaction(OfxJournalSecurity expected, OfxJournalSecurity actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxJournalSecurity should not be null.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFrom,
            actual.SubAccountFrom,
            "SUBACCTFROM does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountTo,
            actual.SubAccountTo,
            "SUBACCTTO does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertMarginInterestTransaction(OfxMarginInterest expected, OfxMarginInterest actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxMarginInterest should not be null.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");
    }

    public static void AssertOptionClosureTransaction(OfxOptionClosure expected, OfxOptionClosure actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxOptionClosure should not be null.");

        Assert.AreEqual(
            expected.Gain,
            actual.Gain,
            "GAIN does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.OptAction,
            actual.OptAction,
            "OPTACTION does not match expected value.");

        Assert.AreEqual(
            expected.RelatedInstitutionId,
            actual.RelatedInstitutionId,
            "RELFITID does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SharesPerContract,
            actual.SharesPerContract,
            "SHPERCTRCT does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertReinvestTransaction(OfxReinvest expected, OfxReinvest actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxReinvest should not be null.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.IncomeType,
            actual.IncomeType,
            "INCOMETYPE does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TaxExempt,
            actual.TaxExempt,
            "TAXEXEMPT does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSellDebtTransaction(OfxSellDebt expected, OfxSellDebt actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSellDebt should not be null.");

        Assert.AreEqual(
            expected.AccruedInterest,
            actual.AccruedInterest,
            "ACCRDINT does not match expected value.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SellReason,
            actual.SellReason,
            "SELLREASON does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSellMutualFundTransaction(OfxSellMutualFund expected, OfxSellMutualFund actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSellMutualFund should not be null.");

        Assert.AreEqual(
            expected.AverageCostBasis,
            actual.AverageCostBasis,
            "AVGCOSTBASIS does not match expected value.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.RelatedInstitutionId,
            actual.RelatedInstitutionId,
            "RELFITID does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SellType,
            actual.SellType,
            "SELLTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSellOptionTransaction(OfxSellOption expected, OfxSellOption actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSellOption should not be null.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.OptionSellType,
            actual.OptionSellType,
            "OPTSELLTYPE does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.RelatedInstitutionId,
            actual.RelatedInstitutionId,
            "RELFITID does not match expected value.");

        Assert.AreEqual(
            expected.RelationType,
            actual.RelationType,
            "RELTYPE does not match expected value.");

        Assert.AreEqual(
            expected.Secured,
            actual.Secured,
            "SECURED does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SharesPerContract,
            actual.SharesPerContract,
            "SHPERCTRCT does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSellOtherTransaction(OfxSellOther expected, OfxSellOther actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSellOther should not be null.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSellStockTransaction(OfxSellStock expected, OfxSellStock actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSellStock should not be null.");

        Assert.AreEqual(
            expected.Commission,
            actual.Commission,
            "COMMISSION does not match expected value.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Fees,
            actual.Fees,
            "FEES does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Load,
            actual.Load,
            "LOAD does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SellType,
            actual.SellType,
            "SELLTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.Taxes,
            actual.Taxes,
            "TAXES does not match expected value.");

        Assert.AreEqual(
            expected.Total,
            actual.Total,
            "TOTAL does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }

    public static void AssertSplitTransaction(OfxSplit expected, OfxSplit actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxSplit should not be null.");

        if (expected.Currency is null)
        {
            Assert.IsNull(expected.Currency, "CURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.Currency, "CURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.Currency is not null && actual.Currency is not null)
        {
            Assert.AreEqual(
                expected.Currency.Rate,
                actual.Currency.Rate,
                "CURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.Currency.Symbol,
                actual.Currency.Symbol,
                "CURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Denominator,
            actual.Denominator,
            "DENOMINATOR does not match expected value.");

        Assert.AreEqual(
            expected.FractionalCash,
            actual.FractionalCash,
            "FRACCASH does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.NewUnits,
            actual.NewUnits,
            "NEWUNITS does not match expected value.");

        Assert.AreEqual(
            expected.Numerator,
            actual.Numerator,
            "NUMERATOR does not match expected value.");

        Assert.AreEqual(
            expected.OldUnits,
            actual.OldUnits,
            "OLDUNITS does not match expected value.");

        if (expected.OriginalCurrency is null)
        {
            Assert.IsNull(expected.OriginalCurrency, "ORIGCURRENCY should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.OriginalCurrency, "ORIGCURRENCY should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.OriginalCurrency is not null && actual.OriginalCurrency is not null)
        {
            Assert.AreEqual(
                expected.OriginalCurrency.Rate,
                actual.OriginalCurrency.Rate,
                "ORIGCURRENCY.CURRATE does not match expected value.");

            Assert.AreEqual(
                expected.OriginalCurrency.Symbol,
                actual.OriginalCurrency.Symbol,
                "ORIGCURRENCY.CURSYM does not match expected value.");
        }

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountFund,
            actual.SubAccountFund,
            "SUBACCTFUND does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");
    }

    public static void AssertTransferTransaction(OfxTransfer expected, OfxTransfer actual)
    {
        Assert.IsNotNull(
            actual,
            "Parsed OfxTransfer should not be null.");

        Assert.AreEqual(
            expected.AverageCostBasis,
            actual.AverageCostBasis,
            "AVGCOSTBASIS does not match expected value.");

        Assert.AreEqual(
            expected.InstitutionId,
            actual.InstitutionId,
            "FITID does not match expected value.");

        if (expected.InvestmentAccountFrom is null)
        {
            Assert.IsNull(expected.InvestmentAccountFrom, "INVACCTFROM should be null.");
        }
        else
        {
            Assert.IsNotNull(expected.InvestmentAccountFrom, "INVACCTFROM should not be null.");
        }

        // Double check to satisfy compiler.
        if (expected.InvestmentAccountFrom is not null && actual.InvestmentAccountFrom is not null)
        {
            Assert.AreEqual(
                expected.InvestmentAccountFrom.AccountNumber,
                actual.InvestmentAccountFrom.AccountNumber,
                "INVACCTFROM.ACCTID does not match expected value.");

            Assert.AreEqual(
                expected.InvestmentAccountFrom.BrokerId,
                actual.InvestmentAccountFrom.BrokerId,
                "INVACCTFROM.BROKERID does not match expected value.");
        }

        Assert.AreEqual(
            expected.Memo,
            actual.Memo,
            "MEMO does not match expected value.");

        Assert.AreEqual(
            expected.PositionType,
            actual.PositionType,
            "POSTYPE does not match expected value.");

        Assert.AreEqual(
            expected.PurchaseDate,
            actual.PurchaseDate,
            "DTPURCHASE does not match expected value.");

        Assert.AreEqual(
            expected.Security.Id,
            actual.Security.Id,
            "SECID.UNIQUEID does not match expected value.");

        Assert.AreEqual(
            expected.Security.IdType,
            actual.Security.IdType,
            "SECID.UNIQUEIDTYPE does not match expected value.");

        Assert.AreEqual(
            expected.SettlementDate,
            actual.SettlementDate,
            "DTSETTLE does not match expected value.");

        Assert.AreEqual(
            expected.ServerId,
            actual.ServerId,
            "SRVRTID does not match expected value.");

        Assert.AreEqual(
            expected.SubAccountSecurity,
            actual.SubAccountSecurity,
            "SUBACCTSEC does not match expected value.");

        Assert.AreEqual(
            expected.TradeDate,
            actual.TradeDate,
            "DTTRADE does not match expected value.");

        Assert.AreEqual(
            expected.TransferAction,
            actual.TransferAction,
            "TFERACTION does not match expected value.");

        Assert.AreEqual(
            expected.UnitPrice,
            actual.UnitPrice,
            "UNITPRICE does not match expected value.");

        Assert.AreEqual(
            expected.Units,
            actual.Units,
            "UNITS does not match expected value.");
    }
}
