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

        public Task<Product> GetProductDetailsByUrlAsync(string producturl)
        {
            //dışarıdan gelen producturl değerini alıp  ShopAppContext ile veritabnına bağlanıp  product ların url i dışarıdan gelen url eşimi ona bak
            // poductlarlar produccategories tablosunu birleşir
            return ShopAppContext
                .Products
                .Where(p => p.Url==producturl)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            return await ShopAppContext
                .Products
                .Where(p => p.IsHome && p.IsApproved)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var products= ShopAppContext.Products.AsQueryable();// aşağıdaki ife girmeden önce pause yapıp sonra devam ettiriyor aşağıdakileri kontrol ettiriyor
            if (category != null) // kategori null değilse yani anasayfamızad tüm kategoriler tıklandığı zaman kategori id si yok onun gibi
            {
                products = products //yukarıdaki pause edilen products içinde p.IsApproved true ise
                    .Where(p => p.IsApproved)
                    .Include(p => p.ProductCategories) //  ProductCategories bağladık producta bağladık
                    .ThenInclude(pc => pc.Category)//  sonra ProductCategories bunuda category tablosuna bağladık
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category)); 
            } // ve product içinde  ProductCategories beraber dönüp   category url eşitse dışarıdan gelen category ye gibi birşey
            return await products.ToListAsync();


        }
    }
}
