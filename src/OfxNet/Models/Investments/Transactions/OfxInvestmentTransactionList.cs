namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents the investment transaction list (<c>INVTRANLIST</c> aggregate).
/// </summary>
/// <remarks>
/// The <c>INVTRANLIST</c> aggregate contains a date range and zero or more
/// investment transactions such as buys, sells, income, expenses, transfers,
/// splits, journals, reinvestments, capital returns, margin interest, and
/// option closures, as well as optional investment bank transactions.
/// </remarks>
public class OfxInvestmentTransactionList
{
    private static readonly string[] TransactionTypeElements =
    [
        OfxInvestmentElementConstants.BuyDebtElement,
        OfxInvestmentElementConstants.BuyMutualFundElement,
        OfxInvestmentElementConstants.BuyOptionElement,
        OfxInvestmentElementConstants.BuyOtherElement,
        OfxInvestmentElementConstants.BuyStockElement,
        OfxInvestmentElementConstants.SellDebtElement,
        OfxInvestmentElementConstants.SellMutualFundElement,
        OfxInvestmentElementConstants.SellOptionElement,
        OfxInvestmentElementConstants.SellOtherElement,
        OfxInvestmentElementConstants.SellStockElement,
        OfxInvestmentElementConstants.JournalFundElement,
        OfxInvestmentElementConstants.JournalSecurityElement,
        OfxInvestmentElementConstants.CapitalReturnElement,
        OfxInvestmentElementConstants.IncomeElement,
        OfxInvestmentElementConstants.ExpenseElement,
        OfxInvestmentElementConstants.MarginInterestElement,
        OfxInvestmentElementConstants.OptionClosureElement,
        OfxInvestmentElementConstants.ReinvestElement,
        OfxInvestmentElementConstants.SplitElement,
        OfxInvestmentElementConstants.TransferElement
    ];

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentTransactionList"/> class.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentTransactionList(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.EndDate = element.GetDateTimeOffset(OfxInvestmentElementConstants.DateEndElement, settings);
        this.StartDate = element.GetDateTimeOffset(OfxInvestmentElementConstants.DateStartElement, settings);

        List<OfxInvestmentTransaction> transactions = [];
        this.InvestmentTransactions = transactions;

        foreach (var tranactionElement in element.TryEnumeratElements(TransactionTypeElements, settings))
        {
            switch (tranactionElement.Name.ToUpperInvariant())
            {
                case OfxInvestmentElementConstants.BuyDebtElement:
                    transactions.Add(new OfxBuyDebt(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.BuyMutualFundElement:
                    transactions.Add(new OfxBuyMutualFund(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.BuyOptionElement:
                    transactions.Add(new OfxBuyOption(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.BuyOtherElement:
                    transactions.Add(new OfxBuyOther(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.BuyStockElement:
                    transactions.Add(new OfxBuyStock(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.CapitalReturnElement:
                    transactions.Add(new OfxCapitalReturn(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.ExpenseElement:
                    transactions.Add(new OfxInvestmentExpense(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.IncomeElement:
                    transactions.Add(new OfxIncome(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.JournalFundElement:
                    transactions.Add(new OfxJournalFund(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.JournalSecurityElement:
                    transactions.Add(new OfxJournalSecurity(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.MarginInterestElement:
                    transactions.Add(new OfxMarginInterest(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.ReinvestElement:
                    transactions.Add(new OfxReinvest(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SellDebtElement:
                    transactions.Add(new OfxSellDebt(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SellMutualFundElement:
                    transactions.Add(new OfxSellMutualFund(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SellOptionElement:
                    transactions.Add(new OfxSellOption(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SellOtherElement:
                    transactions.Add(new OfxSellOther(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SellStockElement:
                    transactions.Add(new OfxSellStock(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.OptionClosureElement:
                    transactions.Add(new OfxOptionClosure(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.SplitElement:
                    transactions.Add(new OfxSplit(tranactionElement, settings));
                    break;

                case OfxInvestmentElementConstants.TransferElement:
                    transactions.Add(new OfxTransfer(tranactionElement, settings));
                    break;
            }
        }

        List<OfxInvestmentBankTransaction> bankTransactions = [];
        this.BankTransactions = bankTransactions;

        foreach (var bankElement in element.Elements(OfxInvestmentElementConstants.InvBankTranElement, settings.TagComparer))
        {
            bankTransactions.Add(new OfxInvestmentBankTransaction(bankElement, settings));
        }
    }

    /// <summary>Gets the end date (<c>DTEND</c>) of the transaction list.</summary>
    public DateTimeOffset EndDate { get; init; }

    /// <summary>Gets the start date (<c>DTSTART</c>) of the transaction list.</summary>
    public DateTimeOffset StartDate { get; init; }

    /// <summary>Gets the collection of investment bank transactions (<c>INVBANKTRAN</c>).</summary>
    public IReadOnlyList<OfxInvestmentBankTransaction> BankTransactions { get; init; }

    /// <summary>Gets the collection of investment transactions.</summary>
    public IReadOnlyList<OfxInvestmentTransaction> InvestmentTransactions { get; init; }
}
