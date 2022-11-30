using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EntityFramework.Contexts;
using BlogApp.Services.Abstract;
using BlogApp.Services.Concrete;
using BlogApp.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region ServiceCollectionburayayazýlýrsa
//buradaki kodlar fazla yer kaplýyordu bizde ServiceCollectionExtensions da bunlarý yazdýk ordan kullanýcaz
//builder.Services.AddDbContext<BlogAppContext>();//---------------------------------------------
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//uygulama istek alýp sona erene kadar IUnitofWork gördüðü yerde UnitOfWork classýna bakýcak yani categorymanager veya articlemanager sayfamýzda biz IUnitOfWork den _unitofwork olarak kullnamýþtýk ama þimdi bu UnitofWork olarak algýlýcak
//builder.Services.AddScoped<IArticleService, ArticleManager>();//bunlarda üstekinin aynýsý
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
#endregion

#region ServiceExtensionÝleÇaðrýlýrsa
builder.Services.LoadMyServices(); //ServiceCollectionExtendisodan metodu çaðýrdýk
#endregion



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();//hata oluþtuðundan hatanýn açýklayýcý þekilde gözükmesini saðlar
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//wwwroot kullanmak için

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name:"Admin",
    areaName:"Admin",
     pattern: "/Admin/{controller=Home}/{action=Index}/{id?}");
   

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
