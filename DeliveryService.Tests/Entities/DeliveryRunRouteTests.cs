using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class DeliveryRunRouteTests
    {


        private readonly Payment _payment;

        private readonly CustomerPerson _customerPerson;
        private readonly DriverPerson _driverPerson;
        private readonly MotorcycleVehicle _vehicleMoto;
        private readonly VehicleIdentification _vehicleIdentification_moto;
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


        private readonly Address _startingAddress;
        private readonly Address _destinationAddress;
        private readonly DeliveryRun _deliveryRun;
        private readonly TimeSpan _totalTime;
        private readonly TimeSpan _estimatedTime;



        public DeliveryRunRouteTests()
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

            _payment = new PixPayment("filipe@email.com", "email", "123456789", DateTime.Now, DateTime.Now.AddDays(7), 100.5m, 80.0m,
            _nameCustomer.FirstName, _customerPerson, _driverPerson, _documentCustomer, null);
            _deliveryRun = new DeliveryRun(_customerPerson, "Teste 11/11/2023");

            _startingAddress = new Address("Rua Exemplo", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "Brasil", "04257000");
            _destinationAddress = new Address("Rua jornada infinita", "25", "Bairro Eldorado", "São paulo", "Paulo", "Brasil", "04476000");

            _totalTime = new TimeSpan(1, 0, 0);
            _estimatedTime = new TimeSpan(1, 0, 0);
     

        }


        [TestMethod]
        public void criar_rota_valida()
        {
            var rota = new DeliveryRunRoute(_driverPerson, _deliveryRun, 10m, _totalTime, _estimatedTime
                 , _startingAddress, _destinationAddress);

            Assert.IsTrue(rota.Valid);
        }

        [TestMethod]
        public void criar_rota_invalida()
        {
            var rota = new DeliveryRunRoute(_driverPerson, _deliveryRun, 10m, _totalTime, _estimatedTime
                 , _startingAddress, null);

            Assert.IsTrue(rota.Invalid);
        }

    }
}
