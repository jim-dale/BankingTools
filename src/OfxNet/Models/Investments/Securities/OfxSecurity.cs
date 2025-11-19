namespace OfxNet.Investments.Securities;

/// <summary>
/// Represents common security information (<c>SECINFO</c> aggregate).
/// </summary>
// <!ELEMENT SECINFO  - - (SECID, SECNAME, TICKER?, FIID?, RATING?, UNITPRICE?, DTASOF?, CURRENCY?, MEMO?)>
public class OfxSecurity : OfxSecurityId
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurity"/> class.
    /// </summary>
    public OfxSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurity"/> class.
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
    public OfxSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings)
    {
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.FinancialInstitutionId = element.TryGetString(OfxInvestmentElementConstants.FiIdElement, settings);
        this.Memo = element.TryGetString(OfxInvestmentElementConstants.MemoElement, settings);
        this.Name = element.GetString(OfxInvestmentElementConstants.SecurityNameElement, settings);
        this.Price = element.TryGetDecimal(OfxInvestmentElementConstants.UnitPriceElement, settings);
        this.PriceAsOfDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.DateAsOfElement, settings);
        this.Rating = element.TryGetString(OfxInvestmentElementConstants.RatingElement, settings);
        this.Ticker = element.TryGetString(OfxInvestmentElementConstants.TickerElement, settings);
    }

    /// <summary>The currency used for this entry.</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>The ticker for the security.</summary>
    public string? FinancialInstitutionId { get; init; }

    /// <summary>The memo for the security.</summary>
    public string? Memo { get; init; }

    /// <summary>The name of the security.</summary>
    required public string Name { get; init; }

    /// <summary>The unit price for the security.</summary>
    public decimal? Price { get; init; }

    /// <summary>The date for the price entry.</summary>
    public DateTimeOffset? PriceAsOfDate { get; init; }

    /// <summary>The rating for the security.</summary>
    public string? Rating { get; init; }

    /// <summary>The ticker for the security.</summary>
    public string? Ticker { get; init; }
}
