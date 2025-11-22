namespace OfxNet.Investments.Transactions;

/// <summary>
/// Common base class for journal transactions (<c>JOURNALSEC</c> and <c>JOURNALFUND</c>).
/// This class intentionally has no members, serving only as a marker type
/// to allow querying all journal transactions together.
/// </summary>
public class OfxJournalTransaction : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalTransaction"/> class.
    /// </summary>
    public OfxJournalTransaction()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxJournalTransaction"/> class.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxJournalTransaction(IOfxElement element, OfxDocumentSettings settings)
        : base(element, settings)
    {
        // No additional members; serves as a marker base class.
    }
}
