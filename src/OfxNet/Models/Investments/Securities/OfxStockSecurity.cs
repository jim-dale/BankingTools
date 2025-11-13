namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents stock security information (<c>STOCKINFO</c> aggregate).
/// </summary>
// <!ELEMENT STOCKINFO  - - (SECINFO , STOCKTYPE? , YIELD? , DTYIELDASOF? , ASSETCLASS? , FIASSETCLASS?) >
public class OfxStockSecurity : OfxSecurity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxStockSecurity"/> class.
    /// </summary>
    public OfxStockSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxStockSecurity"/> class.
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
    public OfxStockSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityElement, settings), settings)
    {
        this.AssetClass = element.TryGetString(OfxInvestmentElementConstants.AssetClassElement, settings);
        this.InstitutionAssetClass = element.TryGetString(OfxInvestmentElementConstants.InstitutionAssetClassElement, settings);
        this.StockType = element.TryGetString(OfxInvestmentElementConstants.StockTypeElement, settings);
        this.Yield = element.TryGetDecimal(OfxInvestmentElementConstants.YieldElement, settings);
        this.YieldAsOfDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.YieldAsOfDateElement, settings);
    }

    /// <summary>Gets or sets the asset class (<c>ASSETCLASS</c>).</summary>
    public string? AssetClass { get; set; }

    /// <summary>Gets or sets the financial institution's asset class (<c>FIASSETCLASS</c>).</summary>
    public string? InstitutionAssetClass { get; set; }

    /// <summary>Gets or sets the stock type (<c>STOCKTYPE</c>).</summary>
    public string? StockType { get; set; }

    /// <summary>Gets or sets the yield (<c>YIELD</c>).</summary>
    public decimal? Yield { get; set; }

    /// <summary>Gets or sets the date the yield was calculated (<c>DTYIELDASOF</c>).</summary>
    public DateTimeOffset? YieldAsOfDate { get; set; }
}
