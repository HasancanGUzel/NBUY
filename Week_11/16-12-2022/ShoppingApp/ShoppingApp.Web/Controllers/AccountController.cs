using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                    return View(loginDto);
                }
                //Bu noktada email onayı yapılıp yapılmadığını kontrol edeceğiz.
                //Eğer email onaylı ise login yaptıracağız, değil ise hatırlatacağız.
                if (!await _userManager.IsEmailConfirmedAsync(user))// email alanı onaylımı  değilmi bakıyor oanylı değilse buraya giriyor
                {
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız onaylanmamış lütfen mailinize gelen onay linkne tıklayınız", "warning");
                    return View(loginDto);


                    //ödev eğer hesap onaylı değilse burada kullanıcıya onay linki gönder şeklinde buton çıksın ve mesaj göndersin
                }



                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(loginDto.ReturnUrl ?? "~/");
                }
                ModelState.AddModelError("", "Email adresi ya da parola hatalı!");
            }
            return View(loginDto);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]//İlgili cookienin sadece ait olduğu tarayıcı tarafından gönderilmesi halinde geçerli olmasını sağlar.
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    //Generate token(mail onayı için)
                    var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = tokenCode
                    });

                    //Mailin gönderilme, onaylanma vs
                    await _emailSender.SendEmailAsync(user.Email, "ShoppingApp Hesap Onaylama", $"<h1>Merhaba</h1>" +
                        $"<br>" +
                        $"<p>Lütfen hesabınızı onaylamak için aşağıdaki linke tıklayınız.</p>" +
                        $"<a href='https://localhost:7215{url}'>Onay linki</a>");
                    // buradan temdata yla layout içine göndericez ve burada jobs daki create message kullanıcaz
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Lütfen mail adresinizi kontrol ediniz gelen linki tıklayrak hesabınızı onalyalyın", "warning");
                    return RedirectToAction("Login", "Account");
                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(registerDto);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "geçersiz token yada mail adresi ", "danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Onay mesajı", "hesabınız başarıyla onaylandı", "success");
                    return View();
                }
            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "hesabınız onaylarken bir sorun oluştu ", "danger");
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = Jobs.CreateMessage("hata", "Lütfen mail adresinizi eksiksiz giriniz", "danger");
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {//bıoş ise
                TempData["Message"] = Jobs.CreateMessage("hata", "böyle kaytlı bir madil adresi bulunamadı yeniden deneyiniz ", "danger");
                return View();
            }
            var tokenCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = tokenCode
            });
            await _emailSender.SendEmailAsync(
                email,
                "ShoppingApp şifre sıfırlama linki",
                $"Lütfen parolanızı yenilemek için <a href='https://localhost:7215{url}'>tıklayınız</a>  "
                );
            TempData["Message"] = Jobs.CreateMessage("Bilgi", "şifre sıfırlama linkiz mail adresine gönderilmiştir lütfen mail adresini kontrol ediniz","info");
            return RedirectToAction("Index","Account");
        }

        public IActionResult ResetPassword (string userId,string token)
        {
            if (userId==null ||token==null)
            {
                TempData["Message"] = Jobs.CreateMessage("hata", "bir sorun oluştu lütfen daha sonra tekrar deneyiniz", "danger");
                return RedirectToAction("Index", "Home");
            }
            var restPasswordDto = new ResetPasswordDto
            {
                Token = token
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if(!ModelState.IsValid) // modalstate false ise yaptık
            {
                return View(resetPasswordDto);
            }
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("hata", "böyle bir kullanıcı bulunamadı", "danger");
                return View(resetPasswordDto);
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token,resetPasswordDto.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("başarılı", "parolanız başarıyla değiştirilmiştir giriş yapmayı deneyebilirisniz", "info");
                return RedirectToAction("Login", "Account");
            }
            TempData["Message"] = Jobs.CreateMessage("hata", "bir sorun oluştu lütfen daha sonra tekrar deneyiniz", "danger");
            return RedirectToAction("~/");
        }


    }
}
