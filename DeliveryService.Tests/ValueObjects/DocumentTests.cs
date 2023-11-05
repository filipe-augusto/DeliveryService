

using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void cpnj_invalido() {

            var doc = new Document("123", EDocumentType.CNPJ);

        Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void cpnj_valido()
        {
            var doc = new Document("67418282000112", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void cpf_invalido()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("86948429041")]
        [DataRow("75279895059")]
        [DataRow("29468753000")]
        [DataRow("98690893059")]
        public void cpf_valido(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
