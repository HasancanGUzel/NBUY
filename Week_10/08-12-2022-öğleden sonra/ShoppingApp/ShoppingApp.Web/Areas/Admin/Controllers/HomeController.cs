using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]//area admin olduğunu belirtiyoruz
        public IActionResult Index()
        {
            return View();
        }
    }
}
