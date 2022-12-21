using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;

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
            List<UserDto> users = _userManager.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed
            }).ToList();
            ViewBag.SelectedMenu = "User";
            ViewBag.Title = "Kullanıcılar";
            return View(users);
        }

        public IActionResult Create()
        {
            UserAddDto userAddDto = new UserAddDto
            {
                Roles = _roleManager.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList(),
                SelectedRoles = new List<string>()
              
                
                //Aslında buraya selectedRoles de konulabilir, hatta konursa işimiz çok rahatlatacak. Daha sonra buraya döneceğiz.
            };
           
            ViewBag.Title = "Kullanıcı Oluştur";
            return View(userAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userAddDto.UserDto.FirstName,
                    LastName = userAddDto.UserDto.LastName,
                    UserName = userAddDto.UserDto.UserName,
                    Email = userAddDto.UserDto.Email,
                    EmailConfirmed = userAddDto.UserDto.EmailConfirmed
                };
                var result = await _userManager.CreateAsync(user,"Qwe123.");
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, userAddDto.SelectedRoles);
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", $"{user.UserName} kullanıcısı başarıyla oluşturuldu.", "success");
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            userAddDto.Roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            userAddDto.SelectedRoles = userAddDto.SelectedRoles ?? new List<string>();
            return View(userAddDto);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            UserAddDto userUpdateDto = new UserAddDto
            {
                UserDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    UserName = user.UserName
                },
                SelectedRoles = await _userManager.GetRolesAsync(user),
                Roles = _roleManager.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList()
            };
            return View(userUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserAddDto userUpdateDto)//sayfa post edildiği zaman buraya UserAddDto tipinde veriler gelicek
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userUpdateDto.UserDto.Id);// buraya gelen veriler içindeki UserDto içindeki kullancıı idsine göre kullanıcı bilgisini getiriyoruz
                if (user == null) { return NotFound();}// boşmu bak
                user.FirstName = userUpdateDto.UserDto.FirstName;// değilse kullanıcı bilgilerine userUpdateDto içinde UserDto bilgilerini aktar
                user.LastName= userUpdateDto.UserDto.LastName;
                user.UserName= userUpdateDto.UserDto.UserName;
                user.Email= userUpdateDto.UserDto.Email;
                user.EmailConfirmed=userUpdateDto.UserDto.EmailConfirmed;

                var result = await _userManager.UpdateAsync(user);// aktardığımız bilgileri veritabanına gönder
                if (!result.Succeeded)// veritabanına gönderme başarılı değilse hata verdir
                {
                 return NotFound();

                }//başarlı ise bunlar olsun
                var userRoles = await _userManager.GetRolesAsync(user);// userın rollerini getirdik
                await _userManager.AddToRolesAsync(user, userUpdateDto.SelectedRoles.Except(userRoles).ToList<string>());//burada  güncellemede role eklerken bizim var olan rolleri çıkarıp olmaynları eklicez yukarıda userin rollerini getirdik ve excepti ile userin rollerini çıkarıp ekleme yaptık

                await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userUpdateDto.SelectedRoles).ToList<string>());//burada da  remov ederken  rollerin içinden gelen rolleri çıkarıcaz
                TempData["Message"] = Jobs.CreateMessage("Başarılı", $"{user.UserName}Kullancııs başarı ile güncellendi", "success");
                return RedirectToAction("Index", "User");
            }
            userUpdateDto.Roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();//rolleri listeleyip userUpdateDto içindeki Roles atıyoruz
            //eğer sayfayı güncelelrken role seçmez ise hata veriyordu ama şimdi role boş olarkda gönderiyoruz ve hata mesajı verdiriyoruz.
            userUpdateDto.SelectedRoles = userUpdateDto.SelectedRoles ?? new List<string>();
            return View(userUpdateDto);
        }

        //Ödev roller ve kullancıılar ile ilgili silme işlemlerinide tamamlayın
    }
}
