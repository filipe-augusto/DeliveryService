using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class DriverPerson : Person
    {
        public Vehicle Vehicle { get; set; }
        public int Assessment { get; set; }
        public int NickName { get; set; }
        public int Races { get; set; }
        public IReadOnlyCollection<DeliveryRunRoute> DeliveryRunRoutes { get; set; }
    }
}
