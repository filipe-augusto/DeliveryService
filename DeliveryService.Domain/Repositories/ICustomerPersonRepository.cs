using DeliveryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Repositories
{
    public interface ICustomerPersonRepository
    {
        //apenas a abstração
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateCustomer(CustomerPerson customerPerson);

    }
}
