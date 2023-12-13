namespace OfxNet;

using System;
using System.Collections.Generic;

public class OfxTransactionList
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public List<OfxStatementTransaction> Transactions { get; set; } = [];
}
