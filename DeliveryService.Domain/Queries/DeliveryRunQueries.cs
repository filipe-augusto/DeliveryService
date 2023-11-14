using DeliveryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Queries
{
    public class DeliveryRunQueries
    {
        public static Expression<Func<DeliveryRun, bool>> GetRun(string number)
        {
            return x => x.Payment.Number == number;
        }
            
    }
}
