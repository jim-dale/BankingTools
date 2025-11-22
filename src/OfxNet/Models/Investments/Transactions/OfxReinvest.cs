namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a reinvestment transaction (<c>REINVEST</c> aggregate).
/// </summary>
// <!ELEMENT REINVEST - - (INVTRAN, SECID, INCOMETYPE, TOTAL, SUBACCTSEC?, UNITS, UNITPRICE, COMMISSION?, TAXES?, FEES?, LOAD?, TAXEXEMPT?, CURRENCY?, ORIGCURRENCY?)>
public class OfxReinvest : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxReinvest"/> class.
    /// </summary>
    public OfxReinvest()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxReinvest"/> class
    /// by parsing the <c>REINVEST</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>REINVEST</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxReinvest(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Commission = element.TryGetDecimal(OfxInvestmentElementConstants.CommissionElement, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.Fees = element.TryGetDecimal(OfxInvestmentElementConstants.FeesElement, settings);
        this.IncomeType = element.GetString(OfxInvestmentElementConstants.IncomeTypeElement, settings);
        this.Load = element.TryGetDecimal(OfxInvestmentElementConstants.LoadElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings) ?? string.Empty;
        this.Taxes = element.TryGetDecimal(OfxInvestmentElementConstants.TaxesElement, settings);
        this.TaxExempt = element.TryGetString(OfxInvestmentElementConstants.TaxExemptElement, settings);
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

    /// <summary>Gets the income type (<c>INCOMETYPE</c>).</summary>
    public required string IncomeType { get; init; }

    /// <summary>Gets the load amount (<c>LOAD</c>).</summary>
    public decimal? Load { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the taxes amount (<c>TAXES</c>).</summary>
    public decimal? Taxes { get; init; }

    /// <summary>Gets a value indicating whether the reinvestment is tax exempt (<c>TAXEXEMPT</c>).</summary>
    public string? TaxExempt { get; init; }

    /// <summary>Gets the total reinvested amount (<c>TOTAL</c>).</summary>
    public required decimal Total { get; init; }

    /// <summary>Gets the unit price (<c>UNITPRICE</c>).</summary>
    public required decimal UnitPrice { get; init; }

    /// <summary>Gets the number of units purchased (<c>UNITS</c>).</summary>
    public required decimal Units { get; init; }
}
