using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValueObjects
{

    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("1111111111111")]
        public void ShouldReturnErrorWhenCnpjIsInvalid(string cnpjInvalid)
        {
            var documentInvalid = new Document(cnpjInvalid, DocumentType.CNPJ);

            Assert.IsTrue(documentInvalid.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("93.214.118/0001-01")]
        [DataRow("85075246000185")]
        public void ShouldReturnSuccessWhenCnpjIsValid(string cnpjValid)
        {
            var documentValid = new Document(cnpjValid, DocumentType.CNPJ);
            Assert.IsTrue(documentValid.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("11111111111")]
        [DataRow("00000000000")]
        [DataRow("")]
        public void ShouldReturnErrorWhenCpfIsInvalid(string cpfInvalid)
        {
            var documentValid = new Document(cpfInvalid, DocumentType.CPF);

            Assert.IsTrue(documentValid.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("099.632.240-08")]
        [DataRow("24866611073")]
        public void ShouldReturnSuccessWhenCpfIsValid(string cpfValid)
        {
            var documentValid = new Document(cpfValid, DocumentType.CPF);

            Assert.IsTrue(documentValid.Valid);
        }
    }
}