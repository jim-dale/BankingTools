namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a mutual fund sell transaction (<c>SELLMF</c> aggregate).
/// </summary>
// <!ELEMENT SELLMF - - (INVSELL, SELLTYPE, AVGCOSTBASIS?, RELFITID?)>
public class OfxSellMutualFund : OfxSellInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellMutualFund"/> class.
    /// </summary>
    public OfxSellMutualFund()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellMutualFund"/> class
    /// by parsing the <c>SELLMF</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellMutualFund(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvSellElement, settings), settings)
    {
        this.SellType = element.GetString(OfxInvestmentElementConstants.SellTypeElement, settings);
        this.AverageCostBasis = element.TryGetDecimal(OfxInvestmentElementConstants.AverageCostBasisElement, settings);
        this.RelatedInstitutionId = element.TryGetString(OfxInvestmentElementConstants.RelatedFitIdElement, settings);
    }

    /// <summary>Gets the average cost basis (<c>AVGCOSTBASIS</c>).</summary>
    public decimal? AverageCostBasis { get; init; }

    /// <summary>Gets the related transaction identifier (<c>RELFITID</c>).</summary>
    public string? RelatedInstitutionId { get; init; }

    /// <summary>Gets the sell type (<c>SELLTYPE</c>).</summary>
    public required string SellType { get; init; } = string.Empty;
}
