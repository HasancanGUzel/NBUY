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

builder.Services.AddDbContext<IdentityContext>(options=>options.UseSqlite("DataSource=ShoppingApp.db")); // IdentityContext options a  UseSqlite("DataSource=ShoppinApp.db" g�nderdik

builder.Services.AddDbContext<ShopAppContext>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();//AddDefaultTokenProviders cookies ve biz mail att���m�z zaman sadece att���m�z ki�inin maile t�klamas� i�in benzersiz de�er olu�turucak

//buraya ge�meden migrations yapabilirsin

builder.Services.Configure<IdentityOptions>(options => // �ifre nin nas�l olmas� gerekti�ini belirlemek i�in 
{
    #region PasswordSettings
    options.Password.RequireDigit = true;// �ifre i�inde mutlaka rakam bulunsun demi� olduk
    options.Password.RequireLowercase = true;//�ifre i�inde mutlaka k���k harf bulunsun
    options.Password.RequireUppercase = true;//�ifre i�inde mutlaka b�y�k harf bulunsun
    options.Password.RequiredLength = 6;//�ifre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric= true;//alfanumerik karakter bulunmas� zorunlu olsun(.,/*) gibi

    #endregion
    #region LoginSetting
    options.Lockout.MaxFailedAccessAttempts = 5;//kullan�c� �ifre girerken �st �ste 5 defa hata yaparsa hesab� kitleyecek
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);// kullan�cn�n hesab�n� hatal� gir� yapt��� i�in kilitlemi�tik ona s�re verdik 5 dakika sonra a��ls�n dedik From yan�na days second minutes falan yapabiliriz

    #endregion
    #region UserSettings
    options.User.RequireUniqueEmail = true;//benzersiz email adresi ile kay�t olunulabilir yani daha �nceden kay�t olunmu� email adresiyle kay�t olunamaz.

    #endregion
    #region SignInSettings
    options.SignIn.RequireConfirmedEmail = false;//true ise email onay� aktiftir 
    options.SignIn.RequireConfirmedPhoneNumber= false;//true ise telefon numaras� onay� aktiftir.
    
    #endregion
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//e�er a��labilmesi i�in login olamn�n zorunlu oldu�u bir istekde bulunulursa kullan�c�n�n y�nlendirilece�i sayfa buras� olacak yani account controllar�ndaki login actionu
    options.LogoutPath= "/account/logout";//kullan�c� ��k�� yapt���nda y�nlendirilecek sayfa
    options.AccessDeniedPath= "/account/accesdenied";//yetkisiz giri�te y�nlendirilecek sayfa
    options.SlidingExpiration = true;// cookienin varsay�lan ya�am s�resi ya da ayarlanan ya�am s�rei 20 dak�kad�r. bu false olsayd� 20 dakika sonra uygulamadan atar ama bunu true yapt�k ve ben uygulamada bir yere t�klarsam  bir aktivite g�sterirsem s�re hep s�f�rdan ba�lar
    options.ExpireTimeSpan= TimeSpan.FromMinutes(5);//ya�am s�resini ayarlar

    options.Cookie = new CookieBuilder // bu sat�r cookiyi olu�turma sat�r�
    {
        HttpOnly=true,// http format�nda �al��ss�n dedik ftp vs ula�amaz
        Name=".ShoppingApp.Security.Cookie",
        SameSite=SameSiteMode.Strict// siteyi sald�r�lardan korumak i�in 
    };
});
// ---------------------------------
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
