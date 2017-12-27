using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Interfaces
{
    interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByOrderId(long orderId);
    }
}
