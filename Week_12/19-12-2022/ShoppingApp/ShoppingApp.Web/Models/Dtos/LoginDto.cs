using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class LoginDto
    {
        [DisplayName("Email ")]
        [Required(ErrorMessage ="{0} boş bırakılmamalı.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } // burada user name vardır ama biz giriş ekranında user name yerine  email ile giriş yapsın dedik bi önceki projeyle buna bak karşılaştır

        

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş bırakılmamalı.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
