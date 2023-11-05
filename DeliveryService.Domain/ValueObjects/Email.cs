using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;
namespace DeliveryService.Domain.ValueObjects
{
    public class Email : ValueObject

    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract()
              .Requires()
              .IsEmail(Address, "Email.Address", "E-mail inválido")
               .HasMinLen(Address, 5, "Email.Address", "E-mail deve conter pelo menos 5 caracteres")
          );
        }

        public string Address { get; private set; }
    }
}
