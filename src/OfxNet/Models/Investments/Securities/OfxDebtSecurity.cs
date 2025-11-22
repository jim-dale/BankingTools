namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents debt security information (<c>DEBTINFO</c> aggregate).
/// </summary>
// <!ELEMENT DEBTINFO  - - (SECINFO , PARVALUE , DEBTTYPE , DEBTCLASS? ,
//               COUPONRT?, DTCOUPON? , COUPONFREQ? , CALLPRICE?,
//               YIELDTOCALL? , DTCALL? , CALLTYPE? , YIELDTOMAT?,
//               DTMAT? , ASSETCLASS? , FIASSETCLASS?) >
public class OfxDebtSecurity : OfxSecurity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxDebtSecurity"/> class.
    /// </summary>
    public OfxDebtSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxDebtSecurity"/> class.
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
    public OfxDebtSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityElement, settings), settings)
    {
        this.AssetClass = element.TryGetString(OfxInvestmentElementConstants.AssetClassElement, settings);
        this.CallDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.CallDateElement, settings);
        this.CallPrice = element.TryGetDecimal(OfxInvestmentElementConstants.CallPriceElement, settings);
        this.CallType = element.TryGetString(OfxInvestmentElementConstants.CallTypeElement, settings);
        this.CouponDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.CouponDateElement, settings);
        this.CouponFrequency = element.TryGetString(OfxInvestmentElementConstants.CouponFrequencyElement, settings);
        this.CouponRate = element.TryGetDecimal(OfxInvestmentElementConstants.CouponRateElement, settings);
        this.DebtClass = element.TryGetString(OfxInvestmentElementConstants.DebtClassElement, settings);
        this.DebtType = element.GetString(OfxInvestmentElementConstants.DebtTypeElement, settings);
        this.InstitutionAssetClass = element.TryGetString(OfxInvestmentElementConstants.InstitutionAssetClassElement, settings);
        this.MaturityDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.MaturityDateElement, settings);
        this.ParValue = element.GetDecimal(OfxInvestmentElementConstants.ParValueElement, settings);
        this.YieldToCall = element.TryGetDecimal(OfxInvestmentElementConstants.YieldToCallElement, settings);
        this.YieldToMaturity = element.TryGetDecimal(OfxInvestmentElementConstants.YieldToMaturityElement, settings);
    }

    /// <summary>Gets or sets the asset class (<c>ASSETCLASS</c>).</summary>
    public string? AssetClass { get; set; }

    /// <summary>Gets or sets the call date (<c>DTCALL</c>).</summary>
    public DateTimeOffset? CallDate { get; set; }

    /// <summary>Gets or sets the call price (<c>CALLPRICE</c>).</summary>
    public decimal? CallPrice { get; set; }

    /// <summary>Gets or sets the call type (<c>CALLTYPE</c>).</summary>
    public string? CallType { get; set; }

    /// <summary>Gets or sets the coupon date (<c>DTCOUPON</c>).</summary>
    public DateTimeOffset? CouponDate { get; set; }

    /// <summary>Gets or sets the coupon frequency (<c>COUPONFREQ</c>).</summary>
    public string? CouponFrequency { get; set; }

    /// <summary>Gets or sets the coupon rate (<c>COUPONRT</c>).</summary>
    public decimal? CouponRate { get; set; }

    /// <summary>Gets or sets the debt class (<c>DEBTCLASS</c>).</summary>
    public string? DebtClass { get; set; }

    /// <summary>Gets or sets the debt type (<c>DEBTTYPE</c>).</summary>
    /// <remarks>Examples include "BOND" or "NOTE".</remarks>
    public required string? DebtType { get; set; }

    /// <summary>Gets or sets the financial institution's asset class (<c>FIASSETCLASS</c>).</summary>
    public string? InstitutionAssetClass { get; set; }

    /// <summary>Gets or sets the maturity date (<c>DTMAT</c>).</summary>
    public DateTimeOffset? MaturityDate { get; set; }

    /// <summary>Gets or sets the par value of the debt security (<c>PARVALUE</c>).</summary>
    public required decimal? ParValue { get; set; }

    /// <summary>Gets or sets the yield to call (<c>YIELDTOCALL</c>).</summary>
    public decimal? YieldToCall { get; set; }

    /// <summary>Gets or sets the yield to maturity (<c>YIELDTOMAT</c>).</summary>
    public decimal? YieldToMaturity { get; set; }
}
