namespace DeliveryService.Domain.Entities;

public abstract class CreditCardPayment : Payment
{
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }



