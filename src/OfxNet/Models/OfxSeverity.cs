namespace OfxNet;

using System.ComponentModel;

/// <summary>
/// OFX severity values.
/// </summary>
public enum OfxSeverity
{
    /// <summary>
    /// Not set.
    /// </summary>
    NotSet,

    /// <summary>
    /// Informational only.
    /// </summary>
    [Description("Informational only")]
    INFO,

    /// <summary>
    /// Some problem with the request occurred but a valid response still present.
    /// </summary>
    [Description("Some problem with the request occurred but a valid response still present")]
    WARN,

    /// <summary>
    /// A problem severe enough that response could not be made.
    /// </summary>
    [Description("A problem severe enough that response could not be made")]
    ERROR,
}
