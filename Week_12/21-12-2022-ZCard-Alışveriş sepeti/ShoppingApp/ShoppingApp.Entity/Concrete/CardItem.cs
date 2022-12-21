using ShoppingApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class CardItem:IEntityBase // her bir cardın içinde birden fazla olabilir
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } // product bilgileri için
        public int CardId { get; set; }// bi cardda birden fazla carditem olabaiir o yüzden card bilgileri
        public Card Card { get; set; }
        public int Quantity { get; set; }// adet bilgisi
    }
}
