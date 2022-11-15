using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Proje04_MVC.Controllers;

public class HomeController : Controller
{
   
    public IActionResult Index()
    {
        string ad="Hasan";
        ViewBag.KisiAd=ad;
        string dil="tr";
        string selamlama;
        if (dil=="tr")
        {
            selamlama="Hoşgeldin";
        }
        else if(dil=="en")
        {
            selamlama="Welcome";
        }
        else
        {
            selamlama="";
        }
        ViewBag.Selam=selamlama;
        return View();
    }


   
}
