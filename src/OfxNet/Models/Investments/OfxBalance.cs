namespace OfxNet.Investments;

/// <summary>
/// Represents a balance entry (<c>BAL</c> aggregate).
/// </summary>
// <!ELEMENT BAL - - (NAME?, DESC?, BALTYPE?, VALUE, DTASOF?, CURRENCY?)>
public class OfxBalance : OfxAccountBalance
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBalance"/> class.
    /// </summary>
    public OfxBalance()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxBalance"/> class
    /// by parsing the <c>BAL</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required element <c>VALUE</c> is missing or invalid.
    /// </exception>
    public OfxBalance(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);

        this.Balance = element.GetDecimal(OfxInvestmentElementConstants.BalanceValueElement, settings);
        this.BalanceType = element.TryGetString(OfxInvestmentElementConstants.BalanceTypeElement, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.DateAsOf = element.TryGetDateTimeOffset(OfxInvestmentElementConstants.DateAsOfElement, settings) ?? default; // TODO: this.DateAsOf should be nullable but currently is not.
        this.Description = element.TryGetString(OfxInvestmentElementConstants.DescriptionElement, settings);
        this.Name = element.TryGetString(OfxInvestmentElementConstants.NameElement, settings);
    }

    /// <summary>Gets the balance type (<c>BALTYPE</c>).</summary>
    public string? BalanceType { get; init; }

    /// <summary>Gets the currency information (<c>CURRENCY</c>).</summary>
    public OfxCurrency? Currency { get; init; }

    /// <summary>Gets the balance description (<c>DESC</c>).</summary>
    public string? Description { get; init; }

    /// <summary>Gets the balance name (<c>NAME</c>).</summary>
    public string? Name { get; init; }
}
