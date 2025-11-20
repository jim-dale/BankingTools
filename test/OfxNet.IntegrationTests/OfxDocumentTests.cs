namespace OfxNet.IntegrationTests;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfxNet.Investments;
using OfxNet.Investments.Positions;
using OfxNet.Investments.Securities;
using OfxNet.Investments.Transactions;

[TestClass]
[ExcludeFromCodeCoverage]
public class OfxDocumentTests
{
    public static IEnumerable<object[]> SampleOfxFiles
    {
        get
        {
            yield return new object[] { "Sample-empty-balance.ofx", 1, 3 };
            yield return new object[] { "SampleBankStatement-1.ofx", 1, 3 };
            yield return new object[] { "SampleBankStatement-2.ofx", 1, 2 };
            yield return new object[] { "SampleCreditCardStatement.ofx", 1, 1 };
            yield return new object[] { "SampleMultiStatement.ofx", 2, 3 };
            yield return new object[] { "SampleSignOnResponse.ofx", 0, 0 };
            yield return new object[] { "Sample-itau.ofx", 1, 3 };
            yield return new object[] { "Sample-santander.ofx", 1, 3 };
            yield return new object[] { "Sample-Banco do Brasil.ofx", 1, 3 };

            // added to test multi-tags per line
            yield return new object[] { "SampleBankStatement_tangerine.ofx", 1, 0 };
            yield return new object[] { "SampleBankStatement_cibc.ofx", 1, 6 };
            yield return new object[] { "SampleCreditCardStatement_cibc.ofx", 1, 4 };
        }
    }

    [TestInitialize]
    public void Setup()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    [DataTestMethod]
    [DynamicData(nameof(SampleOfxFiles), DynamicDataSourceType.Property)]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Required for testing.")]
    public void OfxDocumentLoadSucceeds(string path, int statementCount, int txCount)
    {
        var actual = OfxDocument.Load(path);
        Assert.IsNotNull(actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(SampleOfxFiles), DynamicDataSourceType.Property)]
    public void OfxDocumentLoadGetStatementsReturnsCorrectNumberOfStatementsAndTransactions(string path, int statementCount, int txCount)
    {
        var actual = OfxDocument.Load(path);
        Assert.IsNotNull(actual);

        OfxStatement[] allStatements = actual.GetStatements().ToArray();
        Assert.AreEqual(statementCount, allStatements.Length);

        IEnumerable<OfxStatementTransaction> allTransactions = allStatements.SelectMany(s => s.TransactionList!.Transactions);
        Assert.AreEqual(txCount, allTransactions.Count());
    }

    [DataTestMethod]
    [DynamicData(nameof(SampleOfxFiles), DynamicDataSourceType.Property)]
    public void OfxDocumentLoadStreamGetStatementsReturnsCorrectNumberOfStatementsAndTransactions(string path, int statementCount, int txCount)
    {
        using var stream = File.OpenRead(path);

        var actual = OfxDocument.Load(stream);
        Assert.IsNotNull(actual);

        OfxStatement[] allStatements = actual.GetStatements().ToArray();
        Assert.AreEqual(statementCount, allStatements.Length);

        IEnumerable<OfxStatementTransaction> allTransactions = allStatements.SelectMany(s => s.TransactionList!.Transactions);
        Assert.AreEqual(txCount, allTransactions.Count());
    }

    [TestMethod]
    public void CanParseItau()
    {
        string[] expectedMemos = ["RSHOP", "REND PAGO APLIC AUT MAIS", "SISDEB"];

        IEnumerable<OfxStatement> actual = OfxDocument.Load(@"Sample-itau.ofx")
            .GetStatements();

        OfxStatement statement = actual.First();
        Assert.IsInstanceOfType<OfxBankStatement>(statement);
        var bankStatement = statement as OfxBankStatement;
        Assert.IsNotNull(bankStatement);
        Assert.IsNotNull(bankStatement.Account);

        Assert.AreEqual("9999 99999-9", bankStatement.Account.AccountNumber);
        Assert.AreEqual("0341", bankStatement.Account.BankId);

        Assert.IsNotNull(statement.TransactionList);
        Assert.AreEqual(3, statement.TransactionList.Transactions.Count);

        string?[] actualMemos = statement.TransactionList.Transactions.Select(x => x.Memo).ToArray();
        CollectionAssert.AreEqual(actualMemos, expectedMemos);
    }

