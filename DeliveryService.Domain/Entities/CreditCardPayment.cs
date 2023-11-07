using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities;

public abstract class CreditCardPayment : Payment
{
    protected CreditCardPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        CustomerPerson customerPerson,
        DriverPerson driverPerson,
        Document document) : base(number, paidDate, expireDate, total, totalPaid, payer, customerPerson, driverPerson, document)
    {
    }

    public string? CardHolderName { get; private set; }
    public string? CardNumber { get;  private set; }
    public string? LastTransactionNumber { get; private set; }
}



