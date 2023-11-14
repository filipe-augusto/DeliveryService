using DeliveryService.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeliveryService.Domain.Commands
{
    internal class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success, string message) {
            Success = success;
            Message = message;
        }


        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
