namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a margin interest transaction (<c>MARGININTEREST</c> aggregate).
/// </summary>
// <!ELEMENT MARGININTEREST - - (INVTRAN, TOTAL, SUBACCTFUND?, CURRENCY?, ORIGCURRENCY?)>
public class OfxMarginInterest : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMarginInterest"/> class.
    /// </summary>
    public OfxMarginInterest()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMarginInterest"/> class
    /// by parsing the <c>MARGININTEREST</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>MARGININTEREST</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxMarginInterest(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
    }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the total margin interest amount (<c>TOTAL</c>).</summary>
    required public decimal Total { get; init; }
}
