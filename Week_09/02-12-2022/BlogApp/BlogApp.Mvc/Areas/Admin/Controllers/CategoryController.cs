using BlogApp.Entities.Dtos;
using BlogApp.Mvc.Areas.Admin.Models;
using BlogApp.Services.Abstract;
using BlogApp.Shared.Utilities.Extensions;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using BlogApp.Shared.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogApp.Mvc.Areas.Admin.Controllers
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
            var result = await _categoryService.GetAll();
            if (result.ResultStatus==ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)// valid değeri true ise bu kod bloğu çalışıscak
            {
                var result = await _categoryService.Add(categoryAddDto,"Hasancan Güzel");//asenkron yapı olduğu için await kullandık  ve ICategoryService den türettiğimiz  _categoryService.add metodunu (tabi normalde ICategoryService içinde sadece imzalar var yani ordaki metot boş ama biz  ICategoryService gördüğümüz yerde categorymanager kullan dedğimiz için onun içindeki metotları kullanıyoruz)  kullanıyoruz ve buna 2 tane parametre veriyoruz 1.CategoryAddDto türünde 2 ise creadetbyname için normalde onu böyle elle yapmayacağız fakat şimdlik böyle kullandık
                if (result.ResultStatus==ResultStatus.Success) // yukarıda result değerine attığımız verinin  ResultStatus eşitse ResultStatus.Success burası çalışıcak
                {
                    var categoryAddAjaxModel= JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    { // CategoryAddAjaxViewModel türünde yeni nesne üretiyoruz ve bu nesnenin prop larına karşılık gelen verilere aktarıyoruz
                        CategoryDto =result.Data,
                        CategoryAddPartial= await this.RenderViewToStringAsync("_CategoryAddPartial",categoryAddDto) // _CategoryAddPartial adındaki   viewmızım ve dışarıdan gelen categoryAddDto modelimiz  
                    });
                    return Json(categoryAddAjaxModel);// jsona dönüştürüdk ve category içindeki index view ın daki javascript koduna gönderdik
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto) // _CategoryAddPartial adındaki   viewmızım ve dışarıdan gelen categoryAddDto modelimiz  
            });
            return Json(categoryAddAjaxErrorModel);// jsona dönüştürüdk ve category içindeki ixdex view ın daki javascript koduna gönderdik
        }
    }
}
