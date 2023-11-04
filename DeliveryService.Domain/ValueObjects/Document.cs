using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class Document : ValueObject

    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            TypeDocument = type;
        }

        public string Number { get; private set; }

        public EDocumentType TypeDocument { get; private set; }
    }
}
