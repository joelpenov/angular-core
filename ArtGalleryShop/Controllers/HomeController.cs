using ArtGalleryShop.ArtGalleryContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArtGalleryShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArtGalleryShopDbContext _galleryContext;

        public HomeController(ArtGalleryShopDbContext galleryContext)
        {
            _galleryContext = galleryContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Samp()
        {
            return Ok();
        }

        public IActionResult Products()
        {
            var result = _galleryContext.Products.ToList();
            return View(result);
        }
    }
}