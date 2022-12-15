using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class RegisterDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }

        [DisplayName("SoyAd")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }

        [DisplayName("kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }

        [DisplayName("E-posta")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]// email adresi şeklinde girilsin diye
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password" ,ErrorMessage ="Parola ile {0} aynı olmalıdır")]
        public string RePassword { get; set; }
    }
}
