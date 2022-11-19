using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Proje04_MVC.Controllers;
public class Product
{
    public int id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
public class Categories
{
    public int id { get; set; }
    public string Name { get; set; }
   
}

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
    public IActionResult About()
    {
        ViewBag.Hata=true;
        ViewData["Not"]=75;

        List<string> adlar=new List<string>(){"Sema","Harun","Sefa","Tuğçe"};
        ViewData["Adlar"]=adlar;

        List<string>bolumler=new List<string>{"insan kaynakları","muhasebe","eğitim","satış"};
        ViewBag.Bolumler=bolumler;
        return View();
    }
    public IActionResult GetProducts()
    {
        List<Product>products=new List<Product>(){
            new Product(){id=1,Name="Iphone13",Price=24000},
            new Product(){id=2,Name="Iphone14",Price=23000},
            new Product(){id=3,Name="Iphone15",Price=25000},
            new Product(){id=4,Name="Iphone16",Price=26000},
            new Product(){id=5,Name="Iphone17",Price=27000},
        };
        // ViewBag.Products=products;


        return View(products);
    }
    public IActionResult GetCategories()
    {
         List<Categories>categories=new List<Categories>(){
            new Categories(){id=1,Name="Bilgisayar"},
            new Categories(){id=2,Name="Telefon"},
            new Categories(){id=3,Name="bEYAZ Eşya"},
            new Categories(){id=4,Name="Televizyon"},
        };
        return View(categories);
    }
   
}
