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
                using (var httpClient = new HttpClient())
                {
                    var serializeProductViewModel = JsonConvert.SerializeObject(productViewModel);
                    StringContent stringContent = new StringContent(serializeProductViewModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:5200/api/products", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        #region Kategori getir
                        var kategoriler = new List<CategoryViewModel>();
                       
                            using (var response = await httpClient.GetAsync("http://localhost:5200/api/categories/"))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                kategoriler = JsonConvert.DeserializeObject<List<CategoryViewModel>>(apiResponse);
                            }
                        productViewModel.Categories = kategoriler;

                        #endregion
                        return View(productViewModel);
                    }
                   



                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            #region ürün getir
            var urun = new ProductViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5200/api/products/{id}"))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    urun = JsonConvert.DeserializeObject<ProductViewModel>(stringResponse);
                }
            }
            #endregion
            #region Kategori getir
            var kategoriler = new List<CategoryViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/categories/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kategoriler = JsonConvert.DeserializeObject<List<CategoryViewModel>>(apiResponse);
                }
            }
            #endregion

            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = urun.Id,
                Name = urun.Name,
                Description = urun.Description,
                Price = urun.Price,
                ImageUrl = urun.ImageUrl,
                Categories = kategoriler,
                SelectedCategoryIds = urun.SelectedCategoryIds ?? new int[] { }
            };
            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            if (productViewModel == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                using (var httpClient=new HttpClient())
                {
                    var serializeProduct = JsonConvert.SerializeObject(productViewModel);
                    StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
                    var result = await httpClient.PutAsync("http://localhost:5200/api/products", stringContent);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
