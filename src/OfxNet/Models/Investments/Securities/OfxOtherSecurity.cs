namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents miscellaneous or non-standard security information (<c>OTHERINFO</c> aggregate).
/// </summary>
// <!ELEMENT OTHERINFO  - - (SECINFO , TYPEDESC?, ASSETCLASS? , FIASSETCLASS?) >
public class OfxOtherSecurity : OfxSecurity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOtherSecurity"/> class.
    /// </summary>
    public OfxOtherSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOtherSecurity"/> class.
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
    public OfxOtherSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityElement, settings), settings)
    {
        this.AssetClass = element.TryGetString(OfxInvestmentElementConstants.AssetClassElement, settings);
        this.InstitutionAssetClass = element.TryGetString(OfxInvestmentElementConstants.InstitutionAssetClassElement, settings);
        this.TypeDescription = element.TryGetString(OfxInvestmentElementConstants.TypeDescriptionElement, settings);
    }

    /// <summary>Gets or sets the asset class (<c>ASSETCLASS</c>).</summary>
    public string? AssetClass { get; set; }

    /// <summary>Gets or sets the financial institution's asset class (<c>FIASSETCLASS</c>).</summary>
    public string? InstitutionAssetClass { get; set; }

    /// <summary>Gets or sets the descriptive type of the security (<c>TYPEDESC</c>).</summary>
    public string? TypeDescription { get; set; }
}
