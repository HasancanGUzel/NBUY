using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface ICardRepository:IRepository<Card>
    {
        Task AddToCard (string userId, int productId, int quantity);// card eklemek için hangi user a eklenicek onun id si hangi ürün eklenicek onun id si ve kaç tane  eklenicek onun bilgisi quantity
        Task<Card> GetCardByUserId(string userId);
    }
}
