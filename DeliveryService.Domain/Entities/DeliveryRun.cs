using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRun : Entity
    {
     
        public CustomerPerson Customer { get; set; }
        public Payment Payment { get; set; }
        public byte Status { get; set; }
        public int Assessment { get; set; }
        public string? Observation { get; set; }

        public TimeSpan TotalTime { get; set; }
        public decimal TotalDistance { get; set; }



    }
}


