using WebShop.Interfaces;

namespace WebShop.Models
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
