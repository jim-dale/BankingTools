using System;

namespace OfxNet
{
    public class OfxAccountBalance
    {
        public decimal Balance { get; set; }
        public DateTimeOffset DateAsOf { get; set; }
    }
}
