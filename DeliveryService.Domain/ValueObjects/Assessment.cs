using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class Assessment : ValueObject

    {
        public Assessment(EClassification classification)
        {
            Classification = classification;
        }

        public EClassification Classification { get; private set; }

    }
}
