using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface ICardItemService
    {
        Task ChangeQuantity(int cardItemId,int quantity); // bu metot sepetteki adet bilgisi değiştit zaman çalışıtrıcaz
        Task<CardItem> GetByIdAsync(int id); // id  ye card tın tüm bilgileri geliyor 
        void Delete(CardItem cardItem);

    }
}
