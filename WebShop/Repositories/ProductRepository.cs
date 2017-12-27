using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetByOrderId(long orderId)
        {
            return await context.Set<Product>().Where(x => x.Order.Id == orderId).ToListAsync();
        }
    }
}