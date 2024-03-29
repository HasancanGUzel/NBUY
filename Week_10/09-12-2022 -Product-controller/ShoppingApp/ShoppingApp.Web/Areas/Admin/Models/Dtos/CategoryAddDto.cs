﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş bırkaılmamalıdır")]
        [MinLength(5,ErrorMessage ="{0} , {1} karakterden kısa olmamalıdır")]
        [MaxLength(50, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır")]
        public string Name { get; set; } // admin kategori ekleyeceği zaman sadece bu iki prop lazım o yüzden addDto diye class oluşturudk
        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır")]
        [MinLength(10, ErrorMessage = "{0} , {1} karakterden kısa olmamalıdır")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır")]
        public string Description { get; set; }
    }
}
