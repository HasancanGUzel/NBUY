using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")] 
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var roles = _roleManager.Roles.ToList();//bütün rolleri getirir.
            //List<Role> roles = _roleManager.Roles.ToList();//üstteki ile aynı
            //List<RoleDto> roles = _roleManager.Roles.ToList(); // gelen değer Role tipinde biz listeyi RoleDto a ya aktaıoyurz hata veriyor bunu döngü şeklinde her bir rolü RoleDto ya aktarıcaz
            List<RoleDto> roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id=r.Id,
                Name=r.Name,
                Description=r.Description
            }).ToList(); // role tablosundan gelen verileri çektik ama ROLE titpinde geliyor bizz ise Lit<RoleDto> aktarmaya çalışıyoruz bunun için gelen verileri üzerinden döngü kurduk ve her gelen veriyi tanımladığımız RoleDto proplarına karşılık aktardık

            return View(roles);
        }


        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleDto)// sayfayı post edince RoleDto türünden veri gelicek
        {
            if (ModelState.IsValid) // bu veriyi kontrol edicez
            {
                var result = await _roleManager.CreateAsync(new Role //yeni gelen veriyi nesne oluşturup buna katarıcaz
                {
                    Name=roleDto.Name,
                    Description=roleDto.Description
                });
                if (result.Succeeded)// baarılı ise bu mesajı
                {
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", roleDto.Name + " rolü başarı ile eklenmiştir", "success");
                    return RedirectToAction("Index", "Role");
                }
                foreach (var error in result.Errors) // değilse hata mesajlarını vericez
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(roleDto);//kontrol edilen veri boşşsa aynı sayfaya bilgileri göndericez
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);//id ye göre rol deki bilgileri bulduk getirdik
            if (role == null) 
            {
                return NotFound(); 
            }
            var users = _userManager.Users;//users bilgilerini getirdi
            var members = new List<User>();// ilgili role ait olan kullanıcılar için
            var nonMembers = new List<User>();//ilgili role ait olmayan kullanıcılar için
            foreach (var user in users)// users lar içinde dönüyoruz
            {
                #region uzun yol
                //var isInRole = await _userManager.IsInRoleAsync(user, role.Name);//kullanıcının bu rolde olup olmadığını söylüyor
                //if (isInRole)
                //{
                //    members.Add(user);
                //}
                //else
                //{
                //    nonMembers.Add(user);
                //}
                #endregion

                #region kısa yol
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;// list değişkenine döngüdeki her bir user hangi rolde ona bakıcak
                list.Add(user);
                #endregion

            }
            RoleDetailsDto roleDetailsDto = new RoleDetailsDto
            {
                Role = role, // bilgileri edit sayfasına göndermek için  RoleDetailsDto propların aktarıyoruz
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetailsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditDetailsDto roleEditDetailsDto )// buraya RoleEditDetailsDto türünde veriler gelicek
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditDetailsDto.IdsToAdd ?? new string[] {})// gelen IdsToAdd doluysa içinde dolaş boşsa yeni üret
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user==null)
                    {
                        return NotFound();
                    }
                    var result = await _userManager.AddToRoleAsync(user, roleEditDetailsDto.RoleName);// git sıradaki userı bu modelden gelen role ekle
                    if (!result.Succeeded) // değilse
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                foreach (var userId in roleEditDetailsDto.IdsToRemove ?? new string[] { })// gelen IdsToRemove doluysa içinde dolaş boşsa yeni üret
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user == null)
                    {
                        return NotFound();
                    }
                    var result = await _userManager.RemoveFromRoleAsync (user, roleEditDetailsDto.RoleName);// bu userı bu rolden çıkart
                    if (!result.Succeeded) // değilse
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                return RedirectToAction("Index", "Role");
            }
            return Redirect("/Admin/Role/Edit/" + roleEditDetailsDto.RoleId);
        }
    }
}
