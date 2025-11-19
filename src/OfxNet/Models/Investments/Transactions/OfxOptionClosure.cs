namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an option closure transaction (<c>CLOSUREOPT</c> aggregate).
/// </summary>
// <!ELEMENT CLOSUREOPT - - (INVTRAN, SECID, OPTACTION, UNITS, SHPERCTRCT, SUBACCTSEC?, RELFITID?, GAIN?)>
public class OfxOptionClosure : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionClosure"/> class.
    /// </summary>
    public OfxOptionClosure()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxOptionClosure"/> class
    /// by parsing the <c>CLOSUREOPT</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxOptionClosure(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.OptAction = element.GetString(OfxInvestmentElementConstants.OptActionElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SharesPerContract = element.GetInt(OfxInvestmentElementConstants.SharesPerContractElement, settings);
        this.Units = element.GetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
        this.Gain = element.TryGetDecimal(OfxInvestmentElementConstants.GainElement, settings);
        this.RelatedInstitutionId = element.TryGetString(OfxInvestmentElementConstants.RelatedFitIdElement, settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
    }

    /// <summary>Gets the gain amount (<c>GAIN</c>).</summary>
    public decimal? Gain { get; init; }

    /// <summary>Gets the option action (<c>OPTACTION</c>).</summary>
    /// <remarks>Indicates the type of option action (e.g., "EXERCISE", "ASSIGN", "EXPIRE").</remarks>
    required public string OptAction { get; init; }

    /// <summary>Gets the related transaction identifier (<c>RELFITID</c>).</summary>
    /// <remarks>Provides a reference to a related transaction, if applicable.</remarks>
    public string? RelatedInstitutionId { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    required public OfxSecurityId Security { get; init; }

    /// <summary>Gets the shares per contract (<c>SHPERCTRCT</c>).</summary>
    required public int SharesPerContract { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the number of option units (<c>UNITS</c>).</summary>
    required public decimal Units { get; init; }
}
