namespace Proje09_Interface
{
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
    internal class Program
    {
        static void Main(string[] args)
        {
            // bir abstract classtan miras alan classta
            // eğer base classta abstarct bir metot varsa mutlaka override edilmeli
            // eğer base calssta abstrcat olmayan metotlr varsa  onlar aynen kullanılabilir.
            //ancak bazen miras alınan classtaki her metodun içinin dolu hallerini yazmak zorunlu olsun isteriz.
            //ani bir nevi hepsi abstract olsun bunu yapmak yerine miras alınan classı class değil interface şeklinde tanımlarız.

            //IPersonel personel = new IPersonel();// hatalı kullanım nesne üretilemez.
            Yonetici yonetici = new Yonetici();
            Yonetici yonetici2 = new Yonetici("hAGİ","RİO DE JENARİO","500","FUTBOL");
            Console.WriteLine("");
            

        }
    }
}
