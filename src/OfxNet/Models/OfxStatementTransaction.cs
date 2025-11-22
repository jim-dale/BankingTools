namespace OfxNet;

using System;

/// <summary>
/// Represents a single transaction in an OFX statement.
/// Contains transaction type, posting and optional user/availability dates, amount,
/// identifiers (FITID, server Tx ID, reference), descriptive fields (name, memos),
/// corrective action data, payee and currency information, and optional destination
/// account details for transfers or payments.
/// </summary>
public class OfxStatementTransaction
{
    /// <summary>
    /// Gets or sets the type of the transaction.
    /// </summary>
    public OfxTransactionType TxType { get; set; }

    /// <summary>
    /// Gets or sets the date the transaction was posted.
    /// </summary>
    public DateTimeOffset DatePosted { get; set; }

    /// <summary>
    /// Gets or sets the date the transaction was entered by the user, if available.
    /// </summary>
    public DateTimeOffset? DateUser { get; set; }

    /// <summary>
    /// Gets or sets the date the transaction became available, if available.
    /// </summary>
    public DateTimeOffset? DateAvailable { get; set; }

    /// <summary>
    /// Gets or sets the amount of the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the financial institution transaction ID.
    /// </summary>
    public string? FitId { get; set; }

    /// <summary>
    /// Gets or sets the name associated with the transaction.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the memo for the transaction.
    /// </summary>
    public string? Memo { get; set; }

    /// <summary>
    /// Gets or sets an additional memo for the transaction.
    /// </summary>
    public string? Memo2 { get; set; }

    /// <summary>
    /// Gets or sets the cheque number, if applicable.
    /// </summary>
    public string? ChequeNumber { get; set; }

    /// <summary>
    /// Gets or sets the reference number for the transaction.
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the corrected financial institution transaction ID, if applicable.
    /// </summary>
    public string? CorrectFitId { get; set; }

    /// <summary>
    /// Gets or sets the corrective action for the transaction.
    /// </summary>
    public OfxCorrectiveAction CorrectAction { get; set; }

    /// <summary>
    /// Gets or sets the name of the service provider, if available.
    /// </summary>
    public string? ServiceProviderName { get; set; }

    /// <summary>
    /// Gets or sets the server transaction ID, if available.
    /// </summary>
    public string? ServerTxId { get; set; }

    /// <summary>
    /// Gets or sets the standard industrial code, if available.
    /// </summary>
    public int? StandardIndustrialCode { get; set; }

    /// <summary>
    /// Gets or sets the payee ID, if available.
    /// </summary>
    public string? PayeeId { get; set; }

    /// <summary>
    /// Gets or sets the payee information, if available.
    /// </summary>
    public OfxPayee? Payee { get; set; }

    /// <summary>
    /// Gets or sets the currency of the transaction, if available.
    /// </summary>
    public OfxCurrency? Currency { get; set; }

    /// <summary>
    /// Gets or sets the original currency of the transaction, if available.
    /// </summary>
    public OfxCurrency? OriginalCurrency { get; set; }

    /// <summary>
    /// Gets or sets the destination bank account, if applicable.
    /// </summary>
    public OfxBankAccount? BankAccountTo { get; set; }

    /// <summary>
    /// Gets or sets the destination credit card account, if applicable.
    /// </summary>
    public OfxCreditCardAccount? CreditCardAccountTo { get; set; }
}
