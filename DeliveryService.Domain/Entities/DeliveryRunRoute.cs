using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRunRoute : Entity
    {
        public DriverPerson Driver { get; set; }
        public DeliveryRun DeliveryRun { get; set; }
        public byte Status { get; set; }//trocar
        public decimal Distance { get; set; }//trocar
        public TimeSpan Time { get; set; }

        public string StartingAddress { get; set; }
        public string DestinationAddress { get; set; }

    }
}


