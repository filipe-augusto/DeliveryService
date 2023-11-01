using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public abstract class  Payment : Entity
    {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public CustomerPerson CustomerPerson { get; set; }
    }
}


