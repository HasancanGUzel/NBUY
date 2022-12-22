using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface ICardService
    {
        Task InitializeCard(string userId);//userId ye göre yeni bir card sepet  oluşturuyoruz
        Task AddToCard (string userId, int productId, int quantity);//hangi userin cardına eklenicek userId onun için // card eklemek için hangi user a eklenicek onun id si hangi ürün eklenicek onun id si ve kaç tane  eklenicek onun bilgisi quantity

        Task<Card> GetByIdAsync(int id);
        Task<Card>GetCardByUserId(string userId);// userId ye göre card bilgilerini getiricek
    }
}
