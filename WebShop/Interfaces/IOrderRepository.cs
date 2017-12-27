using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Interfaces
{
    interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetByCustomerId(long customerId);
    }
}
