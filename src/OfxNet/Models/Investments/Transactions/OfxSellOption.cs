namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an option sell transaction (<c>SELLOPT</c> aggregate).
/// </summary>
// <!ELEMENT SELLOPT - - (INVSELL, OPTSELLTYPE, SHPERCTRCT, RELFITID?, RELTYPE?, SECURED)>
public class OfxSellOption : OfxSellInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellOption"/> class.
    /// </summary>
    public OfxSellOption()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSellOption"/> class
    /// by parsing the <c>SELLOPT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxSellOption(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvSellElement, settings), settings)
    {
        this.OptionSellType = element.GetString(OfxInvestmentElementConstants.OptSellTypeElement, settings);
        this.RelatedInstitutionId = element.TryGetString(OfxInvestmentElementConstants.RelatedFitIdElement, settings);
        this.RelationType = element.TryGetString(OfxInvestmentElementConstants.RelationTypeElement, settings);
        this.Secured = element.GetString(OfxInvestmentElementConstants.SecuredElement, settings);
        this.SharesPerContract = element.GetInt(OfxInvestmentElementConstants.SharesPerContractElement, settings);
    }

    /// <summary>Gets the option sell type (<c>OPTSELLTYPE</c>).</summary>
    required public string OptionSellType { get; init; }

    /// <summary>Gets the related transaction identifier (<c>RELFITID</c>).</summary>
    public string? RelatedInstitutionId { get; init; }

    /// <summary>Gets the relation type (<c>RELTYPE</c>).</summary>
    public string? RelationType { get; init; }

    /// <summary>Gets the secured flag (<c>SECURED</c>).</summary>
    required public string Secured { get; init; }

    /// <summary>Gets the shares per contract (<c>SHPERCTRCT</c>).</summary>
    required public int SharesPerContract { get; init; }
}
