using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    // bir sonraki klasörde hocadan alınan daha içeriklisi var bunu ders içinde biz yaptık
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSender _emailSender;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            List<UserDto> users = _userManager.Users.Select(u => new UserDto // bütün usersları  getiridk ve select ile döngü yaptık her bir user için UserDto tipindeki proplara attık ve bunu list türünde tuttuk
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                EmailConfirmed=u.EmailConfirmed
            }).ToList();
            ViewBag.Selectedmenu = "User";
            ViewBag.Title = "Kullanıcılar";
            return View(users);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(CreateDto createDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = createDto.FirstName,
                    LastName = createDto.LastName,
                    UserName = createDto.UserName,
                    Email = createDto.Email,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user,"Qwe123.");
                if (result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "hesap başarıyla kaydedildi. Giriş yapabilirsiniz.", "success");
                    return RedirectToAction("Index", "User");

                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(createDto);
        }
    }
}
