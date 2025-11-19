namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents mutual fund security information (<c>MFINFO</c> aggregate).
/// </summary>
// <!ELEMENT MFINFO  - - (SECINFO , MFTYPE? , YIELD? , DTYIELDASOF? , MFASSETCLASS? , FIMFASSETCLASS?)>
public class OfxMutualFundSecurity : OfxSecurity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMutualFundSecurity"/> class.
    /// </summary>
    public OfxMutualFundSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxMutualFundSecurity"/> class.
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
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxMutualFundSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityElement, settings), settings)
    {
        this.InstitutionAssetClasses = GetAssetClassList(element, settings, wantInstitutionList: true);
        this.MutualFundAssetClasses = GetAssetClassList(element, settings, wantInstitutionList: false);
        this.MutualFundType = element.TryGetString(OfxInvestmentElementConstants.MutualFundTypeElement, settings);
        this.Yield = element.TryGetDecimal(OfxInvestmentElementConstants.YieldElement, settings);
        this.YieldAsOfDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.YieldAsOfDateElement, settings);
    }

    /// <summary>Gets or sets the financial institution's asset class breakdown (<c>FIMFASSETCLASS</c>).</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxAssetClassPortion>? InstitutionAssetClasses { get; init; } = [];

    /// <summary>Gets or sets the asset class breakdown (<c>MFASSETCLASS</c>).</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxAssetClassPortion>? MutualFundAssetClasses { get; init; } = [];

    /// <summary>Gets or sets the mutual fund type (<c>MFTYPE</c>).</summary>
    /// <remarks>Examples may include "OPENEND" or "CLOSEEND".</remarks>
    public string? MutualFundType { get; set; }

    /// <summary>Gets or sets the yield (<c>YIELD</c>).</summary>
    public decimal? Yield { get; set; }

    /// <summary>Gets or sets the date the yield was calculated (<c>DTYIELDASOF</c>).</summary>
    public DateTimeOffset? YieldAsOfDate { get; set; }

    /// <summary>
    /// Helper method to load the <see cref="InstitutionAssetClasses"/> or <see cref="MutualFundAssetClasses"/> which are
    /// use different element constants but are otherwise identical.
    /// </summary>
    /// <param name="element">The <c>MFINFO</c> element being processed.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.</param>
    /// <param name="wantInstitutionList">A valud indicating whether to load the <see cref="InstitutionAssetClasses"/> (true) or <see cref="MutualFundAssetClasses"/> (false).</param>
    /// <returns>The loaded list of <see cref="OfxAssetClassPortion"/>s.</returns>
    private static List<OfxAssetClassPortion> GetAssetClassList(IOfxElement element, OfxDocumentSettings settings, bool wantInstitutionList)
    {
        List<OfxAssetClassPortion> assetClasses = [];

        string listElementName = wantInstitutionList
            ? OfxInvestmentElementConstants.InstitutionAssetClassListElement
            : OfxInvestmentElementConstants.AssetClassListElement;

        string elementsName = wantInstitutionList
            ? OfxInvestmentElementConstants.InstitutionAssetClassPortionElement
            : OfxInvestmentElementConstants.AssetClassPortionElement;

        IOfxElement? assetClassList = element.TryGetElement(listElementName, settings);

        // In later specs, ASSETCLASS is limited to the enumeration:
        //      DOMESTICBOND, INTLBOND, LARGESTOCK, SMALLSTOCK, INTLSTOCK, MONEYMRKT, OTHER
        // while FIASSETCLASS class continues to be a string. To be more strictly conformant
        // to newer versions, add validation here when !wantInstitutionList.
        if (assetClassList is not null)
        {
            foreach (var assetClass in assetClassList.Elements(elementsName, settings.TagComparer))
            {
                assetClasses.Add(new OfxAssetClassPortion(assetClass, settings));
            }
        }

        return assetClasses;
    }
}
