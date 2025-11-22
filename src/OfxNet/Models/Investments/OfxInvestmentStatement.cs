namespace OfxNet.Investments;

using OfxNet.Investments.Positions;
using OfxNet.Investments.Transactions;

/// <summary>
/// Represents an investment statement response (<c>INVSTMTRS</c> aggregate).
/// </summary>
/// <remarks>
/// The <c>INVSTMTRS</c> aggregate defines the contents of an investment statement,
/// including default currency, account information, positions, transactions,
/// balances, and optionally a security list.
/// </remarks>
// <!ELEMENT INVSTMTRS  - - (DTASOF, CURDEF, INVACCTFROM, INVTRANLIST?, INVPOSLIST?, INVBAL?, INVOOLIST?, MKTGINFO?) >
// INVOOLIST?, MKTGINFO? are intetionally not handled currently.
public class OfxInvestmentStatement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentStatement"/> class.
    /// </summary>
    public OfxInvestmentStatement()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentStatement"/> class
    /// by parsing the <c>INVSTMTRS</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements <c>CURDEF</c> or <c>INVACCTFROM</c> are missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentStatement(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Account = new OfxInvestmentAccount(element.GetElement(OfxInvestmentElementConstants.AccountElement, settings), settings);
        this.Balances = TryGetBalances(element, settings);
        this.DefaultCurrency = element.GetString(OfxInvestmentElementConstants.DefaultCurrencyElement, settings);
        this.Positions = GetOptionalPositionList(element, settings);
        this.StatementDate = element.GetDateTimeOffset(OfxInvestmentElementConstants.DateAsOfElement, settings);
        this.Transactions = GetOptionalTransactionList(element, settings);
    }

    /// <summary>Gets the investment account information (<c>INVACCTFROM</c>).</summary>
    public required OfxInvestmentAccount Account { get; init; }

    /// <summary>Gets the account balances (<c>INVBAL</c>).</summary>
    public OfxInvestmentBalance? Balances { get; init; }

    /// <summary>Gets the default currency (<c>CURDEF</c>).</summary>
    public required string DefaultCurrency { get; init; }

    /// <summary>Gets the list of investment positions (<c>INVPOSLIST</c>).</summary>
    public OfxInvestmentPositionList? Positions { get; init; }

    /// <summary>Gets the list of investment transactions (<c>INVTRANLIST</c>).</summary>
    public OfxInvestmentTransactionList? Transactions { get; init; }

    /// <summary>Gets the list of securities (<c>SECLIST</c>).</summary>
    public required DateTimeOffset StatementDate { get; init; }

    /// <summary>Helper method to load optional balances.</summary>
    private static OfxInvestmentBalance? TryGetBalances(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? balanceElement = element.TryGetElement(OfxInvestmentElementConstants.InvestmentBalanceElement, settings);

        return balanceElement is not null
            ? new OfxInvestmentBalance(balanceElement, settings)
            : null;
    }

    /// <summary>Helper method to load optional position list.</summary>
    private static OfxInvestmentPositionList? GetOptionalPositionList(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? positionList = element.TryGetElement(OfxInvestmentElementConstants.PositionListElement, settings);

        return positionList is not null
            ? new OfxInvestmentPositionList(positionList, settings)
            : null;
    }

    /// <summary>Helper method to load optional transaction list.</summary>
    private static OfxInvestmentTransactionList? GetOptionalTransactionList(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? transactionList = element.TryGetElement(OfxInvestmentElementConstants.TransactionListElement, settings);

        return transactionList is not null
            ? new OfxInvestmentTransactionList(transactionList, settings)
            : null;
    }
}
