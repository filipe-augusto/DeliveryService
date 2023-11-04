using DeliveryService.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class VanVehicle : Vehicle
    {
        public VanVehicle(int passengerCapacity,bool hasAirConditioning, bool hasArmored,
            VehicleIdentification vehicleIdentification, decimal fuelcapacity, bool hasInsurance, decimal cargoVolume, DriverPerson driverPerson)
            : base(vehicleIdentification, fuelcapacity, hasInsurance, cargoVolume, driverPerson)
        {
            PassengerCapacity = passengerCapacity;
            HasAirConditioning = hasAirConditioning;
            HasArmored = hasArmored;
        }

        public int PassengerCapacity { get; private set; }
        public bool HasAirConditioning { get; private set; }
        public bool HasArmored { get; private set; }

    }
}
