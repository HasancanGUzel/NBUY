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
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ShopAppContext context):base(context)
        {
                
        }
        private ShopAppContext ShopAppContext 
        {
            get { return _context as ShopAppContext; }
        }
        public async Task<List<Order>> GetOrders(string userId)
        {
            #region userId contolü yapılmadan
            //var orders = ShopAppContext.Order
            //   .Where(o => o.UserId == userId)
            //   .Include(o => o.OrderItams)
            //   .ThenInclude(od => od.Product)
            //   .ToList();
            //return orders;
            #endregion

            #region  userIdNullKonrolü yaparak
            var orders = ShopAppContext.Order // buraya gelen kullanıcı id si ile Order tablosuna bağlanıcaz ve burada Order entitmi içindeki OrderItams ile dönücez ve aynı id olanları bulucak
                .Include(o => o.OrderItams)
                .ThenInclude(oi => oi.Product)// sonra yukarıda bulduğumuz id ile OrderItems entitmizdeki  Porduct lara bulucaz
                .AsQueryable(); // burada bekleticez
            if (String.IsNullOrEmpty(userId)) // userId mize bakıcaz boş mu "" falanmı diye
            {
               orders= orders.Where(o => o.UserId == userId);// boşsa orders nesneimze orders adışarıdan gele userId yi atıcaz
            }
            return orders.ToList();
            #endregion

        }
    }
}
