using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities
{
    public class CarVehicle : Vehicle
    {
        public CarVehicle(int numberDoors, int passengerCapacity, bool hasAirConditioning, bool hasArmored,
            VehicleIdentification vehicleIdentification, decimal fuelcapacity, bool hasInsurance, decimal cargoVolume, DriverPerson driverPerson)
            : base(vehicleIdentification, fuelcapacity, hasInsurance, cargoVolume, driverPerson)
        {
           NumberDoors = numberDoors;
            PassengerCapacity = passengerCapacity;
            HasAirConditioning = hasAirConditioning;
            HasArmored = hasArmored;
            CargoVolume = cargoVolume;
        }

        public int NumberDoors { get; private set; }
        public int PassengerCapacity { get; private set; }
        public bool HasAirConditioning { get; private set; }
        public bool HasArmored { get; private set; }
    }
}
