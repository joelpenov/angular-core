using ArtGalleryShop.ArtGalleryContext;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtGalleryContext _galleryContext;

        public HomeController(IArtGalleryContext galleryContext)
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
            return View(_galleryContext.GetProducts());
        }
    }
}