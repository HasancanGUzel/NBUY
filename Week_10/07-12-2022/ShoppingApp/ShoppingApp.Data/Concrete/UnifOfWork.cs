using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Data.Concrete.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete
{
    public class UnifOfWork : IUnitOfWork // bu unitofwork  biz business katmanında  EfCoreCategoryRepository daki metotlara erişmek için veya EfCoreProductRepository buna erişmek için  nesne tanımlamamız gerekiyordu ama şimdi  UnifOfWork bunun içinde ikiside var ve biz bunu kullanıcaz

    {
        private readonly ShoppAppContext _context; // dışarıdan bir context alıcaz ve bıurada kullanıcaz

        public UnifOfWork(ShoppAppContext context)
        {
            _context = context;
        }

        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreProductRepository _productRepository;

        public ICategoryRepository Categories =>_categoryRepository= _categoryRepository ?? new EfCoreCategoryRepository(_context); // eğer  _categoryRepository varsa aynısını al ama yoksa ?? sonrasında  EfCoreCategoryRepository dan  _context bağalntımızla yenisini üret

        public IProductRepository Products => _productRepository=_productRepository ?? new EfCoreProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
