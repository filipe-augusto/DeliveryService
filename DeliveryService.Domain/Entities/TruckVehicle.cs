using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System.Diagnostics;

namespace DeliveryService.Domain.Entities
{
    public class TruckVehicle : Vehicle
    {
        public TruckVehicle(ETruckBodyType eTruckBodyType, bool dualWheels,
            VehicleIdentification vehicleIdentification, decimal fuelcapacity, bool hasInsurance, decimal cargoVolume, DriverPerson driverPerson) : base(vehicleIdentification, fuelcapacity, hasInsurance, cargoVolume, driverPerson)
        {
            TypeTruckBody = eTruckBodyType;
            DualWheels = dualWheels;


            AddNotifications(new Contract()
  .Requires()
  .IsTrue(TypeTruckBody != ETruckBodyType.None, "TruckVehicle.TypeTruckBody", "é necessario um tipo de caçamba para fazer entregas"));
        }

        public ETruckBodyType TypeTruckBody { get; private set; }
        public bool DualWheels { get; private set; }

    }
}
