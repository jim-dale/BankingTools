namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an investment income transaction (<c>INCOME</c> aggregate).
/// </summary>
// <!ELEMENT INCOME - - (INVTRAN, SECID, INCOMETYPE, TOTAL, SUBACCTSEC?, SUBACCTFUND?, TAXEXEMPT?, WITHHOLDING?, CURRENCY?, ORIGCURRENCY?)>
public class OfxIncome : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxIncome"/> class.
    /// </summary>
    public OfxIncome()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxIncome"/> class
    /// by parsing the <c>INCOME</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>INCOME</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxIncome(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.IncomeType = element.GetString(OfxInvestmentElementConstants.IncomeTypeElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
        this.TaxExempt = element.TryGetString(OfxInvestmentElementConstants.TaxExemptElement, settings);
        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
        this.Withholding = element.TryGetDecimal(OfxInvestmentElementConstants.WithholdingElement, settings);
    }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the income type (<c>INCOMETYPE</c>).</summary>
    public required string IncomeType { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets a value indicating whether the income is tax exempt (<c>TAXEXEMPT</c>).</summary>
    public string? TaxExempt { get; init; }

    /// <summary>Gets the total income amount (<c>TOTAL</c>).</summary>
    public required decimal Total { get; init; }

    /// <summary>Gets the withholding amount (<c>WITHHOLDING</c>).</summary>
    public decimal? Withholding { get; init; }
}
