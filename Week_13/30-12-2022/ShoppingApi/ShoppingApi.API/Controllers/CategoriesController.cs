using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.API.Model;
using ShoppingApi.Business.Abstract;

namespace ShoppingApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                });
            }
            return Ok(categoryDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var products = await _productService.GetProductsByCategoryAsync(category.Url);
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Url = product.Url
                });
            }
            return Ok(productDtos);
        }
    }
}
