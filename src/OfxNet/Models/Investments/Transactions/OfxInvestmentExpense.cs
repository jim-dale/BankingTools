namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an investment expense transaction (<c>INVEXPENSE</c> aggregate).
/// </summary>
// <!ELEMENT INVEXPENSE - - (INVTRAN, SECID, TOTAL, SUBACCTSEC?, SUBACCTFUND?, CURRENCY?, ORIGCURRENCY?)>
public class OfxInvestmentExpense : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentExpense"/> class.
    /// </summary>
    public OfxInvestmentExpense()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentExpense"/> class
    /// by parsing the <c>INVEXPENSE</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>INVEXPENSE</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentExpense(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
    }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the total expense amount (<c>TOTAL</c>).</summary>
    public required decimal Total { get; init; }
}
