using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System.Net;

namespace DeliveryService.Domain.Entities
{
    public abstract class  Payment : Entity
    {
        protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer,
            CustomerPerson customerPerson, DriverPerson driverPerson, Document document, DeliveryRun deliveryRun)
        {
            Number = number;
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            CustomerPerson = customerPerson;
            DriverPerson = driverPerson;
            Document = document;
            DeliveryRun = deliveryRun;

            AddNotifications(new Contract()
            .Requires()
             .IsFalse(PaidDate.Day > DateTime.Now.Day, "PaidDate", "A data do pagamento deve ser futura")
            .IsNotNull(CustomerPerson, "Payment.CustomerPerson", "Necessario um cliente vinculado ao pagamento")
            .IsNotNull(DriverPerson, "Payment.DriverPerson", "Necessario um motorista vinculado ao pagamento")
            .IsNotNull(Document, "Payment.Document", "Necessario um documentVinculado ao pagamento")
             .IsNotNull(DeliveryRun, "Payment.DeliveryRun", "Necessario uma corrida ao pagamento")
            .IsLowerOrEqualsThan(0, TotalPaid , "TotalPaid", "Valor precisa ser maior que R$ 0")
        );


        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public CustomerPerson CustomerPerson { get; private set; }
        public DriverPerson DriverPerson { get; private set; }
        public Document Document { get; private set; }
        public DeliveryRun DeliveryRun { get; private set; }

    }
}


