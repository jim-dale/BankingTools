namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents a debt security position (<c>POSDEBT</c> aggregate).
/// </summary>
// <!ELEMENT POSDEBT - - (INVPOS)>
public class OfxDebtPosition : OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxDebtPosition"/> class.
    /// </summary>
    public OfxDebtPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxDebtPosition"/> class
    /// by parsing the <c>POSDEBT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>INVPOS</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxDebtPosition(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvPosElement, settings), settings)
    {
        // No additional fields beyond INVPOS
    }
}
