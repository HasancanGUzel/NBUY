using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Dto== Data Transfer Object veri taşaımak için kullanıcaz
namespace BlogApp.Entities.Dtos
{
    //Article entitimiz ve entitibase  classlarımızdan hangilerini kullanıcaksak onları burada tutuyoruz
    public class ArticleAddDto
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage ="{0} alanı boş geçilmemeldir")] //{0} alanı [DisplayName("Başlık")] bunun içinde ne yazarsak onu yazar
        [MaxLength(100, ErrorMessage="{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(5, ErrorMessage="{0} alanın uzunluğu {1} karakterden az olmamalıdır")]
        public string Title { get; set; }




        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")] //{0} alanı [DisplayName("İçerik")] bunun içinde ne yazarsak onu yazar
        [MinLength(5, ErrorMessage = "{0} alanın uzunluğu {1} karakterden az olmamalıdır")]
        public string Content { get; set; }






        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(250, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(5, ErrorMessage = "{0} alanın uzunluğu {1} karakterden az olmamalıdır")]
        public string Thumbnail { get; set; }


        


        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }




        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(50, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        public string SeoAuthor { get; set; }




        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(150, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        public string SeoDescription { get; set; }



        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        [MaxLength(70, ErrorMessage = "{0} alanın uzunluğu {1} karakteri geçmemelidir")]
        public string  SeoTags { get; set; }




        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }




        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemeldir")]
        public bool IsActive { get; set; }
    }
}
