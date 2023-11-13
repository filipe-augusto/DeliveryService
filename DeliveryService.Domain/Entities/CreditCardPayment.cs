using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities;

public  class CreditCardPayment : Payment
{
    public CreditCardPayment(
        string CardHolderName, 
        string CardNumber, 
        string LastTransactionNumber,
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        CustomerPerson customerPerson,
        DriverPerson driverPerson,
        Document document,
        DeliveryRun deliveryRun
        ) : base(number, paidDate, expireDate, total, totalPaid, payer, customerPerson, driverPerson, document, deliveryRun)
    {
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get;  private set; }
    public string LastTransactionNumber { get; private set; }
}



