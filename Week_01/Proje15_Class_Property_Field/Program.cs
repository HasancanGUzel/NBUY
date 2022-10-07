using System.Drawing;

namespace Proje15_Class_Property_Field
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogrenci1 = new Ogrenci();
            ogrenci1.OgrNo = 11;
            ogrenci1.Ad = "ahmet";
            ogrenci1.Sinif = "12A";

            Ogrenci ogrenci2 = new Ogrenci();
            ogrenci2.OgrNo = 18;
            ogrenci2.Ad = "mehmet";
            ogrenci2.Sinif = "10A";

            Ogrenci ogrenci3 = new Ogrenci() { OgrNo= 18, Ad="mehmet", Sinif="10A" };//üsttekilerle aynı tanımlama ama kısası

            /* Ogrenci ogrenci3 = new Ogrenci()//üstteki ile aynı biraz anlaşılır
             { 
                 OgrNo = 18, 
                 Ad = "mehmet", 
                 Sinif = "10A" 
             };
            */

            Ogrenci[] ogrenciler = { ogrenci1, ogrenci2, ogrenci3 };
            //for (int i = 0; i < ogrenciler.Length; i++)
            //{
            //    Console.WriteLine($"Ad:{ogrenciler[i].Ad}, sinif:{ogrenciler[i].Sinif}");
            //}

            //foreach (var ogrenci in ogrenciler)
            //{
            //    Console.WriteLine($"ad:{ogrenci.Ad}, Sınıf:{ ogrenci.Sinif}, Öğrenci no:{ ogrenci.OgrNo}");
            //}


            //int[] sayilar = { 32, 65, 33 };
            //foreach (var sayi in sayilar)
            //{
            //    Console.WriteLine(sayi*sayi);
            //}







        }
        class Ogrenci
        {
            //public int OgrNo { get; set; }

            private int ogrNo;// field
            public int OgrNo// property         //bu satır kapsülleme asıl ogrNo yukarıda ve private dışarıya kapalı ama biz burada get de return olarak veriyi ogrNo dan alıyoruz. ve set ile değer atıyoruz şuan atamadık ama set değer atıyor get de alıyor.
            {
                get { return ogrNo; }
                set { ogrNo = value; }
            }

            //public string Ad { get; set; }

            private string ad;
            public string Ad
            {
                get { return ad.ToUpper(); }// foreach da yazdırınca ben isimleri küçük harflerle yazmıştım ve """ad""" kısmında da küçük yazılı fakat """Ad"" kısmında geri dönüşü 'ad' dan aldığım veriyi büyük harflere dönüştrüdüm.
                set { ad = value; }
            }

            public string Sinif { get; set; }



        }
    }
}