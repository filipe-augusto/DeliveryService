using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class MotorcycleVehicle : Vehicle
    {
        public bool IsScooter { get; set; }
        public bool HasTopBox { get; set; }
    }
}
