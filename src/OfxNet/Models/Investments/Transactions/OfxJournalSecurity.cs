namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a journal security transaction (<c>JRNLSEC</c> aggregate).
/// </summary>
// <!ELEMENT JRNLSEC - - (INVTRAN, SECID, SUBACCTTO, SUBACCTFROM, UNITS)>
public class OfxJournalSecurity : OfxJournalTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalSecurity"/> class.
    /// </summary>
    public OfxJournalSecurity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalSecurity"/> class
    /// by parsing the <c>JRNLSEC</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxJournalSecurity(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountFrom = element.GetString(OfxInvestmentElementConstants.SubAccountFromElement, settings);
        this.SubAccountTo = element.GetString(OfxInvestmentElementConstants.SubAccountToElement, settings);
        this.Units = element.GetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
    }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    public required OfxSecurityId Security { get; init; }

    /// <summary>Gets the source sub-account (<c>SUBACCTFROM</c>).</summary>
    public required string SubAccountFrom { get; init; }

    /// <summary>Gets the destination sub-account (<c>SUBACCTTO</c>).</summary>
    public required string SubAccountTo { get; init; }

    /// <summary>Gets the number of units transferred (<c>UNITS</c>).</summary>
    public required decimal Units { get; init; }
}
