using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryListDto = new CategoryListDto
            {
                Categories = categories
            };
            return View(categoryListDto);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = categoryAddDto.Name,
                    Description = categoryAddDto.Description,
                    //Url="buraya bir metot hazırlaycağız"
                    Url = Jobs.InitUrl(categoryAddDto.Name)

                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("Index");// kayıt yaptıktan sonra tekrar kategori listesine gitmek için bunu yazdık oda Index de
                //return RedirectToAction(nameof(Index));// böylede kullanılabilirz
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) // index den gelen id verisini aldık ve aşşığdaki metodu kullanarak id ye göre verileri getiricek ve biz düzenle butonuna basınca basılan butondaki verileri tekrar ekrana getiricek bizde post metoduyla güncellicez
        {
            var category = await _categoryService.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            var categoryUpdateDto = new CategoryUpdateDto
            {
                Id=category.Id,
                Name = category.Name,
                Description = category.Description,
                Url = category.Url
            };
            return View(categoryUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateDto categoryUpdateDto) //Edit sayfamızaden gelen veriler ile güncellem yapıcak
        {
            if (ModelState.IsValid)
            {
                var category=await _categoryService.GetByIdAsync(categoryUpdateDto.Id);// dışarıdan gelen categoryUpdateDto id sini alıp  bu metoda yolluyoruz bu metot id ye göre verileri category e atıyor
                if (category==null)
                {
                    return NotFound();
                }   
                category.Name = categoryUpdateDto.Name; // güncellenmiş olan veriler    yani şunları (categoryUpdateDto.Name;)  yeni verileri eski verlerin üstüne tek tek atıyoruz
                category.Description = categoryUpdateDto.Description;
                category.Url=Jobs.InitUrl(categoryUpdateDto.Name);
               

                _categoryService.Update(category);// güncellenmiş veriler category içinde bizde  Update metodunu kullanarak güncelleme işlemini yapıyoruz.
                return RedirectToAction("Index");
            }
            return View(categoryUpdateDto);
        }

        [HttpGet] // buraya formdan bir veri göndermedik o yüzden get formdan bir veri gönderseydik post olucaktı buraya gelen id formdan gelmiyor kafan karışmasın burya gelen id route dan geliyor
        public async Task<IActionResult> Delete(int id)  // formumuzdaki sil butonu için tanımladık 
        {
            var category = await _categoryService.GetByIdAsync(id); // sil butonuna tıklandığı zaman hangi butonu tıklandıysa o butonun ilgili id sini alıp bu id yi GetByIdAsync metotla gidip bluyor ve category içine atıyor
            if (category==null)
            {
                return NotFound();
            }
            _categoryService.Delete(category); // sonra o category içindeki bilgileri alıp delete metotuyla siliyoruz
            return RedirectToAction("Index"); // sonra ansayfamıza gidiyoruz
        }
    }
}
