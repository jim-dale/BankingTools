namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a sell transaction for an "other" security type (<c>SELLOTHER</c> aggregate).
/// </summary>
// <!ELEMENT SELLOTHER - - (INVSELL)>
public class OfxSellOther : OfxSellInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellOther"/> class.
    /// </summary>
    public OfxSellOther()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellOther"/> class
    /// by parsing the <c>SELLOTHER</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellOther(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvSellElement, settings), settings)
    {
        // No additional fields beyond INVSELL
    }
}
