namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a buy investment transaction (<c>INVBUY</c> aggregate).
/// </summary>
// <!ELEMENT INVBUY - - (INVTRAN, SECID, UNITS, UNITPRICE, MARKUP?, COMMISSION?, TAXES?, FEES?, LOAD?, TOTAL, CURRENCY?, ORIGCURRENCY?, SUBACCTSEC?, SUBACCTFUND?)>
public class OfxBuyInvestment : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyInvestment"/> class.
    /// </summary>
    public OfxBuyInvestment()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyInvestment"/> class
    /// by parsing the <c>INVBUY</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>INVBUY</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyInvestment(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        this.Commission = element.TryGetDecimal(OfxInvestmentElementConstants.CommissionElement, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.Fees = element.TryGetDecimal(OfxInvestmentElementConstants.FeesElement, settings);
        this.Load = element.TryGetDecimal(OfxInvestmentElementConstants.LoadElement, settings);
        this.Markup = element.TryGetDecimal(OfxInvestmentElementConstants.MarkupElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
        this.Taxes = element.TryGetDecimal(OfxInvestmentElementConstants.TaxesElement, settings);
        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
        this.UnitPrice = element.GetDecimal(OfxInvestmentElementConstants.UnitPriceElement, settings);
        this.Units = element.GetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
    }

    /// <summary>Gets the commission amount (<c>COMMISSION</c>).</summary>
    public decimal? Commission { get; init; }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the fees amount (<c>FEES</c>).</summary>
    public decimal? Fees { get; init; }

    /// <summary>Gets the load amount (<c>LOAD</c>).</summary>
    public decimal? Load { get; init; }

    /// <summary>Gets the markup amount (<c>MARKUP</c>).</summary>
    public decimal? Markup { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    required public OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the taxes amount (<c>TAXES</c>).</summary>
    public decimal? Taxes { get; init; }

    /// <summary>Gets the total transaction amount (<c>TOTAL</c>).</summary>
    required public decimal Total { get; init; }

    /// <summary>Gets the unit price (<c>UNITPRICE</c>).</summary>
    required public decimal UnitPrice { get; init; }

    /// <summary>Gets the number of units purchased (<c>UNITS</c>).</summary>
    required public decimal Units { get; init; }
}
