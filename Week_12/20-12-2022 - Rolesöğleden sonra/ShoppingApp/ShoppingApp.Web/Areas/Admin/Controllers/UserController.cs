using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using System.Data;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            List<UserDto> users = _userManager.Users.Select(u => new UserDto //UserDto türünü list olarak tutarak her bir user(kullanıcıyı)select ile döngüye soktuk ve hepsini userDto içindeki proplar attık
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed
            }).ToList();// listeledik ve anasayfamıza gönderdik
            ViewBag.SelectedMenu = "User";
            ViewBag.Title = "Kullanıcılar";
            return View(users);
        }

        public IActionResult Create() // get metodunda sayfa ilk açıldığı zaman oraya sağ tarafa rolleri gönderiyoruz yani ürünler ve kategoriler gibi
        {
            UserAddDto userAddDto = new UserAddDto // UserAddDto tipindeki modelimizden nesne tanımlıyoruz ve bunun içinde tutuğumuz Role propu na Rol tablomuzdan verileri çektik ve select ile döngü içinde tek tek  RoleDto proplarına attık bunuda  UserAddDto içinde tutuyoruz 
            {
                Roles = _roleManager.Roles.Select(r => new RoleDto
                {
                    Id=r.Id,
                    Name=r.Name,
                    Description=r.Description
                }).ToList(),
                SelectedRoles=new List<string> { }// bunu burada  create da 49 satır için yaptık bbunu yapmasaydık null gidicekti ve böyle gidrese butona basılınca hata veriridi bunun başka bir çözümü ise  o view da if kontrolu yapardık dolumu boşmu diye

                //aslında buaraya selectedroles de konulabilir hatta konursa işimiz çok rahatlayacak daha sonra buraya döneceğiz
            };
            ViewBag.Title = "Kullanıcı oluştur.";
            return View(userAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAddDto userAddDto) // viewmızdan gelen veriler
        {
            if(ModelState.IsValid)
            {
                var user = new User //gelen UserAddDto tipindeki bilgiler ile yeni bir User tipinde user oluşturuyoruz çünkü veritabanına atıcaz
                {
                    FirstName = userAddDto.UserDto.FirstName,
                    LastName = userAddDto.UserDto.LastName,
                    UserName = userAddDto.UserDto.UserName,
                    Email = userAddDto.UserDto.Email,
                    EmailConfirmed = userAddDto.UserDto.EmailConfirmed
                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");//oluşturuduğumuz user bilgisi ile şifreyi girerek kaydediyoruz
                if (result.Succeeded)// kayıt işlemi başarılı ise seçili rolleri veya rolü kullanıcı bilgilerinide kullanarak ekliyoruz
                {
                    await _userManager.AddToRolesAsync(user, userAddDto.SelectedRoles);
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", $"{user.UserName} kullanıcısı başarı ile oluşturuldu", "success");
                    return RedirectToAction("Index", "User");

                }
                foreach (var error in result.Errors) // hata mesajlarını yazdıroyurz
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
           //eğer hata varsa sayfaya kullancıı verilerini tekrar göndericez burada role bilgilerini göndericez userAddDto içine rol tablosudan verleri çekip roleDto türünde atıyoruz 
            userAddDto.Roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            //burada kullanıcı rol seçtiyse seçili olan rolleri UserAddDto içindeki sleectedRoles içine atıyoruz boşsa yeni üretiyoruz
            userAddDto.SelectedRoles = userAddDto.SelectedRoles ?? new List<string>();
            return View(userAddDto);
        }

        public async Task<IActionResult> Edit(string id)//index sayfamızadan buraya id yi yolluyoruz
        {
            var user = await _userManager.FindByIdAsync(id); // gelen bu id ye göre de user bilgisini buluyoruz
            if (user == null) { return NotFound(); } // boşmu bakıyoruz
            UserAddDto userUpdateDto = new UserAddDto // boş değilse  UserAddDto nesne tanımladık bu nesnein içinde 
            {
                UserDto = new UserDto//user bilgilerini UserDto tipine dönüştürüyoruz
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    UserName = user.UserName,
                },
                SelectedRoles = await _userManager.GetRolesAsync(user),// bu user bilgisinin seçili rollerini alıyoruz
                Roles = _roleManager.Roles.Select(r => new RoleDto // içinde roledtolar barındıran roller lazımdı
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList()
            };
            return View(userUpdateDto);// ve edit sayfamıza içinde userDto tipinde user barındıran  seçili rolleri tutan ve rollerin tamamını yolluyoruz
        }
    }
}
