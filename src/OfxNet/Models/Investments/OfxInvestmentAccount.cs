namespace OfxNet.Investments;

/// <summary>
/// Represents an investment account reference (<c>INVACCTFROM</c> or <c>INVACCTTO</c> aggregate).
/// </summary>
// <!ELEMENT INVACCTFROM  - - (BROKERID, ACCTID) >
// <!ELEMENT INVACCTTO  - - (BROKERID, ACCTID) >
public class OfxInvestmentAccount : OfxAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentAccount"/> class.
    /// </summary>
    public OfxInvestmentAccount()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentAccount"/> class
    /// by parsing the <c>INVACCTFROM</c> or <c>INVACCTTO</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements <c>BROKERID</c> or <c>ACCTID</c> are missing or invalid.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentAccount(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.AccountNumber = element.GetString(OfxInvestmentElementConstants.AccountIdElement, settings);
        this.BrokerId = element.GetString(OfxInvestmentElementConstants.BrokerIdElement, settings);
        this.Checksum = element.TryGetString(OfxInvestmentElementConstants.AccountKeyElement, settings);
    }

    /// <summary>Gets the broker identifier (<c>BROKERID</c>).</summary>
    public required string BrokerId { get; init; }
}
