using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            var categories = await _categoryService.GetAllAsync(); // veritabanında tüm kategorileri çektik ve categories içine attık ama biz direk entityle ile ileişime geçmesinler diye CtageoyList Dto tanımlamıştık
            var categoryListDto = new CategoryListDto// burada CtageorListDto dan kategorileri tutan Categories içine ukarıda tanımladığımız categories içindeki verilri atıyruz
            {
                Categories = categories

            };
            return View(categoryListDto);
        }
    }
}
