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

        public async Task CreateProductAsync(Product product, int[] selectedCategoryIds)
        {
            //önce product kaydı yapacağız böylece elimize product id olacak sonrada bu product id yi kullanarak productCategory kayıdını/kayıtlarını yapacağız
            // imzaya göre metodu yazdık ve bu metodun işlemlerini açıkladık
            await ShopAppContext.Products.AddAsync(product);  // buraya gelen product nesnesini veritabanına kaydettik
            await ShopAppContext.SaveChangesAsync();
            product.ProductCategories = selectedCategoryIds // buraya gelen product nesnesinden Product entitysinde bulunan  ProductCategories e bağlandık ve bunun içine buraya gelen categorilerinin id sinin içine döndük ve  ProductCategory tablosuna karşılık gelen verileri mapper işlemi yaptık
                .Select(catId => new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = catId,
                }).ToList();
            await ShopAppContext.SaveChangesAsync();


        }

        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            return await ShopAppContext
                .Products
                .Where(p => p.IsHome && p.IsApproved)
                .ToListAsync();
        }

        public Task<Product> GetProductDetailsByUrlAsync(string productUrl)
        {
            return ShopAppContext
                .Products
                .Where(p => p.Url == productUrl)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var products= ShopAppContext.Products.AsQueryable();
            if (category != null)
            {
                products = products
                    .Where(p => p.IsApproved)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category));
            }
            return await products.ToListAsync();


        }

        public async Task<List<Product>> GetProductsWithCategories()
        {
            return await ShopAppContext
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductWithCategories(int id)
        {
            return await ShopAppContext
                .Products
                .Where(p=>p.Id==id)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateProductAsync(Product product, int[] selectedCategoryIds)
        {
            //şeçili olan kategorileri kayıt etmek için ve product bilgilerinide
            Product newProduct =await ShopAppContext // product tipinde nesne tanımladık ve veritabanına bağlanıp 
                .Products // products tablosuyla product categories tablosu arasında eşleşen bilgiyi bulduk
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(p => p.Id == product.Id); // bulunan ortak bilgiyi ile dışarıdan gelen product nesnesinin id si eşit mi diye baktık

            newProduct.ProductCategories = selectedCategoryIds // elimizde olan newProduct nesnesiyle  ProductCategories içine selectedCategoryIds dışaırdan gelen bu nesneyle   
                .Select(catId => new ProductCategory // catId değişkeni tanımladık ve bir döngü içinde  ProductCategory nesnsi tanımlayarak
                {
                    ProductId = newProduct.Id, //ProductCategory içindeki   ProductId ye newProduct.Id içindeki veriyi
                    CategoryId = catId //ProductCategory içindeki  CategoryId ye catId değerini atıp listeledik
                }).ToList();
             ShopAppContext.Update(newProduct); // ve güncelledik
            await ShopAppContext.SaveChangesAsync();
            
        }
    }
}
