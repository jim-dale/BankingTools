namespace OfxNet;

public class OfxCurrency(decimal rate, string symbol)
{
    public decimal Rate { get; init; } = rate;
    public string Symbol { get; init; } = symbol;
}
