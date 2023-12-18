namespace OfxNet;

using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Transactions;

/// <summary>
/// Constants for parsing OFX documents.
/// </summary>
public static class OfxConstants
{
    /// <summary>
    /// The OFX document root node.
    /// </summary>
    public const string OfxTag = "OFX";

    /// <summary>
    /// Sign-on message set response.
    /// </summary>
    public const string SignonMessageSetResponseV1 = "SIGNONMSGSRSV1";

    /// <summary>
    /// Sign-on response.
    /// </summary>
    public const string SignonResponse = "SONRS";

    /// <summary>
    /// Bank messsage set response.
    /// </summary>
    public const string BankMessageSetResponseV1 = "BANKMSGSRSV1";

    /// <summary>
    /// Statement transactions response.
    /// </summary>
    public const string StatementTxResponse = "STMTTRNRS";

    /// <summary>
    /// Statement response.
    /// </summary>
    public const string StatementResponse = "STMTRS";

    /// <summary>
    /// Bank account from aggregate.
    /// </summary>
    public const string BankAccountFrom = "BANKACCTFROM";

    /// <summary>
    /// Bank account to aggregate.
    /// </summary>
    public const string BankAccountTo = "BANKACCTTO";

    /// <summary>
    /// Statement transaction data aggregate.
    /// </summary>
    public const string BankTransactionList = "BANKTRANLIST";

    /// <summary>
    /// Credit Card message set response version 1.
    /// </summary>
    public const string CreditCardMessageSetResponseV1 = "CREDITCARDMSGSRSV1";

    /// <summary>
    /// Credit Card message set response version 2.
    /// </summary>
    public const string CreditCardMessageSetResponseV2 = "CREDITCARDMSGSRSV2";

    /// <summary>
    /// Credit Card statement transaction response.
    /// </summary>
    public const string CreditCardStatementTxResponse = "CCSTMTTRNRS";

    /// <summary>
    /// Credit card statement download response.
    /// </summary>
    public const string CreditCardStatementResponse = "CCSTMTRS";

    /// <summary>
    /// Credit Card account from aggregate.
    /// </summary>
    public const string CreditCardAccountFrom = "CCACCTFROM";

    /// <summary>
    /// Credit Card account to aggregate.
    /// </summary>
    public const string CreditCardAccountTo = "CCACCTTO";

    /// <summary>
    /// Intuit bank identifier.
    /// </summary>
    public const string IntuBId = "INTU.BID";

    /// <summary>
    /// Identifies the human-readable language used for such things as status messages and email.
    /// Language is specified as a three-letter code based on ISO-639.
    /// </summary>
    public const string Language = "LANGUAGE";

    /// <summary>
    /// Date and time of the server response.
    /// </summary>
    public const string ServerDate = "DTSERVER";

    /// <summary>
    /// Client-assigned globally-unique ID for this transaction.
    /// </summary>
    public const string TransactionUid = "TRNUID";

    /// <summary>
    /// Status aggregate.
    /// </summary>
    public const string Status = "STATUS";

    /// <summary>
    /// OFX error code.
    /// </summary>
    public const string Code = "CODE";

    /// <summary>
    /// Severity of the error.
    /// <list type="table">
    ///   <item>
    ///     <term>INFO</term>
    ///     <description>Informational only.</description>
    ///   </item>
    ///   <item>
    ///     <term>WARN</term>
    ///     <description>Some problem with the request occurred but a valid response still present.</description>
    ///   </item>
    ///   <item>
    ///     <term>ERROR</term>
    ///     <description>A problem severe enough that response could not be made.</description>
    ///   </item>
    /// </list>
    /// </summary>
    public const string Severity = "SEVERITY";

    /// <summary>
    /// Default currency identifier. The values are based on the ISO-4217 three-letter currency identifiers.
    /// </summary>
    public const string DefaultCurrency = "CURDEF";

    /// <summary>
    /// Currency identifier. The values are based on the ISO-4217 three-letter currency identifiers.
    /// </summary>
    public const string Currency = "CURRENCY";

    /// <summary>
    /// Currency identifier. The values are based on the ISO-4217 three-letter currency identifiers.
    /// </summary>
    public const string OriginalCurrency = "ORIGCURRENCY";

    /// <summary>
    /// Ratio of &lt;CURDEF&gt; currency to &lt;CURSYM&gt; currency, in decimal form.
    /// </summary>
    public const string CurrencyRate = "CURRATE";

    /// <summary>
    /// ISO-4217 3-letter currency identifier.
    /// </summary>
    public const string CurrencySymbol = "CURSYM";

    /// <summary>
    /// Start date of statement requested.
    /// </summary>
    public const string StartDate = "DTSTART";

    /// <summary>
    /// End date of statement requested.
    /// </summary>
    public const string EndDate = "DTEND";

    /// <summary>
    /// Routing: ABA number or S.W.I.F.T. number.
    /// </summary>
    public const string BankId = "BANKID";

    /// <summary>
    /// Branch identifier. May be required for some banks.
    /// </summary>
    public const string BranchId = "BRANCHID";

    /// <summary>
    /// Account number.
    /// </summary>
    public const string AccountId = "ACCTID";

    /// <summary>
    /// Type of account, version 1.
    /// </summary>
    public const string AccountType = "ACCTTYPE";

    /// <summary>
    /// Type of account, version 2.
    /// </summary>
    public const string AccountType2 = "ACCTTYPE2";

    /// <summary>
    /// Checksum.
    /// </summary>
    public const string AccountKey = "ACCTKEY";

    /// <summary>
    /// Statement transaction.
    /// </summary>
    public const string StatementTransaction = "STMTTRN";

