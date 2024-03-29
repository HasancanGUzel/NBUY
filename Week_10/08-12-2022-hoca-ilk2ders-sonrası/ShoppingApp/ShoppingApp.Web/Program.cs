using ShoppingApp.Business.Abstract;
using ShoppingApp.Business.Concrete;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete;
using ShoppingApp.Data.Concrete.EfCore.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShopAppContext>();
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "productdetails",
    pattern: "/{url?}", // link yap�sn� ismini category yapt�k bunu kitabeviappde ayn�s�n� yapm��t�ka am onda id kullanm��t�k 
    defaults: new { controller = "Shop", action = "ProductDetails" } // burada controller ismi ve hangi metot oldu�unu belirledik 

    );

app.MapControllerRoute(
    name: "products",
    pattern: "/{category?}", // link yap�sn� ismini category yapt�k bunu kitabeviappde ayn�s�n� yapm��t�ka am onda id kullanm��t�k 
    defaults: new { controller = "Shop", action = "ProductList" }

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //www.enginniyazi.com/home/index
app.Run();
