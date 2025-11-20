namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an option buy transaction (<c>BUYOPT</c> aggregate).
/// </summary>
// <!ELEMENT BUYOPT - - (INVBUY, OPTBUYTYPE, SHPERCTRCT)>
public class OfxBuyOption : OfxBuyInvestment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyOption"/> class.
    /// </summary>
    public OfxBuyOption()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBuyOption"/> class
    /// by parsing the <c>BUYOPT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxBuyOption(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvBuyElement, settings), settings)
    {
        this.OptionBuyType = element.GetString(OfxInvestmentElementConstants.OptBuyTypeElement, settings);
        this.SharesPerContract = element.GetInt(OfxInvestmentElementConstants.SharesPerContractElement, settings);
    }

    /// <summary>Gets the option buy type (<c>OPTBUYTYPE</c>).</summary>
    required public string OptionBuyType { get; init; }

    /// <summary>Gets the shares per contract (<c>SHPERCTRCT</c>).</summary>
    required public int SharesPerContract { get; init; }
}
