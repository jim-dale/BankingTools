namespace OfxNet.Investments;

internal static class OfxInvestmentHelpers
{
    /// <summary>
    /// Helper method for getting an optional OfxCurrency for an investment element.
    /// </summary>
    /// <param name="parent">The element being processed.</param>
    /// <param name="subElementName">The name of the optional OfxCurrency child element.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.</param>
    /// <returns>The <see cref="OfxCurrency"/> or null if the child element is not present.</returns>
    public static OfxCurrency? GetOptionalCurrencySubElement(IOfxElement parent, string subElementName, OfxDocumentSettings settings)
    {
        IOfxElement? currencyElement = parent.TryGetElement(subElementName, settings);

        return currencyElement is null
            ? null
            : new OfxCurrency(
                currencyElement.GetDecimal(OfxInvestmentElementConstants.CurrencyRateElement, settings),
                currencyElement.GetString(OfxInvestmentElementConstants.CurrencySymbolElement, settings));
    }

    /// <summary>
    /// Helper method for getting an optional OfxSecurityId for an investment element.
    /// </summary>
    /// <param name="parent">The element being processed.</param>
    /// <param name="subElementName">The name of the optional OfxSecurityId child element.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.</param>
    /// <returns>The <see cref="OfxSecurityId"/> or null if the child element is not present.</returns>
    public static OfxSecurityId? GetOptionalSecurityIdSubElement(IOfxElement parent, string subElementName, OfxDocumentSettings settings)
    {
        IOfxElement? securityElement = parent.TryGetElement(subElementName, settings);

        return securityElement is null
            ? null
            : new OfxSecurityId(securityElement, settings);
    }
}
