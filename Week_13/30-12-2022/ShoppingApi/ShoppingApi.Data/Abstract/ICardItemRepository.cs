using ShoppingApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApi.Data.Abstract
{
    public interface ICardItemRepository : IRepository<CardItem>
    {
        Task ChangeQuantity(CardItem cardItem, int quantity);
        void ClearCard(int cardId);
    }
}
