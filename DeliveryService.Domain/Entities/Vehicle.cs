using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
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

            AddNotifications(new Contract().Requires()
         .IsNotNull(VehicleIdentification, "Vehicle.VehicleIdentification", "Identificação necessaria necessario.")
         .IsLowerOrEqualsThan(5, Fuelcapacity, "Vehicle.Fuelcapacity", "Capacidade do tanque precisa ser maior que 5L")
        .IsTrue(HasInsurance, "Vehicle.HasInsurance", "Necessario seguro")
        .IsLowerOrEqualsThan(20, CargoVolume, "Vehicle.CargoVolume", "volume minimo é 20 ")
         );

        }

        public VehicleIdentification VehicleIdentification { get; set; }
        public decimal Fuelcapacity { get; set; }
        public bool HasInsurance { get; set; }
        public decimal CargoVolume { get; set; }

        public DriverPerson DriverPerson { get; set; }


        public void ChangeIdentification(VehicleIdentification vehicleIdentification)
        {
            if (vehicleIdentification.Valid)
            {
                VehicleIdentification = vehicleIdentification;
            }
        }

    }
}
