using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryShop.ArtGalleryContext
{
    public class ArtGalleryShopDbContext : DbContext
    {
        public ArtGalleryShopDbContext(DbContextOptions<ArtGalleryShopDbContext> options) : base(options)
        {

        }

        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}
