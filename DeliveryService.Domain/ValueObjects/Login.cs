using DeliveryService.Shared.ValueObjects;

namespace DeliveryService.Domain.ValueObjects
{
    public class Login  : ValueObject
    {
        public Login(string userName, string password, bool active)
        {
            UserName = userName;
            Password = password;
            Active = active;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }

    }
}
