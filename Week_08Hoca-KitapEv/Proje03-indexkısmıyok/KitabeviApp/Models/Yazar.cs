using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        // [Required(ErrorMessage ="Lütfen adı boş bırakmayınız")] //Ad alanının required yani zorunlu olmasını sağlıyoruz ama tam anlamıyla böyle olmaz bunu diğer sayflarda kontrol etmemiz lazım
        public string Ad { get; set; }
        // [Required(ErrorMessage ="Lütfen Dogum YILINI boş bırakmayınız")]
        public int? DogumYili { get; set; }// bunun yanına ?yazmadığımız zaman üstteki mesajı yazmıyordu çünkü bu int değerinde 
        public char Cinsiyet { get; set; }
    }
}