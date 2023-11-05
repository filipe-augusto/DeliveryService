using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;
namespace DeliveryService.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 5, "Name.FirstName", "Nome deve conter pelo menos 5 caracteres")
                .HasMinLen(LastName, 5, "Name.LastName", "Sobrenome deve conter pelo menos 5 caracteres")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "Nome deve conter até 40 caracteres")
                .HasMaxLen(LastName, 50, "Name.LastName", "Nome deve conter até 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
