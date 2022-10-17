using System.Collections;

namespace Proje04_Sayisal_Loto_Oyunu
{
    
    internal class Program
    {


       
        static int[] SayiUret()
        {
            Random rnd=new Random();
            int[] loto=new int[6];
            int sayi;
            for (int i = 0; i < 6; i++)
            {
                
                do
                {
                    sayi = rnd.Next(1, 50);
                } while (loto.Contains(sayi));
                loto[i] = sayi;               
            }
            return loto;// metot tun türü ile aynı olması lazım yani metot un türü int[], ve bizim return loto da int türünde dizi.
        }

        static void Hile(int[]loto)
        {
            Console.WriteLine("hile");
            Console.WriteLine("****");
            foreach (var siradakiSayi in loto)
            {
                Console.WriteLine(siradakiSayi);
            }
        }

        static int TahminYap(int tahminSiraNo)//Kullanıcın her tahmin yapışını burası sağlayacak
        {
            int tahmin;
            Console.Write($"{tahminSiraNo}. tahmininizi giriniz==");
            tahmin = int.Parse(Console.ReadLine());
            return tahmin;
        }
        static void Main(string[] args)
        {

            #region uygulama hakkında açıklama


            /*
             * 1) Sistem 6 tane 1-49 arasında 6 tane farklı  sayı üretsin.
             * 2) Kullanıcıdan 6 tane tahmin alalım
             * 3) Sonuc olarak kullanıcının kaç tne doğru tahmin yaptığını tahminleriyle birlikte yazdıralım.
             * NOT==== Hiç doğru tahmin yapamazsa KAYBETTİNİZ yapsın.
             */
            #endregion


            int tahmin ;
            int[] loto =SayiUret();// buradakı loto metotla aynı olan değil ürettiğimiz sayıları burdada dizide tutuyoruz.
            int[] tahminler=new int[6];

            Hile(loto);
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    tahmin=TahminYap(i + 1);
                } while (tahmin<0 || tahmin >49);
                tahminler[i] = tahmin;               
            }
            ArrayList bilinenler = new ArrayList();//Arraylislerin kaç elemanlı olacağı söylenmez!!! içinde her bir eleman istenilen tipte değer tutabilir, int string, char vb.

            foreach (var siradakiTahmin in tahminler)
            {
                if (loto.Contains(siradakiTahmin))
                {
                    bilinenler.Add(siradakiTahmin);
                }
            }
            if (bilinenler.Count==0)
            {
                Console.WriteLine("kaybettiniz hiç sayı bilemediniz");
            }
            else
            {
                Console.WriteLine($"TEBRİKLER {bilinenler.Count} adet doğru tahmin yaptınız");
                Console.WriteLine("bildiğiniz sayılar");
                foreach (var siradakiBilinen in bilinenler)
                {
                    Console.WriteLine(siradakiBilinen);
                }
            }
            Console.ReadLine();
        }
    }
}