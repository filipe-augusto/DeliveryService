using DeliveryService.Domain.Commands;
using DeliveryService.Domain.Entities;
using DeliveryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Tests.Commands
{
    [TestClass]
    public class ChangeVehicleToCarCommandTests
    {
        [TestMethod]
        public void adicionar_motorista_valido()
        {

            var command = new ChangeVehicleToCarCommand();
            command.FirstName = "filipe";
            command.LastName = "chaves";
            command.Validate();
            Assert.AreEqual(true, command.Valid);
        }
        [TestMethod]
        public void adicionar_motorista_invalido()
        {

            var command = new ChangeVehicleToCarCommand();
            command.FirstName = "1";
            command.LastName = "chaves";
            command.Validate();
            Assert.AreEqual(true, command.Invalid);
        }

    }
}
