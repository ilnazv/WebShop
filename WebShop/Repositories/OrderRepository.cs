using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(WebShopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(long customerId)
        {
            return await context.Set<Order>().Where(x => x.Customer.Id == customerId).ToListAsync();
        }
    }
}