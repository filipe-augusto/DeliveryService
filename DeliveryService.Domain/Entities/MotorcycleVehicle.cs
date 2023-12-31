﻿using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class MotorcycleVehicle : Vehicle
    {
        public MotorcycleVehicle(bool isScooter, bool hasTopBox, VehicleIdentification vehicleIdentification,
            decimal fuelcapacity, bool hasInsurance, decimal cargoVolume, DriverPerson driverPerson)
            : base(vehicleIdentification, fuelcapacity, hasInsurance, cargoVolume, driverPerson)
        {
            IsScooter = isScooter;
            HasTopBox = hasTopBox;

          AddNotifications(new Contract()
         .Requires()
         .IsTrue(HasTopBox, "MotorcycleVehicle.HasTopBox", "É necessario ter uma bag para realização de entregas"));
        }

        public bool IsScooter { get; set; }
        public bool HasTopBox { get; set; }
    }
}
