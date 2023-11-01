namespace DeliveryService.Domain.Entities
{
    public class CarVehicle : Vehicle
    {
        public int NumberDoors { get; set; }
        public int PassengerCapacity { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasArmored { get; set; }
    }
}
