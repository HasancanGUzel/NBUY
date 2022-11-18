using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proje06_ModelBinding_Form.Models;

namespace Proje06_ModelBinding_Form.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult VerileriAl(string txtAd, int txtYas)
    {

        return View();
    }

    public IActionResult YasGrubu()// bu yas grubu cs.html yani anasayfadaki butona basıldığı zaman bu sayfaya gidicek
    {// bu get metodu yani alıcı istekde bulunuyor  metodlar karışmasın diye alttaki metou post olarak belirledik istersek bunuda get olarak belirleyebiliriz ama bunun get olduğunu algıladı
        return View();
    }

    [HttpPost] // metodlar karışmasın diye bunu post olarak belirledik
    public IActionResult YasGrubu(int yas, string ad) // buda yasgrubu sayfasındaki hesapla butonuna basılınca çalışıcak üstteki metodun aynısı overload edildi parametre eklendi
    {// bu post metodu bunda ise alıcıya  geri dönüş sağlanıyor
     //metdoun içinde parametre adları formdan gelen name ler ile aynı olmak zorunda
        if (yas==0)
        {
            ViewBag.YasGrubu = "Yaş Bilgisini Girmediniz";
        }
        else if (yas < 18)
        {
            ViewBag.YasGrubu = $"{ad},Reşit değilsiniz";
        }
        else if (yas < 40)
        {
            ViewBag.YasGrubu = $"{ad}, Gençsiniz";
        }
        else if (yas < 60)
        {
            ViewBag.YasGrubu = $"{ad}, Gençlere taş çıkarırsın";
        }
        else
        {
            ViewBag.YasGrubu = $"{ad},GGG";
        }


        return View();
    }
    public IActionResult CreateProduct()
    {
        return View();
    }

    // [HttpPost]
    // public IActionResult CreateProduct(string productName, string productCategory, decimal productPrice)
    // {
    //     //burada veri tabanına kayıt işlemi vb. yapılacak
    //     // şimdilik biz gelen verilerin testini yapabilmek için tekrar sayfaya bastırıyor.
    //     ViewBag.ResultHeader=$"{productName} adlı ürün eklendi.";
    //     ViewBag.ResultBody=$"Category:{productCategory}, Price: {productPrice}";
    //     return View();
    // }


    [HttpPost]
                                            // burda yaptığımız daha kısası bizim 3 parametre değilde daha fazla paramtre ile veri almış olsaydık uğraştırıdı ama böyle daha kısa
    public IActionResult CreateProduct(Product product) // üstteki satırla yapmıştık ama şimdi onu değiştirk Product classı oluşturudk ve onun adında tanımladığımız product nesnei tanımladık
    {
        // ViewBag.ResultHeader=$"{product.Name} adlı ürün eklendi.";
        // ViewBag.ResultBody=$"Category:{product.Category}, Price: {productPrice}";
        return View(product);
    }

}
