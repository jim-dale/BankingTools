namespace OfxNet;

/// <summary>
/// OFX status aggregate.
/// </summary>
public class OfxStatus
{
    /// <summary>
    /// Gets or sets the OFX error code.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the severity of the error.
    /// </summary>
    public OfxSeverity Severity { get; set; }

    /// <summary>
    /// Gets or sets the textual explanation from the financial institution.
    /// </summary>
    public string? Message { get; set; }
}
