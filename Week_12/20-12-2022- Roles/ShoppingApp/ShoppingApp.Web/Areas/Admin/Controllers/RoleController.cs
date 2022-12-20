using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<RoleDto> roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id=r.Id,
                Name=r.Name,
                Description=r.Description
            }).ToList();
            ViewBag.SelectedMenu = "Role";
            ViewBag.Title = "Roller";

            return View(roles);
        }
    
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _roleManager.CreateAsync(new Role
                {
                    Name = roleDto.Name,
                    Description = roleDto.Description
                });
                if (result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Başarılı!", roleDto.Name + " rolü, başarıyla eklenmiştir.", "success");
                    return RedirectToAction("Index", "Role");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(roleDto);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role==null) { return NotFound(); }
            var users = _userManager.Users;
            var members = new List<User>();//İlgili role ait olan kullanıcılar için
            var nonMembers = new List<User>();//İlgili role ait olmayan kullanıcılar için
            foreach (var user in users)
            {
                #region UzunYol
                //var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                //if (isInRole)
                //{
                //    members.Add(user);
                //}
                //else
                //{
                //    nonMembers.Add(user);
                //}
                #endregion
                #region KısaYol
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
                #endregion
            }
            
            

            RoleDetailsDto roleDetailsDto = new RoleDetailsDto
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetailsDto);
        }
        [HttpPost]
        public  async Task<IActionResult> Edit(RoleEditDetailsDto roleEditDetailsDto)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditDetailsDto.IdsToAdd ?? new string[] {})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user==null) { return NotFound(); }
                    var result = await _userManager.AddToRoleAsync(user, roleEditDetailsDto.RoleName);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                foreach (var userId in roleEditDetailsDto.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user == null) { return NotFound(); }
                    var result = await _userManager.RemoveFromRoleAsync(user, roleEditDetailsDto.RoleName);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                
            }

           
            
            return Redirect("/Admin/Role/Edit/" + roleEditDetailsDto.RoleId);
        }

        //----------------------------------------------------------------
        public  IActionResult UserRoles()
        {
            ViewBag.SelectedMenu = "UserRoles";
            ViewBag.Title = "Rol atama";

            List<User> users = _userManager.Users.Select(u => new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName
            }).ToList(); //userları  User entitymizden çekip  listeleyip tutucaz

            //List<Role> roles = _roleManager.Roles.ToList();// alltakiyle aynı farkı bu role tablosuun bütün sütunlarını getiri ama biz aşşağıda işimize yarayanları aldık

            List<Role> roles = _roleManager.Roles.Select(r => new Role
            {
                Id=r.Id,
                Name=r.Name,
                Description=r.Description
            }).ToList();//rolleri Role entitymizden listeleyip tutuyoruz

//-----------------------------------------------------------------------------------------------
            List<SelectListItem> selectRoleList = roles.Select(r => new SelectListItem
            {//rollerin adı ve id sini getirmek için UserRoles viewmında liste şeklinde getirmek için
                Text=r.Name,
                Value=r.Id
            }).ToList(); //  List<SelectListItem> tipinden nesne üretiyoruz ve yukarıdaki çektiğimiz rollerin içinde dönüyoruz her bir rol için  SelectListItem propların aktarıyoruz
            UserRolesDto userRolesDto = new UserRolesDto //sonra modelimiz içide tanımlı olan SelectedRoleList içine yukarıdaki selectedRoleList atıyoruz users içine ise users ı atıyoruz
            {
                SelectRoleList = selectRoleList,
                Users = users
            };
            return View(userRolesDto);// ve bu nesneyi döndürüyoruz kullanıcılar ve rolleri
        }

        public async Task<IActionResult> GetUsers(UserRolesDto userRolesDto) //UserRoles deki 1. forman buaraya veri geldi
        {
            var role = await _roleManager.FindByIdAsync(userRolesDto.RoleId);//gelen bilgiye göre yani tıklanılan role göre id si geldi ve o id ye göre de rol bilgisini bulduk ve roles e attık
            var members = new List<User>();// List tipinde user tutan members adında nesne tanımladık 
            var nonMembers=new List<User>(); // List tipinde user tutan nonmember adında nesne tanımladık

            List<User> users = _userManager.Users.Select(u => new User //List<user> tipinde user ları çektik ve tek tek prolara attık
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName
            }).ToList();

            foreach (var user in users) // bu users lar içinde döndük ve her bir kullanıcının rolü varmı baktık ve varsa yukarıda tanımladığımız members değişkenine rolü yoksa nonmembers değişkenine attık
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            var roleDetailsDto = new RoleDetailsDto //bu RoleDetailsDto UserRolesDto daki değil bizim RoleDetailsDto modelimizden nesne ürettik ve bizim yukarıdaki tanımlaıdğımız role members ve nonmembers i bu modelde karşılık gelen proplara attık
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            List<Role> roles = _roleManager.Roles.Select(r => new Role//rolleri Role entitymizden listeleyip tutuyoruz
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            List<SelectListItem> selectRoleList = roles.Select(r => new SelectListItem
            {//rollerin adı ve id sini getirmek için UserRoles viewmında liste şeklinde getirmek için
                Text = r.Name,
                Value = r.Id
            }).ToList();//  List<SelectListItem> tipinden nesne üretiyoruz ve yukarıdaki çektiğimiz rollerin içinde dönüyoruz her bir rol için  SelectListItem propların aktarıyoruz
            userRolesDto.SelectRoleList = selectRoleList; // selectRoleList nesnesini userRolesDo içindeki SelectRoleLis içine attık
            userRolesDto.RoleDetailsDto= roleDetailsDto;//bizim yukarıda tanımladığımız roleDetailsList nesnesini userRolesDo içindeki RoleDetailsDo içine attık
            userRolesDto.Users = users;// users bilisinide  userRolesDto içindeki  Users attık
            ViewBag.Onay = true;
            return View("UserRoles", userRolesDto);//UserRoles viewına git dedik ve içinde kullanıcıları rolleri seçili rolleri falan yolladık
            
        }


    }
}
