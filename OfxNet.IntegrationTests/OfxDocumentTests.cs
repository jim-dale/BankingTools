using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OfxNet.IntegrationTests
{
    [TestClass]
    public class OfxDocumentTests
    {
        [TestInitialize]
        public void Setup()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [DataTestMethod]
        [DataRow("SampleBankStatement-1.ofx")]
        [DataRow("SampleBankStatement-2.ofx")]
        [DataRow("SampleCreditCardStatement.ofx")]
        [DataRow("SampleSignOnResponse.ofx")]
        public void OfxDocumentLoad_Succeeds(string path)
        {
            _ = OfxDocument.Load(path);
        }
    }
}
