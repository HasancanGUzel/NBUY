using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KitabeviApp.Web.ViewModels;
using KitabeviApp.Data.EfCore;
using KitabeviApp.Entity;
using Microsoft.EntityFrameworkCore;
using KitabeviApp.Data.EfCore.Concrete;
using KitabeviApp.Business.Concrete;

namespace KitabeviApp.Web.Controllers;

public class HomeController : Controller
{
    KitabeviContext context = new KitabeviContext();
    EfCoreKategoriRepository kategoriRepository = new EfCoreKategoriRepository();// global olarak tanımladık
    EfCoreYazarRepository yazarRepository=new EfCoreYazarRepository();
     EfCoreKitapRepository kitapRepository=new EfCoreKitapRepository();
 public IActionResult Index()
    {
        List<Kitap> kitaplar = context
                .Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yazar)
                .ToList();
        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        return View(kitapListViewModels);
    }
    
    
    #region KATEGORİ İŞLEMLERİ
    public IActionResult KategoriListesi()
    {
       var kategoriManager=new KategoriManager();//burda ise data da yaprığımızın aynısı busines ile yapıyoruz bu sefer web sayfası busines ile iletişime geçiyor busines ise data ile sonra data veriyi businese veriyor busines de webe geri gertiriyor
        var kategoriler = kategoriManager.KategoriListele(); 
        return View(kategoriler);
    }
     public IActionResult KategoriEkle()
    {
        return View();
    }
    [HttpPost]
    public IActionResult KategoriEkle(Kategori kategori)
    {
        var kategoriManager=new KategoriManager();
        kategoriManager.KategoriEkle(kategori);
        return RedirectToAction("KategoriListesi");
    }

    public IActionResult KategoriGuncelle(int id)
    {
        // Kategori kategori = context.Kategoriler.Where(k=>k.Id==id).FirstOrDefault();
        var kategoriManager = new KategoriManager();
        Kategori kategori = kategoriManager.KategoriGet(id);
        return View(kategori);
    }

    [HttpPost]
    public IActionResult KategoriGuncelle(Kategori kategori)
    {
        var kategoriManager = new KategoriManager();
        kategoriManager.KategoriGuncelle(kategori);
        return RedirectToAction("KategoriListesi");
    }

     public IActionResult KategoriSil(int id)
    {
        var kategoriManager = new KategoriManager();
        Kategori kategori = kategoriManager.KategoriGet(id);
        return View(kategori);
    }
    [HttpPost]
    public IActionResult KategoriSil(Kategori kategori)
    {
        var kategoriManager = new KategoriManager();
        kategoriManager.KategoriSil(kategori);
        return RedirectToAction("KategoriListesi");
    }

    #endregion
   
   //#region YAZAR İŞLEMLERİ
   //  public IActionResult YazarListesi()
   // {
   //     // var yazarRepository=new EfCoreYazarRepository();//globale aldık
   //     var yazarlar = yazarRepository.YazarListele();
   //     return View(yazarlar);
   // }
   //  public IActionResult YazarEkle()
   // {
   //     return View();
   // }
   // [HttpPost]
   // public IActionResult YazarEkle(YazarViewModel yazarViewModel)
   // {
   //     if (ModelState.IsValid)
   //     {
   //         Yazar yazar = new Yazar()
   //         {
   //             Ad = yazarViewModel.Ad,
   //             DogumYili = yazarViewModel.DogumYili,
   //             Cinsiyet = yazarViewModel.Cinsiyet
   //         };
   //        yazarRepository.YazarEkle(yazar);
   //         return RedirectToAction("YazarListesi");
   //     }
   //     return View();
   // }
   //  public IActionResult YazarGuncelle(int id)
   // {
   //     // Yazar yazar = context.Yazarlar.Where(k=>k.Id==id).FirstOrDefault();
   //     Yazar yazar = yazarRepository.YazarGet(id);
   //     return View(yazar);
   // }

   // [HttpPost]
   // public IActionResult YazarGuncelle(Yazar yazar)
   // {
   //     yazarRepository.YazarGuncelle(yazar);
   //     return RedirectToAction("YazarListesi");
   // }
   

   // public IActionResult YazarSil(int id)
   // {
   //     Yazar yazar = yazarRepository.YazarGet(id);
   //     return View(yazar);
   // }
   // [HttpPost]
   // public IActionResult YazarSil(Yazar yazar)
   // {
   //     yazarRepository.YazarSil(yazar);
   //     return RedirectToAction("YazarListesi");
   // }




   //#endregion
    
   // #region KİTAP İŞLEMLERİ
        
   // public IActionResult KitapListesi(int? id = null)
   // {
   //     //  var kitapRepository=new EfCoreKitapRepository();
   //      List<Kitap>kitaplar= kitapRepository.KitapListele(id);
   //     List<KitapListViewModel> kitapListViewModels = kitaplar
   //         .Select(k => new KitapListViewModel()
   //         {
   //             Id = k.Id,
   //             Ad = k.Ad,
   //             BasimYili = k.BasimYili,
   //             SayfaSayisi = k.SayfaSayisi,
   //             YazarAd = k.Yazar.Ad,
   //             KategoriAd = k.Kategori.Ad
   //         }).ToList();
   //     return View(kitapListViewModels);
   // }
   // public IActionResult KitapEkle()
   // {
   //     ViewBag.Kategoriler = context.Kategoriler.ToList();
   //     ViewBag.Yazarlar = context.Yazarlar.ToList();
   //     return View();
   // }
   // [HttpPost]
   // public IActionResult KitapEkle(Kitap kitap)
   // {
   //     kitapRepository.KitapEkle(kitap);
   //     return RedirectToAction("KitapListesi");
   // }
   // public IActionResult KitapGuncelle(int id)
   // {
   //     Kitap kitap = kitapRepository.KitapGet(id);
   //     // KitapViewModel kitapModel = new KitapViewMode
   //     // kitapModel.Kitap=kitap;
   //     // kitapModel.Yazarlar=context.Yazarlar.ToList();
   //     // kitapModel.Kategoriler=context.Kategoriler.ToList();
   //     var liste = context.Yazarlar.Select(y => y.Ad).ToList();
   //     KitapViewModel kitapViewModel = new KitapViewModel()
   //     {
   //         Kitap = kitap,
   //         Yazarlar = context.Yazarlar.ToList(),
   //         Kategoriler = context.Kategoriler.ToList()
   //     };
   //     return View(kitapViewModel);
   // }
   // [HttpPost]
   // public IActionResult KitapGuncelle(Kitap kitap)
   // {
   //     kitapRepository.KitapGuncelle(kitap);
   //     return RedirectToAction("KitapListesi");
   // }
   // public IActionResult KitapSil(int id)
   // {
   //     Kitap kitap = kitapRepository.KitapGet(id);
   //     ViewBag.Kategoriler = context.Kategoriler.ToList();
   //     ViewBag.Yazarlar = context.Yazarlar.ToList();
   //     return View(kitap);
   // }
   // [HttpPost]
   // public IActionResult KitapSil(Kitap kitap)
   // {
   //    kitapRepository.KitapSil(kitap);
   //     return RedirectToAction("KitapListesi");
   // }

 
   // #endregion

    

    
    public IActionResult Detay(int id)
    {
        var kitap = context
            .Kitaplar
            .Where(k => k.Id == id)
            .Include(k => k.Yazar)
            .Include(k => k.Kategori)
            .FirstOrDefault();
        return View(kitap);
    }
    

       public IActionResult KategoriyeGoreKitapListesi(int id)
    {
        List<Kitap> kitaplar = context
            .Kitaplar
            .Where(k => k.KategoriId == id)
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();

        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        ViewBag.Tip = "Kategori";
        return View("Index", kitapListViewModels);

    }
    public IActionResult YazaraGoreKitapListesi(int id)
    {
        List<Kitap> kitaplar = context
            .Kitaplar
            .Where(k => k.YazarId == id)
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();

        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        ViewBag.Tip = "Yazar";
        return View("Index", kitapListViewModels);

    }

}
