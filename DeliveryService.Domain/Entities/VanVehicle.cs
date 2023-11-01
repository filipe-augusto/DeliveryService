using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class VanVehicle : Vehicle
    {
        public int PassengerCapacity { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasArmored { get; set; }

    }
}
