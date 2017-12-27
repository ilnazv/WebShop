using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class OrderController : BaseController<Order>
    {
        public OrderController()
        {
            this.repository = new OrderRepository(new WebShopContext());
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(long customerId)
        {
            return await ((IOrderRepository)repository).GetByCustomerId(customerId);
        }
    }
}
