namespace Proje09_ıfConditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("bir sayı giriniz");
            //int sayi= int.Parse(Console.ReadLine());
            //if (sayi >= 0)
            //{
            //    Console.WriteLine("sayı 0 dan büyüktür {0}", sayi);
            //}


            //--------------------------------------------------------

            //kullanııcdan yaşını girmesini isteyelim 18 den küçüklere giriş yasak yazalım

            //Console.WriteLine("yaşınızı giriniz");
            //int yas=int.Parse(Console.ReadLine());
            //if (yas<=18)
            //{
            //    Console.WriteLine("giriş yasak");
            //}
            //else
            //    Console.WriteLine("18 den büyüksünüz girdiniz!!!");


            //---------------------------------------------------

            //girilen 2 sayıdan büyük olanı yazdır

            //Console.WriteLine("1. sayıyı gir");
            //int sayi1=int.Parse(Console.ReadLine());
            //Console.WriteLine("2.sayıyı gir");
            //int sayi2=int.Parse(Console.ReadLine());
            //if (sayi1>sayi2)
            //{
            //    Console.WriteLine("büyük sayı: {0}",sayi1);
            //    Console.WriteLine($"büyük sayı {sayi1}");
            //}
            //else if (sayi2>sayi1)
            //{
            //    Console.WriteLine("büyük sayı: {0}",sayi2);
            //    Console.WriteLine($"büyük sayı: {sayi2}");
            //}
            //else
            //{
            //    Console.WriteLine("sayılar birbirine eşittir sayi1={0}, sayi2={1}",sayi1,sayi2);
            //    Console.WriteLine($"sayılar birbirine eşit sayi1== {sayi1}, sayi2== {sayi2}");
            //}

            //----------------------------------------------------------

            //girilen 3 sayıdan büyük olanı yazdır.


            //Console.WriteLine("1. sayıyı giriniz");//ctrl+k+d  satır böyle içerideyse tam hizaya getirir.

            //Console.WriteLine("1. sayıyı giriniz");
            //int sayi1=int.Parse(Console.ReadLine());
            //Console.WriteLine("2.sayıyı giriniz");
            //int sayi2=int.Parse(Console.ReadLine());
            //Console.WriteLine("3.sayıyı giriniz");
            //int sayi3=int.Parse(Console.ReadLine());
            //if (sayi1 >=sayi2 && sayi1 >= sayi3)
            //{
            //    Console.WriteLine(sayi1);

            //}
            //else if (sayi2 >= sayi1 && sayi2 >= sayi3)
            //{
            //    Console.WriteLine(sayi2);
            //}
            //else if (sayi3 >= sayi1 && sayi3 >= sayi1)
            //{
            //    Console.WriteLine(sayi3);
            //}



            //-------------------------------------------------------


            //Console.WriteLine("1. sayıyı giriniz");
            //int sayi1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("2.sayıyı giriniz");
            //int sayi2 = int.Parse(Console.ReadLine());
            //int buyukSayi=0;
            //if (sayi1>sayi2)
            //{
            //    buyukSayi = sayi1;
            //}
            //else if (sayi2>sayi1)
            //{
            //    buyukSayi = sayi2;
            //}

            //Console.WriteLine(buyukSayi);


            //------------------------------------------


            //Console.WriteLine("1. sayıyı giriniz");
            //int sayi1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("2.sayıyı giriniz");
            //int sayi2 = int.Parse(Console.ReadLine());
            //int buyukSayi = sayi1 > sayi2 ? sayi1 : sayi2;// if in değişik versiyonu
            //Console.WriteLine(buyukSayi);

            //----------------------------------------

            Console.WriteLine("1. sayıyı giriniz");
            int sayi1 = int.Parse(Console.ReadLine());
            Console.WriteLine("2.sayıyı giriniz");
            int sayi2 = int.Parse(Console.ReadLine());
            string sonuc = sayi1> sayi2 ? "1.sayı 2. yıdan büyüktür." : 
                                  sayi2 > sayi1 ? "2.sayı 1 . sayıdan büyüktür" : 
                                        "iki sayı birbirine eşittir.";
            Console.WriteLine(sonuc);








        }
    }
}