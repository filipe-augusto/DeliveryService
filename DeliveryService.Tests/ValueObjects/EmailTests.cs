using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("email@dominio")]
        [DataRow("email@dominio@com")]
        [DataRow("email@dominio..com")]
        [DataRow("email@com")]
        [DataRow("email@.com")]
        [DataRow("email@dominio@com")]
        [DataRow("email@dominio_com")]
        [DataRow("email@dominio.")]
        [DataRow("email@.com")]
        [DataRow("email@dominio,com")]
        [DataRow("email@dominio@com")]
        public void email_invalido(string enderecoEmail)
        {

            var email = new Email(enderecoEmail);
            Assert.IsTrue(email.Invalid);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("email@example.com")]
        [DataRow("usuario.email@dominio.com")]
        [DataRow("nome.sobrenome@provedor.com")]
        [DataRow("email123@dominio.net")]
        [DataRow("email+tag@dominio.org")]
        [DataRow("email123@subdominio.dominio.com")]
        [DataRow("email@dominio.co.uk")]
        [DataRow("email@dominio.info")]
        [DataRow("email@dominio.museum")]
        [DataRow("email@dominio.name")]
        public void email_valido(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);
            bool isValid = email.Valid;
            Assert.IsTrue(isValid);
        }


    }
}
