using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities;

public  class PixPayment : Payment
{
    public PixPayment(string keyPix, string pixType,
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
        )
        : base(number, paidDate, expireDate, total, totalPaid, payer, customerPerson, driverPerson, document , deliveryRun)
    {
        KeyPIx = keyPix;
        PixType = pixType;
    }

    public string? KeyPIx { get; private set; }
    public string? PixType { get; private set; }
}



