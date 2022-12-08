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
            // bunu IsHome true olanları  anasayfamızad gözüksün diye
            return await ShopAppContext // bunu veritabanından products tablosunun içinde dönüp  IsHome ve IsApproved true olanları bulu listeliyor ve geri döndürüyor
                .Products
                .Where(p => p.IsHome && p.IsApproved)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category) 
        {
           var products=ShopAppContext.Products.AsQueryable();
            if (category !=null)
            {
                products = products
                    .Where(p => p.IsApproved)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category));
            }
            return await products.ToListAsync();
                
        }
    }
}
