using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class UserAddDto
    {
        public UserDto UserDto { get; set; } // UserDto tipinde veri tanımladık yani UserDto içindekiler kullanabiliyoruz
        public List<RoleDto> Roles { get; set; } // RoleDto tipindeki dto muzu list rüründe tutuk roller için

        [DisplayName("Rol")]
        [Required(ErrorMessage ="En az 1 {0} seçilmedilidr")]
        public IList<string> SelectedRoles{ get; set; } // seçili rolü burada tuttuk
    }
}
