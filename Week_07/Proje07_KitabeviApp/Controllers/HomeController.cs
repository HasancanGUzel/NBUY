using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KitabeviApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Controllers;

public class HomeController : Controller
{
    KitabeviContext context = new KitabeviContext();
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult KategoriListesi()
    {
        var kategoriler = context.Kategoriler.ToList();
        return View(kategoriler);
    }
    public IActionResult YazarListesi()
    {
        var yazarlar = context.Yazarlar.ToList();
        return View(yazarlar);
    }
    public IActionResult KitapListesi(int? id=null) // buradaki id değişkenimiz program cs de controller içinde değişkenin isminde olması lazım oraya mahmut yazrsam burasıda mahmut olması lazım ve buraya gelen id değeri kategori listesindeki asp-rouet-id=@k.id sonucunda gelen değer
    {
        List<Kitap> kitaplar =null;
        if(id==null)
        {
             kitaplar = context
            .Kitaplar
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();
        }
        else
        {
             kitaplar = context
            .Kitaplar
            .Where(k=>k.KategoriId==id)// kategori ıd miz dışarıda gelen id ye eşitse
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();
        }
        
        return View(kitaplar);
    }
    public IActionResult Detay(int id) // _Kitap.cshtml sayfasındaki İncele butonundaki asp-route-id=@Model.Id gelen veri
    {
        var kitap=context.Kitaplar.Where(k=>k.Id==id).Include(k=>k.Yazar).Include(k=>k.Kategori).FirstOrDefault();
        return View(kitap);
    }
    public  IActionResult KategoriEkle()
    {
        return View();
    }

    [HttpPost]
    public  IActionResult KategoriEkle(Kategori kategori)//Kategori türünde kategori adında değişken tanımladık
    {
        context.Kategoriler.Add(kategori);
        context.SaveChanges();//kaydetmek için
        return RedirectToAction("KategoriListesi");
    }

    public  IActionResult YazarEkle()
    {
        return View();
    }

    [HttpPost]
    public  IActionResult YazarEkle(Yazar yazar)//Yazar türünde kategori adında değişken tanımladık
    {
        context.Yazarlar.Add(yazar);
        context.SaveChanges();//kaydetmek için
        return RedirectToAction("YazarListesi");
    }
    public IActionResult KitapEkle()
    {
        ViewBag.Kategoriler=context.Kategoriler.ToList();
        return View();
    }

    [HttpPost]
     public IActionResult KitapEkle(Kitap kitap)
    {
       
        return View();
    }



    //httpget, http post,httput,httpdelete metotları araştır
    
}
