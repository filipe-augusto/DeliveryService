using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.Entities
{
    [TestClass]
    public class VehicleTests
    {

        private readonly VehicleIdentification _vehicleIdentification_car;
        private readonly VehicleIdentification _vehicleIdentification_moto;
        private readonly VehicleIdentification _vehicleIdentification_trunk;
        private readonly VehicleIdentification _vehicleIdentification_van;



        public VehicleTests()
        {
            _vehicleIdentification_car = new VehicleIdentification("VIN5555666677", "Chevrolet", "Malibu", 2020);
            _vehicleIdentification_moto = new VehicleIdentification("BGF557562222", "Honda", "PCX", 2021);
            _vehicleIdentification_trunk = new VehicleIdentification("ZDFSGDFG55111", "Mercedes-Benz", "Scania", 2023);
            _vehicleIdentification_van = new VehicleIdentification("F1895651544", "Ford ", "Transit", 2023);
        }

     

        [TestMethod]
        public void adicionar_carro_valido()
        {
            var carro = new CarVehicle(4, 6, true, false, _vehicleIdentification_car, 30, true, 200, null);
            Assert.IsTrue(carro.Valid);
        }

        [TestMethod]
        public void adicionar_carro_invalido()
        {
            var carro = new CarVehicle(4, 6, true, false, null, 30, true, 200, null);
            Assert.IsTrue(carro.Invalid);
        }

        [TestMethod]
        public void adicionar_moto_valido()
        {
            var moto = new MotorcycleVehicle(true, true, _vehicleIdentification_moto, 8, true, 50, null);
            Assert.IsTrue(moto.Valid); 
        }
        [TestMethod]
        public void adicionar_moto_invalido()
        {
            var moto = new MotorcycleVehicle(true, false, _vehicleIdentification_moto, 8, true, 50, null);
            Assert.IsTrue(moto.Invalid);
        }

        [TestMethod]
        public void adicionar_caminhao_valido()
        {
            var caminhao = new TruckVehicle(ETruckBodyType.OpenDumpTruck,true, _vehicleIdentification_trunk, 80, true, 2000, null);
            Assert.IsTrue(caminhao.Valid);
        }
        [TestMethod]
        public void adicionar_caminhao_invalido()
        {
            var caminhao = new TruckVehicle(ETruckBodyType.None, true, _vehicleIdentification_trunk, 80, true, 2000, null);
            Assert.IsTrue(caminhao.Invalid);
        }

        [TestMethod]
        public void adicionar_van_valido()
        {
            var van = new VanVehicle(2, true, false, _vehicleIdentification_van, 50, true, 500, null);
            Assert.IsTrue(van.Valid);
        }
        [TestMethod]
        public void adicionar_van_invalido()
        {
            var van = new VanVehicle(2, true, false, _vehicleIdentification_van, 50, true, 5, null);
            Assert.IsTrue(van.Invalid);
        }


    }
}
