namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents a miscellaneous or non-standard security position (<c>POSOTHER</c> aggregate).
/// </summary>
// <!ELEMENT POSOTHER - - (INVPOS)>
public class OfxOtherPosition : OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOtherPosition"/> class.
    /// </summary>
    public OfxOtherPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOtherPosition"/> class
    /// by parsing the <c>POSOTHER</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>INVPOS</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxOtherPosition(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvPosElement, settings), settings)
    {
        // No additional fields beyond INVPOS
    }
}
