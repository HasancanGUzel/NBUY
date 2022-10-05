using System;

namespace Proje10_SwitchCondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //klavyden girilen bir sayının 5 olması halinde 2 katını 10 olması halinde 3katını  15 olması halinde 4katını  olmadığını ekrana yazdıran program hazırlayalım eğer üçüde değilse tanınmayan değer yazsın.

            //Console.WriteLine("bir sayı giriniz");
            //int sayi1=int.Parse(Console.ReadLine());
            //int sonuc = 0;
            //switch (sayi1)
            //{
            //    case 5:
            //        Console.WriteLine(sonuc=(sayi1*2));
            //                break;
            //    case 10:
            //        Console.WriteLine(sonuc = (sayi1 * 3));
            //        break;
            //    case 15:
            //        Console.WriteLine(sonuc = (sayi1 * 4));
            //        break;

            //    default:
            //        Console.WriteLine("tanınmayan değer");
            //        break;

            //---------------------------------------------------------


            // x  10 dan küçükse arasında ise 2 ile çarp.
            // x 11 ila 20 arasında ise 3 ile çarp.
            // x 21 ila 50 arasında ise 4 ile çarp.
            // x 51 ila 100 arasında ise 5 ile çarp.
            // x 100 den büyük ise10 ile çarp.

            //if ile çözümü
            //int x = 11;
            //int katsayi = 0;
            ////int sonuc = 0;
            //if (x <= 10)
            //{
            //    //sonuc = x * 2;
            //    katsayi = 2;
            //}
            //else if (x >= 11 && x <= 20)
            //{
            //    //sonuc = x * 3;
            //    katsayi = 3;
            //}
            //else if (x >= 21 && x <= 50)
            //{
            //    // sonuc = x * 4;
            //    katsayi = 4;
            //}
            //else if (x >= 51 && x <= 100)
            //{
            //    //sonuc = x * 5;
            //    katsayi = 5;
            //}
            //else
            //{
            //    //sonuc = x * 10;
            //    katsayi = 10;
            //}
            ////Console.WriteLine($"X={x},sonuç={sonuc}");

            //int sonuc = x * katsayi;
            //Console.WriteLine($"X: {x}. sonuç= {x} x {katsayi} == {sonuc}");

            //swicth ile yapımı


            //int x = 120;
            //int katsayi = 0;
            //switch (x)
            //{
            //    case (>=0 and <= 10):
            //        katsayi = 2;
            //        break;
            //    case (>= 11 and <= 20):
            //        katsayi = 3;
            //        break;
            //    case (>= 21 and <= 50):
            //        katsayi = 4;
            //        break;
            //    case (>= 51 and <= 100):
            //        katsayi = 10;
            //        break;
            //    default:
            //        katsayi = 6;
            //        break;
            //}
            //int sonuc = x * katsayi;
            //Console.WriteLine($"X: {x}. sonuç= {x} x {katsayi} == {sonuc}");

            //---------------------------------------------------

            // içinde olduğumuz günün hafta içi mi yoksa hafta sonu mu olduğunu bulalım
            //DateTime tarih = new DateTime(2022,10,8);
            //DayOfWeek gun = tarih.DayOfWeek;
            //if (gun==DayOfWeek.Sunday || gun==DayOfWeek.Saturday)
            //{
            //    Console.WriteLine("haftasonu");
            //}
            //else
            //{
            //    Console.WriteLine("hafta içi çalış");
            //}

            // sswitch case ile yapımı
            //DateTime tarih = new DateTime(2022,10,8);
            //DayOfWeek gun = tarih.DayOfWeek;
            //switch (gun)
            //{

            //    case DayOfWeek.Monday or 
            //         DayOfWeek.Tuesday or 
            //         DayOfWeek.Wednesday or 
            //         DayOfWeek.Thursday or 
            //         DayOfWeek.Friday:
            //        Console.WriteLine("hafta içindesin  çalış");
            //        break;
            //    case DayOfWeek.Saturday or
            //         DayOfWeek.Sunday:
            //        Console.WriteLine("hafta sonu tatil");
            //        break;
                    
            //    default:
            //        break;
            //}



        }
    }
}