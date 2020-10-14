using System;
using System.Collections.Generic;

namespace OfxNet
{
    public class OfxTransactionList
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public List<OfxStatementTransaction> Transactions { get; set; }
    }
}
