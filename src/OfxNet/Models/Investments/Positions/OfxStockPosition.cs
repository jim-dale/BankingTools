namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents a stock position (<c>POSSTOCK</c> aggregate).
/// </summary>
// <!ELEMENT POSSTOCK - - (INVPOS, UNITSSTREET?, UNITSUSER?, REINVDIV?)>
public class OfxStockPosition : OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxStockPosition"/> class.
    /// </summary>
    public OfxStockPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxStockPosition"/> class
    /// by parsing the <c>POSSTOCK</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>INVPOS</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxStockPosition(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvPosElement, settings), settings)
    {
        this.ReinvestDividends = element.TryGetString(OfxInvestmentElementConstants.ReinvestDividendsElement, settings);
        this.UnitsStreet = element.TryGetDecimal(OfxInvestmentElementConstants.UnitsStreetElement, settings);
        this.UnitsUser = element.TryGetDecimal(OfxInvestmentElementConstants.UnitsUserElement, settings);
    }

    /// <summary>Gets a value indicating whether dividends are reinvested (<c>REINVDIV</c>).</summary>
    public string? ReinvestDividends { get; init; }

    /// <summary>Gets the number of street name units (<c>UNITSSTREET</c>).</summary>
    public decimal? UnitsStreet { get; init; }

    /// <summary>Gets the number of user name units (<c>UNITSUSER</c>).</summary>
    public decimal? UnitsUser { get; init; }
}
