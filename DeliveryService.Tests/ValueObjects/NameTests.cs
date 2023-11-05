

using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("filipefilipefilipefilipefilipefilipefilipefilipefilipefilipefilipefilipe", "chaves")]
        [DataRow("fili pefil ipefi", "chaveschaveschaveschaveschaveschaveschaveschaves")]
        [DataRow("aa", "s")]
        [DataRow("aaaaaaa", "s")]
        public void name_invalido(string nome, string sobrenome) {

        var nomecompleto = new Name(nome, sobrenome);

        Assert.IsTrue(nomecompleto.Invalid);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("Filipe", "Chaves")]
        [DataRow("Alice", "Johnson")]
        [DataRow("John", "Doe")]
        [DataRow("Mary", "Smith")]
        [DataRow("Robert", "Brown")]
        public void name_valido(string nome, string sobrenome)
        {
            var nomecompleto = new Name(nome, sobrenome);
            bool isValid = nomecompleto.Valid;
            Assert.IsTrue(isValid);
        }

      
    }
}
