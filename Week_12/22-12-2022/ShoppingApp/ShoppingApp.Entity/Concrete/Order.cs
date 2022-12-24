using ShoppingApp.Entity.Abstract;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Order : IEntityBase // satış bilgileri ttuulacak kime satılmış falan
    {
        public int Id { get  ; set ; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; } // uerbilgisinide tututyur hangi kullanıcı almış diye
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumOrderType OrderType { get; set; }
        public List<OrderItem>  OrderItams { get; set; } // buda satılan ürünün bilgileri tutulacak list tipinde olması 1 den fazla ürün olması durumunda tutabilmek için


    }

    public enum EnumOrderState // kendimiz enum yani tip tanımladık
    {
        Waiting=0,
        Unpaid=1,
        Complete=2
    }

    public enum EnumOrderType
    {
        CreditCard=0,
        Eft=1
    }
}
