using System;
using System.Collections.Generic;
using WebShop.Interfaces;

namespace WebShop.Models
{
    public class Order : IEntity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
