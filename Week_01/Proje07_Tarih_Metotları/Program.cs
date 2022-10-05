
namespace Proje07_Tarih_Metotları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(DateTime.Today);

            //DateTime dogumTarihi = new DateTime(2000,8,18); // belirledğimiz tarihi yazar
            //Console.WriteLine(dogumTarihi);
            //DateTime bugun = DateTime.Now;               //bugunun tarihi
            //TimeSpan span=bugun.Subtract(dogumTarihi);//belirlediğimiz tarihten şimdidki tarih arası hesaplama
            //Console.WriteLine(Math.Floor(span.TotalDays));


            //DateTime bugun = DateTime.Now;
            //Console.WriteLine(bugun.ToLongDateString()); //5 ekim 2022 çarşamba şeklinde yazar
            //Console.WriteLine(bugun.ToLongTimeString()); //13:35.02 saati saniye gösterir
            //Console.WriteLine(bugun.ToShortDateString()); //5.10.2022 şeklinde
            //Console.WriteLine(bugun.ToShortTimeString()); //13:36 saniyeyi göstermez



            //bir sonraki yılın ilk günün tarihi bulduralım.

            //DateTime bugun = DateTime.Now;
            //int yil = bugun.Year + 1;
            //DateTime sonuc = new DateTime(yil, 1, 1);
            //Console.WriteLine(sonuc.ToLongDateString());


            // bir sonraki ayın ilk günün tarihi bulduralım.
            //DateTime bugun = DateTime.Now;
            //int yil = bugun.Year + 1;
            //int ay = bugun.Month + 1;
            //DateTime sonuc = new DateTime(yil, ay, 1);
            //Console.WriteLine(sonuc.ToLongDateString());





           // -------------OOOOOODEEEEEEVVVVVVV---------------

            //// ertesi günün tarihi bulup ekrana yazdıran program yazınız.
            //DateTime bugun = DateTime.Now;
            //int day = bugun.Day + 1;
            //int yil = bugun.Year ;
            //int ay = bugun.Month ;
            //DateTime sonuc = new DateTime(yil, ay, day);
            //Console.WriteLine(sonuc.ToLongDateString());






        }
    }
}