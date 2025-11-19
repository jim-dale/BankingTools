namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents a transfer transaction (<c>TRANSFER</c> aggregate).
/// </summary>
// <!ELEMENT TRANSFER - - (INVTRAN, SECID, SUBACCTSEC?, UNITS, TFERACTION, POSTYPE, INVACCTFROM?, AVGCOSTBASIS?, UNITPRICE?, DTPURCHASE?)>
public class OfxTransfer : OfxInvestmentTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxTransfer"/> class.
    /// </summary>
    public OfxTransfer()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxTransfer"/> class
    /// by parsing the <c>TRANSFER</c> aggregate.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOfxElement"/> representing the <c>TRANSFER</c> aggregate.
    /// </param>
    /// <param name="settings">
    /// The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxTransfer(IOfxElement element, OfxDocumentSettings settings)
        : base(element.GetElement(OfxInvestmentElementConstants.InvTranElement, settings), settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.AverageCostBasis = element.TryGetDecimal(OfxInvestmentElementConstants.AverageCostBasisElement, settings);
        this.InvestmentAccountFrom = GetOptionalInvestmentAcount(element, OfxInvestmentElementConstants.InvestmentAccountFromElement, settings);
        this.PositionType = element.GetString(OfxInvestmentElementConstants.PositionTypeElement, settings);
        this.PurchaseDate = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.PurchaseDateElement, settings);
        this.Security = new OfxSecurityId(element.GetElement(OfxInvestmentElementConstants.SecurityIdElement, settings), settings);
        this.SubAccountSecurity = element.TryGetString(OfxInvestmentElementConstants.SubAccountSecurityElement, settings);
        this.TransferAction = element.GetString(OfxInvestmentElementConstants.TransferActionElement, settings);
        this.UnitPrice = element.TryGetDecimal(OfxInvestmentElementConstants.UnitPriceElement, settings);
        this.Units = element.GetDecimal(OfxInvestmentElementConstants.UnitsElement, settings);
    }

    /// <summary>Gets the average cost basis (<c>AVGCOSTBASIS</c>).</summary>
    public decimal? AverageCostBasis { get; init; }

    /// <summary>Gets the originating investment account (<c>INVACCTFROM</c>).</summary>
    public OfxInvestmentAccount? InvestmentAccountFrom { get; init; }

    /// <summary>Gets the position type (<c>POSTYPE</c>).</summary>
    required public string PositionType { get; init; }

    /// <summary>Gets the purchase date (<c>DTPURCHASE</c>).</summary>
    public DateTimeOffset? PurchaseDate { get; init; }

    /// <summary>Gets the security identifier (<c>SECID</c>).</summary>
    required public OfxSecurityId Security { get; init; }

    /// <summary>Gets the sub-account for the security (<c>SUBACCTSEC</c>).</summary>
    public string? SubAccountSecurity { get; init; }

    /// <summary>Gets the transfer action (<c>TFERACTION</c>).</summary>
    required public string TransferAction { get; init; }

    /// <summary>Gets the unit price (<c>UNITPRICE</c>).</summary>
    public decimal? UnitPrice { get; init; }

    /// <summary>Gets the number of units transferred (<c>UNITS</c>).</summary>
    required public decimal Units { get; init; }

    /// <summary>
    /// Helper method to move logic out of constructor.
    /// </summary>
    private static OfxInvestmentAccount? GetOptionalInvestmentAcount(IOfxElement element, string childElementName, OfxDocumentSettings settings)
    {
        OfxInvestmentAccount? result = null;

        IOfxElement? acctFromElement = element.TryGetElement(OfxInvestmentElementConstants.InvestmentAccountFromElement, settings);
        if (acctFromElement is not null)
        {
            result = new OfxInvestmentAccount(acctFromElement, settings);
        }

        return result;
    }
}
