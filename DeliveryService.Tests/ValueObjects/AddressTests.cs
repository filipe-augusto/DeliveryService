

using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void address_valido()
        {

            var address = new Address("Rua Exemplo", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");
            bool isValid = address.Valid;
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void address_com_rua_invalida()
        {
            var address = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void address_com_cep_invalido()
        {
            var address = new Address("Rua Exemplo", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "1234");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void address_com_bairro_invalido()
        {
            var address = new Address("Rua Exemplo", "123", "B", "Cidade Exemplo", "Estado", "País", "1234");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void address_com_cidade_invalido()
        {
            var address = new Address("Rua Exemplo", "123", "Bairro Exemplo", "Ci", "Estado", "País", "1234");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void address_com_estado_invalido()
        {
            var address = new Address("Rua Exemplo", "123", "Bairro Exemplo", "são paulo", "ii", "País", "1234");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void address_com_pais_invalido()
        {
            var address = new Address("Rua Exemplo", "123", "Bairro Exemplo", "são paulo", "minas gerais", "ll", "1234");
            bool isValid = address.Valid;
            Assert.IsFalse(isValid);
        }

    }
}
