using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class DeliveryRun : Entity
    {
        private IList<DeliveryRunRoute> _routes;
        public DeliveryRun(CustomerPerson customer, string? observation)
        {
            Customer = customer;
            Observation = observation;
            _routes = new List<DeliveryRunRoute>();
            RaceStatus = ERaceStatus.Creating;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(Customer, "DeliveryRun.Customer", "Nome necessario")
               .IsNotNull(Observation, "DeliveryRun.Observation", "Obeservação necessaria"));
        }
        public DateTime DataCreate { get; private set; }
        public CustomerPerson Customer { get; private set; }
        public Assessment Assessment { get; private set; }
        public string? Observation { get; private set; }
        public Payment Payment { get; private set; }
        public ERaceStatus RaceStatus { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public decimal TotalDistance { get; private set; }


        public IReadOnlyCollection<DeliveryRunRoute> DeliveryRunRoutes { get { return _routes.ToArray(); } }

        public void AddRoute(DeliveryRunRoute route)
        {
            AddNotifications(new Contract().Requires()
                .AreNotEquals(0, route.TotalDistance, "DeliveryRunRoute.TotalDistance", "Não ha distancia entre os dois pontos"));
            if (Valid)
            {
                _routes.Add(route);
                TotalDistance += route.TotalDistance;
                TotalTime += route.TotalTime;
            }

        }
        public void SetCustomer(CustomerPerson customerPerson)
        {
            AddNotifications(new Contract().Requires()
                .IsFalse(customerPerson.Valid, "DeliveryRunRoute.CustomerPerson", "Cliente invalido"));
            if (customerPerson.Valid) Customer = customerPerson;
        }

        public void SetAssessment(Assessment assessment) { if (assessment.Valid) Assessment = assessment; }

        public void SetPayment(Payment payment)
        {
            AddNotifications(new Contract()
          .Requires()
          .IsLowerOrEqualsThan(0, DeliveryRunRoutes.Sum(x => x.TotalDistance), "DeliveryRun.DeliveryRunRoutes", "Distancia precisa ser maior que 0")
          .IsLowerOrEqualsThan(0, DeliveryRunRoutes.Count, "Person.DeliveryRunRoutes", "Corrida não tem roteiros")
          //.IsFalse(payment.Valid, "DeliveryRunRoute.CustomerPerson", "Cliente invalido")
          );
            if (DeliveryRunRoutes.Count > 0)
            {
                if (payment.Valid)
                {

                    Payment = payment;
                };
            }
        }

        public void StartRun(Payment payment, CustomerPerson customer, DeliveryRunRoute deliveryRunRoute    )
        {

            AddNotifications(new Contract()
           .Requires()
           .IsNotNull(Customer, "DeliveryRun.Customer", "Cliente necessario")
          // .IsNotNull(Payment, "DeliveryRun.Payment", "pagamento necessario")
            .IsTrue(DeliveryRunRoutes.Count > 0, "DeliveryRun.Payment", "Necessario uma rota.")
           );

            if (deliveryRunRoute.Valid && payment.Valid && customer.Valid)
            {
                RaceStatus = ERaceStatus.Starting;
            }
        }





    }
}


