using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
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
        }

        public ETruckBodyType TypeTruckBody { get; private set; }
        public bool DualWheels { get; private set; }

    }
}
