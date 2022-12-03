using BlogApp.Entities.Dtos;
using BlogApp.Services.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]//burası admin areasına ati diyoruz belirtiyoruz
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        public async Task<IActionResult> Index() //task ile asenkron yaptık
        {
            var result = await _categoryService.GetAll(); // categori service git bütün kategorileri çek ve result değişkenine at
            if (result.ResultStatus==ResultStatus.Success) // result.ResultStatus  ResultStatus.Success ise onunla birlikte gelen datayı view ile gönderiyoruz eğer data gelmemişse boş olarak göndericek
            {
                return View(result.Data);
            }
            return View();
        }

        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");// geriye category içindeki _CategoryAddPartial bu isimdeki sayfamızı döndürücek
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            return View("/Admin");
        }
    }
}
