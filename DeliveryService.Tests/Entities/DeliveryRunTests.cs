using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using System.Net;
using System.Xml.Linq;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class DeliveryRunTests
    {

        private readonly DateTime _run;
        private readonly CustomerPerson _person;
        private readonly Payment _payment;
        private readonly ERaceStatus _status;
        private readonly Assessment _assessment;
        private readonly string Observation;
        private readonly TimeSpan TotalTime;
        public decimal TotalDistance { get; private set; }

       
        public DeliveryRunTests()
        {
           var run = DateTime.Now;
           var name = new Name("filipe", "augusto");
           var phone = new Phone("119807550055");
           var email = new Email("filipe@gmail.com");
           var document = new Document("41300055588", EDocumentType.CPF);
           var login = new Login("filipe_augusto", "senha123", true);
           var address = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");
            _person = new CustomerPerson(false, name, phone, email, document, login, address);

           // _payment = new PayPalPayment(Guid.NewGuid().ToString().Substring(0,6),"12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", document, address);
        }




        [TestMethod]
        public void adicionar_pagamento_valido()
        {
           
        }
    }
}
