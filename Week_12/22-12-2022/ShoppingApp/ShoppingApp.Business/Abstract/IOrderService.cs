using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface IOrderService
    {
        Task CreateAsync(Order Order);
        Task<List<Order>> GetOrders(string userId);//hangi userId yi göderirsek onun satışlarını listelicek
    }
}
