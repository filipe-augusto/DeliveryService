using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Services
{
    public interface IEmailService
    {

        void seendEmail(string to, string email, string subject, string body);
    }
}
