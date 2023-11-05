using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public Phone(string number)
        {
            Number = number;

            AddNotifications(new Contract()
          .Requires()
           .HasMinLen(Number, 11, "Email.Number", "Número do telefone deve conter pelo menos 9 caracteres"));
        }

        public string Number { get; private set; }
    }
}
