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
    public class EfCoreCardRepository:EfCoreGenericRepository<Card> ,ICardRepository
    {
        public EfCoreCardRepository(ShopAppContext context):base(context)
        {

        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }

        public async Task AddToCard (string userId, int productId, int quantity)
        {
           var card =await GetCardByUserId(userId);//  userId ye göre card bilgilerini getirdi
            if (card!=null)// card boş değilse aşşağıadkileri yapıcak
            {
                var index = card.CardItems.FindIndex(ci => ci.ProductId == productId);//card entitmizin içindei CardItems içinde bul neyi Product ilgilerini tutuyoruz b yüzdn ProductId si dışarıdan gelen productId ye eşitmi bak
                if (index<0)//eğer ürün daha önceden sepete eklenmemişseyani ProductId dışarıdan gelen productId ye eşit değilse
                {
                    card.CardItems.Add(new CardItem // card entitmiz içindeki cardItems propuna ekle ne ekle CardItem entitymizdeki proplara karşılık gelen dışşarıdan gelen verileri
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CardId = card.Id
                    });
                }
                else// eğer ürün daha önceden spete eklenmişsse
                {
                    card.CardItems[index].Quantity += quantity; //ard entitmiz deki cardItems propuna yukarıda tanımı olan ProductId dışaıdan gelen ProductId ye eşitsedeki indexin yani daha önceden sepette ekli olan ürünün fiyatını al ve dışarıan gelen fiyatın üzerie ekle
                }
               
                ShopAppContext.Cards.Update(card);// güncelleme yap
            }
        }

        public async Task<Card> GetCardByUserId(string userId)
        {
            var card = ShopAppContext //ShopAppContext den Cards eriş ve CardItems tablosuan bak aynı olanalrı al sonra ordan Product lara eriş ve burdaki verilerle UserId dışarıdan gelen userId eşitmi
                .Cards
                .Include(c => c.CardItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == userId);
            return card;
        }
    }
}
