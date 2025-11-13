namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a buy transaction for a debt security (<c>BUYDEBT</c> aggregate).
/// </summary>
// <!ELEMENT BUYDEBT - - (INVBUY, ACCRDINT?)>
public class OfxBuyDebt : OfxBuyInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyDebt"/> class.
    /// by parsing the <c>BUYDEBT</c> aggregate.
    /// </summary>
    public OfxBuyDebt()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyDebt"/> class
    /// by parsing the <c>BUYDEBT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyDebt(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvBuyElement, settings), settings)
    {
        this.AccruedInterest = element.TryGetDecimal(OfxInvestmentElementConstants.AccruedInterestElement, settings);
    }

    /// <summary>Gets the accrued interest (<c>ACCRDINT</c>).</summary>
    public decimal? AccruedInterest { get; init; }
}
