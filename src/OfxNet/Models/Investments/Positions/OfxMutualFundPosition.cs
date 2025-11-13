namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents a mutual fund position (<c>POSMF</c> aggregate).
/// </summary>
// <!ELEMENT POSMF - - (INVPOS, UNITSSTREET?, UNITSUSER?, REINVDIV?, REINVCG?)>
public class OfxMutualFundPosition : OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMutualFundPosition"/> class.
    /// </summary>
    public OfxMutualFundPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMutualFundPosition"/> class
    /// by parsing the <c>POSMF</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>INVPOS</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxMutualFundPosition(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvPosElement, settings), settings)
    {
        this.ReinvestCapitalGains = element.TryGetString(OfxInvestmentElementConstants.ReinvestCapitalGainsElement, settings);
        this.ReinvestDividends = element.TryGetString(OfxInvestmentElementConstants.ReinvestDividendsElement, settings);
        this.UnitsStreet = element.TryGetDecimal(OfxInvestmentElementConstants.UnitsStreetElement, settings);
        this.UnitsUser = element.TryGetDecimal(OfxInvestmentElementConstants.UnitsUserElement, settings);
    }

    /// <summary>Gets a value indicating whether capital gains are reinvested (<c>REINVCG</c>).</summary>
    public string? ReinvestCapitalGains { get; init; }

    /// <summary>Gets a value indicating whether dividends are reinvested (<c>REINVDIV</c>).</summary>
    public string? ReinvestDividends { get; init; }

    /// <summary>Gets the number of units in the FI's street name (<c>UNITSSTREET</c>).</summary>
    public decimal? UnitsStreet { get; init; }

    /// <summary>Gets the number of units in the user's name (<c>UNITSUSER</c>).</summary>
    public decimal? UnitsUser { get; init; }
}
