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
           .HasMinLen(Number, 8, "Phone.Number", "Número do telefone deve conter pelo menos 8 caracteres!")
           .IsTrue(!Hasletters(Number), "Phone.Number","Telefone invalido!"));
        }

        public string Number { get; private set; }
        static bool Hasletters(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    return true; 
                }
            }
            return false;
        }
    }


}
