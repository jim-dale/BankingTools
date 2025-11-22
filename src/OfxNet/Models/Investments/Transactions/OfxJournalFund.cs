namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a journal fund transaction (<c>JRNLFUND</c> aggregate).
/// </summary>
// <!ELEMENT JRNLFUND - - (INVTRAN, SUBACCTTO, SUBACCTFROM, TOTAL)>
public class OfxJournalFund : OfxJournalTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalFund"/> class.
    /// </summary>
    public OfxJournalFund()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalFund"/> class
    /// by parsing the <c>JRNLFUND</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxJournalFund(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.SubAccountFrom = element.GetString(OfxInvestmentElementConstants.SubAccountFromElement, settings);
        this.SubAccountTo = element.GetString(OfxInvestmentElementConstants.SubAccountToElement, settings);
        this.Total = element.GetDecimal(OfxInvestmentElementConstants.TotalElement, settings);
    }

    /// <summary>Gets the source sub-account (<c>SUBACCTFROM</c>).</summary>
    public required string SubAccountFrom { get; init; }

    /// <summary>Gets the destination sub-account (<c>SUBACCTTO</c>).</summary>
    public required string SubAccountTo { get; init; }

    /// <summary>Gets the total amount transferred (<c>TOTAL</c>).</summary>
    public required decimal Total { get; init; }
}
