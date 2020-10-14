using System;

namespace OfxNet
{
    public class OfxStatementTransaction
    {
        public OfxTransactionType TxType { get; set; }
        public DateTimeOffset DatePosted { get; set; }
        public DateTimeOffset? DateUser { get; set; }
        public DateTimeOffset? DateAvailable { get; set; }
        public decimal Amount { get; set; }
        public string FitId { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public string Memo2 { get; set; }
        public string ChequeNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string CorrectFitId { get; set; }
        public OfxCorrectiveAction CorrectAction { get; set; }
        public string ServiceProviderName { get; set; }
        public string ServerTxId { get; set; }
        public int? StandardIndustrialCode { get; set; }
        public string PayeeId { get; set; }
        public OfxPayee Payee { get; set; }
        public OfxCurrency Currency { get; set; }
        public OfxCurrency OriginalCurrency { get; set; }
        public OfxBankAccount BankAccountTo { get; set; }
        public OfxCreditCardAccount CreditCardAccountTo { get; set; }
    }
}
