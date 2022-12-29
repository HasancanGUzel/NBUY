using ShoppingApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApi.Data.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        Task AddToCard(string userId, int productId, int quatity);
        Task<Card> GetCardByUserId(string userId);
    }
}
