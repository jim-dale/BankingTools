using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace OfxNet
{
    public class OfxDocument
    {
        private readonly object _document;

        public OfxDocumentSettings Settings { get; }

        public OfxDocument(object document)
            : this(document, OfxDocumentSettings.Default)
        {
        }

        public OfxDocument(object document, OfxDocumentSettings settings)
        {
            _document = document;
            Settings = settings;
        }

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

        public IOfxElement? GetRoot()
        {
            IOfxElement? result = default;
            if (_document is SgmlDocument sgmlDocument)
            {
                result = sgmlDocument.Root;
            }
            else if (_document is XDocument { Root: not null } xmlDocument)
            {
                result = new XElementAdapter(xmlDocument.Root);
            }

            return result;
        }

        public IEnumerable<OfxStatement> GetStatements()
        {
            var element = GetRoot();

            return GetStatements(element);
        }

        public IEnumerable<OfxStatement> GetStatements(IOfxElement element)
        {
            return GetBankStatements(element).Concat(GetCreditCardStatements(element));
        }

        public IEnumerable<OfxStatement> GetBankStatements(IOfxElement element)
        {
            var set = GetElement(element, OfxConstants.BankMessageSetResponseV1);
            var elements = GetElements(set, OfxConstants.StatementTxResponse);
            var statements = GetBankStatements(elements);

            if (statements != null)
            {
                foreach (var statement in statements)
                {
                    yield return statement;
                }
            }
        }

        public IEnumerable<OfxStatement> GetCreditCardStatements(IOfxElement element)
        {
            var set = GetElement(element, OfxConstants.CreditCardMessageSetResponseV1, OfxConstants.CreditCardMessageSetResponseV2);
            var elements = GetElements(set, OfxConstants.CreditCardStatementTxResponse);
            var creditCardStatements = GetCreditCardStatements(elements);

            if (creditCardStatements != null)
            {
                foreach (var statement in creditCardStatements)
                {
                    yield return statement;
                }
            }
        }

        public IEnumerable<OfxBankStatement> GetBankStatements(IEnumerable<IOfxElement> elements)
        {
            foreach (var element in elements)
            {
                yield return GetBankStatement(GetElement(element, OfxConstants.StatementResponse));
            }
        }

        public IEnumerable<OfxCreditCardStatement> GetCreditCardStatements(IEnumerable<IOfxElement> elements)
        {
            foreach (var element in elements)
            {
                yield return GetCreditCardStatement(GetElement(element, OfxConstants.CreditCardStatementResponse));
            }
        }

        [return: NotNullIfNotNull("element")]
        public OfxSignOn? GetSignon(IOfxElement element)
        {
            return (element is null)
                ? null
                : new OfxSignOn
                {
                    Status = GetStatus(GetElement(element, OfxConstants.Status)),
                    ServerDate = GetAsDateTimeOffset(element, OfxConstants.ServerDate),
                    Language = GetAsString(element, OfxConstants.Language),
                    IntuBid = GetAsString(element, OfxConstants.IntuBId)
                };
        }

        [return: NotNullIfNotNull("element")]
        public OfxBankStatement? GetBankStatement(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxBankStatement
                {
                    DefaultCurrency = GetAsString(element, OfxConstants.DefaultCurrency),
                    Account = GetBankAccount(GetElement(element, OfxConstants.BankAccountFrom)),
                    TransactionList = GetStatementTransactionList(GetElement(element, OfxConstants.BankTransactionList)),
                    LedgerBalance = GetAccountBalance(GetElement(element, OfxConstants.LedgerBalance)),
                    AvailableBalance = GetAccountBalance(GetElement(element, OfxConstants.AvailableBalance))
                };
        }

        public OfxCreditCardStatement GetCreditCardStatement(IOfxElement element)
        {
            return new OfxCreditCardStatement
            {
                DefaultCurrency = GetAsString(element, OfxConstants.DefaultCurrency),
                Account = GetCreditCardAccount(GetElement(element, OfxConstants.CreditCardAccountFrom)),
                TransactionList = GetStatementTransactionList(GetElement(element, OfxConstants.BankTransactionList)),
                LedgerBalance = GetAccountBalance(GetElement(element, OfxConstants.LedgerBalance)),
                AvailableBalance = GetAccountBalance(GetElement(element, OfxConstants.AvailableBalance))
            };
        }

        public OfxTransactionList GetStatementTransactionList(IOfxElement element)
        {
            var query = from t in GetElements(element, OfxConstants.StatementTransaction)
                        select GetStatementTransaction(t);

            return new OfxTransactionList
            {
                StartDate = GetAsDateTimeOffset(element, OfxConstants.StartDate),
                EndDate = GetAsDateTimeOffset(element, OfxConstants.EndDate),
                Transactions = query.ToList()
            };
        }

        [return: NotNullIfNotNull("element")]
        public OfxStatementTransaction? GetStatementTransaction(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxStatementTransaction
                {
                    TxType = GetTransactionType(element),
                    DatePosted = GetAsDateTimeOffset(element, OfxConstants.DatePosted),
                    DateUser = GetAsNullableDateTimeOffset(element, OfxConstants.UserDate),
                    DateAvailable = GetAsNullableDateTimeOffset(element, OfxConstants.DateAvailable),
                    Amount = GetAsDecimal(element, OfxConstants.TransactionAmount),
                    FitId = GetAsString(element, OfxConstants.FitId),
                    Name = GetAsString(element, OfxConstants.Name),
                    Memo = GetAsString(element, OfxConstants.Memo),
                    Memo2 = GetAsString(element, OfxConstants.Memo2),
                    ChequeNumber = GetAsString(element, OfxConstants.ChequeNumber),
                    ReferenceNumber = GetAsString(element, OfxConstants.ReferenceNumber),
                    CorrectFitId = GetAsString(element, OfxConstants.CorrectFitId),
                    CorrectAction = GetCorrectiveAction(element),
                    ServiceProviderName = GetAsString(element, OfxConstants.ServiceProviderName),
                    ServerTxId = GetAsString(element, OfxConstants.ServerTxId2, OfxConstants.ServerTxId),
                    StandardIndustrialCode = GetAsNullableInt(element, OfxConstants.StandardIndustrialCode),
                    PayeeId = GetAsString(element, OfxConstants.PayeeId2, OfxConstants.PayeeId),
                    Payee = GetPayee(GetElement(element, OfxConstants.Payee2, OfxConstants.Payee)),
                    Currency = GetCurrency(GetElement(element, OfxConstants.Currency)),
                    OriginalCurrency = GetCurrency(GetElement(element, OfxConstants.OriginalCurrency)),
                    BankAccountTo = GetBankAccount(GetElement(element, OfxConstants.BankAccountTo)),
                    CreditCardAccountTo = GetCreditCardAccount(GetElement(element, OfxConstants.CreditCardAccountTo))
                };
        }

        [return: NotNullIfNotNull("element")]
        public OfxCurrency? GetCurrency(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxCurrency
                {
                    Rate = GetAsDecimal(element, OfxConstants.CurrencyRate),
                    Symbol = GetAsString(element, OfxConstants.CurrencySymbol)
                };
        }

        [return: NotNullIfNotNull("element")]
        public OfxPayee? GetPayee(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxPayee
                {
                    Name = GetAsString(element, OfxConstants.Name),
                    AddressLine1 = GetAsString(element, OfxConstants.Address1),
                    AddressLine2 = GetAsString(element, OfxConstants.Address2),
                    AddressLine3 = GetAsString(element, OfxConstants.Address3),
                    City = GetAsString(element, OfxConstants.City),
                    State = GetAsString(element, OfxConstants.State),
                    PostalCode = GetAsString(element, OfxConstants.PostalCode),
                    Country = GetAsString(element, OfxConstants.Country),
                    PhoneNumber = GetAsString(element, OfxConstants.Phone),
                };
        }

        [return: NotNullIfNotNull("element")]
        public OfxAccountBalance? GetAccountBalance(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxAccountBalance
                {
                    Balance = GetAsDecimal(element, OfxConstants.BalanceAmount),
                    DateAsOf = GetAsDateTimeOffset(element, OfxConstants.DateAsOf)
                };
        }

        public OfxStatus GetStatus(IOfxElement element)
        {
            return new OfxStatus
            {
                Code = GetAsInt(element, OfxConstants.Code),
                Severity = GetSeverity(element)
            };
        }

        [return: NotNullIfNotNull("element")]
        public OfxBankAccount? GetBankAccount(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxBankAccount
                {
                    BankId = GetAsString(element, OfxConstants.BankId),
                    BranchId = GetAsString(element, OfxConstants.BranchId),
                    AccountNumber = GetAsString(element, OfxConstants.AccountId),
                    AccountType = GetAccountType(element),
                    Checksum = GetAsString(element, OfxConstants.AccountKey)
                };
        }

        [return: NotNullIfNotNull("element")]
        public OfxCreditCardAccount? GetCreditCardAccount(IOfxElement? element)
        {
            return (element is null)
                ? null
                : new OfxCreditCardAccount
                {
                    AccountNumber = GetAsString(element, OfxConstants.AccountId),
                    Checksum = GetAsString(element, OfxConstants.AccountKey)
                };
        }

        private int GetAsInt(IOfxElement parent, string name)
        {
            string? value = GetAsString(parent, name);
            return int.Parse(value);
        }

        private int? GetAsNullableInt(IOfxElement parent, string name)
        {
            string? value = GetAsString(parent, name);
            return int.TryParse(value, out var result) ? result : default(int?);
        }

        private decimal GetAsDecimal(IOfxElement parent, string name)
        {
            string? value = GetAsString(parent, name);
            return decimal.Parse(value);
        }

        private DateTimeOffset GetAsDateTimeOffset(IOfxElement parent, string name)
        {
            string? value = GetAsString(parent, name);
            return OfxParser.ParseDateTime(value);
        }

        private DateTimeOffset? GetAsNullableDateTimeOffset(IOfxElement parent, string name)
        {
            string? value = GetAsString(parent, name);
            return OfxParser.ParseNullableDateTime(value);
        }

        private OfxAccountType GetAccountType(IOfxElement parent)
        {
            return OfxParser.ParseAccountType(
                GetAsString(parent, OfxConstants.AccountType2, OfxConstants.AccountType));
        }

        private OfxSeverity GetSeverity(IOfxElement parent)
        {
            return OfxParser.ParseSeverity(
                GetAsString(parent, OfxConstants.Severity));
        }

        private OfxTransactionType GetTransactionType(IOfxElement parent)
        {
            return OfxParser.ParseTransactionType(
                GetAsString(parent, OfxConstants.TransactionType));
        }

        private OfxCorrectiveAction GetCorrectiveAction(IOfxElement parent)
        {
            return OfxParser.ParseCorrectiveAction(
                GetAsString(parent, OfxConstants.CorrectAction));
        }

        public string? GetAsString(IOfxElement element, string first, string second)
        {
            var result = GetAsString(element, first);
            if (string.IsNullOrWhiteSpace(result))
            {
                result = GetAsString(element, second);
            }

            return result;
        }

        private string? GetAsString(IOfxElement parent, string name)
        {
            var result = GetElement(parent, name)?.Value;
            if (Settings.TrimValues && string.IsNullOrEmpty(result) == false)
            {
                result = result.Trim();
            }
            return result;
        }

        private IEnumerable<IOfxElement> GetElements(IOfxElement? parent, string name)
        {
            if (parent != null)
            {
                var items = parent.Elements(name, Settings.TagComparer);
                foreach (var item in items)
                {
                    yield return item;
                }
            }
        }

        private IOfxElement? GetElement(IOfxElement parent, string name)
        {
            return parent.Element(name, Settings.TagComparer);
        }

        public IOfxElement? GetElement(IOfxElement parent, string first, string second)
        {
            return GetElement(parent, first) ?? GetElement(parent, second);
        }
    }
}
