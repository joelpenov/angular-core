using System.Collections.Generic;
using System.Linq;
using ArtGalleryShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryShop.ArtGalleryContext
{
    public interface IArtGalleryContext
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAllChanges();
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
        void Add(object entity);
    }

    public class ArtGalleryContext : IArtGalleryContext
    {
        private readonly ArtGalleryShopDbContext _artGalleryShopDbContext;

        public ArtGalleryContext(ArtGalleryShopDbContext artGalleryShopDbContext)
        {
            _artGalleryShopDbContext = artGalleryShopDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _artGalleryShopDbContext.Products.OrderBy(x => x.Title).ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _artGalleryShopDbContext.Products
                .Where(x=> x.Category == category)
                .OrderBy(x => x.Title).ToList();
        }

        public bool SaveAllChanges()
        {
            return _artGalleryShopDbContext.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _artGalleryShopDbContext
                .Orders.Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _artGalleryShopDbContext.Orders
                .Include(x=> x.Items)
                .ThenInclude(x=> x.Product)
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void Add(object entity)
        {
            _artGalleryShopDbContext.Add(entity);
        }
    }
}