    [TestMethod]
    public void CanParseBancoDoBrasil()
    {
        string[] expectedMemos = ["Transferência Agendada", "Compra com Cartão", "Saque"];

        IEnumerable<OfxStatement> actual = OfxDocument.Load("Sample-Banco do Brasil.ofx")
            .GetStatements();

        OfxStatement statement = actual.First();
        Assert.IsInstanceOfType<OfxBankStatement>(statement);
        var bankStatement = statement as OfxBankStatement;
        Assert.IsNotNull(bankStatement);
        Assert.IsNotNull(bankStatement.Account);

        Assert.AreEqual(bankStatement.Account.AccountNumber, "99999-9");
        Assert.AreEqual(bankStatement.Account.BranchId, "9999-9");
        Assert.AreEqual(bankStatement.Account.BankId, "1");

        Assert.IsNotNull(statement.TransactionList);
        Assert.AreEqual(3, statement.TransactionList.Transactions.Count);

        string?[] actualMemos = statement.TransactionList.Transactions.Select(x => x.Memo).ToArray();
        CollectionAssert.AreEqual(actualMemos, expectedMemos);
    }

    [TestMethod]
    public void CanParseEmptyBalance()
    {
        IEnumerable<OfxStatement> actual = OfxDocument.Load("Sample-empty-balance.ofx")
            .GetStatements();

        OfxStatement statement = actual.First();
        Assert.IsInstanceOfType<OfxBankStatement>(statement);
        var bankStatement = statement as OfxBankStatement;
        Assert.IsNotNull(bankStatement);
        Assert.IsNotNull(bankStatement.Account);

        Assert.AreEqual(bankStatement.Account.AccountNumber, "9999999999999");
        Assert.IsNull(bankStatement.Account.BranchId);
        Assert.AreEqual(bankStatement.Account.BankId, "033");
        Assert.IsNotNull(statement.TransactionList);

        Assert.AreEqual(3, statement.TransactionList.Transactions.Count);

        Assert.IsNull(bankStatement.LedgerBalance);
    }

