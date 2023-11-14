using DeliveryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Repositories
{
    public interface IDeliveryRunRepository 
    {
        //apenas a abstração
        bool PaymentExists(string  number);

        void CreateDeliveryRun(DeliveryRun deliveryRun);

    }
}
