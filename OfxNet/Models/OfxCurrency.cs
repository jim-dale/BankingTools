
namespace OfxNet
{
    public class OfxCurrency
    {
        public decimal Rate { get; init; }
        public string Symbol { get; init; }

        public OfxCurrency(decimal rate, string symbol)
        {
            Rate = rate;
            Symbol = symbol;
        }
    }
}
