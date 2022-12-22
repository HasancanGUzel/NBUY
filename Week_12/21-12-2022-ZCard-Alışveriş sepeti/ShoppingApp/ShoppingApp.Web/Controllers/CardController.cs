using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICardService _cardManager;

        public CardController(UserManager<User> userManager, ICardService cardManager)
        {
            _userManager = userManager;
            _cardManager = cardManager;
        }

        public async Task<IActionResult>Index()
        {
            var userId = _userManager.GetUserId(User);// o sırada login olan User bilgisinden userId yi bulucak 
            var card = await _cardManager.GetCardByUserId(userId);//userId ye görede card bilgilerini getiricek
            CardDto cardDto = new CardDto // gelen bu card bilgileri içindeki veileri
            {
                CardId = card.Id,//cardId yi CarIdpropumuza
                CardItems = card.CardItems.Select(ci => new CardItemDto //CarDto içindeki CradItems içinde dön  ve her döüşündeki bilgleri CardItemDto daki proplara aktar eğer sepette hiçbirşeyyoksa CradItems içinde boşa dönücek yani sepetin içini boş gönderice ve bnu index de kontrol ettiricez
                {
                    CardItemId = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ItemPrice = ci.Product.Price,
                    ImageUrl = ci.Product.ImageUrl,
                    Quantity = ci.Quantity
                }).ToList()
            };
            return View(cardDto);                                    
        }

        [HttpPost]
        public IActionResult AddToCard(int productId,int quantity)
        {
            var userId = _userManager.GetUserId(User);// o sırada login olan User bilgisinden userId yi bulucak
            _cardManager.AddToCard(userId, productId, quantity);
            return RedirectToAction("Index","Card");
        }
    }
}
