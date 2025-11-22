namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents an investment position (<c>INVPOS</c> aggregate).
/// </summary>
// <!ELEMENT INVPOS - - (SECID, HELDINACCT?, POSTYPE?, UNITS?, UNITPRICE?, MKTVAL?, DTPRICEASOF?, CURRENCY?, MEMO?)>
public class OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentPosition"/> class.
    /// </summary>
    public OfxInvestmentPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentPosition"/> class
    /// by parsing the <c>INVPOS</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>SECID</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentPosition(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.HeldInAcct = element.TryGetString(OfxInvestmentElementConstants.HeldInAcctElement, settings);
        this.MarketValue = element.TryGetDecimal(OfxInvestmentElementConstants.MarketValueElement, settings);
        this.Memo = element.TryGetString(OfxInvestmentElementConstants.MemoElement, settings);
        this.PositionType = element.TryGetString(OfxInvestmentElementConstants.PositionTypeElement, settings);
        this.PriceAsOfDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.PriceAsOfDateElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.UnitPrice = element.TryGetDecimal(OfxInvestmentElementConstants.UnitPriceElement, settings);
        this.Units = element.TryGetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
    }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the account in which the security is held (<c>HELDINACCT</c>).</summary>
    public string? HeldInAcct { get; init; }

    /// <summary>Gets the market value of the position (<c>MKTVAL</c>).</summary>
    public decimal? MarketValue { get; init; }

    /// <summary>Gets an optional memo (<c>MEMO</c>).</summary>
    public string? Memo { get; init; }

    /// <summary>Gets the position type (<c>POSTYPE</c>).</summary>
    public string? PositionType { get; init; }

    /// <summary>Gets the date the price was last updated (<c>DTPRICEASOF</c>).</summary>
    public DateTimeOffset? PriceAsOfDate { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the unit price (<c>UNITPRICE</c>).</summary>
    public decimal? UnitPrice { get; init; }

    /// <summary>Gets the number of units held (<c>UNITS</c>).</summary>
    public decimal? Units { get; init; }
}