    /// <summary>
    /// Transaction type.
    /// </summary>
    public const string TransactionType = "TRNTYPE";

    /// <summary>
    /// Date transaction was posted to account.
    /// </summary>
    public const string DatePosted = "DTPOSTED";

    /// <summary>
    /// Date user initiated transaction, if known.
    /// </summary>
    public const string UserDate = "DTUSER";

    /// <summary>
    /// Date funds are available.
    /// </summary>
    public const string DateAvailable = "DTAVAIL";

    /// <summary>
    /// Amount of transaction.
    /// </summary>
    public const string TransactionAmount = "TRNAMT";

    /// <summary>
    /// Transaction ID issued by financial institution.
    /// </summary>
    public const string FitId = "FITID";

    /// <summary>
    /// Name of payee or description of transaction.
    /// </summary>
    public const string Name = "NAME";

    /// <summary>
    /// Extra information (not in &lt;NAME&gt;), version 1.
    /// </summary>
    public const string Memo = "MEMO";

    /// <summary>
    /// Extra information (not in &lt;NAME&gt;), version 2.
    /// </summary>
    public const string Memo2 = "MEMO2";

    /// <summary>
    /// Check (or other reference) number.
    /// </summary>
    public const string ChequeNumber = "CHECKNUM";

    /// <summary>
    /// Reference number that uniquely identifies the transaction.
    /// </summary>
    public const string ReferenceNumber = "REFNUM";

    /// <summary>
    /// If present, the FITID of a previously sent transaction that is corrected by this record.
    /// This transaction replaces or deletes the transaction that it corrects, based on the value of &lt;CORRECTACTION&gt;.
    /// </summary>
    public const string CorrectFitId = "CORRECTFITID";

    /// <summary>
    /// Actions can be REPLACE or DELETE. REPLACE replaces the transaction referenced by CORRECTFITID; DELETE deletes it.
    /// </summary>
    public const string CorrectAction = "CORRECTACTION";

    /// <summary>
    /// Service provider name.
    /// </summary>
    public const string ServiceProviderName = "SPNAME";

    /// <summary>
    /// Server assigned transaction ID; used for transactions initiated by client, such as payment or funds transfer.
    /// </summary>
    public const string ServerTxId = "SRVRTID";

    /// <summary>
    ///  Server assigned transaction ID; used for transactions initiated by client, such as payment or funds transfer.
    /// </summary>
    public const string ServerTxId2 = "SRVRTID2";

    /// <summary>
    /// Standard Industrial Code.
    /// </summary>
    public const string StandardIndustrialCode = "SIC";

    /// <summary>
    /// Payee identifier if available, version 1.
    /// </summary>
    public const string PayeeId = "PAYEEID";

    /// <summary>
    /// Payee identifier if available, version 2.
    /// </summary>
    public const string PayeeId2 = "PAYEEID2";

    /// <summary>
    /// Payee aggregate, version 1.
    /// </summary>
    public const string Payee = "PAYEE";

    /// <summary>
    /// Payee aggregate, version 2.
    /// </summary>
    public const string Payee2 = "PAYEE2";

    /// <summary>
    /// FI address, line 1.
    /// </summary>
    public const string Address1 = "ADDR1";

    /// <summary>
    /// FI address, line 2.
    /// </summary>
    public const string Address2 = "ADDR2";

    /// <summary>
    /// FI address, line 3.
    /// </summary>
    public const string Address3 = "ADDR3";

    /// <summary>
    /// FI address city.
    /// </summary>
    public const string City = "CITY";

    /// <summary>
    /// FI address state.
    /// </summary>
    public const string State = "STATE";

    /// <summary>
    /// FI address postal code.
    /// </summary>
    public const string PostalCode = "POSTALCODE";

    /// <summary>
    /// FI address country.
    /// </summary>
    public const string Country = "COUNTRY";

    /// <summary>
    /// Telephone number for the account.
    /// </summary>
    public const string Phone = "PHONE";

    /// <summary>
    /// Ledger balance aggregate.
    /// </summary>
    public const string LedgerBalance = "LEDGERBAL";

    /// <summary>
    /// Available balance aggregate.
    /// </summary>
    public const string AvailableBalance = "AVAILBAL";

    /// <summary>
    /// Balance amount.
    /// </summary>
    public const string BalanceAmount = "BALAMT";

    /// <summary>
    /// Balance date.
    /// </summary>
    public const string DateAsOf = "DTASOF";

    /// <summary>
    /// Used when parsing datetime values to set defaults.
    /// </summary>
    public const DateTimeStyles DefaultDateTimeStyles = DateTimeStyles.AssumeUniversal;

    /// <summary>
    /// Used when parsing datetime values to remove the timezone name.
    /// </summary>
    public const string TimeZoneRegexPattern = @":(\w+)\]\s*$";

    /// <summary>
    /// Used when parsing datetime values to remove the timezone name.
    /// </summary>
    public const string TimeZoneReplacement = "]";

    /// <summary>
    /// Supported OFX datetime formats.
    /// </summary>
    /// <remarks>The full specification is <c>YYYYMMDDHHMMSS.XXX [gmt offset:tz name]</c>.
    /// <para>Datetime also accepts values with fields omitted from the right.</para></remarks>
    public static readonly string[] DateTimeFormats =
    [
        "yyyyMMdd",
        "yyyyMMddHHmm",
        "yyyyMMddHHmmss",
        "yyyyMMddHHmmss[z]",
        "yyyyMMddHHmmss.fff",
        "yyyyMMddHHmmss.fff[z]"
    ];
}
