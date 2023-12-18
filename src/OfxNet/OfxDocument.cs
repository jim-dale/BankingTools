namespace OfxNet;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

public class OfxDocument
{
    private readonly object document;

    public OfxDocument(object document)
        : this(document, OfxDocumentSettings.Default)
    {
    }

    public OfxDocument(object document, OfxDocumentSettings settings)
    {
        this.document = document;
        this.Settings = settings;
    }

    public OfxDocumentSettings Settings { get; }

    public static OfxDocument Load(string path)
    {
        return Load(path, OfxDocumentSettings.Default);
    }

    public static OfxDocument Load(string path, OfxDocumentSettings settings)
    {
        OfxDocument result;

        if (SgmlDocument.TryLoad(path, out SgmlDocument? sgmlDocument))
        {
            result = new OfxDocument(sgmlDocument, settings);
        }
        else
        {
            result = new OfxDocument(XDocument.Load(path), settings);
        }

        return result;
    }

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Breaking change.")]
    public IOfxElement? GetRoot()
    {
        IOfxElement? result = default;
        if (this.document is SgmlDocument sgmlDocument)
        {
            result = sgmlDocument.Root;
        }
        else if (this.document is XDocument { Root: not null } xmlDocument)
        {
            result = new XElementAdapter(xmlDocument.Root);
        }

        return result;
    }

    public IEnumerable<OfxStatement> GetStatements()
    {
        IOfxElement? element = this.GetRoot();

        return this.GetStatements(element);
    }

    public IEnumerable<OfxStatement> GetStatements(IOfxElement? element)
    {
        IEnumerable<OfxStatement> result = (element is null)
            ? Enumerable.Empty<OfxStatement>()
            : this.GetBankStatements(element).Concat(this.GetCreditCardStatements(element));

        return result;
    }

    public IEnumerable<OfxStatement> GetBankStatements(IOfxElement element)
    {
        ArgumentNullException.ThrowIfNull(element);

        IOfxElement? set = this.GetElement(element, OfxConstants.BankMessageSetResponseV1);
        IEnumerable<IOfxElement> elements = this.GetElements(set, OfxConstants.StatementTxResponse);
        IEnumerable<OfxBankStatement> statements = this.GetBankStatements(elements);

        if (statements != null)
        {
            foreach (OfxBankStatement statement in statements)
            {
                yield return statement;
            }
        }
    }

    public IEnumerable<OfxStatement> GetCreditCardStatements(IOfxElement element)
    {
        IOfxElement? set = this.GetElement(element, OfxConstants.CreditCardMessageSetResponseV1, OfxConstants.CreditCardMessageSetResponseV2);
        IEnumerable<IOfxElement> elements = this.GetElements(set, OfxConstants.CreditCardStatementTxResponse);
        IEnumerable<OfxCreditCardStatement> creditCardStatements = this.GetCreditCardStatements(elements);

        if (creditCardStatements != null)
        {
            foreach (OfxCreditCardStatement statement in creditCardStatements)
            {
                yield return statement;
            }
        }
    }

    public IEnumerable<OfxBankStatement> GetBankStatements(IEnumerable<IOfxElement> elements)
    {
        ArgumentNullException.ThrowIfNull(elements);

        foreach (IOfxElement element in elements)
        {
            IOfxElement? response = this.GetElement(element, OfxConstants.StatementResponse);
            if (response != null)
            {
                yield return this.GetBankStatement(response);
            }
        }
    }