    [TestMethod] // Validates multiple investment statements can be found in a single file.
    public void GetInvestmentStatementsFindsMultipleStatements()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_ThreeStatements.ofx");
        Assert.AreEqual(
            3,
            document.GetInvestmentStatements().Count(),
            "Three investment statements should have been loaded.");
    }

    [TestMethod] // Validates full balance definition correctly.
    public void GetInvestmentStatementsHandlesFullBalances()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_FullBalances.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Balances,
            "Balances should have been loaded.");

        Assert.IsNotNull(
            statement.Balances!.Other,
            "'other' balance should have been populated.");

        Assert.AreEqual(
            1,
            statement.Balances!.Other.Count,
            "One 'other' balance should have been loaded.");

        OfxBalance other = statement.Balances!.Other[0];

        Assert.AreEqual(
            15234.56m,
            other.Balance,
            $"{other.Balance} should have been loaded correctly.");

        Assert.AreEqual(
            "AVAIL",
            other.BalanceType,
            $"{other.BalanceType} should have been loaded correctly.");

        Assert.IsNotNull(
            other.Currency,
            $"{other.Currency} should not be null.");

        Assert.AreEqual(
            1m,
            other.Currency.Rate,
            $"{other.Currency!.Rate} should have been loaded correctly.");

        Assert.AreEqual(
            "USD",
            other.Currency.Symbol,
            $"{other.Currency!.Symbol} should have been loaded correctly.");

        Assert.AreEqual(
            new DateTimeOffset(2025, 11, 18, 18, 0, 0, 0, TimeSpan.Zero),
            other.DateAsOf,
            $"{other.DateAsOf} should have been loaded correctly.");

        Assert.AreEqual(
            "Funds part of some other balance.",
            other.Description,
            $"{other.Name} should have been loaded correctly.");

        Assert.AreEqual(
            "Other balance",
            other.Name,
            $"{other.Name} should have been loaded correctly.");
    }

    [TestMethod] // Validates full positions of each type can be loaded correctly.
    public void GetInvestmentStatementsHandlesBankTransactions()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_BankTransactions.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Transactions,
            "A transaction list should be loaded.");

        Assert.AreEqual(
            2,
            statement.Transactions!.BankTransactions.Count,
            "Two bank transactions should have been loaded.");

        // TODO: Validate the transaction has all the expected values.
    }

    [TestMethod] // Validates full positions of each type can be loaded correctly.
    public void GetInvestmentStatementsHandlesFullPositions()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_FullTransactions.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Positions,
            "A position list should be loaded.");

        Assert.AreEqual(
            5,
            statement.Positions!.InvestmentPositions.Count,
            "Five positions should have been loaded.");

        Assert.AreEqual(
            5,
            statement.Positions!.InvestmentPositions.DistinctBy(t => t.GetType()).Count(),
            "Each position should be of a distinct type for this test.");

        foreach (var position in statement.Positions!.InvestmentPositions)
        {
            switch (position)
            {
                case OfxDebtPosition debtPosition:
                    InvestmentPositionAssertions.AssertDebtPosition(InvestmentPositionAssertions.FullDebtPosition, debtPosition);
                    break;

                case OfxMutualFundPosition mutualFundPosition:
                    InvestmentPositionAssertions.AssertMutualFundPosition(InvestmentPositionAssertions.FullMutualFundPosition, mutualFundPosition);
                    break;

                case OfxOptionPosition optionPosition:
                    InvestmentPositionAssertions.AssertOptionPosition(InvestmentPositionAssertions.FullOptionPosition, optionPosition);
                    break;

                case OfxOtherPosition otherPosition:
                    InvestmentPositionAssertions.AssertOtherPosition(InvestmentPositionAssertions.FullOtherPosition, otherPosition);
                    break;

                case OfxStockPosition stockPosition:
                    InvestmentPositionAssertions.AssertStockPosition(InvestmentPositionAssertions.FullStockPosition, stockPosition);
                    break;

                default:
                    Assert.Fail($"Unexpected position type {position}");
                    break;
            }
        }
    }

    [TestMethod] // Validates full transactions of each type can be loaded.
    public void GetInvestmentStatementsHandlesFullTransactions()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_FullTransactions.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Transactions,
            "A transaction list should be loaded.");

        Assert.AreEqual(
            20,
            statement.Transactions!.InvestmentTransactions.Count,
            "Twenty transactions should have been loaded.");

        Assert.AreEqual(
            20,
            statement.Transactions!.InvestmentTransactions.DistinctBy(t => t.GetType()).Count(),
            "Each transaction should be of a distinct type for this test.");

        foreach (var transaction in statement.Transactions!.InvestmentTransactions)
        {
            switch (transaction)
            {
                case OfxBuyDebt buyDebt:
                    InvestmentTransactionAssertions.AssertBuyDebtTransaction(InvestmentTransactionAssertions.FullBuyDebtTransaction, buyDebt);
                    break;

                case OfxBuyMutualFund buyMutualFund:
                    InvestmentTransactionAssertions.AssertBuyMutualFundTransaction(InvestmentTransactionAssertions.FullBuyMutualFundTransaction, buyMutualFund);
                    break;

                case OfxBuyOption buyOption:
                    InvestmentTransactionAssertions.AssertBuyOptionTransaction(InvestmentTransactionAssertions.FullBuyOptionTransaction, buyOption);
                    break;

                case OfxBuyOther buyOther:
                    InvestmentTransactionAssertions.AssertBuyOtherTransaction(InvestmentTransactionAssertions.FullBuyOtherTransaction, buyOther);
                    break;

                case OfxBuyStock buyStock:
                    InvestmentTransactionAssertions.AssertBuyStockTransaction(InvestmentTransactionAssertions.FullBuyStockTransaction, buyStock);
                    break;

                case OfxCapitalReturn capitalReturn:
                    InvestmentTransactionAssertions.AssertCapitalReturnTransaction(InvestmentTransactionAssertions.FullCapitalReturnTransaction, capitalReturn);
                    break;

                case OfxIncome income:
                    InvestmentTransactionAssertions.AssertIncomeTransaction(InvestmentTransactionAssertions.FullIncomeTransaction, income);
                    break;

                case OfxInvestmentExpense invExpense:
                    InvestmentTransactionAssertions.AssertInvestmentExpenseTransaction(InvestmentTransactionAssertions.FullInvestmentExpenseTransaction, invExpense);
                    break;

                case OfxJournalFund journalFund:
                    InvestmentTransactionAssertions.AssertJournalFundTransaction(InvestmentTransactionAssertions.FullJournalFundTransaction, journalFund);
                    break;

                case OfxJournalSecurity journalSecurity:
                    InvestmentTransactionAssertions.AssertJournalSecurityTransaction(InvestmentTransactionAssertions.FullJournalSecurityTransaction, journalSecurity);
                    break;

                case OfxMarginInterest marginInterest:
                    InvestmentTransactionAssertions.AssertMarginInterestTransaction(InvestmentTransactionAssertions.FullMarginInterestTransaction, marginInterest);
                    break;

                case OfxOptionClosure optionClosure:
                    InvestmentTransactionAssertions.AssertOptionClosureTransaction(InvestmentTransactionAssertions.FullOptionClosureTransaction, optionClosure);
                    break;

                case OfxReinvest reinvest:
                    InvestmentTransactionAssertions.AssertReinvestTransaction(InvestmentTransactionAssertions.FullReinvestTransaction, reinvest);
                    break;

                case OfxSellDebt sellDebt:
                    InvestmentTransactionAssertions.AssertSellDebtTransaction(InvestmentTransactionAssertions.FullSellDebtTransaction, sellDebt);
                    break;

                case OfxSellMutualFund sellMutualFund:
                    InvestmentTransactionAssertions.AssertSellMutualFundTransaction(InvestmentTransactionAssertions.FullSellMutualFundTransaction, sellMutualFund);
                    break;

                case OfxSellOption sellOption:
                    InvestmentTransactionAssertions.AssertSellOptionTransaction(InvestmentTransactionAssertions.FullSellOptionTransaction, sellOption);
                    break;

                case OfxSellOther sellOther:
                    InvestmentTransactionAssertions.AssertSellOtherTransaction(InvestmentTransactionAssertions.FullSellOtherTransaction, sellOther);
                    break;

                case OfxSellStock sellStock:
                    InvestmentTransactionAssertions.AssertSellStockTransaction(InvestmentTransactionAssertions.FullSellStockTransaction, sellStock);
                    break;

                case OfxSplit split:
                    InvestmentTransactionAssertions.AssertSplitTransaction(InvestmentTransactionAssertions.FullSplitTransaction, split);
                    break;

                case OfxTransfer transfer:
                    InvestmentTransactionAssertions.AssertTransferTransaction(InvestmentTransactionAssertions.FullTransferTransaction, transfer);
                    break;

                default:
                    Assert.Fail($"Unexpected transaction type {transaction}");
                    break;
            }
        }
    }

    [TestMethod] // Validates a statement with only required elements can be loaded.
    public void GetInvestmentStatementsHandlesMinimalStatement()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_MinimalStatement.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");
    }

    [TestMethod] // Validates a statement with only minimal versions of transactions and positions can be loaded.
    public void GetInvestmentStatementsHandlesMinimalTransactions()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_MinimalTransactions.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Transactions,
            "A transaction list should be loaded.");

        Assert.AreEqual(
            20,
            statement.Transactions!.InvestmentTransactions.Count,
            "Twenty transactions should have been loaded.");

        Assert.AreEqual(
            20,
            statement.Transactions!.InvestmentTransactions.DistinctBy(t => t.GetType()).Count(),
            "Each transaction should be of a distinct type.");

        // Intentionally skip deep validation since ParseInvestmentStatementsHandlesFullTransactions
        // already handles that.
    }

    [TestMethod] // Test file https://github.com/kedder/ofxstatement/blob/master/doc/ofx_sample_files/ofx_spec201_invest_transactions_example.xml converted to OFX.
    public void GetInvestmentStatementsHandlesReferenceExample()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_ReferenceExample.ofx");
        List<OfxInvestmentStatement> statements = document.GetInvestmentStatements().ToList();

        Assert.AreEqual(
            1,
            document.GetInvestmentStatements().Count(),
            "Investment statement should have been loaded.");

        OfxInvestmentStatement statement = statements.First();

        Assert.IsNotNull(
            statement.Transactions,
            "A transaction list should be loaded.");

        Assert.AreEqual(
            3,
            statement.Transactions!.InvestmentTransactions.Count,
            "Three transactions should have been loaded.");
    }

    [TestMethod] // Validates GetSecurities() can load a security of each type that includes all optional fields.
    public void GetSecuritiesHandlesFullSecurities()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_FullSecurities.ofx");
        List<OfxSecurity> securities = [.. document.GetSecurities()];

        Assert.AreEqual(
            5,
            securities.Count,
            "Only five reference securities should be present.");

        Assert.AreEqual(
            5,
            securities.DistinctBy(s => s.GetType()).Count(),
            "Each security should be of a distinct type for this test.");

        foreach (var security in securities)
        {
            switch (security)
            {
                case OfxDebtSecurity debtSecurity:
                    InvestmentSecurityAssertions.AssertDebtSecurity(InvestmentSecurityAssertions.FullDebtSecurity, debtSecurity);
                    break;

                case OfxMutualFundSecurity mutualFundSecurity:
                    InvestmentSecurityAssertions.AssertMutualFundSecurity(InvestmentSecurityAssertions.FullMutualFundSecurity, mutualFundSecurity);
                    break;

                case OfxOptionSecurity optionSecurity:
                    InvestmentSecurityAssertions.AssertOptionSecurity(InvestmentSecurityAssertions.FullOptionSecurity, optionSecurity);
                    break;

                case OfxOtherSecurity otherSecurity:
                    InvestmentSecurityAssertions.AssertOtherSecurity(InvestmentSecurityAssertions.FullOtherSecurity, otherSecurity);
                    break;

                case OfxStockSecurity stockSecurity:
                    InvestmentSecurityAssertions.AssertStockSecurity(InvestmentSecurityAssertions.FullStockSecurity, stockSecurity);
                    break;

                default:
                    Assert.Fail("Unexpected security type {security}");
                    break;
            }
        }
    }

    [TestMethod] // Validates GetSecurities() can load a security of each type that include only required fields.
    public void GetSecuritiesHandlesMinimalSecurities()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_MinimalSecurities.ofx");
        List<OfxSecurity> securities = [.. document.GetSecurities()];

        Assert.AreEqual(
            5,
            securities.Count,
            "Five securities should have been loaded.");

        // Deep validation deferred to GetSecuritiesHandlesFullSecurities.
    }

    [TestMethod] // Test file https://github.com/kedder/ofxstatement/blob/master/doc/ofx_sample_files/ofx_spec201_invest_transactions_example.xml converted to OFX.
    public void GetSecuritiesHandlesReferenceExample()
    {
        OfxDocument document = OfxDocument.Load(@"SampleInvestmentStatement_ReferenceExample.ofx");
        List<OfxSecurity> securities = [.. document.GetSecurities()];

        Assert.AreEqual(
            2,
            securities.Count,
            "Two securities should have been loaded.");
    }
}
