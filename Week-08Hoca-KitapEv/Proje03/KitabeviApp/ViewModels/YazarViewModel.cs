using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.ViewModels
{
    public class YazarViewModel
    {
         public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen adı boş bırakmayınız")] //Ad alanının required yani zorunlu olmasını sağlıyoruz ama tam anlamıyla böyle olmaz bunu diğer sayflarda kontrol etmemiz lazım
        [StringLength(30,ErrorMessage ="30 karakter uzunluğundan fazla  değer girmeyiniz")]//bu satır ise ad satırının kaç max kaç karakter uzunluğund aolacağını belitri
        [Display(Name ="Yazar Adı Soyadı.",Prompt =" yazar ad soyadını giriniz...")]//bu satır ise yazarekle cs deki ad inputumuzun öündedi name kısmı propmt ise inputun yani textboxun içindeki placholder gibi
        public string Ad { get; set; }
          [Required(ErrorMessage ="Lütfen Dogum YILINI boş bırakmayınız")]
          [Display(Name ="Yazar dogum yılı",Prompt ="2000...")]
        public int? DogumYili { get; set; }
        public char Cinsiyet { get; set; }
    
    }
}