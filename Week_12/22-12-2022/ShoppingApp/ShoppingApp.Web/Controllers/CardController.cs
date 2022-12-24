using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICardService _cardManager;
        private readonly ICardItemService _cardItemManager;
        private readonly IOrderService _orderManager;

        public CardController(UserManager<User> userManager, ICardService cardManager, ICardItemService cardItemManager, IOrderService orderManager)
        {
            _userManager = userManager;
            _cardManager = cardManager;
            _cardItemManager = cardItemManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var card = await _cardManager.GetCardByUserId(userId);
            CardDto cardDto = new CardDto
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(ci => new CardItemDto
                {
                    CardItemId = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ItemPrice = ci.Product.Price,
                    ImageUrl = ci.Product.ImageUrl,
                    Quantity = ci.Quantity,
                    Url=ci.Product.Url // urli buradan aldık
                }).ToList()
            };
            return View(cardDto);
        }

        [HttpPost]
        public IActionResult AddToCard(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cardManager.AddToCard(userId, productId, quantity);
            return RedirectToAction("Index","Card");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int cardItemId,int quantity)// form submit olduğu zaman  buraya cardItemId ve qunatit bilgisi gelicek
        {
            await _cardItemManager.ChangeQuantity(cardItemId, quantity);  // businesde ki changequantity e bu verileri gönderiyoruz
            return RedirectToAction("Index", "Card");
        }
        
        public async Task<IActionResult> DeleteFromCard(int id) // bu metodun asnekron olmasının nenedeni getByIdAsync kullandığımız için yoksa delete metodu asnekron değil
        {
            var card =  await _cardItemManager.GetByIdAsync(id);
            if (card == null) 
            { 
                return NotFound(); 
            }
             _cardItemManager.Delete(card);
            return RedirectToAction("Index", "Card");
        }
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User); // o anki kullanıcı bilgisinden Id y bulduk
            var user = await _userManager.FindByIdAsync(userId);// user bilgilerini getirdik
            var card = await _cardManager.GetCardByUserId(userId);// kullancıı id sine göre card bilgilerini getiridk

            OrderDto orderDto = new OrderDto//OrderDto tipinde nesne tanımladık ve bunun içine öncelikle
            {
                FirstName=user.FirstName, // kullanıcı bilgilerini yerleştirdik
                LastaName=user.LastName,
                Adress=user.Adress,
                City=user.City,
                Phone=user.PhoneNumber,
                Email=user.Email,


                CardDto = new CardDto // sonra CardDto dan nesne ürettik yani sepet den
                {
                    CardId = card.Id, //yukarıda card bilgisini geirmiştik id yi burada aktardık
                    CardItems = card.CardItems.Select(ci => new CardItemDto // sonra  CardDto içinde bulunan CardItems a yukarıdaki card içindeki cardItems içinde döngü ile dönreke her ir cardItems için CardItemsDto tipinde nesne üretip ordaki bilgilere karşılık gelen verileri aktardık
                    {
                        CardItemId = ci.Id,
                        ProductId = ci.ProductId,
                        ProductName = ci.Product.Name,
                        ItemPrice = ci.Product.Price,
                        ImageUrl = ci.Product.ImageUrl,
                        Url = ci.Product.Url,
                        Quantity = ci.Quantity
                    }).ToList()
                }
            };
            return View(orderDto); // en son ise Checkoutsayfasına bu bilgileri gönderdik

        }
        [HttpPost]
        public async Task<IActionResult>Checkout(OrderDto orderDto) // ödeme ap butonuna tıklandığı zaman kullanıcının inputlara girdiği bilgiler buraya gelicek
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User); // o bililele User ile sisteme girmiş olan kullanıcı ıd sini bulucaz
                var card = await _cardManager.GetCardByUserId(userId); // userId ile sepet bilgisini getiricez
                orderDto.CardDto = new CardDto
                {
                    CardId = card.Id,
                    CardItems = card.CardItems.Select(ci => new CardItemDto
                    {
                        CardItemId = ci.Id,
                        ProductId=ci.ProductId, 
                        ProductName = ci.Product.Name,
                        ItemPrice = ci.Product.Price,
                        ImageUrl= ci.Product.ImageUrl,
                        Url= ci.Product.Url,
                        Quantity= ci.Quantity 

                    }).ToList()
                };
                //Ödeme işmelerine ile ilgili kodları buraya yazacağız

                //Yapılan satışı kaydetme işlemleri (save order)
                SaveOrder(orderDto, userId);
            }
            return View("Index","Home");
        }

        private async void SaveOrder(OrderDto orderDto,string userId) //üstteki post metou çalışınca saveOrder metodu çalışıcak
        {
            Order order = new Order();//tanımladığımı order nesnesie aşşaığıdaki bilgileri atıcaz
            order.OrderNumber ="SA-"+ new Random().Next(111111111, 999999999).ToString();
            order.OrderState = EnumOrderState.Unpaid;//bunu geçiçi olarak yapıyoruz aslında buraya ödeme tamamlanmış olarak geleceğiz buranın Unpaid değilde completed olmasını sağlayacağız
            order.OrderType = EnumOrderType.CreditCard;
            order.OrderDate=new DateTime();
            order.FirstName=orderDto.FirstName;
            order.LastName = orderDto.LastaName;
            order.Email= orderDto.Email;
            order.Phone= orderDto.Phone;
            order.City= orderDto.City;
            order.Adress= orderDto.Adress;
            order.UserId=userId;
            order.OrderItams = new List<OrderItem>();
            foreach (var item in orderDto.CardDto.CardItems)
            {
                var orderItem = new OrderItem();
                orderItem.Price = item.ItemPrice;
                orderItem.Quantity = item.Quantity;
                orderItem.ProductId= item.ProductId;
                order.OrderItams.Add(orderItem);

            }
            await _orderManager.CreateAsync(order);


        }
    }
}
