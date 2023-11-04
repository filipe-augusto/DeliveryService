using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class VehicleIdentification : ValueObject

    {
        public VehicleIdentification(string vehicleIdentificationNumber, string vehicleMake, string vehicleModel, int yearNumber)
        {
            VehicleIdentificationNumber = vehicleIdentificationNumber;
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            YearNumber = yearNumber;
        }

        public string VehicleIdentificationNumber { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int YearNumber { get; set; }


    }
}
