using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //FillTables();
        }   
        
        private static async Task FillTables()
        {
            var dbcontext = new WebShopContext();

            var customersRepo = new BaseRepository<Customer>(dbcontext);
            var ordersRepo = new BaseRepository<Order>(dbcontext);
            var productsRepo = new BaseRepository<Product>(dbcontext);

            var names = new string []{ "John Doe", "Josh Brown", "Ethan Smith", "Michael Johnson", "John Davis", "Jacob Miller", "Tyler Jackson", "Ryan White", "David Harris", "Daniel Anderson" };

            for (int i = 1; i <= 10; i++)
            {
                var newCustomer = new Customer { Id = i, Name = names[i - 1] };
                await customersRepo.Add(newCustomer);

                for (int j = 1; j <= 10; j++)
                {
                    var newOrder = new Order { Id = j, Date = DateTime.Now, Customer = newCustomer };
                    await ordersRepo.Add(newOrder);

                    for (int k = 1; k <= 10; k++)
                    {
                        var newProduct = new Product { Id = k, Name = $"Product #{k}", Price = k, Order = newOrder };
                        await productsRepo.Add(newProduct);
                    }
                }
            }
        }
    }
}
