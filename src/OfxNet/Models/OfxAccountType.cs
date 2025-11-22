namespace OfxNet;

using System.ComponentModel;

/// <summary>
/// Specifies the type of account for OFX transactions.
/// </summary>
public enum OfxAccountType
{
    /// <summary>
    /// Account type is not set.
    /// </summary>
    [Description("Not Set")]
    NotSet,

    /// <summary>
    /// Checking account.
    /// </summary>
    [Description("Checking")]
    CHECKING,

    /// <summary>
    /// Savings account.
    /// </summary>
    [Description("Savings")]
    SAVINGS,

    /// <summary>
    /// Money market account.
    /// </summary>
    [Description("Money Market")]
    MONEYMRKT,

    /// <summary>
    /// Line of credit account.
    /// </summary>
    [Description("Line of credit")]
    CREDITLINE,

    /// <summary>
    /// Certificate of deposit account.
    /// </summary>
    [Description("Certificate of Deposit")]
    CD,
}
