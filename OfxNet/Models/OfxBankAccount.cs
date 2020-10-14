
namespace OfxNet
{
    public class OfxBankAccount : OfxAccount
    {
        public string BankId { get; set; }
        public string BranchId { get; set; }
        public OfxAccountType AccountType { get; set; }
    }
}
