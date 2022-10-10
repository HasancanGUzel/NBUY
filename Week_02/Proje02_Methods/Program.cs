using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace Proje02_Methods
{
    public class Program
    {
        //public static void Topla(int sayi1, int sayi2)// parametre alan ama geriye değer döndürmeyen metotlar
        //{
        //    int toplam = sayi1 + sayi2;
        //    Console.WriteLine(toplam);
        //}
        //public static void Fark(int sayi1, int sayi2) // parametre alan ama geriye değer döndürmeyen metotlar.
        //{
        //    int fark = sayi1 - sayi2;
        //    Console.WriteLine(fark);
        //}



        //***************************************************************************


        //public static int Topla(int sayi1, int sayi2)// parametre alan ve geriye değer döndüren metotlar
        //{
        //    int toplam = sayi1 + sayi2;
        //    return toplam;

        //}
        //public static int Fark(int sayi1, int sayi2)//parametre alan ve geriye değer döndüren metotlar
        //{
        //    int fark = sayi1 - sayi2;
        //    return fark;

        //}



        ////******************************************


        //public static void Topla1()// parametre almayan ve geriye değer döndürmeyen metotlar
        //{

        //    Console.WriteLine("birinci sayıyı giriniz");
        //    int s1=int.Parse(Console.ReadLine());
        //    Console.WriteLine("ikinci sayıyı giriniz");
        //    int s2 = int.Parse(Console.ReadLine());
        //    int toplam = s1 + s2;
        //    Console.WriteLine(toplam);

        //}
        //public static void Fark1()//parametre almayan ve geriye değer döndürmeyen metotlar
        //{
        //    Console.WriteLine("birinci sayıyı giriniz");
        //    int s1 = int.Parse(Console.ReadLine());
        //    Console.WriteLine("ikinci sayıyı giriniz");
        //    int s2 = int.Parse(Console.ReadLine());
        //    int fark = s1 + s2;
        //    Console.WriteLine(fark);
        //}

        //******************************************

        //public static int Topla2()// parametre almayan ve geriye değer döndüren metotlar
        //{

        //    Console.WriteLine("birinci sayıyı giriniz");
        //    int s1 = int.Parse(Console.ReadLine());
        //    Console.WriteLine("ikinci sayıyı giriniz");
        //    int s2 = int.Parse(Console.ReadLine());
        //    int toplam = s1 + s2;
        //    return toplam;



        //}
        //public static int Fark2()// parametre almayan ve geriye değer döndüren metotlar
        //{
        //    Console.WriteLine("birinci sayıyı giriniz");
        //    int s1 = int.Parse(Console.ReadLine());
        //    Console.WriteLine("ikinci sayıyı giriniz");
        //    int s2 = int.Parse(Console.ReadLine());
        //    int fark = s1 + s2;
        //    Console.WriteLine(fark);
        //    return fark;
        //}

        //**************************************************

        //public static int SiraNo(string metin,char karakter)
        //{
        //    int sonuc = metin.IndexOf(karakter);
        //    return sonuc;
        //}
        //public static bool VarMi(string metin, char karakter)
        //{
        //   bool sonuc=metin.Contains(karakter);
        //    return sonuc;
        //}

        static void Main(string[] args)
        {
            //Console.Write("Birinci sayıyı giriniz:");
            //int s1=int.Parse(Console.ReadLine());
            //Console.Write("ikinci sayıyı giriniz:");
            //int s2 = int.Parse(Console.ReadLine());
            // int sonuc = Topla(s1 ,s2);//parametre alan ve geriye değer döndüren metotlar
            //int sonuc2 = Fark(s1, s2);//parametre alan ve geriye değer döndüren metotlar
            //Console.WriteLine("toplamı : {0}\nfarkı {1}",sonuc,sonuc2);

            //Topla(s1,s2);//parametre alan ama geriye değer döndürmeyen metotlar
            //Fark(s1, s2);//parametre alan ama geriye değer döndürmeyen metotlar

            //***********************************

            //Topla1();//parametre almayan ve geriye değer döndürmeyen metotlar
            // Fark1();//parametre almayan ve geriye değer döndürmeyen metotlar

            //int sonuc = Topla2(); // parametre almayan ve geriye değer döndüren metotlar
            //int sonuc2 = Fark2(); // parametre almayan ve geriye değer döndüren metotlar



            //uygulama****************************

            // kendisine verilen metnin içinde aradığımız karakterin kaçıncı sırada olduğunu bulan metodu hazırla.

            // kendisine verilen metnin içinde aradığımız karakterın olup olmadığını  bize söyleyen bir metodu hazırla.
            //Console.WriteLine(SiraNo("wissen akademie",'a'));
            //Console.WriteLine(VarMi("wissen akademie",'a')==true ? "içinde geçiyor":"içinde geçmiyor");

            #region MethodOverload

            MethodOverload methodOverload = new MethodOverload();
            methodOverload.DenemeMetodu();//// MethodOverload class ını static tanımlamazsak Program.cs sınıfında nesne üretmek zorundayım.
            //MethodOverload.DenemeMetodu();// MethodOverload sınfıında sınıfı static olarak tanımladım.
            //Console.WriteLine(methodOverload.Topla(55,66));
           //Console.WriteLine(methodOverload.Islem(55,28));
            int[] sayilar = { 35, 45, 55, 69, 87, 99 };
            Console.WriteLine(methodOverload.Topla(sayilar));

            #endregion


        }


    }
}