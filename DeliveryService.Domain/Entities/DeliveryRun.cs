using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRun : Entity
    {
        public DeliveryRun(CustomerPerson customer, Payment payment, ERaceStatus raceStatus, Assessment assessment, string? observation, TimeSpan totalTime, decimal totalDistance)
        {
            Customer = customer;
            Payment = payment;
            RaceStatus = raceStatus;
            Assessment = assessment;
            Observation = observation;
            TotalTime = totalTime;
            TotalDistance = totalDistance;
        }

        public CustomerPerson Customer { get; set; }
        public Payment Payment { get; set; }
        public ERaceStatus RaceStatus { get; set; }
        public Assessment Assessment { get; set; }
        public string? Observation { get; set; }

        public TimeSpan TotalTime { get; set; }
        public decimal TotalDistance { get; set; }
      
        public IReadOnlyCollection<DeliveryRunRoute> DeliveryRunRoutes { get; private set; }



    }
}


