using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EntityFramework.Contexts;
using BlogApp.Services.Abstract;
using BlogApp.Services.Concrete;
using BlogApp.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region ServiceCollectionburayayaz�l�rsa
//buradaki kodlar fazla yer kapl�yordu bizde ServiceCollectionExtensions da bunlar� yazd�k ordan kullan�caz
//builder.Services.AddDbContext<BlogAppContext>();//---------------------------------------------
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//uygulama istek al�p sona erene kadar IUnitofWork g�rd��� yerde UnitOfWork class�na bak�cak yani categorymanager veya articlemanager sayfam�zda biz IUnitOfWork den _unitofwork olarak kullnam��t�k ama �imdi bu UnitofWork olarak alg�l�cak
//builder.Services.AddScoped<IArticleService, ArticleManager>();//bunlarda �stekinin ayn�s�
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
#endregion

#region ServiceExtension�le�a�r�l�rsa
builder.Services.LoadMyServices(); //ServiceCollectionExtendisodan metodu �a��rd�k
#endregion



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();//hata olu�tu�undan hatan�n a��klay�c� �ekilde g�z�kmesini sa�lar
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//wwwroot kullanmak i�in

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
