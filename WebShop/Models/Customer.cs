using System.Collections.Generic;
using WebShop.Interfaces;

namespace WebShop.Models
{
    public class Customer : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
