namespace OfxNet.Investments.Transactions;

/// <summary>
/// Represents an investment banking transaction (<c>INVBANKTRAN</c> aggregate).
/// </summary>
// <!ELEMENT INVBANKTRAN - - (STMTTRN, SUBACCTFUND?)>
public class OfxInvestmentBankTransaction : OfxStatementTransaction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentBankTransaction"/> class.
    /// </summary>
    public OfxInvestmentBankTransaction()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfxInvestmentBankTransaction"/> class
    /// by parsing the <c>INVBANKTRAN</c> aggregate.
    /// </summary>
    /// <param name="element">The <see cref="IOfxElement"/> representing the aggregate.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that defines parsing behavior.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if required elements are missing or invalid in the provided <paramref name="element"/>.
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public OfxInvestmentBankTransaction(IOfxElement element, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(element);
        IOfxElement stmt = element.GetElement(OfxInvestmentElementConstants.StatementTransactionElement, settings);

        if (stmt is null)
        {
            throw new OfxException($"Require element {OfxInvestmentElementConstants.StatementTransactionElement} is missing.");
        }

        // CONSIDER: Carry the element initialization pattern down to OfxStatementTransaction, OfxBankAccount, OfxCreditCardAccount, etc.
        this.Amount = stmt.GetDecimal(OfxInvestmentElementConstants.TransactionAmountElement, settings);
        this.BankAccountTo = GetOptionalBankAccountTo(stmt, settings);
        this.ChequeNumber = stmt.TryGetString(OfxInvestmentElementConstants.ChequeNumberElement, settings);
        this.CorrectFitId = stmt.TryGetString(OfxInvestmentElementConstants.CorrectFitIdElement, settings);
        this.CorrectAction = OfxParser.ParseCorrectiveAction(stmt.TryGetString(OfxInvestmentElementConstants.CorrectActionElement, settings));
        this.CreditCardAccountTo = GetOptionalCreditCardAccountTo(stmt, settings);
        this.Currency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.CurrencyElement, settings);
        this.DateAvailable = stmt.TryGetDateTimeOffset(OfxInvestmentElementConstants.DateAvailableElement, settings);
        this.DatePosted = stmt.GetDateTimeOffset(OfxInvestmentElementConstants.DatePostedElement, settings);
        this.DateUser = stmt.TryGetDateTimeOffset(OfxInvestmentElementConstants.UserDateElement, settings);
        this.FitId = stmt.TryGetString(OfxInvestmentElementConstants.FitIdElement, settings);
        this.Memo = stmt.TryGetString(OfxInvestmentElementConstants.MemoElement, settings);
        this.Memo2 = stmt.TryGetString(OfxInvestmentElementConstants.Memo2Element, settings);
        this.Name = stmt.TryGetString(OfxInvestmentElementConstants.NameElement, settings);
        this.Payee = GetOptionalPayee(stmt, settings);
        this.PayeeId = stmt.TryGetString(OfxInvestmentElementConstants.PayeeIdElement, settings);
        this.OriginalCurrency = OfxInvestmentHelpers.GetOptionalCurrencySubElement(element, OfxInvestmentElementConstants.OriginalCurrencyElement, settings);
        this.ReferenceNumber = stmt.TryGetString(OfxInvestmentElementConstants.ReferenceNumberElement, settings);
        this.ServerTxId = stmt.TryGetString(OfxInvestmentElementConstants.ServerIdElement, settings);
        this.ServiceProviderName = stmt.TryGetString(OfxInvestmentElementConstants.ServiceProviderNameElement, settings);
        this.StandardIndustrialCode = stmt.TryGetInt(OfxInvestmentElementConstants.StandardIndustrialCodeElement, settings);
        this.SubAccountFund = element.TryGetString(OfxInvestmentElementConstants.SubAccountFundElement, settings) ?? string.Empty;
        this.TxType = OfxParser.ParseTransactionType(element.TryGetString(OfxInvestmentElementConstants.TransactionTypeElement, settings));
    }

    /// <summary>Gets the sub-account for the fund (<c>SUBACCTFUND</c>).</summary>
    public string SubAccountFund { get; init; } = string.Empty;

    /// <summary>Helper method to load the optional BankAccountTo property.</summary>
    private static OfxBankAccount? GetOptionalBankAccountTo(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? bankAccountTo = element.TryGetElement(OfxInvestmentElementConstants.BankAccountToElement, settings);

        return bankAccountTo is null
            ? null
            : new OfxBankAccount()
            {
                AccountNumber = bankAccountTo.TryGetString(OfxConstants.AccountId, settings),
                AccountType = OfxParser.ParseAccountType(bankAccountTo.TryGetString(OfxConstants.AccountType2, settings)
                    ?? bankAccountTo.GetString(OfxConstants.AccountType, settings)),
                BankId = bankAccountTo.TryGetString(OfxConstants.BankId, settings),
                BranchId = bankAccountTo.TryGetString(OfxConstants.BranchId, settings),
                Checksum = bankAccountTo.TryGetString(OfxConstants.AccountKey, settings),
            };
    }

    /// <summary>Helper method to load the optional CreditCardAccountTo property.</summary>
    private static OfxCreditCardAccount? GetOptionalCreditCardAccountTo(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? creditCardAccountTo = element.TryGetElement(OfxInvestmentElementConstants.CreditCardAccountToElement, settings);

        return creditCardAccountTo is null
            ? null
            : new OfxCreditCardAccount
            {
                AccountNumber = creditCardAccountTo.TryGetString(OfxConstants.AccountId, settings),
                Checksum = creditCardAccountTo.TryGetString(OfxConstants.AccountKey, settings),
            };
    }

    /// <summary>Helper method to load the optional Payee property.</summary>
    private static OfxPayee? GetOptionalPayee(IOfxElement element, OfxDocumentSettings settings)
    {
        IOfxElement? payeeElement = element.TryGetElement(OfxInvestmentElementConstants.PayeeElement, settings);
        return payeeElement is null
            ? null
            : new OfxPayee()
            {
                Name = payeeElement.TryGetString(OfxConstants.Name, settings),
                AddressLine1 = payeeElement.TryGetString(OfxConstants.Address1, settings),
                AddressLine2 = payeeElement.TryGetString(OfxConstants.Address2, settings),
                AddressLine3 = payeeElement.TryGetString(OfxConstants.Address3, settings),
                City = payeeElement.TryGetString(OfxConstants.City, settings),
                State = payeeElement.TryGetString(OfxConstants.State, settings),
                PostalCode = payeeElement.TryGetString(OfxConstants.PostalCode, settings),
                Country = payeeElement.TryGetString(OfxConstants.Country, settings),
                PhoneNumber = payeeElement.TryGetString(OfxConstants.Phone, settings),
            };
    }
}
