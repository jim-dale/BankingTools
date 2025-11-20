namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a buy transaction for an "other" security type (<c>BUYOTHER</c> aggregate).
/// </summary>
// <!ELEMENT BUYOTHER - - (INVBUY)>
public class OfxBuyOther : OfxBuyInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyOther"/> class.
    /// </summary>
    public OfxBuyOther()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyOther"/> class
    /// by parsing the <c>BUYOTHER</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyOther(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvBuyElement, settings), settings)
    {
        // No additional fields beyond INVBUY
    }
}
