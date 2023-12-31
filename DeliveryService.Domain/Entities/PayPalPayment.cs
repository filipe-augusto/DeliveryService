using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Domain.Entities;

    public class PayPalPayment : Payment
    {
    public PayPalPayment(string transactionCode,
        string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
        string payer, CustomerPerson customerPerson, DriverPerson driverPerson, Document document, DeliveryRun deliveryRun)
        : base(number, paidDate, expireDate, total, totalPaid, payer, customerPerson, driverPerson, document , deliveryRun)
    {
        TransactionCode = transactionCode;
    }

    public string? TransactionCode { get; private set; }
    }
