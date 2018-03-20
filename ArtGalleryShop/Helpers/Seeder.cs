using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArtGalleryShop.ArtGalleryContext;
using ArtGalleryShop.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ArtGalleryShop.Helpers
{
    public class Seeder
    {
        private readonly IHostingEnvironment _environment;
        private readonly ArtGalleryShopDbContext _artGalleryShopDbContext;

        public Seeder(IHostingEnvironment environment, ArtGalleryShopDbContext artGalleryShopDbContext)
        {
            _environment = environment;
            _artGalleryShopDbContext = artGalleryShopDbContext;
        }

        public void Seed()
        {
            _artGalleryShopDbContext.Database.EnsureCreated();
            var jsonFilePath = Path.Combine(_environment.ContentRootPath, "Config/art.json");
            var fileContent = File.ReadAllText(jsonFilePath);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(fileContent).ToList();

            if (_artGalleryShopDbContext.Products.Any()) return;
            
            _artGalleryShopDbContext.Products.AddRange(products);

            var sampleOrder = new Order()
            {
                OrderNumber = 53.ToString(),
                OrderDate = new DateTime(2015,5,3),
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        Product = products.First(),
                        Quantity = 4,
                        UnitPrice = products.First().Price
                    }
                }
            };

            _artGalleryShopDbContext.Orders.Add(sampleOrder);
            _artGalleryShopDbContext.SaveChanges();
        }
    }
}
