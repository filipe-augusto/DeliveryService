using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities
{
    public class CustomerPerson : Person
    {
        public CustomerPerson(bool Banned, Name nome, Phone phone, Email email, Document documento, Login login, Address address) : base(nome, phone, email, documento, login, address)
        {
            this.Banned = Banned;
        }
              

        public bool Banned { get; set; }
        public IReadOnlyCollection<DeliveryRun> DeliveryRuns { get; set; }
        public IReadOnlyCollection<Payment> Payments { get; set; }

    }
}
