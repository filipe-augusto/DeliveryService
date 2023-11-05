using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class VehicleIdentificationTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("VIN1234567890", "Toyota", "Corolla", 2019)]
        [DataRow("VIN9876543210", "Honda", "Civic", 2022)]
        [DataRow("VIN1112233445", "Ford", "Mustang", 2021)]
        [DataRow("VIN5555666677", "Chevrolet", "Malibu", 2020)]
        public void identification_valido(string indentificacao, string marca, string modelo, int ano)
        {
            var vehicleIdentification = new VehicleIdentification(indentificacao, marca, modelo, ano);
            Assert.IsTrue(vehicleIdentification.Valid);
        }

        [TestMethod]
        public void identification_com_ano_futuro_invalido()
        {
            var vehicleIdentification = new VehicleIdentification("VIN1234567890", "Marca", "Modelo", DateTime.Now.Year + 1);
            Assert.IsFalse(vehicleIdentification.Valid);
        }
        [TestMethod]
        public void identification_com_marca_invalido()
        {
            var vehicleIdentification = 
                new VehicleIdentification("VIN1234567890", "MarcaMarcaMarcaMarcaMarcaMarcaMarcaMarcaMarcaMarcaMarca", "Modelo", 1800);

            Assert.IsFalse(vehicleIdentification.Valid);
        }

        [TestMethod]
        public void identification_com_ano_menor_que_1900()
        {
            var vehicleIdentification = new VehicleIdentification("VIN1234567890", "Marca", "Modelo", 1800);
            Assert.IsFalse(vehicleIdentification.Valid);
        }


    }
}
