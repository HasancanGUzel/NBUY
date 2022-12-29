using ShoppingApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApi.Business.Abstract
{
    public interface ICardItemService
    {
        Task ChangeQuantity(int cardItemId, int quantity);
        Task<CardItem> GetByIdAsync(int id);
        void Delete(CardItem cardItem);
        void ClearCard(int cardId);
    }
}
