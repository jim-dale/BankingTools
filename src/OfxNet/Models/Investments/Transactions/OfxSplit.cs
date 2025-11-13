namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a split transaction (<c>SPLIT</c> aggregate).
/// </summary>
// <!ELEMENT SPLIT - - (INVTRAN, SECID, SUBACCTSEC?, OLDUNITS, NEWUNITS, NUMERATOR, DENOMINATOR, CURRENCY?, ORIGCURRENCY?, FRACCASH?, SUBACCTFUND?)>
public class OfxSplit : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSplit"/> class.
    /// </summary>
    public OfxSplit()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSplit"/> class
    /// by parsing the <c>SPLIT</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>SPLIT</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSplit(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Denominator = element.GetInt(OfxInvestmentElementConstants.DenominatorElement, settings);
        this.OldUnits = element.GetDecimal(OfxInvestmentElementConstants.OldUnitsElement, settings);
        this.NewUnits = element.GetDecimal(OfxInvestmentElementConstants.NewUnitsElement, settings);
        this.Numerator = element.GetInt(OfxInvestmentElementConstants.NumeratorElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.FractionalCash = element.TryGetDecimal(OfxInvestmentElementConstants.FractionalCashElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
    }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the denominator of the split ratio (<c>DENOMINATOR</c>).</summary>
    required public int Denominator { get; init; }

    /// <summary>Gets the fractional cash amount (<c>FRACCASH</c>).</summary>
    public decimal? FractionalCash { get; init; }

    /// <summary>Gets the new number of units (<c>NEWUNITS</c>).</summary>
    required public decimal NewUnits { get; init; }

    /// <summary>Gets the numerator of the split ratio (<c>NUMERATOR</c>).</summary>
    required public int Numerator { get; init; }

    /// <summary>Gets the old number of units (<c>OLDUNITS</c>).</summary>
    required public decimal OldUnits { get; init; }

    /// <summary>Gets the original currency information (<c>ORIGCURRENCY</c>).</summary>
    public OfxCurrency? OriginalCurrency { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    required public OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string? SubAccountFund { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }
}
