namespace Proje14_Value_Reference_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 45;
            int b = a * 2;
            Random rnd = new Random();

            Kisi kisi1 = new Kisi();
            kisi1.Ad = "hasan";
            kisi1.Yas = 47;
            kisi1.Meslek = "software";

            Kisi kisi2 = new Kisi();
            kisi2.Ad = "saliha";
            kisi2.Yas = 40;
            kisi2.Meslek = "eğitmen";

            Kisi kisi3 = new Kisi();
            kisi3.Ad = "mahmut";
            kisi3.Yas = 50;
            kisi3.Meslek = "şair";


            Araba araba1 = new Araba();
            araba1.Marka = "opel";
            araba1.Renk = "mor";

            DateTime bugun = DateTime.Now;
            Random rnd2 = new Random();






        }
        
        class Kisi
        {
            public string? Ad { get; set; } // string tanımlanan proporties lerde ad ve meslek kısmı yeşil altı çizgili var ama sorun değil bunu kaldırmak için stringin yanına ? koyuyoruz.
            public int Yas { get; set; }
            public string? Meslek { get; set; }  



        }
        class Araba
        {
            // herhangi bir proportiesin başına public yazmazsak private olur. dşarıdan erişemeyiz.
            //public heryerden erişim sağlanabilir
            //private olursa sadece bu class dan erişilebilir.
            public string Marka { get; set; }

            public string Renk { get; set; }
            string VitesTuru { get; set; }//Eğer herhangi bir eişim belirleyici kullanılmamışsa private olarak kabul edilir.

            /*
             * erişim belirleyiciler::.Bir proportiynin dışarıdan yani içinde bulunduğu classın dışından erişim seviyesini belirleyen anahtar sözcüklere denir.Eğer herhangi bir eişim belirleyici kullanılmamışsa private olarak kabul edilir.
             * erişim belirleyiciler::
             * Public
             * Private
             * Protectec
             * İnternal
             */

        }
    }
}