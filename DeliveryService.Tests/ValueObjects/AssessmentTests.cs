using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class AssessmentTests
    {
        [TestMethod]
        public void avalicao_valido()
        {
            var assessment = new Assessment(EClassification.Good);
            Assert.IsTrue(assessment.Valid);
        }

        [TestMethod]
        public void avalicao_invalido()
        {
            var assessment = new Assessment((EClassification)10); // Um valor não definido em EClassification
            Assert.IsFalse(assessment.Valid);
        }


    }
}
