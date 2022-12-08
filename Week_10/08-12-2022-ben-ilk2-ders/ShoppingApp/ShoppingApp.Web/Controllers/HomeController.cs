using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete;
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
        //business katmanından gelen  GetHomePageProductsAsync metodundan gelen değeri alıp product listesine atıyor
        //ama biz bütün product ları göstermek yerine göstermek istediğimiz kolonları ProductDto içinde topladık ve ProductDto içindeki kolonlara göre  aktardık
        List<Product> products = await _productManager.GetHomePageProductsAsync();
        List<ProductDto> productDtos= new List<ProductDto>();
        foreach (var product in products)
        {
            productDtos.Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl=product.ImageUrl,
                DateAdded = product.DateAdded,
            });
        }
        return View(productDtos);
    }
}
