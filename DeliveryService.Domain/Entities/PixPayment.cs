namespace DeliveryService.Domain.Entities;

    public abstract class PixPayment : Payment
    {
        public string KeyPIx { get; set; }
        public string PixType { get; set; }
    }



