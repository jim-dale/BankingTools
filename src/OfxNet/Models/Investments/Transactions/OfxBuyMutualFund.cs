namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a mutual fund buy transaction (<c>BUYMF</c> aggregate).
/// </summary>
// <!ELEMENT BUYMF - - (INVBUY, BUYTYPE, RELFITID?)>
public class OfxBuyMutualFund : OfxBuyInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyMutualFund"/> class.
    /// </summary>
    public OfxBuyMutualFund()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyMutualFund"/> class
    /// by parsing the <c>BUYMF</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyMutualFund(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvBuyElement, settings), settings)
    {
        this.BuyType = element.GetString(OfxInvestmentElementConstants.BuyTypeElement, settings);
        this.RelatedInstitutionId = element.TryGetString(OfxInvestmentElementConstants.RelatedFitIdElement, settings);
    }

    /// <summary>Gets the buy type (<c>BUYTYPE</c>).</summary>
    required public string BuyType { get; init; } = string.Empty;

    /// <summary>Gets the related transaction identifier (<c>RELFITID</c>).</summary>
    public string? RelatedInstitutionId { get; init; }
}
