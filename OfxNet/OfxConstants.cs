using System.Globalization;

namespace OfxNet
{
    public static class OfxConstants
    {
        #region OFX Data string constants
        public const string OfxTag = "OFX";
        public const string SignonMessageSetResponseV1 = "SIGNONMSGSRSV1";
        public const string SignonResponse = "SONRS";

        public const string BankMessageSetResponseV1 = "BANKMSGSRSV1";
        public const string StatementTxResponse = "STMTTRNRS";
        public const string StatementResponse = "STMTRS";
        public const string BankAccountFrom = "BANKACCTFROM";
        public const string BankAccountTo = "BANKACCTTO";
        public const string BankTransactionList = "BANKTRANLIST";

        public const string CreditCardMessageSetResponseV1 = "CREDITCARDMSGSRSV1";
        public const string CreditCardMessageSetResponseV2 = "CREDITCARDMSGSRSV2";
        public const string CreditCardStatementTxResponse = "CCSTMTTRNRS";
        public const string CreditCardStatementResponse = "CCSTMTRS";
        public const string CreditCardAccountFrom = "CCACCTFROM";
        public const string CreditCardAccountTo = "CCACCTTO";

        public const string IntuBId = "INTU.BID";
        public const string Language = "LANGUAGE";
        public const string ServerDate = "DTSERVER";
        public const string TransactionUid = "TRNUID";
        public const string Status = "STATUS";
        public const string Code = "CODE";
        public const string Severity = "SEVERITY";
        public const string DefaultCurrency = "CURDEF";
        public const string Currency = "CURRENCY";
        public const string OriginalCurrency = "ORIGCURRENCY";
        public const string CurrencyRate = "CURRATE";
        public const string CurrencySymbol = "CURSYM";
        public const string StartDate = "DTSTART";
        public const string EndDate = "DTEND";
        public const string BankId = "BANKID";
        public const string BranchId = "BRANCHID";
        public const string AccountId = "ACCTID";
        public const string AccountType = "ACCTTYPE";
        public const string AccountType2 = "ACCTTYPE2";
        public const string AccountKey = "ACCTKEY";
        public const string StatementTransaction = "STMTTRN";
        public const string TransactionType = "TRNTYPE";
        public const string DatePosted = "DTPOSTED";
        public const string UserDate = "DTUSER";
        public const string DateAvailable = "DTAVAIL";
        public const string TransactionAmount = "TRNAMT";
        public const string FitId = "FITID";
        public const string Name = "NAME";
        public const string Memo = "MEMO";
        public const string Memo2 = "MEMO2";
        public const string ChequeNumber = "CHECKNUM";
        public const string ReferenceNumber = "REFNUM";
        public const string CorrectFitId = "CORRECTFITID";
        public const string CorrectAction = "CORRECTACTION";
        public const string ServiceProviderName = "SPNAME";
        public const string ServerTxId = "SRVRTID";
        public const string ServerTxId2 = "SRVRTID2";
        public const string StandardIndustrialCode = "SIC";
        public const string PayeeId = "PAYEEID";
        public const string PayeeId2 = "PAYEEID2";
        public const string Payee = "PAYEE";
        public const string Payee2 = "PAYEE2";
        public const string Address1 = "ADDR1";
        public const string Address2 = "ADDR2";
        public const string Address3 = "ADDR3";
        public const string City = "CITY";
        public const string State = "STATE";
        public const string PostalCode = "POSTALCODE";
        public const string Country = "COUNTRY";
        public const string Phone = "PHONE";
        public const string LedgerBalance = "LEDGERBAL";
        public const string AvailableBalance = "AVAILBAL";
        public const string BalanceAmount = "BALAMT";
        public const string DateAsOf = "DTASOF";
        #endregion

        #region Valid Date & Time formats
        public static DateTimeStyles DefaultDateTimeStyles = DateTimeStyles.AssumeUniversal;

        public static readonly string[] DateTimeFormats = new string[]
        {
            "yyyyMMdd",
            "yyyyMMddHHmm",
            "yyyyMMddHHmmss",
            "yyyyMMddHHmmss[z]",
            "yyyyMMddHHmmss.fff",
            "yyyyMMddHHmmss.fff[z]"
        };
        #endregion

        #region Regular Expression Patterns to remove time zone name from OFX Date/time string
        public const string TimeZoneRegexPattern = @":(\w+)\]\s*$";
        public const string TimeZoneReplacement = "]";
        #endregion
    }
}
