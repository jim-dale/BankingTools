namespace OfxNet;

using System;
using System.Collections.Generic;

public class OfxTransactionList
{
    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxStatementTransaction> Transactions { get; set; } = [];
}