    public IEnumerable<OfxCreditCardStatement> GetCreditCardStatements(IEnumerable<IOfxElement> elements)
    {
        ArgumentNullException.ThrowIfNull(elements);

        foreach (IOfxElement element in elements)
        {
            IOfxElement? response = this.GetElement(element, OfxConstants.CreditCardStatementResponse);
            if (response != null)
            {
                yield return this.GetCreditCardStatement(response);
            }
        }
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxSignOn? GetSignon(IOfxElement element)
    {
        return (element is null)
            ? null
            : new OfxSignOn
            {
                Status = this.GetStatus(this.GetElement(element, OfxConstants.Status)),
                ServerDate = this.GetAsDateTimeOffset(element, OfxConstants.ServerDate),
                Language = this.GetAsString(element, OfxConstants.Language),
                IntuBid = this.GetAsString(element, OfxConstants.IntuBId),
            };
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxBankStatement? GetBankStatement(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxBankStatement
            {
                DefaultCurrency = this.GetAsString(element, OfxConstants.DefaultCurrency),
                Account = this.GetBankAccount(this.GetElement(element, OfxConstants.BankAccountFrom)),
                TransactionList = this.GetStatementTransactionList(this.GetElement(element, OfxConstants.BankTransactionList)),
                LedgerBalance = this.GetAccountBalance(this.GetElement(element, OfxConstants.LedgerBalance)),
                AvailableBalance = this.GetAccountBalance(this.GetElement(element, OfxConstants.AvailableBalance)),
            };
    }

    public OfxCreditCardStatement GetCreditCardStatement(IOfxElement element)
    {
        ArgumentNullException.ThrowIfNull(element);

        return new OfxCreditCardStatement
        {
            DefaultCurrency = this.GetAsString(element, OfxConstants.DefaultCurrency),
            Account = this.GetCreditCardAccount(this.GetElement(element, OfxConstants.CreditCardAccountFrom)),
            TransactionList = this.GetStatementTransactionList(this.GetElement(element, OfxConstants.BankTransactionList)),
            LedgerBalance = this.GetAccountBalance(this.GetElement(element, OfxConstants.LedgerBalance)),
            AvailableBalance = this.GetAccountBalance(this.GetElement(element, OfxConstants.AvailableBalance)),
        };
    }

    public OfxTransactionList? GetStatementTransactionList(IOfxElement? element)
    {
        OfxTransactionList? result = null;

        if (element != null)
        {
            IEnumerable<OfxStatementTransaction> query = from t in this.GetElements(element, OfxConstants.StatementTransaction)
                        select this.GetStatementTransaction(t);

            result = new OfxTransactionList
            {
                StartDate = this.GetAsDateTimeOffset(element, OfxConstants.StartDate),
                EndDate = this.GetAsDateTimeOffset(element, OfxConstants.EndDate),
                Transactions = query.ToList(),
            };
        }

        return result;
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxStatementTransaction? GetStatementTransaction(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxStatementTransaction
            {
                TxType = this.GetTransactionType(element),
                DatePosted = this.GetAsDateTimeOffset(element, OfxConstants.DatePosted),
                DateUser = this.GetAsNullableDateTimeOffset(element, OfxConstants.UserDate),
                DateAvailable = this.GetAsNullableDateTimeOffset(element, OfxConstants.DateAvailable),
                Amount = this.GetAsRequiredDecimal(element, OfxConstants.TransactionAmount, "Missing or invalid transaction amount from transaction element"),
                FitId = this.GetAsString(element, OfxConstants.FitId),
                Name = this.GetAsString(element, OfxConstants.Name),
                Memo = this.GetAsString(element, OfxConstants.Memo),
                Memo2 = this.GetAsString(element, OfxConstants.Memo2),
                ChequeNumber = this.GetAsString(element, OfxConstants.ChequeNumber),
                ReferenceNumber = this.GetAsString(element, OfxConstants.ReferenceNumber),
                CorrectFitId = this.GetAsString(element, OfxConstants.CorrectFitId),
                CorrectAction = this.GetCorrectiveAction(element),
                ServiceProviderName = this.GetAsString(element, OfxConstants.ServiceProviderName),
                ServerTxId = this.GetAsString(element, OfxConstants.ServerTxId2, OfxConstants.ServerTxId),
                StandardIndustrialCode = this.GetAsNullableInt(element, OfxConstants.StandardIndustrialCode),
                PayeeId = this.GetAsString(element, OfxConstants.PayeeId2, OfxConstants.PayeeId),
                Payee = this.GetPayee(this.GetElement(element, OfxConstants.Payee2, OfxConstants.Payee)),
                Currency = this.GetCurrency(this.GetElement(element, OfxConstants.Currency)),
                OriginalCurrency = this.GetCurrency(this.GetElement(element, OfxConstants.OriginalCurrency)),
                BankAccountTo = this.GetBankAccount(this.GetElement(element, OfxConstants.BankAccountTo)),
                CreditCardAccountTo = this.GetCreditCardAccount(this.GetElement(element, OfxConstants.CreditCardAccountTo)),
            };
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxCurrency? GetCurrency(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxCurrency(
                this.GetAsRequiredDecimal(element, OfxConstants.CurrencyRate, "Missing required currency rate in currency element."),
                this.GetAsRequiredString(element, OfxConstants.CurrencySymbol, "Missing required currency symbol in currency element."));
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxPayee? GetPayee(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxPayee
            {
                Name = this.GetAsString(element, OfxConstants.Name),
                AddressLine1 = this.GetAsString(element, OfxConstants.Address1),
                AddressLine2 = this.GetAsString(element, OfxConstants.Address2),
                AddressLine3 = this.GetAsString(element, OfxConstants.Address3),
                City = this.GetAsString(element, OfxConstants.City),
                State = this.GetAsString(element, OfxConstants.State),
                PostalCode = this.GetAsString(element, OfxConstants.PostalCode),
                Country = this.GetAsString(element, OfxConstants.Country),
                PhoneNumber = this.GetAsString(element, OfxConstants.Phone),
            };
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxAccountBalance? GetAccountBalance(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxAccountBalance
            {
                Balance = this.GetAsRequiredDecimal(element, OfxConstants.BalanceAmount, "Missing or invalid balance from balance element."),
                DateAsOf = this.GetAsDateTimeOffset(element, OfxConstants.DateAsOf),
            };
    }

    public OfxStatus? GetStatus(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxStatus
            {
                Code = this.GetAsRequiredInteger(element, OfxConstants.Code, "Missing required Code from status element."),
                Severity = this.GetSeverity(element),
            };
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxBankAccount? GetBankAccount(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxBankAccount
            {
                BankId = this.GetAsString(element, OfxConstants.BankId),
                BranchId = this.GetAsString(element, OfxConstants.BranchId),
                AccountNumber = this.GetAsString(element, OfxConstants.AccountId),
                AccountType = this.GetAccountType(element),
                Checksum = this.GetAsString(element, OfxConstants.AccountKey),
            };
    }

    [return: NotNullIfNotNull(nameof(element))]
    public OfxCreditCardAccount? GetCreditCardAccount(IOfxElement? element)
    {
        return (element is null)
            ? null
            : new OfxCreditCardAccount
            {
                AccountNumber = this.GetAsString(element, OfxConstants.AccountId),
                Checksum = this.GetAsString(element, OfxConstants.AccountKey),
            };
    }

    public IOfxElement? GetElement(IOfxElement parent, string first, string second)
    {
        ArgumentNullException.ThrowIfNull(parent);

        return this.GetElement(parent, first) ?? this.GetElement(parent, second);
    }

    public string? GetAsString(IOfxElement element, string first, string second)
    {
        var result = this.GetAsString(element, first);
        if (string.IsNullOrWhiteSpace(result))
        {
            result = this.GetAsString(element, second);
        }

        return result;
    }

    private int GetAsRequiredInteger(IOfxElement parent, string name, string errorString)
    {
        string? s = this.GetAsString(parent, name);

        (bool nullOrWhiteSpace, bool notInteger, int value) = OfxParser.ParseInteger(s);
        if (nullOrWhiteSpace || notInteger)
        {
            throw new OfxException(errorString);
        }

        return value;
    }

    private int? GetAsNullableInt(IOfxElement parent, string name)
    {
        string? value = this.GetAsString(parent, name);
        return int.TryParse(value, out var result) ? result : default(int?);
    }

    private decimal GetAsRequiredDecimal(IOfxElement parent, string name, string errorString)
    {
        string? s = this.GetAsString(parent, name);

        (bool nullOrWhiteSpace, bool notDecimal, decimal value) = OfxParser.ParseDecimal(s);
        if (nullOrWhiteSpace || notDecimal)
        {
            throw new OfxException(errorString);
        }

        return value;
    }

    private DateTimeOffset GetAsDateTimeOffset(IOfxElement parent, string name)
    {
        string? value = this.GetAsString(parent, name);
        return OfxParser.ParseDateTime(value);
    }

    private DateTimeOffset? GetAsNullableDateTimeOffset(IOfxElement parent, string name)
    {
        string? value = this.GetAsString(parent, name);
        return OfxParser.ParseNullableDateTime(value);
    }

    private OfxAccountType GetAccountType(IOfxElement parent)
    {
        return OfxParser.ParseAccountType(
            this.GetAsString(parent, OfxConstants.AccountType2, OfxConstants.AccountType));
    }

    private OfxSeverity GetSeverity(IOfxElement parent)
    {
        return OfxParser.ParseSeverity(
            this.GetAsString(parent, OfxConstants.Severity));
    }

    private OfxTransactionType GetTransactionType(IOfxElement parent)
    {
        return OfxParser.ParseTransactionType(
            this.GetAsString(parent, OfxConstants.TransactionType));
    }

    private OfxCorrectiveAction GetCorrectiveAction(IOfxElement parent)
    {
        return OfxParser.ParseCorrectiveAction(
            this.GetAsString(parent, OfxConstants.CorrectAction));
    }

    private string? GetAsString(IOfxElement parent, string name)
    {
        string? result = this.GetElement(parent, name)?.Value;
        if (this.Settings.TrimValues && string.IsNullOrEmpty(result) == false)
        {
            result = result.Trim();
        }

        return result;
    }

    private string GetAsRequiredString(IOfxElement parent, string name, string errorString)
    {
        string? result = this.GetElement(parent, name)?.Value;
        if (string.IsNullOrWhiteSpace(result))
        {
            throw new OfxException(errorString);
        }

        if (this.Settings.TrimValues && string.IsNullOrEmpty(result) == false)
        {
            result = result.Trim();
        }

        return result;
    }

    private IEnumerable<IOfxElement> GetElements(IOfxElement? parent, string name)
    {
        if (parent != null)
        {
            IEnumerable<IOfxElement> items = parent.Elements(name, this.Settings.TagComparer);
            foreach (IOfxElement item in items)
            {
                yield return item;
            }
        }
    }

    private IOfxElement? GetElement(IOfxElement parent, string name)
    {
        return parent.Element(name, this.Settings.TagComparer);
    }
}
