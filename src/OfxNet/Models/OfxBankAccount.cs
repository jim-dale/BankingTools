namespace OfxNet;

/// <summary>
/// OFX Bank account information.
/// </summary>
public class OfxBankAccount : OfxAccount
{
    /// <summary>
    /// Gets or sets the bank identifier.
    /// </summary>
    public string? BankId { get; set; }

    /// <summary>
    /// Gets or sets the branch identifier.
    /// </summary>
    public string? BranchId { get; set; }

    /// <summary>
    /// Gets or sets the type of account.
    /// </summary>
    public OfxAccountType AccountType { get; set; }
}
