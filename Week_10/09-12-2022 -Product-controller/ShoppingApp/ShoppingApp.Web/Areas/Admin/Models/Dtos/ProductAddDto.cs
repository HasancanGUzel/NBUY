using ShoppingApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class ProductAddDto
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage ="{0} boş bırakılmamlaıdır")]
        [MinLength(5,ErrorMessage ="{0},{1} karakter uzunluğunda olmalı")]
        [MaxLength(50,ErrorMessage ="{0},{1} karakter uzunluğunda olmalı")]
        public string Name { get; set; }

        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "{0} boş bırakılmamlaıdır")]
        public decimal? Price { get; set; }



        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage = "{0} boş bırakılmamlaıdır")]
        [MinLength(5, ErrorMessage = "{0},{1} karakter uzunluğunda olmalı")]
        [MaxLength(500, ErrorMessage = "{0},{1} karakter uzunluğunda olmalı")]
        public string Description { get; set; }


        [DisplayName("Ürün Resmi")]
        [Required(ErrorMessage = "{0} boş bırakılmamlaıdır")]
        public IFormFile ImageFile { get; set; } // kullanıcıdan resim isteyeceğimiz zaman seçip yükleyeceği için dosya  yüklemek için


        [DisplayName("Ana sayfa ürünümü")]

        public bool IsHome { get; set; }

        [DisplayName("Onaylı ürün mü")]

        public bool IsApproved { get; set; }

        [DisplayName("Kategoriler")]

        public List<Category> Categories{ get; set; }// kategorilerin listesi

        [Required(ErrorMessage = "EN AZ BİR KATEGORİ SEÇMELİSİNİZ   ")]


        public List<Category>SelectedCategories { get; set; }//seçili ürün hangi kategoriye olacak
    }
}
