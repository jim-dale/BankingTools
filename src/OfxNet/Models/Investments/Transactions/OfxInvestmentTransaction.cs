namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an investment transaction header (<c>INVTRAN</c> aggregate).
/// </summary>
// <!ELEMENT INVTRAN - - (FITID, DTTRADE, DTSETTLE?, SRVRTID?, MEMO?)>
public class OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentTransaction"/> class.
    /// </summary>
    public OfxInvestmentTransaction()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentTransaction"/> class
    /// by parsing the <c>INVTRAN</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>INVTRAN</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentTransaction(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.InstitutionId = element.GetString(OfxInvestmentElementConstants.FitIdElement, settings);
        this.Memo = element.TryGetString(OfxInvestmentElementConstants.MemoElement, settings);
        this.SettlementDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.SettlementDateElement, settings);
        this.ServerId = element.TryGetString(OfxInvestmentElementConstants.ServerIdElement, settings);
        this.TradeDate = element.GetDateTimeOffset(OfxInvestmentElementConstants.TradeDateElement, settings);
    }

    /// <summary>Gets the unique transaction identifier (<c>FITID</c>).</summary>
    public required string InstitutionId { get; init; }

    /// <summary>Gets the optional memo (<c>MEMO</c>).</summary>
    public string? Memo { get; init; }

    /// <summary>Gets the optional settlement date (<c>DTSETTLE</c>).</summary>
    public DateTimeOffset? SettlementDate { get; init; }

    /// <summary>Gets the optional server-assigned identifier (<c>SRVRTID</c>).</summary>
    public string? ServerId { get; init; }

    /// <summary>Gets the trade date (<c>DTTRADE</c>).</summary>
    public required DateTimeOffset TradeDate { get; init; }
}
