﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    [AutoValidateAntiforgeryToken]// burada post olan metotlara uyguluyor
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager; // bizim produt ve kategori için yaptığımı _productManager gibi buradada user için tanımladık
        private readonly SignInManager<User> _signInManager; // kayıt olma işlemleri için
        private readonly IEmailSender _emailSender; 

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
             _emailSender = emailSender;
        }

        public IActionResult Login(string returnUrl = null)// default değerini null dedik
        {
            return View(new LoginDto { ReturnUrl=returnUrl}); // burdan veriyi alıp login sayfasıya yolluyoruz ve orada hiçbiryerde kullnamyaıp kullanıcı giriş yaptığı anda post ile login post actionuna gönderiyoruz
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user= await _userManager.FindByNameAsync(loginDto.UserName); // veritabanına dışarıdan gelen veriden UserName e göre arama yapıpbilgilerini getiriyor
                if (user == null)// eğer veritabanında veri gelmezse 
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");//login sayfasındaki  asp-validation-summary="All divinde hatayı yazdırıyoruz eğer içi boş tırnağın arasına UserName yazarsam username altındaki spana hatayı yazar
                    return View(loginDto);
                }
                //bu noktada email onayı yapılıp yapılmasığını kontrol ettitereceğiz 
                //eğer email onaylı ise login yaptıracağız değilse hatırlatacağız


                //-----------------------------
                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(loginDto.ReturnUrl ?? "~/");// ReturnUrl doluysa urlın olduğu yere git boşsa anasayfaya git dedik
                }
                ModelState.AddModelError("", "Email adresi ya da parola hatalı");
            }
            return View(loginDto);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]// benim bilgisayarımdan gelen cookie bilgisi ile çalışır
        // ilgili cookie nin sadece ait olduğu tarayıcı tarafından gönderilmesi halinde geçerli olmasını sağlar.
        //bunu en yukarıda her post metodu için geçerli olmasını sağladık
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            
            if (ModelState.IsValid) 
            {
                var user = new User //user entitymiz deki proplara Register safasından post olduğu zaman RegisterDtodaki karşılık gelen verileri aktarıyoruz ama passwordu aktaramayız
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                };
                var result = await _userManager.CreateAsync(user,registerDto.Password);// yukarıdaki user a attığımız bilgileri aldı ve post yapılırken registerDto.Password içinde olan şifre ile kayıt yaptı 
                if (result.Succeeded)//kayıt işlemi başarılı ise 
                {
                    //Generate Token(mail onayı için)

                    //---------------------------------
                    var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail","Account",new  // ConfirmEmail action acoount da controlları
                    { 
                        userId=user.Id,
                        token=tokenCode
                    });

                    //Mailin gönderilme onaylanma işlemleri vs
                   
                    //mail gönderme işlemi gerçekleştirdik smtpEmailsender içindeki metodu çağırdık
                    await _emailSender.SendEmailAsync(user.Email, "ShoppingApp Hesap Onaylama", $"<h1>Merhaba</h1>"+
                        $"<br>"+
                        $"<p>Lütfen hesabınızı onaylamak için aşğıdaki linke tıklayınız</p>"+
                        $"<a href='https://localhost:5178{url}'></a>");
                    ViewBag.Message = "Kayıt işlemini tamamlamak için mailinize gönderilen onaylama linkine tıklayınız.";


                    return RedirectToAction("Login","Account");
                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu lütfen tekrar deneyiniz");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult>ConfirmEmail(string userId,string token)
        {
            //register post actionundan gelen userId ve token bilgisi boş ise aşşağıdaki mesaj veriliyor
            if (userId==null || token==null)
            {
                ViewBag.Message("Geçersiz oken ya da user bilgisi");
                return View();

            }
            var user = await _userManager.FindByIdAsync(userId); // userId ye göre bilgleri buluyor
            if (user!=null) // boş değilse 
            {
                var result = await _userManager.ConfirmEmailAsync(user, token); // kendisine verilen user ve token bilgilerini kullanarak başarılı başarısz kodunu döndürüyor
                if (result.Succeeded) // başarılı ise aşşağıdaki mesaj
                {
                    ViewBag.Message("hesabınız başarıyla onaylandı");
                    return View();

                }
            }
            ViewBag.Message("bir sorun oluştu ve hesabınız onaylanmadı tekrar deneyiniz");
            return View();
        }


    }
}
