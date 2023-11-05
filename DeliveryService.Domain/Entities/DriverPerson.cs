using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.Entities
{
    public class DriverPerson : Person
    {


        private IList<Assessment> _assessments;
        public DriverPerson(Vehicle vehicle, string nickName, Name nome, Phone phone, Email email, Document documento, Login login, Address address)
            : base(nome, phone, email, documento, login, address)
        {
            Vehicle = vehicle;
            NickName = nickName;
            _assessments = new List<Assessment>();
        }

        public Vehicle Vehicle { get; private set; }
        public Assessment Assessment { get; private set; }
        public IReadOnlyCollection<Assessment> Assessments { get { return _assessments.ToArray(); } }
        public string? NickName { get; private set; }


        public void ChangeVehicle(Vehicle vehicle) => Vehicle = vehicle;
        
        public void AddAssessment(Assessment assessment) => _assessments.Add(assessment);

        

    }


    }

