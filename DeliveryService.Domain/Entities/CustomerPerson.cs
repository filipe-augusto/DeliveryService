using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.Entities
{
    public class CustomerPerson : Person
    {

        private IList<DeliveryRun> _deliveryRuns;

        public CustomerPerson(bool Banned, Name nome, Phone phone, Email email, Document documento, Login login, Address address) : base(nome, phone, email, documento, login, address)
        {
            this.Banned = Banned;
            _deliveryRuns = new List<DeliveryRun>();

        }


        public bool Banned { get; set; }
        public IReadOnlyCollection<DeliveryRun> DeliveryRuns { get { return _deliveryRuns.ToArray(); } }

        public void AddDeliveryRun(DeliveryRun deliveryRun)
        {
            if (Banned != true)
            {
            AddNotifications(new Contract()
               .Requires()
               .IsTrue(deliveryRun.TotalDistance == 0, "DeliveryRun.TotalDistance", "Distancia menor que 0"));

               if(Valid)
                _deliveryRuns.Add(deliveryRun);
            }
        }

    }
}
