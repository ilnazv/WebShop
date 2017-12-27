using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class ProductController : BaseController<Product>
    {
        public ProductController()
        {
            this.repository = new ProductRepository(new WebShopContext());
        }

        public async Task<IEnumerable<Product>> GetByOrderId(long orderId)
        {
            return await ((IProductRepository)repository).GetByOrderId(orderId);
        }
    }
}
