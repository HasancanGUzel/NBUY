using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Business.Abstract;
using ShoppingApi.Business.Concrete;
using ShoppingApi.Data.Abstract;
using ShoppingApi.Data.Concrete.EfCore.Contexts;
using ShoppingApi.Data.Concrete;
using ShoppingApi.Entity.Concrete.Identity;
using ShoppingApi.API.EmailServices.Abstract;
using ShoppingApi.API.EmailServices.Concrete;
using ShoppingApi.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ShopAppContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    #region PasswordSettings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;//
    options.Password.RequiredLength = 6; 
    options.Password.RequireNonAlphanumeric = true; 
    #endregion
    #region LoginSettings
    options.Lockout.MaxFailedAccessAttempts = 3; 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15);
    #endregion
    #region UserSettings
    options.User.RequireUniqueEmail = true;
    #endregion
    #region SignInSettings
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    #endregion
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".ShoppingApp.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICardService, CardManager>();
builder.Services.AddScoped<ICardItemService, CardItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"]
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.UpdateDatabase().Run();
