using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities;

public class BoletoPayment : Payment
{
    public BoletoPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        CustomerPerson customerPerson,
        DriverPerson driverPerson,
        Document document
         )
        : base(number, paidDate, expireDate, total, totalPaid, payer, customerPerson, driverPerson, document)
    {
    }

    public string? BarCode { get; private set; }
    public string? BoletoNumber { get; private set; }
}
