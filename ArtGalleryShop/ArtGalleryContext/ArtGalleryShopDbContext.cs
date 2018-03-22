using ArtGalleryShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryShop.ArtGalleryContext
{
    public class ArtGalleryShopDbContext : DbContext
    {
        public ArtGalleryShopDbContext(DbContextOptions<ArtGalleryShopDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
