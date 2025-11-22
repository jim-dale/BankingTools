namespace OfxNet;

#pragma warning disable SA1402 // File may only contain a single type

/// <summary>
/// Represents a financial statement containing account balances and transactions.
/// </summary>
public class OfxStatement
{
    /// <summary>
    /// Gets or sets the default currency for the statement.
    /// </summary>
    public string? DefaultCurrency { get; set; }

    /// <summary>
    /// Gets or sets the ledger balance of the account.
    /// </summary>
    public OfxAccountBalance? LedgerBalance { get; set; }

    /// <summary>
    /// Gets or sets the available balance of the account.
    /// </summary>
    public OfxAccountBalance? AvailableBalance { get; set; }

    /// <summary>
    /// Gets or sets the list of transactions for the statement.
    /// </summary>
    public OfxTransactionList? TransactionList { get; set; }
}

/// <summary>
/// Represents a financial statement with a specific account type.
/// </summary>
/// <typeparam name="TAccount">The type of the account associated with the statement.</typeparam>
public class OfxStatement<TAccount> : OfxStatement
{
    /// <summary>
    /// Gets or sets the account associated with the statement.
    /// </summary>
    public TAccount? Account { get; set; }
}
