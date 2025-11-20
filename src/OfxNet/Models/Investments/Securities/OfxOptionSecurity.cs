namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents option security information (<c>OPTINFO</c> aggregate).
/// </summary>
// <!ELEMENT OPTINFO  - - (SECINFO , OPTTYPE , STRIKEPRICE , DTEXPIRE , SHPERCTRCT , SECID? , ASSETCLASS? , FIASSETCLASS?) >
public class OfxOptionSecurity : OfxSecurity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionSecurity"/> class.
    /// </summary>
    public OfxOptionSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionSecurity"/> class.
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
    public OfxOptionSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityElement, settings), settings)
    {
        this.AssetClass = element.TryGetString(OfxInvestmentElementConstants.AssetClassElement, settings);
        this.ExpirationDate = element.GetDateTimeOffset(OfxInvestmentElementConstants.ExpirationDateElement, settings);
        this.InstitutionAssetClass = element.TryGetString(OfxInvestmentElementConstants.InstitutionAssetClassElement, settings);
        this.OptionType = element.GetString(OfxInvestmentElementConstants.OptionTypeElement, settings);
        this.Security = OfxInvestmentHelpers.GetOptionalSecurityIdSubElement(element, OfxInvestmentElementConstants.SecurityIdElement, settings);
        this.SharesPerContract = element.GetInt(OfxInvestmentElementConstants.SharesPerContractElement, settings);
        this.StrikePrice = element.GetDecimal(OfxInvestmentElementConstants.StrikePriceElement, settings);
    }

    /// <summary>Gets or sets the asset class (<c>ASSETCLASS</c>).</summary>
    public string? AssetClass { get; set; }

    /// <summary>Gets or sets the expiration date (<c>DTEXPIRE</c>).</summary>
    required public DateTimeOffset? ExpirationDate { get; set; }

    /// <summary>Gets or sets the financial institution's asset class (<c>FIASSETCLASS</c>).</summary>
    public string? InstitutionAssetClass { get; set; }

    /// <summary>Gets or sets the option type (<c>OPTTYPE</c>).</summary>
    /// <remarks>Examples include "CALL" or "PUT".</remarks>
    required public string OptionType { get; set; }

    /// <summary>Gets or sets an optional secondary security identifier (<c>SECID</c>).</summary>
    public OfxSecurityId? Security { get; set; }

    /// <summary>Gets or sets the number of shares per contract (<c>SHPERCTRCT</c>).</summary>
    required public int SharesPerContract { get; set; }

    /// <summary>Gets or sets the strike price (<c>STRIKEPRICE</c>).</summary>
    required public decimal StrikePrice { get; set; }
}
