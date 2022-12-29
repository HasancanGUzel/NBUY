using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingAppClient.Models;
using System.Text;

namespace ShoppingAppClient.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var urunler = new List<ProductViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/products/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    urunler = JsonConvert.DeserializeObject<List<ProductViewModel>>(apiResponse);
                }
            }
            return View(urunler);
        }
        public async Task<IActionResult> Create()
        {
            var kategoriler = new List<CategoryViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/categories/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kategoriler = JsonConvert.DeserializeObject<List<CategoryViewModel>>(apiResponse);
                }
            }
            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = kategoriler
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            
            if (ModelState.IsValid)
            {
                using (var httpClient=new HttpClient())
                {
                    var serializeProductViewModel = JsonConvert.SerializeObject(productViewModel);
                    StringContent stringContent = new StringContent(serializeProductViewModel,Encoding.UTF8,"application/json");
                    var result= await httpClient.PostAsync("http://localhost:5200/api/products", stringContent);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var urun = new ProductViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5200/api/products/{id}"))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    urun = JsonConvert.DeserializeObject<ProductViewModel>(stringResponse);
                }
            }
            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = urun.Id,
                Name = urun.Name,
                Description = urun.Description,
                Price = urun.Price,
                ImageUrl = urun.ImageUrl,
            };
            return View(productViewModel);
        }
    }
}
