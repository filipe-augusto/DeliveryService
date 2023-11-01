using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public abstract class Vehicle : Entity
    {
        public string VehicleIdentificationNumber { get; set; }
        public decimal Fuelcapacity { get; set; }
        public string VehicleMake { get; set; }
        public int YearNumber { get; set; }
        public bool HasInsurance { get; set; }
        public decimal CargoVolume { get; set; }

    }
}
