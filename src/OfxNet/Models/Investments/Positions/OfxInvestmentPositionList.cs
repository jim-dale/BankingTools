namespace OfxNet.Investments.Positions;

/// <summary>
/// Represents a list of investment positions (<c>INVPOSLIST</c> aggregate).
/// </summary>
// <!ELEMENT INVPOSLIST  - - ((POSMF | POSSTOCK | POSDEBT| POSOPT | POSOTHER)*) >
public class OfxInvestmentPositionList
{
    private static readonly string[] PositionElements =
    [
        OfxInvestmentElementConstants.DebtPositionElement,
        OfxInvestmentElementConstants.MutualFundPositionElement,
        OfxInvestmentElementConstants.OptionPositionElement,
        OfxInvestmentElementConstants.OtherPositionElement,
        OfxInvestmentElementConstants.StockPositionElement,
    ];

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentPositionList"/> class.
    /// </summary>
    public OfxInvestmentPositionList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentPositionList"/> class
    /// by parsing the <c>INVPOSLIST</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements <c>DTASOF</c> or <c>CURDEF</c> are missing or invalid.
    /// </exception>
    public OfxInvestmentPositionList(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        foreach (var posElement in element.TryEnumeratElements(PositionElements, settings))
        {
            switch (posElement.Name.ToUpperInvariant())
            {
                case OfxInvestmentElementConstants.MutualFundPositionElement:
                    this.InvestmentPositions.Add(new OfxMutualFundPosition(posElement, settings));
                    break;

                case OfxInvestmentElementConstants.StockPositionElement:
                    this.InvestmentPositions.Add(new OfxStockPosition(posElement, settings));
                    break;

                case OfxInvestmentElementConstants.DebtPositionElement:
                    this.InvestmentPositions.Add(new OfxDebtPosition(posElement, settings));
                    break;

                case OfxInvestmentElementConstants.OptionPositionElement:
                    this.InvestmentPositions.Add(new OfxOptionPosition(posElement, settings));
                    break;

                case OfxInvestmentElementConstants.OtherPositionElement:
                    this.InvestmentPositions.Add(new OfxOtherPosition(posElement, settings));
                    break;
            }
        }
    }

    /// <summary>Gets the collection of investment positions.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxInvestmentPosition> InvestmentPositions { get; init; } = [];
}
