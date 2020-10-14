using System.ComponentModel;

namespace OfxNet
{
    public enum OfxSeverity
    {
        NotSet,
        [Description("Informational only")]
        INFO,
        [Description("Some problem with the request occurred but a valid response still present")]
        WARN,
        [Description("A problem severe enough that response could not be made")]
        ERROR
    }
}
