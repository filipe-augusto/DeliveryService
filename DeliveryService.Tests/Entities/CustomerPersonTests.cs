using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using System.Net;
using System.Numerics;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class CustomerPersonTests
    {

        private readonly Name _name;
        private readonly Phone _phone;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Login _login;
        private readonly Address _address;


        public CustomerPersonTests()
        {

            _name = new Name("filipe", "augusto");
            _phone = new Phone("119807550055");
            _email = new Email("filipe@gmail.com");
            _document = new Document("41300055588", EDocumentType.CPF);
            _login = new Login("filipe_augusto", "senha123", true);
            _address = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");

        }


        [TestMethod]
        public void adicionar_person_invalido()
        {
            var person = new CustomerPerson(false, null, _phone, _email, _document, _login, null);

            Assert.IsTrue(person.Invalid);
        }

        [TestMethod]
        public void adicionar_cliente_valido()
        {
            var person = new CustomerPerson(false, _name, _phone, _email, _document, _login, _address);

            Assert.IsTrue(person.Valid);
        }

        //[TestMethod]
        //public void adicionar_corrida_valido()
        //{
        //    var nome = new Name("filipe", "augusto");
        //    var phone = new Phone("119807550055");
        //    var email = new Email("filipe@gmail.com");
        //    var doc = new Document("41300055588", EDocumentType.CPF);
        //    var login = new Login("filipe_augusto", "senha123", true);
        //    var address = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");
        //    var person = new CustomerPerson(false, null, phone, email, doc, login, null);


        //    //var corrida = new CustomerPerson()

        //   // Assert.IsTrue(person.Invalid);
        //}


    }
}
