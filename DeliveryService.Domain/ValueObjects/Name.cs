using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firtName, string lastName)
        {
            FirtName = firtName;
            LastName = lastName;
        }

        public string FirtName { get; private set; }
        public string LastName { get; private set; }
    }
}
