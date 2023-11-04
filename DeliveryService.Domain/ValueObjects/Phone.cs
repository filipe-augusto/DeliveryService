using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public Phone(string number)
        {
            Number = number;
        }

        public string Number { get;  private set; }
    }
}
