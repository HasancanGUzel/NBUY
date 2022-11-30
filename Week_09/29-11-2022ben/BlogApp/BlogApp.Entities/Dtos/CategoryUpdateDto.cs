using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }



        [DisplayName("Kategori İsmi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(70, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(5, ErrorMessage = "{0} alanın uzunluğu {1} karakterden az olmamalıdır")]
        public string Name { get; set; }


        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(50, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        public string Description { get; set; }



        [DisplayName("Kategori notu")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(500, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(3, ErrorMessage = "{0} alanın uzunluğu {1} karakterden az olmamalıdır")]
        public string Note { get; set; }



        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        public bool IsActive { get; set; }


        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        public bool IsDeleted { get; set; }
    }
}
