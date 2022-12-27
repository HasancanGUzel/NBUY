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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopAppContext context) : base(context)
        {
            //buraya gelen context base classa gönderiliyor ve aynı zamanda sadece bu constructor içinde geçerli. Ama bu classın bütününde henüz kullanılamıyor. Eğer kullanılsın istersek yapmamız gereken işlemler var.
        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }

        public Category GetByIdWithProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetSearchResultAsync(string searchString)
        {
            
            searchString = searchString.ToLower();
            return await ShopAppContext
                .Categories
                .Where(c =>c.Name.ToLower().Contains(searchString) || c.Description.ToLower().Contains(searchString))
                .ToListAsync();
        }
    }
}
