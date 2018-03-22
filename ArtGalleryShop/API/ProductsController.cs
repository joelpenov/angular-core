using System.Collections.Generic;
using ArtGalleryShop.ArtGalleryContext;
using ArtGalleryShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryShop.API
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IArtGalleryContext _artGalleryContext;

        public ProductsController(IArtGalleryContext artGalleryContext)
        {
            _artGalleryContext = artGalleryContext;
        }

        public IEnumerable<Product> Get()
        {
            return _artGalleryContext.GetProducts();
        }
    }
}