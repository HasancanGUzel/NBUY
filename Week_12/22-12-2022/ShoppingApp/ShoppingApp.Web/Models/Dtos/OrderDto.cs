using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class OrderDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage =("{0} alanı boş bırakılmamalıdır"))]
        public string FirstName { get; set; }

        [DisplayName("SoyAd")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string LastaName { get; set; }

        [DisplayName("Adress")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string Adress { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string City { get; set; }
        [DisplayName("Telefon")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Kartın üzerindeki ad soyad")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        
        public string CardName { get; set; }
        [DisplayName("Kartın numarası")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik tarihi ay")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string ExpirationMonth { get; set; } // geçerlilik   ay bilgisi için
        [DisplayName("Geçerlilik tarihi yıl")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string ExpirationYear { get; set; }// geçerlilik   yıl bilgisi için
        [DisplayName("Kartın arka yüzündeki 3haneli güvenlik numarası")]
        [Required(ErrorMessage = ("{0} alanı boş bırakılmamalıdır"))]
        public string Cvc { get; set; }
        public CardDto CardDto { get; set; }

    }
}
