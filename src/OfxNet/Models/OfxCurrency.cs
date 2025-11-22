namespace OfxNet;

/// <summary>
/// Represents a currency with its exchange rate and symbol.
/// </summary>
public class OfxCurrency(decimal rate, string symbol)
{
    /// <summary>
    /// Gets the exchange rate for the currency.
    /// </summary>
    public decimal Rate { get; init; } = rate;

    /// <summary>
    /// Gets the symbol of the currency.
    /// </summary>
    public string Symbol { get; init; } = symbol;
}
