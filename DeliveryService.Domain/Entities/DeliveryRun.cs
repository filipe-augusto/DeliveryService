using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public class DeliveryRun : Entity
    {
        private IList<DeliveryRunRoute> _routes;
        public DeliveryRun(CustomerPerson customer, Payment payment, ERaceStatus raceStatus, string? observation, TimeSpan totalTime, decimal totalDistance)
        {
            Customer = customer;
            Payment = payment;
            RaceStatus = raceStatus;
            Observation = observation;
            TotalTime = totalTime;
            TotalDistance = totalDistance;
            _routes = new List<DeliveryRunRoute>();


            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(Customer, "DeliveryRun.Customer", "Nome necessario")
               .IsNotNull(Payment, "DeliveryRun.Payment", "Telefone necessario")
               .IsNotNull(RaceStatus, "DeliveryRun.RaceStatus", "Email necessario")
               .IsNotNull(Observation, "DeliveryRun.Observation", "Documento necessario")
               .IsLowerOrEqualsThan(0, DeliveryRunRoutes.Sum(x => x.TotalDistance), "DeliveryRun.DeliveryRunRoutes", "Distancia precisa ser maior que 0")
               .IsLowerOrEqualsThan(0, DeliveryRunRoutes.Count, "Person.DeliveryRunRoutes", "Corrida não tem roteiros"));

        }
        public DateTime DataCreate { get; private set; }
        public CustomerPerson Customer { get; private set; }
        public Payment Payment { get; private set; }
        public ERaceStatus RaceStatus { get; private set; }
        public Assessment Assessment { get; private set; }
        public string? Observation { get; private set; }

        public TimeSpan TotalTime { get; private set; }
        public decimal TotalDistance { get; private set; }

        public IReadOnlyCollection<DeliveryRunRoute> DeliveryRunRoutes { get { return _routes.ToArray(); } }

        public void AddRoute(DeliveryRunRoute route)
        {
            AddNotifications(new Contract().Requires()
                .AreNotEquals(0, route.TotalDistance, "DeliveryRunRoute.TotalDistance", "Não ha distancia entre os dois pontos"));
            if (Valid)
                _routes.Add(route);

        }
        public void SetCustomer(CustomerPerson customerPerson) {
            if (customerPerson.Valid) Customer = customerPerson;
        }

        public void SetPayment(Payment payment)
        {
            if (payment.Valid) Payment = payment;
        }

        public void SetAssessment(Assessment assessment)
        {
            if (assessment.Valid) Assessment = assessment;
        }



    }
}


