using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proje05_MVC_EfCore_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Proje05_MVC_EfCore_CodeFirst.Controllers
{
   
    public class ProductController : Controller
    {
       

        public IActionResult Index()
        {
            MyDbContext context= new MyDbContext();// nesne tanımladık
            // var products=context.Products.ToList(); // buradan gelen veri DbSet<Product> türünde bi veri ve biz bunu list olarak tutabiliriz
            List<Product> products=context //tanımladığımız nesne ile o sınıftaki Products tablosunu liste halinde list türündeki MyDbContext bu sınıftaki DbSet<Product> tanımladık diye product nesnesine attık
            .Products
            .Include(p=>p.Category) //product tablosundaki category tipinde oluşturduğumuz Category kolonunu getirdik
            .ToList();
            return View(products);
        }

       
    }
}