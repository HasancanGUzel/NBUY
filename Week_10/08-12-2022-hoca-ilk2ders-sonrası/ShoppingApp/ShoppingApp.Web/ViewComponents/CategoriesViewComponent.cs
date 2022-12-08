using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;

namespace ShoppingApp.Web.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["category"] != null) // buradaki category ismi program cs deki  mapcontrollerdaki category den geliyor aynı isim olması lazım
            {
                ViewBag.SelectedCategory = RouteData.Values["category"];//buradaki isimde program cs deki isimler aynı olması lazım link yapısnı ismini category yapmıştık ve url i aldık buraya ne geliyor beyaz-esya gibi vs
            }
            var categories = await _categoryManager.GetAllAsync();
            return View(categories);
        }
    }
}
