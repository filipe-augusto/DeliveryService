﻿using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using System.Net;
using System.Xml.Linq;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class PaymentTests
    {

        private readonly CustomerPerson _customerPerson;
        private readonly DriverPerson _driverPerson;
        private readonly MotorcycleVehicle _vehicleMoto;
        private readonly VehicleIdentification _vehicleIdentification_moto;
        private readonly Document _document;
        private readonly DeliveryRun _deliveryRun;
        private readonly Name _nameCustomer;
        private readonly Phone _phoneCustomer;
        private readonly Email _emailCustomer;
        private readonly Document _documentCustomer;
        private readonly Login _loginCustomer;
        private readonly Address _addressCustomer;
        private readonly Name _nameDriver;
        private readonly Phone _phoneDriver;
        private readonly Email _emailDriver;
        private readonly Document _documentDriver;
        private readonly Login _loginDriver;
        private readonly Address _addressDriver;
       



        public PaymentTests()
        {
            _nameCustomer = new Name("filipe", "augusto");
            _phoneCustomer = new Phone("119807550055");
            _emailCustomer = new Email("filipe@gmail.com");
            _documentCustomer = new Document("41300055588", EDocumentType.CPF);
            _loginCustomer = new Login("filipe_augusto", "senha123", true);
            _addressCustomer = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");
            _customerPerson = new CustomerPerson(false, _nameCustomer, _phoneCustomer, _emailCustomer, _documentCustomer, _loginCustomer, _addressCustomer);

            _nameDriver = new Name("João", "Silva");
            _phoneDriver = new Phone("987654321");
            _emailDriver = new Email("joao@gmail.com");
            _documentDriver = new Document("32165498700", EDocumentType.CPF);
            _loginDriver = new Login("joao_silva", "senha456", true);
            _addressDriver = new Address("S", "456", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "87654321");
            _vehicleIdentification_moto = new VehicleIdentification("BGF557562222", "Honda", "PCX", 2021);
            _vehicleMoto = new MotorcycleVehicle(true, true, _vehicleIdentification_moto, 8, true, 50, null);
            _driverPerson = new DriverPerson(_vehicleMoto, "João Silva", _nameDriver, _phoneDriver, _emailDriver, _documentDriver, _loginDriver, _addressDriver);



            _document =  new Document("01770065016", EDocumentType.CPF);
            _deliveryRun = new DeliveryRun(_customerPerson, "teste teste");

            //primeiro precisa criar o teste da corrida

        }

        [TestMethod]
        public void adicionar_pix_valido()
        {
            var pix = new  PixPayment("filipe@email.com", "email", "123456789", DateTime.Now, DateTime.Now.AddDays(7), 100, 80,
                _nameCustomer.FirstName, _customerPerson, _driverPerson, _documentCustomer, _deliveryRun);

            Assert.IsTrue(pix.Valid);
        }

        [TestMethod]
        public void adicionar_pix_invalido()
        {

            var pix = new PixPayment("filipe@email.com", "email", "123456789", DateTime.Now.AddMonths(1), DateTime.Now.AddDays(7), 10, 10,
          _nameCustomer.FirstName, _customerPerson, _driverPerson, _documentCustomer, _deliveryRun);

            Assert.IsTrue(pix.Invalid);
        }
        [TestMethod]
        public void adicionar_cartaoCredito_valido()
        {
            var cartaoCredito = new CreditCardPayment("filipe a chaves","******2598005","313265465431213185811", "987654321",
                DateTime.Now, DateTime.Now.AddDays(5), 10, 10,"filipe ",
                _customerPerson, _driverPerson, _document, _deliveryRun);

            Assert.IsTrue(cartaoCredito.Invalid);
        }


    }
}
