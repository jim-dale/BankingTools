using System.ComponentModel;

namespace OfxNet
{
    public enum OfxCorrectiveAction
    {
        NotSet,
        [Description("Replace this transaction with one referenced by CORRECTFITID")]
        REPLACE,
        [Description("Delete transaction")]
        DELETE,
    }
}
