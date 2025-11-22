namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents a list of security definitions (<c>SECLIST</c> aggregate).
/// </summary>
// <!ELEMENT SECLIST  - - ((MFINFO | STOCKINFO | OPTINFO | DEBTINFO |  OTHERINFO)*) >
public class OfxSecurityList
{
    private static readonly string[] SecurityElements = [
        OfxInvestmentElementConstants.DebtElement,
        OfxInvestmentElementConstants.MutualFundElement,
        OfxInvestmentElementConstants.OptionElement,
        OfxInvestmentElementConstants.OtherElement,
        OfxInvestmentElementConstants.StockElement
    ];

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurityList"/> class.
    /// </summary>
    public OfxSecurityList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurityList"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    public OfxSecurityList(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        foreach (var securityElement in element.TryEnumeratElements(SecurityElements, settings))
        {
            switch (securityElement.Name.ToUpperInvariant())
            {
                case OfxInvestmentElementConstants.DebtElement:
                    this.Securities.Add(new OfxDebtSecurity(securityElement, settings));
                    break;

                case OfxInvestmentElementConstants.MutualFundElement:
                    this.Securities.Add(new OfxMutualFundSecurity(securityElement, settings));
                    break;

                case OfxInvestmentElementConstants.OptionElement:
                    this.Securities.Add(new OfxOptionSecurity(securityElement, settings));
                    break;

                case OfxInvestmentElementConstants.OtherElement:
                    this.Securities.Add(new OfxOtherSecurity(securityElement, settings));
                    break;

                case OfxInvestmentElementConstants.StockElement:
                    this.Securities.Add(new OfxStockSecurity(securityElement, settings));
                    break;
            }
        }
    }

    /// <summary>Gets the collection of security definitions.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxSecurity> Securities { get; init; } = [];
}
