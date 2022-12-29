using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingAppClient.Models;
using System.Diagnostics;

namespace ShoppingAppClient.Controllers
{
    public class HomeController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var urunler = new List<ProductViewModel>();
            using (var httpClient=new HttpClient())
            {
                using (var response= await httpClient.GetAsync("http://localhost:5200/api/products"))
                {
                    string apiResponse= await response.Content.ReadAsStringAsync();
                    urunler=JsonConvert.DeserializeObject<List<ProductViewModel>>(apiResponse);
                }
            }
            return View(urunler);
        }

      
    }
}