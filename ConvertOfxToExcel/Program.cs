using System;
using System.Text;
using Microsoft.Extensions.FileSystemGlobbing;
using OfxNet;

namespace ConvertOfxToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Matcher matcher = new Matcher();
            matcher.AddInclude("**/*.ofx");

            var items = matcher.GetResultsInFullPath(Environment.ExpandEnvironmentVariables("%SCANDOCS%"));

            long fileCount = 0;
            long statementCount = 0;
            long transactionCount = 0;

            foreach (var item in items)
            {
                ++fileCount;
                Console.WriteLine($"{fileCount}\t\"{item}\"");

                var doc = OfxDocument.Load(item);

                foreach (var statement in doc.GetStatements())
                {
                    ++statementCount;
                    Console.WriteLine($"{statementCount}\t{statement.GetType().Name}");
                    foreach (var tx in statement.TransactionList.Transactions)
                    {
                        ++transactionCount;
                        Console.WriteLine($"\t{transactionCount}\t\"{tx.Name}\",{tx.Amount}");
                    }
                }
            }

            Console.WriteLine($"Files={fileCount},Statements={statementCount},Transactions={transactionCount}");
        }
    }
}
