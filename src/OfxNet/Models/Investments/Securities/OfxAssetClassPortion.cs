namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents an asset class portion (<c>PORTION</c> aggregate) within <c>MFASSETCLASS</c>.
/// </summary>
// <!ELEMENT PORTION  - - (ASSETCLASS , PERCENT) >
// <!ELEMENT FIPORTION  - - (FIASSETCLASS , PERCENT) >
public class OfxAssetClassPortion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxAssetClassPortion"/> class.
    /// </summary>
    public OfxAssetClassPortion()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxAssetClassPortion"/> class.
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
    public OfxAssetClassPortion(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.AssetClass = GetAssetClass(element, settings);
        this.Percent = element.GetDecimal(OfxInvestmentElementConstants.PercentElement, settings);
    }

    /// <summary>Gets or sets the asset class (<c>ASSETCLASS</c>).</summary>
    public required string AssetClass { get; set; }

    /// <summary>Gets or sets the percentage allocation (<c>PERCENT</c>).</summary>
    public required decimal Percent { get; set; }

    /// <summary>
    /// Helper method to get asset class using the correct child element name based on the parent element being processed.
    /// </summary>
    private static string GetAssetClass(IOfxElement element, OfxDocumentSettings settings)
    {
        if (settings.TagComparer.Equals(element.Name, OfxInvestmentElementConstants.InstitutionAssetClassPortionElement))
        {
            return element.GetString(OfxInvestmentElementConstants.InstitutionAssetClassElement, settings);
        }
        else
        {
            return element.GetString(OfxInvestmentElementConstants.AssetClassElement, settings);
        }
    }
}
