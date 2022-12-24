using ShoppingApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class OrderItem : IEntityBase// satışın bilgilerini tutucak yani satın alan kişi eski siparişlerine bakıncaorderItem sayesinde aldığı ürünleri görbeilecek o yüzden Product türünde Product tutyoruz
    {
        public int Id { get ; set ; }
        public int OrderId { get; set; }
        public Order Order { get; set; } //order bilgilerinide tutucaz
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal? Price { get; set; } // price ise ürün alan kiinin aldığı ürün fiyatı güncellense dahi aldığı eski fiyatı grebilmesii için
        public int Quantity { get; set; }
    }
}
