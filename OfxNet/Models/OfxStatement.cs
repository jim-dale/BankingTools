
namespace OfxNet
{
    public class OfxStatement
    {
        public string DefaultCurrency { get; set; }
        public OfxAccountBalance LedgerBalance { get; set; }
        public OfxAccountBalance AvailableBalance { get; set; }
        public OfxTransactionList TransactionList { get; set; }
    }

    public class OfxStatement<TAccount> : OfxStatement
    {
        public TAccount Account { get; set; }
    }
}
