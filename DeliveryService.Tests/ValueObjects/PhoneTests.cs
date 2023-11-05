using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("115550")]
        [DataRow("15656bbbb77")]

        public void telefone_invalido(string numero)
        {

            var tel = new Phone(numero);
            Assert.IsFalse(tel.Valid);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("55920201010")]
        [DataRow("11980805555")]
        public void telefone_valido(string numero)
        {
            var tel = new Phone(numero);
            Assert.IsTrue(tel.Valid);
        }


    }
}
