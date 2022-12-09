using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService; // bunu productlra erşebilmek için yaptık
        private readonly ICategoryService _categoryService;// kategorilere erişebilmek için

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsWithCategories(); 
            var productListDto = products 
                .Select(p => new ProductListDto 
                {
                    Product = p,
                  
                }) .ToList();
            
            return View(productListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories =await _categoryService.GetAllAsync(); //bütün kategori bilgilerini al
            var productAddDto = new ProductAddDto
            {
                Categories = categories // kategori bilgilerini yaratacağımız Create sayfasına gönderdik
            };
            return View(productAddDto);
        }
    }
}

















// hangi ürün hangi kategoride onu bulduk

// products içinden seçicez neyi 

// new yaptığımız ProductListDto daki Product a productları atıyoruz categories listimizide productdan ProductCategories tablosuna 