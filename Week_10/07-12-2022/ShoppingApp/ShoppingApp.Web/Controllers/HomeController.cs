using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers;

public class HomeController : Controller
{

    private readonly IProductService _productManager;

    public HomeController(IProductService productManager)
    {
        _productManager = productManager;
    }

    public async Task<IActionResult> Index()
    {
        var products=await _productManager.GetAllAsync();// bunun içinde normalde Product lerin bütün listesi var yani bütün propertiesleri var ama biz listeemk istediğimiz zaman tüm proplarıyla değilde belli proplarıyla listelemk istiyoruz o yüzden models kalsörü içinde  ProductDto adında class oluşturduk ve bizim Product bilgilerini tutan products nesnesini bir döngüde döndürüp o bilgileri  ProductDto içinde karşılık gelen proplara attık ve onuda bir listede tutuk ve o listeyi geri döndürdük index sayfamıza gönderdik
        List<ProductDto> productsDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            productsDtos.Add(
                 new ProductDto
                 {
                     Id = product.Id,
                     Name = product.Name,
                     Price = product.Price,
                     DateAdded = product.DateAdded
                 });


        }
       
        return View(productsDtos);
    }

 
}
