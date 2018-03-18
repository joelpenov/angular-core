using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}