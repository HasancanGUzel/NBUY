using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Concrete.EfCore.Contexts;

namespace ShoppingApp.Web.Extensions
{
    public static class MigrationManager
    {
        //bu kalsörü biz sürekli database update yapmak yerine eğer yeni bir migrations varsa onu program çalışmaya başlayınca update etsin
        public static IHost UpdateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var shopAppContext = scope.ServiceProvider.GetRequiredService<ShopAppContext>())
                {
                    try
                    {
                        shopAppContext.Database.Migrate();// bu komut henuz işlenmemiş migrationları alır ve database işlemine tabii tutar
                    }
                    catch (Exception)
                    {
                        //hataların tutulduğu loglar burada hazırlanabilir
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
