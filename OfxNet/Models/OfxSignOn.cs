using System;

namespace OfxNet
{
    public class OfxSignOn
    {
        public OfxStatus Status { get; set; }
        public DateTimeOffset ServerDate { get; set; }
        public string Language { get; set; }
        public string IntuBid { get; set; }
    }
}
