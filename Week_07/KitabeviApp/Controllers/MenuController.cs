using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KitabeviApp.Controllers
{
    
    public class MenuController : Controller
    {
       
         public IActionResult Index()
        {
            MyDbContext context= new MyDbContext();
            List<Kitap> kitaplar=context 
            .Kitaplar
            .Include(p=>p.Kategori)
            .Include(p=>p.Yazar)
            .ToList();
            return View(kitaplar);
        }
         public IActionResult Kategori()
        {
            MyDbContext context=new MyDbContext();
            List<Kategori>kategoriler=context.Kategoriler.ToList();
            return View(kategoriler);
        }
        public IActionResult Yazar()
        {
            MyDbContext context=new MyDbContext();
            List<Yazar>yazarlar=context.Yazarlar.ToList();
            return View(yazarlar);
        }

       
    }
}