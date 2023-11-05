using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeliveryService.Domain.ValueObjects
{
    public class Login : ValueObject
    {
        public Login(string userName, string password, bool active)
        {
            UserName = userName;
            Password = password;
            Active = active;

            AddNotifications(new Contract()
      .Requires()
       .HasMinLen(UserName, 5, "Login.UserName", "UserName deve conter pelo menos 5 caracteres")
       .HasMinLen(Password, 5, "Login.Password", "Senha deve conter pelo menos 5 caracteres")
       .HasMaxLen(UserName, 20, "Login.UserName", "UserName deve conter no maximo 20 caracteres")
       .HasMaxLen(Password, 30, "Login.Password", "Senha deve conter no maximo 30 caracteres")
            );
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }

    }
}
