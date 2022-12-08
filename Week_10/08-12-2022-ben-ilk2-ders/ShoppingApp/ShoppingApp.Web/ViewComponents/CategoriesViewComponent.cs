using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;

namespace ShoppingApp.Web.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent // biz bu CategoriesViewComponent klasörünü biz index de producları PorductDto ile getirmiştik ama aynı sayfaya Categrileri de getirmk istiyoruz onun için viewbag lede gönderebilirz bunlada kitabevi app iyi bak orda yaptık
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["category"]!= null) //eğer bir kategori seçilmişsse o catgori bilgisini viewbag içinde bulunduruyor.
            {
                ViewBag.SelectCategory = RouteData.Values["category"];
            }
            var categories= await _categoryManager.GetAllAsync();
            return View(categories); // buradaki return view bizim Components içindeki categories içindeki default.cshtml dosyasına gidiyor
        }

    }
}
