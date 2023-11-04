using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities
{
    public class DriverPerson : Person
    {
        public DriverPerson(Vehicle vehicle, Assessment assessment, string nickName, Name nome, Phone phone, Email email, Document documento, Login login, Address address)
            : base(nome, phone, email, documento, login, address)
        {
            Vehicle = vehicle;
            Assessment = assessment;
            NickName = nickName;
        }

        public Vehicle Vehicle { get; private set; }
        public Assessment Assessment { get; private set; }
        public string? NickName { get; private set; }
        public IReadOnlyCollection<DeliveryRunRoute> DeliveryRunRoutes { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get; private set; }
        
    }
}
