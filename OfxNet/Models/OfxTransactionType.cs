using System.ComponentModel;

namespace OfxNet
{
    public enum OfxTransactionType
    {
        NotSet,
        [Description("Generic credit")]
        CREDIT,
        [Description("Generic debit")]
        DEBIT,
        [Description("Interest earned or paid. Note: Depends on signage of amount")]
        INT,
        [Description("Dividend")]
        DIV,
        [Description("FI fee")]
        FEE,
        [Description("Service charge")]
        SRVCHG,
        [Description("Deposit")]
        DEP,
        [Description("ATM debit or credit. Note: Depends on signage of amount")]
        ATM,
        [Description("Point of sale debit or credit. Note: Depends on signage of amount")]
        POS,
        [Description("Transfer")]
        XFER,
        [Description("Check")]
        CHECK,
        [Description("Electronic payment")]
        PAYMENT,
        [Description("Cash withdrawal")]
        CASH,
        [Description("Direct Deposit")]
        DIRECTDEP,
        [Description("Merchant Initiated Debit")]
        DIRECTDEBIT,
        [Description("Repeating payment/standing order")]
        REPEATPMT,
        [Description("Only valid in <STMTTRNP>; indicates the amount is under a hold. Note: Depends on signage of amount and account type")]
        HOLD,
        [Description("Other")]
        OTHER,
    }
}
