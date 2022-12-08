using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(ShopAppContext context):base(context)
        {

        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext;  }
        }
                
        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            //bir önceki kalsör anlaattım ordan bak
            return await ShopAppContext
                .Products
                .Where(p => p.IsHome && p.IsApproved)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            // tıklanılan categorinin url sini category ile buraya gönderdik ve  ShopAppContext ile products veritabanına yani entity mize bağlantık
            var products= ShopAppContext.Products.AsQueryable(); // AsQueryable bak ne işe yarar
            if (category != null)// gelen veri boş değilse aşşğıdaki işlemleri yap
            {
                products = products 
                    .Where(p => p.IsApproved)//IsApproved true 
                    .Include(p => p.ProductCategories)// ProductCategories ortak tablosu olduğu için tabloyu aldık
                    .ThenInclude(pc => pc.Category)// ve category
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category));
            }
            return await products.ToListAsync();


        }
    }
}
