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
        public EfCoreCategoryRepository(ShoppAppContext context) : base(context) // dışarıdan gelen ShoppAppContext tipinde context mizi miras aldığımız   EfCoreGenericRepository a  base(context) ile gönderiyoruz.
        {
            //buraya gelen context base classa gönderiyliyor ve aynı zamanda sadece bu constructo içinde geçerli ama bu class bütününde henüz kullanılamıyor eğer kullanılsın istersek yapmamız gereken işlemler var.

        }
        public Category GetByIdProducts()
        {
            throw new NotImplementedException();
        }
    }
}
