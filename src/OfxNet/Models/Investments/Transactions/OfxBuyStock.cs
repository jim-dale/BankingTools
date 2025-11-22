namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a stock buy transaction (<c>BUYSTOCK</c> aggregate).
/// </summary>
// <!ELEMENT BUYSTOCK - - (INVBUY, BUYTYPE)>
public class OfxBuyStock : OfxBuyInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyStock"/> class.
    /// </summary>
    public OfxBuyStock()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyStock"/> class
    /// by parsing the <c>BUYSTOCK</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyStock(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvBuyElement, settings), settings)
    {
        this.BuyType = element.GetString(OfxInvestmentElementConstants.BuyTypeElement, settings);
    }

    /// <summary>Gets the buy type (<c>BUYTYPE</c>).</summary>
    public required string BuyType { get; init; }
}
