using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.ValueObjects
{
    public class Assessment : ValueObject

    {
        public Assessment(EClassification classification)
        {
            Classification = classification;

            AddNotifications(new Contract()
         .Requires().IsTrue(Validate(), "Assessment.Classification", "Avalição incorreta")
     );
        }

        public EClassification Classification { get; private set; }

        private bool Validate()
        {
            if (Enum.IsDefined(typeof(EClassification), Classification))
                 return true;
            
            return false;
        }
    }



}
