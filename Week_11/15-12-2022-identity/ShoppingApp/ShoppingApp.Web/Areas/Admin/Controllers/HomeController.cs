using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]//bu sayfaya girebilmek için login olman lazım yani admin panele tıklayınca giriş yap sayfası açılıyor buraya gelceğini nasıl anladı program cs deki  cookideki ilk satır 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
