using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class CardItemManager : ICardItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ChangeQuantity(int cardItemId, int quantity) // buraya cardItem ve qantity verileri geliyor
        {
            var cardItem=await _unitOfWork.CardItems.GetByIdAsync(cardItemId); //aşşağıda tanımladımız getByIdAsync metodunu kullanarak buraya gelen cardItemId ye göre Crad bilgilerini alıyoruz
            await _unitOfWork.CardItems.ChangeQuantity(cardItem, quantity);//yukarıda aldığımız card bilgileri ile dışarıdan gelen quantity bilgisini alıp _unitofWork ile EfCoreCardItemRepositorye yolluyoruz
            await _unitOfWork.SaveAsync();// ve kayıt işlemini yapıyoruz
        }

        public void Delete(CardItem cardItem) // burada CardItem tipinde cardItem yolkluyoruz ve o cardın tüm bilgilerini silmek için cardItem kullanarak tüm bilgilerini siliyoruz
        {
            _unitOfWork.CardItems.Delete(cardItem);
            _unitOfWork.Save();
        }

        public async Task<CardItem> GetByIdAsync(int id) // id ye göre card bilgileri döndürüyoruz
        {
            return await _unitOfWork.CardItems.GetByIdAsync(id);
        }
    }
}
