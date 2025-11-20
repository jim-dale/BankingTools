namespace OfxNet.Investments;

using OfxNet;

/// <summary>
/// Represents a security identifier (<c>SECID</c> aggregate).
/// </summary>
// <!ELEMENT SECID  - - (UNIQUEID , UNIQUEIDTYPE) >
public class OfxSecurityId
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurityId"/> class.
    /// </summary>
    public OfxSecurityId()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxSecurityId"/> class.
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
    public OfxSecurityId(IOfxElement element, OfxDocumentSettings settings)
    {
        this.Id = element.GetString(OfxInvestmentElementConstants.IdElement, settings);
        this.IdType = element.GetString(OfxInvestmentElementConstants.IdTypeElement, settings);
    }

    /// <summary>The Unique ID for the Security.</summary>
    required public string Id { get; init; }

    /// <summary>Standard used for Unique ID e.g. CUSIP.</summary>
    /// <remarks>
    /// Indicates the standard used for the identifier, such as "CUSIP",
    /// "ISIN", or another recognized scheme.
    /// </remarks>
    required public string IdType { get; init; }
}
