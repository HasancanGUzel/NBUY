using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Business.Concrete;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productManager;

        public ShopController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList(string category)
        {
            // bunu bir sonraki klasrde bak
            List<Product> products = await _productManager.GetHomePageProductsAsync();
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    DateAdded = product.DateAdded,
                });
            }
            return View(productDtos);
        }
    }
}
