namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a stock sell transaction (<c>SELLSTOCK</c> aggregate).
/// </summary>
// <!ELEMENT SELLSTOCK - - (INVSELL, SELLTYPE)>
public class OfxSellStock : OfxSellInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellStock"/> class.
    /// </summary>
    public OfxSellStock()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellStock"/> class
    /// by parsing the <c>SELLSTOCK</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellStock(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvSellElement, settings), settings)
    {
        this.SellType = element.GetString(OfxInvestmentElementConstants.SellTypeElement, settings);
    }

    /// <summary>Gets the sell type (<c>SELLTYPE</c>).</summary>
    public required string SellType { get; init; }
}
