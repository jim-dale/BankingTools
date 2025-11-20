namespace OfxNet.Investments;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents investment account balances (<c>INVBAL</c> aggregate).
/// </summary>
// <!ELEMENT INVBAL - - (AVAILCASH?, MARGINBALANCE?, SHORTBALANCE?, BUYPOWER?, BALLIST?)>
// <!ELEMENT BALLIST  - - (BAL*) > is inlined.
public class OfxInvestmentBalance
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentBalance"/> class.
    /// </summary>
    public OfxInvestmentBalance()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentBalance"/> class
    /// by parsing the <c>INVBAL</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    public OfxInvestmentBalance(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.AvailableCash = element.TryGetDecimal(OfxInvestmentElementConstants.AvailableCashElement, settings);
        this.BuyPower = element.TryGetDecimal(OfxInvestmentElementConstants.BuyPowerElement, settings);
        this.Margin = element.TryGetDecimal(OfxInvestmentElementConstants.MarginBalanceElement, settings);
        this.Other = GetOptionalBalanceList(element, settings);
        this.ShortBalance = element.TryGetDecimal(OfxInvestmentElementConstants.ShortBalanceElement, settings);
    }

    /// <summary>Gets the available cash balance (<c>AVAILCASH</c>).</summary>
    public decimal? AvailableCash { get; init; }

    /// <summary>Gets the buying power (<c>BUYPOWER</c>).</summary>
    public decimal? BuyPower { get; init; }

    /// <summary>Gets the margin balance (<c>MARGINBALANCE</c>).</summary>
    public decimal? Margin { get; init; }

    /// <summary>Gets the list of additional balances (<c>BALLIST</c>).</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxBalance>? Other { get; init; }

    /// <summary>Gets the short balance (<c>SHORTBALANCE</c>).</summary>
    public decimal? ShortBalance { get; init; }

    /// <summary>
    /// Helper to load the optional BalanceList property.
    /// </summary>
    private static List<OfxBalance>? GetOptionalBalanceList(IOfxElement element, OfxDocumentSettings settings)
    {
        List<OfxBalance>? balances = null;

        IOfxElement? balanceListElement = element.TryGetElement(OfxInvestmentElementConstants.BalanceListElement, settings);
        if (balanceListElement is not null)
        {
            balances = [];
            foreach (var balElement in balanceListElement.Elements(OfxInvestmentElementConstants.BalanceElement, settings.TagComparer))
            {
                balances.Add(new OfxBalance(balElement, settings));
            }
        }

        return balances;
    }
}
