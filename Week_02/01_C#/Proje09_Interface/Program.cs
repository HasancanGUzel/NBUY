namespace Proje09_Interface
{
    /* Interface ler için belirtilmediğinde default erişim belirleyici publictir.
     * interface ler protected, private ya da static olarak işaretlenemezler.
     * Interfaceler içinde çalışabilir kodlar olamaz: yani metodların sadece imzası bulunur. yani sadece metot adı bulunur {}içi boştur.
     * Bir inteface bir ya da daha çok interface den miras alabilir.
     * Bir interface  class tan miras alamaaz.
     * Eğer bir class bir Interface den miras alıyorsa miras aldığı Interface dek tüm metotları İmplemente etmek zorundadır.(Implemente :: Miras alınan Interface de imzası bulunan tüm metotların içi dolu halleri)
     */
    interface IPersonel
    {
        public string Departman { get; set; }
    }
    interface IKisi
    {
        public string AdSoyad { get; set; }
        public string Adres { get; set; }       
        public string Maas { get; set; }

        public void Bilgi();//Interfacler içindeki metotlarda sadece imza bulunur metodun gövdesi olmaz
        //metodun gövdesi bu interfaci miras alan class içinde doldurulur.
    }
    class Yonetici : IKisi, IPersonel
    // interface den miras alınırsa miras alınan interface taki her bilginin buraya aktarılması gerekli
    // bir class birden fazla clastan miras alamazdı fakat birden fazla inteface den miras alabilir.
    //bir sınıf bir class ve bir interface den miras alabilir ama sadece bir classtan,, bununda önceliği miras alınan class miras alınan interface den önce yazılır.
    //ve birden fazla interfaceden miras alınırsa her interfacin tüm özellileri buraya aktarılmalı.
    // interface new yapılamaz.
    {

        /// <summary>
        /// Bu metot herhangi bir yönetici bilgisi girmeden yönetici oluşturur.
        /// </summary>
        public Yonetici()
        {
            //kimi zaman AdSoyad Adres Maas ve Departman ilgisini vermeden de yönetici oluşturmak istediğimiz zaman bu constructur çalışır.
        }
        /// <summary>
        /// Bu metot AdSoyad Adres Maas ve Departman bilgileri girilerek Yönetici oluşturu.
        /// </summary>
        /// <param name="adSoyad">Buraya Ad Soyadı girin</param>
        /// <param name="adres">buraya adresi girin</param>
        /// <param name="maas">buraya maası girin</param>
        /// <param name="departman">buraya departman girin</param>
        public Yonetici(string adSoyad, string adres, string maas, string departman)
        {
            AdSoyad = adSoyad;
            Adres = adres;
            Maas = maas;
            Departman = departman;
        }

        public string AdSoyad { get ; set ; }
        public string Adres { get ; set ; }
        public string Maas { get; set; }
        public string Departman { get; set; }

        public void Bilgi()
        {
            Console.WriteLine($"Ad Soyad.{AdSoyad}Departman {Departman}");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // bir abstract classtan miras alan classta
            // eğer base classta abstarct bir metot varsa mutlaka override edilmeli
            // eğer base calssta abstrcat olmayan metotlr varsa  onlar aynen kullanılabilir.
            //ancak bazen miras alınan classtaki her metodun içinin dolu hallerini yazmak zorunlu olsun isteriz.
            //ani bir nevi hepsi abstract olsun bunu yapmak yerine miras alınan classı class değil interface şeklinde tanımlarız.

            //IPersonel personel = new IPersonel();// hatalı kullanım nesne üretilemez.
            //Yonetici yonetici = new Yonetici();
            //Yonetici yonetici2 = new Yonetici("hAGİ","RİO DE JENARİO","500","FUTBOL");
            //Console.WriteLine("");

            Product product1 = new Product()
            {
                Id = 1,
                Name = "Iphone 13",
                Price = 5900,
                Properties = "8gb ram",
                Ratio=0.5m,
                CreatedDate=DateTime.Now


            };
            Console.WriteLine($"Product Name={product1.Name}(Büyük harf={product1.NameToUpper(product1.Name)})properties= {product1.Properties}");


            Category category1 = new Category()
            {
                Id = 1,
                Name = "telefon",
                CreatedDate = DateTime.Now,
                Description = "bu kategori telefonlar için"
            };
            Console.WriteLine($"Category Name={category1.Name}(Büyük harf={category1.NameToUpper(category1.Name)}) descrption= {category1.Description}");

            Console.ReadKey();
            
            

        }
    }
}
