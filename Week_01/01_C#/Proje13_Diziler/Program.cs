namespace Proje13_Diziler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string adSoyad = "fatih candan, cemal gündenm,selin dilci";
            //Console.WriteLine(adSoyad);

            //string[] adlar = new string[3];//içinde 3 adet strimg bilgi tutabilecek bir dizi.
            //adlar[0]="Fatih candan";
            //adlar[1] = "cemal gündem";
            //adlar[2] = "selin dilci";
            //Console.WriteLine(adlar[0]);

            //for (int i = 0; i < adlar.Length; i++)
            //{
            //    Console.WriteLine(adlar[i]);
            //}

            //int toplam = 0;
            //int[] yaslar = new int[3];
            //int[] rakamlar = { 35, 89, 90, 56, 45, 55 };
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    toplam += rakamlar[i];
            //}
            //Console.WriteLine(toplam);





            //string okul = "wissen akademie";// bu satur dizi olmamasına rağmen okul[0] yazınca W ekrana yazar çünkü string de bir karakter dizisidir.
            //Console.WriteLine(okul[0]);


            // ÇALIŞMA::: Klavyeden kullancıının adınını soyadını girmesini isyteyiniz.
            // girilen ad soyadı aşağıya doğru büyük ahrflerle yazdırınız.



            //Console.WriteLine("adınızı giriniz:");
            //string ad = Console.ReadLine().ToUpper();
            //for (int i = 0; i < ad.Length; i++)
            //{

            //    Console.WriteLine(ad[i]);

            //}

            //Console.WriteLine("bir metin giriniz");
            //string girilenMetin=Console.ReadLine().ToLower();
            //Console.Write("hangi karakterin sırasını  bulmamı istersiniz");
            //string karakter = Console.ReadLine().ToLower();
            //int siraNo = girilenMetin.IndexOf(karakter)+1;
            //Console.Clear();//console ekranını temizliyor.
            //Console.WriteLine($"girilen metin:{girilenMetin} \n aradığınız karakter:{karakter}\n sıra numarası {siraNo}");

            //int[] rakamlar = { 35, 89, 90, 56, 45, 55 };
            //Console.WriteLine("dizinin orjinal hali");
            //Console.WriteLine("************************");
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    Console.WriteLine($"{i+1}. eleman:\t{rakamlar[i]}");
            //}

            //kendimiz en büyük sayıyı bulalım.
            //Console.WriteLine($"en küçük:\t{rakamlar.Min()}");// \t console ekranında tab tuşuna basılmış gibi sonuc verir.
            //Console.WriteLine($"en büyük:\t{rakamlar.Max()}");

            //int enBuyuk = rakamlar[0];
            //int enKucuk = rakamlar[0];

            //for (int i = 1; i < rakamlar.Length; i++)
            //{
            //    if (rakamlar[i]>enBuyuk)
            //    {
            //        enBuyuk = rakamlar[i];

            //    }
            //    if (rakamlar[i]<enKucuk)
            //    {
            //    enKucuk = rakamlar[i];
            //    }
            //}
            //    Console.WriteLine(enBuyuk);
            //Console.WriteLine(enKucuk);

            //**************************************
            //isteğe bağlı ödev diziyi küçükten büyüğe sırala
            //**************************************

            //int[] rakamlar = { 35, 89, 90, 56, 45, 55 };
            //Console.WriteLine("dizinin orjinal hali");
            //Console.WriteLine("************************");
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. eleman:\t{rakamlar[i]}");
            //}


            //Console.WriteLine("dizinin ter çevrilmiş hali");
            //Console.WriteLine("***************************");
            //Array.Reverse(rakamlar);
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. eleman:\t{rakamlar[i]}");
            //}

            //Console.WriteLine("dizinin küçükten büyüğe çevrilmiş hali");
            //Console.WriteLine("***************************");
            //Array.Sort(rakamlar);
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. eleman:\t{rakamlar[i]}");
            //}

            //Console.WriteLine("dizinin büyükten küçüğe çevrilmiş hali");
            //Console.WriteLine("***************************");
            //Array.Sort(rakamlar);
            //Array.Reverse(rakamlar);
            //for (int i = 0; i < rakamlar.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. eleman:\t{rakamlar[i]}");
            //}


            //****************************ÖRNEKLER*********************
            //ÖRNEK1:*** sayilar dizisinin ortaamsını bulup ekrana yazdır.

            //int[] sayilar = { 5, -16, 8, 12, -15, 78, 90, 0 };


            //int toplam = sayilar.Sum();
            //Console.WriteLine(toplam);


            //ÖRNEK2: sayılar dizisindeki çift sayıları ekrana yazdıralım.

            //for (int i = 0; i < sayilar.Length; i++)
            //{
            //    if (sayilar[i]%2==0)
            //    {
            //        Console.WriteLine(sayilar[i]);

            //    }
            //}


            //ÖRNEk3sayılar dizindek sayıları yanlarına pozitif negatif ya da işaretsiz olma bilgileryile yazdıralım.
            //string tip = "";
            //for (int i = 0; i < sayilar.Length; i++)
            //{
            //    tip = sayilar[i] > 0 ? "pozitif" : 
            //            sayilar[i] < 0 ? " negatif" :
            //                "işaretsiz";

            //    Console.WriteLine($"{i+1}.sayı:{sayilar[i]}-tipi:{tip}");
            //}

            //ÖRNEK:4::Kullanıcın gireceği bir metnin içindeki sesli harf sayısını ekrana yazdıralım.

            //char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
            //int sesliHarfAdedi = 0;
            //Console.WriteLine("bir metin giriniz:");
            //string girilenMetin = Console.ReadLine().ToLower();
            //for (int i = 0; i < girilenMetin.Length; i++)
            //{
            //    if (sesliHarfler.Contains(girilenMetin[i]))
            //    {
            //        sesliHarfAdedi++;

            //    }
            //}
            //Console.WriteLine(sesliHarfAdedi);

            //ÖRNEK5:Klavyeden girilen bir cümledeki yine klavyeden girilecek bir kelimenin kaç kez geçtiğini bulduralım.

            //string ornekMetin = "ahmet mehmet fatma";
            //string[]sozcukDizisi=ornekMetin.Split(" ");//split dizilerde kullanılır ve isteğimiz karaktere göre diziyi böler
            //for (int i = 0; i < sozcukDizisi.Length; i++)
            //{
            //    Console.WriteLine(sozcukDizisi[i]);
            //}

            int sozcukAdedi = 0;
            Console.Write("cümleyi giriniz");
            string girilenCumle=Console.ReadLine();
            Console.Write("adedini bulmak istediğiniz sözğü giriniz");
            string sayilacakSozcuk=Console.ReadLine();
            string[] girilenCumleninDiziHali = girilenCumle.Split(" ");
            for (int i = 0; i < girilenCumleninDiziHali.Length; i++)
            {
                if (sayilacakSozcuk.ToLower() == girilenCumleninDiziHali[i].ToString().ToLower())
                {

                    sozcukAdedi++;
                }
            }
            Console.WriteLine($"'{girilenCumle}'cümlesi içinde '{sayilacakSozcuk}'sözcüğü '{sozcukAdedi}'kez geçmektedir");


            ///araştırma ödevi
            ///***************
            ///çok boyutlu dizileri araştırın.
            

            ///**************PROJE ÖDEVİ.**********
            ///İÇİNDE TÜRKÇE KARAKTERLER HARİÇ TÜM KÜÇÜK HARFLER, 0-9 ARASI RAKAMLAR NOKTA(.) VİRGÜL(,) ARTI(+) EKSİ(-) KARAKTERLERİ BULUNABİLECEKE TOPLAM UZUNLUĞU 6 KARAKTER OLACAK ŞEKİLDE RASTGELE ŞİFRE ÜRETEN PROGRAMI YAZINI.








        }
    }
}