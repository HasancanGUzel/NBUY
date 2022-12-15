using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Business.Concrete;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.EmailServices.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(options=>options.UseSqlite("DataSource=ShoppingApp.db")); // IdentityContext options a  UseSqlite("DataSource=ShoppinApp.db" gönderdik

builder.Services.AddDbContext<ShopAppContext>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();//AddDefaultTokenProviders cookies ve biz mail attýðýmýz zaman sadece attýðýmýz kiþinin maile týklamasý için benzersiz deðer oluþturucak

//buraya geçmeden migrations yapabilirsin

builder.Services.Configure<IdentityOptions>(options => // þifre nin nasýl olmasý gerektiðini belirlemek için 
{
    #region PasswordSettings
    options.Password.RequireDigit = true;// þifre içinde mutlaka rakam bulunsun demiþ olduk
    options.Password.RequireLowercase = true;//þifre içinde mutlaka küçük harf bulunsun
    options.Password.RequireUppercase = true;//þifre içinde mutlaka büyük harf bulunsun
    options.Password.RequiredLength = 6;//þifre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric= true;//alfanumerik karakter bulunmasý zorunlu olsun(.,/*) gibi

    #endregion
    #region LoginSetting
    options.Lockout.MaxFailedAccessAttempts = 5;//kullanýcý þifre girerken üst üste 5 defa hata yaparsa hesabý kitleyecek
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);// kullanýcnýn hesabýný hatalý girþ yaptýðý için kilitlemiþtik ona süre verdik 5 dakika sonra açýlsýn dedik From yanýna days second minutes falan yapabiliriz

    #endregion
    #region UserSettings
    options.User.RequireUniqueEmail = true;//benzersiz email adresi ile kayýt olunulabilir yani daha önceden kayýt olunmuþ email adresiyle kayýt olunamaz.

    #endregion
    #region SignInSettings
    options.SignIn.RequireConfirmedEmail = false;//true ise email onayý aktiftir 
    options.SignIn.RequireConfirmedPhoneNumber= false;//true ise telefon numarasý onayý aktiftir.
    
    #endregion
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//eðer açýlabilmesi için login olamnýn zorunlu olduðu bir istekde bulunulursa kullanýcýnýn yönlendirileceði sayfa burasý olacak yani account controllarýndaki login actionu
    options.LogoutPath= "/account/logout";//kullanýcý çýkýþ yaptýðýnda yönlendirilecek sayfa
    options.AccessDeniedPath= "/account/accesdenied";//yetkisiz giriþte yönlendirilecek sayfa
    options.SlidingExpiration = true;// cookienin varsayýlan yaþam süresi ya da ayarlanan yaþam sürei 20 dakýkadýr. bu false olsaydý 20 dakika sonra uygulamadan atar ama bunu true yaptýk ve ben uygulamada bir yere týklarsam  bir aktivite gösterirsem süre hep sýfýrdan baþlar
    options.ExpireTimeSpan= TimeSpan.FromMinutes(5);//yaþam süresini ayarlar

    options.Cookie = new CookieBuilder // bu satýr cookiyi oluþturma satýrý
    {
        HttpOnly=true,// http formatýnda çalýþssýn dedik ftp vs ulaþamaz
        Name=".ShoppingApp.Security.Cookie",
        SameSite=SameSiteMode.Strict// siteyi saldýrýlardan korumak için 
    };
});
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x=>new SmtpEmailSender
    (
        "smtp.office365.com",587,true,"wissen_core@hotmail.com","Wissen123."

    ));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "products",
    pattern: "kategori/{categoryurl?}",
    defaults: new { controller = "Shop", action = "ProductList" }
    );

app.MapControllerRoute(
    name:"productdetails",
    pattern:"urunler/{producturl}",
    defaults: new {controller="Shop", action="ProductDetails"}
    );


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"); ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
