namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a debt security sell transaction (<c>SELLDEBT</c> aggregate).
/// </summary>
// <!ELEMENT SELLDEBT - - (INVSELL, SELLREASON, ACCRDINT?)>
public class OfxSellDebt : OfxSellInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellDebt"/> class.
    /// </summary>
    public OfxSellDebt()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellDebt"/> class
    /// by parsing the <c>SELLDEBT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellDebt(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvSellElement, settings), settings)
    {
        this.AccruedInterest = element.TryGetDecimal(OfxInvestmentElementConstants.AccruedInterestElement, settings);
        this.SellReason = element.GetString(OfxInvestmentElementConstants.SellReasonElement, settings);
    }

    /// <summary>Gets the accrued interest (<c>ACCRDINT</c>).</summary>
    public decimal? AccruedInterest { get; init; }

    /// <summary>Gets the reason for the debt sale (<c>SELLREASON</c>).</summary>
    public required string SellReason { get; init; } = string.Empty;
}
