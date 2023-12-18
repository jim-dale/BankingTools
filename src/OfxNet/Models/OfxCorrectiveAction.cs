namespace OfxNet;

using System.ComponentModel;

/// <summary>
/// OFX corrective action enum values.
/// </summary>
public enum OfxCorrectiveAction
{
    /// <summary>
    /// Not set.
    /// </summary>
    NotSet,

    /// <summary>
    /// Replace this transaction with one referenced by <c>CORRECTFITID</c>.
    /// </summary>
    [Description("Replace this transaction with one referenced by CORRECTFITID")]
    REPLACE,

    /// <summary>
    /// Delete transaction.
    /// </summary>
    [Description("Delete transaction")]
    DELETE,
}
