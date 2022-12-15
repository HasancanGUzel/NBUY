using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class LoginDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage ="{0} boş bırakılmamalı")]
        public string UserName { get; set; }

        [DisplayName("Parola ")]
        [Required(ErrorMessage = "{0} boş bırakılmamalı")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } // bunu yapmamızdaki amaç giriş yapmadan admin panele tıklayınca giriş yapsa sayfasına yolluyor ama girince admin panele girmiyor ve ansayfaya giriyor bizde admin panale tıklayıp giriş yapa girince yukarıdaki url bilgisini alıcaz
    }
}
