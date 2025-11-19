namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents an option position (<c>POSOPT</c> aggregate).
/// </summary>
// <!ELEMENT POSOPT - - (INVPOS, SECURED?)>
public class OfxOptionPosition : OfxInvestmentPosition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionPosition"/> class.
    /// </summary>
    public OfxOptionPosition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionPosition"/> class
    /// by parsing the <c>POSOPT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>INVPOS</c> is missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxOptionPosition(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvPosElement, settings), settings)
    {
        this.Secured = element.TryGetString(OfxInvestmentElementConstants.SecuredElement, settings);
    }

    /// <summary>Gets the secured indicator (<c>SECURED</c>).</summary>
    public string? Secured { get; init; }
}
