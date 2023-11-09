using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class DriverPersonTests
    {

        private readonly CarVehicle _vehicleCar;
        private readonly MotorcycleVehicle _vehicleMoto;
        private readonly VehicleIdentification _vehicleIdentification_car;
        private readonly VehicleIdentification _vehicleIdentification_moto;
        private readonly Name _name;
        private readonly Phone _phone;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Login _login;
        private readonly Address _address;



        public DriverPersonTests()
        {
            _vehicleIdentification_car = new VehicleIdentification("VIN5555666677", "Chevrolet", "Malibu", 2020);
            _vehicleCar = new CarVehicle(4, 6, true, false, _vehicleIdentification_car, 30, true, 200, null);

            _vehicleIdentification_moto = new VehicleIdentification("BGF557562222", "Honda", "PCX", 2021);
            _vehicleMoto = new MotorcycleVehicle(true, true, _vehicleIdentification_moto, 8, true, 50, null);

            _name = new Name("filipe", "augusto");
            _phone = new Phone("119807550055");
            _email = new Email("filipe@gmail.com");
            _document = new Document("41300055588", EDocumentType.CPF);
            _login = new Login("filipe_augusto", "senha123", true);
            _address = new Address("R", "123", "Bairro Exemplo", "Cidade Exemplo", "Estado", "País", "12345678");

        }




        [TestMethod]
        public void adicionar_motorista_valido()
        {
            var motorista = new DriverPerson(_vehicleCar, "Filipe Chaves", _name,_phone,_email,_document, _login, _address);
            Assert.IsTrue(motorista.Valid);
        }

        [TestMethod]
        public void adicionar_motorista_invalido()
        {
            var motorista = new DriverPerson(null, "Filipe Chaves", _name, _phone, _email, _document, _login, _address);
            Assert.IsTrue(motorista.Invalid);
        }

        [TestMethod]
        public void trocar_veiculo_motorista_valido()
        {

            var motorista = new DriverPerson(_vehicleCar, "Filipe Chaves", _name, _phone, _email, _document, _login, _address);
            motorista.ChangeVehicle(_vehicleMoto);
            Assert.IsTrue(motorista.Valid);
        }
        [TestMethod]
        public void trocar_veiculo_motorista_invalido()
        {
            var motorista = new DriverPerson(_vehicleCar, "Filipe Chaves", _name, _phone, _email, _document, _login, _address);
            var carro_com_problema = new CarVehicle(0, 6, true, false, null, 30, true, 200, null);
            motorista.ChangeVehicle(carro_com_problema);
            Assert.IsTrue(motorista.Invalid);
        }
        [TestMethod]
        public void adicionar_avaliacao_motorista_valido()
        {

            var motorista = new DriverPerson(_vehicleCar, "Filipe Chaves", _name, _phone, _email, _document, _login, _address);
            motorista.ChangeVehicle(_vehicleMoto);
            var avaliacao = new Assessment(EClassification.Good);
            motorista.AddAssessment(avaliacao);
            Assert.IsTrue(motorista.Valid);
        }



    }
}
