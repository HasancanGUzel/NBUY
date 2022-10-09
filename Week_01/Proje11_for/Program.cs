using System.Globalization;

namespace Proje11_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 150; i++)
            //{
            //    //Console.WriteLine(i+ "." + "adsasd");
            //    Console.WriteLine($"{i+1}. adsasd");
            //}
            // int sonuc = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    sonuc +=i;
            //    Console.WriteLine(sonuc);

            //}

            //1 ile 10 arasındaki çift sayıların toplamı ekrana yazdır
            //int toplam = 0;
            //for (int i = 0; i <=10; i+=2)
            //{
            //    toplam += i;
            //    Console.WriteLine(toplam);
            //}

            ////-----------------------------------
            //int sonuc = 0;
            //for (int j = 0; j <=10; j++)
            //{
            //    if (j%2==0)
            //    {
            //        sonuc += j;
            //        Console.WriteLine(sonuc);
            //    }
            //}

            // tek ve çift sayıların toplamını yaz

            //int sonuc = 0;
            //int tek = 0;
            //for (int j = 0; j <= 10; j++)
            //{
            //    if (j % 2 == 0)
            //    {
            //        sonuc += j;

            //    }
            //    else
            //    {
            //        tek += j;

            //    }

            //}
            //Console.WriteLine("tek toplam=={0}, çift toplam {1}", tek, sonuc);

            //----------------------------------------------------


            // soru: klavyeden 2 sayı girilsin . bu sayıların arasındaki  sayıların toplamını ekrana yazdıralım.

            //Console.WriteLine("1. sayıyı giriniz:");
            //int sayi1=int.Parse(Console.ReadLine());
            //Console.WriteLine("2. sayıyı giriniz:");
            //int sayi2 = int.Parse(Console.ReadLine());
            //int toplam = 0;
            //for (int i = sayi1; i <= sayi2; i++)
            //{
            //    toplam += i;

            //}
            //Console.WriteLine(toplam);


            //----------------------------------------------------


            //1. sayı 2. syıdan büyük girilirse

            //Console.WriteLine("1. sayıyı giriniz:");
            //int sayi1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("2. sayıyı giriniz:");
            //int sayi2 = int.Parse(Console.ReadLine());
            //int toplam = 0;

            //if (sayi2>sayi1)
            //{
            //    for (int i = sayi1; i <= sayi2; i++)
            //    {
            //        toplam += i;

            //    }
            //    Console.WriteLine(toplam);
            //}
            //else
            //{
            //    for (int i = sayi1; i >= sayi2; i--)
            //    {
            //        toplam += i;

            //    }
            //    Console.WriteLine(toplam);
            //}


            //----------------------------------------------------


            //max ve min ile kısa olarak çözümü

            //Console.WriteLine("1. sayıyı giriniz:");
            //int sayi1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("2. sayıyı giriniz:");
            //int sayi2 = int.Parse(Console.ReadLine());
            //int enKucuk=Math.Min(sayi1, sayi2); 
            //int enBuyuk=Math.Max(sayi1, sayi2);    
            //int toplam = 0;
            //for (int i = enKucuk; i <= enBuyuk; i++)
            //{
            //    toplam += i;

            //}
            //Console.WriteLine(toplam);

            //----------------------------------------------------


            // soru::Program kullanıcıdan bir sayı girmesini istesin ancak kullanıcı sayı girmeye devam ettikçe girilen sayıların toplanmasını sağlaylım.sayı adedi belirsizdir.uygulamanın bitip ekrana toplamı yazıdırabilmesi için kullanıcıın sayı yerine exit yazmasını kontrol edeceğiz.

            //int toplam = 0;

            //string girilenDeger = "";
            //string sonucMetin = "";
            //string sonEk = " + ";
            //for (int i = 1; i < 10000000; i++)
            //{
            //    //Console.Write(i+ "."+" sıradaki sayıyı giriniz:(çıkış için exit)"); //alt satırla aynı
            //    Console.Write($"{i}.sıradaki sayıyı giriniz:(çıkış için exit)[Geçerli toplam=={toplam}=]");
            //    girilenDeger =Console.ReadLine();
            //     if(girilenDeger.ToLower()=="exit")//if (girilenDeger=="exit" || girilenDeger=="EXİT")
            //    {
            //        break;//içinde bulunulan döngünün tamamalanmasını beklemeden istenilen bir anda durdurulmasını için kullanılır

            //    }
            //    sonucMetin += girilenDeger + sonEk;// girilen sayıları string olarak tanımladığımız sonucMetin değişkenine atıyoruz.
            //    toplam += Convert.ToInt32(girilenDeger);


            //}
            //int uzunluk = sonucMetin.Length - sonEk.Length;//sonucMetin değişkeninin uzunluğundan 3 eksiğini alıp yani son boşluk + ve son boşluğu alıp bunları silip uzunluk değişkenine atıyoruz
            //sonucMetin=sonucMetin.Substring(0, uzunluk);// sonucMetin değişkenine substring metinini kullanarak 0 indeks yani sonucMetinin başlangıcından itibaren uzunluk değişkeni kadar kısmını alıp sonucMetin değişkenine atıyorum.
            //Console.WriteLine($"girilen değerlerin tek tek gösterimi =={sonucMetin}={toplam}");

            //Console.WriteLine($"toplam =={toplam}");

            //----------------------------------------------------

            //5x5 lik bir kare biçimini yıldız işaretleriyle oluşturan uygulam yazınız.

            /*
             *         *****
             *         *****
             *         *****
             *         *****
             *         *****
             */

            //int satir = 5;
            //int sutun = 5;
            //for (int i = 0; i < satir; i++)
            //{

            //    for (int j = 0; j < sutun; j++)
            //    {
            //        Console.Write("*");

            //    }

            //    Console.WriteLine();

            //}

            // satır ve sutun dışarıdan girilsin

            //Console.WriteLine("satırı giriniz");
            //int satir=int.Parse(Console.ReadLine());
            //Console.WriteLine("sütunu giriniz");
            //int sutun = int.Parse(Console.ReadLine());
            //for (int i = 0; i < satir; i++)
            //{

            //    for (int j = 0; j < sutun; j++)
            //    {
            //        Console.Write("*");

            //    }

            //    Console.WriteLine();

            //}



            //----------------------------------------------------




            /*
             *       *****
             *       ****
             *       ***
             *       **
             *       *      şeklini oluşturdum.
             */

            Console.WriteLine("satırı giriniz");
            int satir = int.Parse(Console.ReadLine());
            Console.WriteLine("sütunu giriniz");
            int sutun = int.Parse(Console.ReadLine());
            for (int i = 0; i < satir; i++)
            {

                for (int j = sutun; j > 0; j--)
                {
                    Console.Write("*");


                }
                sutun--;
                Console.WriteLine();

            }



            //----------------------------------------------------

            //soru 5x5 lik içi boş kare oluştur

            /*
             *     *****
             *     *   *
             *     *   *
             *     *   *
             *     *****
             */

            //int satir = 5;
            //int sutun = 5;
            //for (int i = 1; i <= satir; i++)
            //{
            //    for (int j = 1; j <= sutun; j++)
            //    {
            //        if (i == 1 || i == satir)// eeğer 1. veya son satır ise
            //        {
            //            Console.Write("*");
            //        }
            //        else if (j == 1 || j == sutun) // eğer 1 .veya son sutündaysan
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }

            //    }
            //    Console.WriteLine();
            //}
            // ödev  üstteki içi boş kareyi oluşturan uygulamayı adım adım çalıştır bak

            //Ödev1: 1-100 arasındaki sayıların ortalamasını bulduran program
            //Ödev2: 1-100 arasındaki çift tek ve 5 in katı olan sayıların adetleri ve toplamlarını ekrana yazdrıan program.
            //Ödev3:Aşağıdaki yüksekliği 5 tabanı 9 birim olan yıldızlardan oluşan dik üçgeni çizdiren program.
            /*
             * *
             * ***
             * *****
             * *******
             * *********
             */















        }
    }
}