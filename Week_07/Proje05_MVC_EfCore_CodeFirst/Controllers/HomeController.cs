using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Proje05_MVC_EfCore_CodeFirst.Controllers;

public class HomeController : Controller
{
  

    public IActionResult Index()
    {
        return View();
    }

    

    
}
