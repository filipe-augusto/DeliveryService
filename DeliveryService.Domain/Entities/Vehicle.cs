using DeliveryService.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public abstract class Vehicle : Entity
    {
        protected Vehicle(VehicleIdentification vehicleIdentification, decimal fuelcapacity, bool hasInsurance, decimal cargoVolume, DriverPerson driverPerson)
        {
            VehicleIdentification = vehicleIdentification;
            Fuelcapacity = fuelcapacity;
            HasInsurance = hasInsurance;
            CargoVolume = cargoVolume;
            DriverPerson = driverPerson;
        }

        public VehicleIdentification VehicleIdentification { get; set; }
        public decimal Fuelcapacity { get; set; }
        public bool HasInsurance { get; set; }
        public decimal CargoVolume { get; set; }

        public DriverPerson DriverPerson { get; set; }

    }
}
