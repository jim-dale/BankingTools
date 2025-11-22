namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a sell investment transaction (<c>INVSELL</c> aggregate).
/// </summary>
// <!ELEMENT INVSELL - - (INVTRAN, SECID, UNITS, UNITPRICE, MARKDOWN?, COMMISSION?, TAXES?, FEES?, LOAD?, WITHHOLDING?, TAXEXEMPT?, TOTAL, GAIN?, CURRENCY?, ORIGCURRENCY?, SUBACCTSEC?, SUBACCTFUND?)>
public class OfxSellInvestment : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellInvestment"/> class.
    /// </summary>
    public OfxSellInvestment()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellInvestment"/> class
    /// by parsing the <c>INVSELL</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>INVSELL</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellInvestment(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Commission = element.TryGetDecimal(OfxInvestmentElementConstants.CommissionElement, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.Fees = element.TryGetDecimal(OfxInvestmentElementConstants.FeesElement, settings);
        this.Gain = element.TryGetDecimal(OfxInvestmentElementConstants.GainElement, settings);
        this.Load = element.TryGetDecimal(OfxInvestmentElementConstants.LoadElement, settings);
        this.Markdown = element.TryGetDecimal(OfxInvestmentElementConstants.MarkdownElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
        this.Taxes = element.TryGetDecimal(OfxInvestmentElementConstants.TaxesElement, settings);
        this.TaxExempt = element.TryGetString(OfxInvestmentElementConstants.TaxExemptElement, settings);
        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
        this.Units = element.GetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
        this.UnitPrice = element.GetDecimal(OfxInvestmentElementConstants.UnitPriceElement, settings);
        this.Withholding = element.TryGetDecimal(OfxInvestmentElementConstants.WithholdingElement, settings);
    }

    /// <summary>Gets the commission amount (<c>COMMISSION</c>).</summary>
    public decimal? Commission { get; init; }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the fees amount (<c>FEES</c>).</summary>
    public decimal? Fees { get; init; }

    /// <summary>Gets the gain amount (<c>GAIN</c>).</summary>
    public decimal? Gain { get; init; }

    /// <summary>Gets the load amount (<c>LOAD</c>).</summary>
    public decimal? Load { get; init; }

    /// <summary>Gets the markdown amount (<c>MARKDOWN</c>).</summary>
    public decimal? Markdown { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the taxes amount (<c>TAXES</c>).</summary>
    public decimal? Taxes { get; init; }

    /// <summary>Gets a value indicating whether the transaction is tax exempt (<c>TAXEXEMPT</c>).</summary>
    public string? TaxExempt { get; init; }

    /// <summary>Gets the total transaction amount (<c>TOTAL</c>).</summary>
    public required decimal Total { get; init; }

    /// <summary>Gets the number of units sold (<c>UNITS</c>).</summary>
    public required decimal Units { get; init; }

    /// <summary>Gets the unit price (<c>UNITPRICE</c>).</summary>
    public required decimal UnitPrice { get; init; }

    /// <summary>Gets the withholding amount (<c>WITHHOLDING</c>).</summary>
    public decimal? Withholding { get; init; }
}
