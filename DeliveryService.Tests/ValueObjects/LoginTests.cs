using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;

namespace DeliveryService.Tests.ValueObjects
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void login_valido()
        {

            var login = new Login("user123", "password123", true);
            Assert.IsTrue(login.Valid);
        }

        [TestMethod]
        public void login_com_userName_invalido()
        {
            var login = new Login("user", "password123", true);
            Assert.IsFalse(login.Valid);
        }

        [TestMethod]
        public void login_com_password_invalido()
        {
            var login = new Login("user123", "pass", true);
            Assert.IsFalse(login.Valid);
        }
    }
}
