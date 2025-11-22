namespace OfxNet;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a list of OFX statement transactions within a specified date range.
/// </summary>
public class OfxTransactionList
{
    /// <summary>
    /// Gets or sets the start date of the transaction list.
    /// </summary>
    public DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the transaction list.
    /// </summary>
    public DateTimeOffset EndDate { get; set; }

    /// <summary>
    /// Gets or sets the collection of statement transactions.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Simple implementation.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Simple implementation.")]
    public List<OfxStatementTransaction> Transactions { get; set; } = [];
}
