namespace DeliveryService.Domain.Entities;

    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; private set; }
    }
