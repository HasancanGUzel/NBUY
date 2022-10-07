namespace Proje12_While;
class Program
{
    static void Main(string[] args)
    {
       /* int sayac=1;
        while (sayac<=5)
        {
                Console.WriteLine("Hello, World!");
                sayac++;

            
        }*/
        // int toplam=0;
        // string girilenDeger="";
        // int sayac=1;
        // while (girilenDeger!="exit")
        // {
        //     Console.Write($"{sayac}.sayıyı giriniz(Çıkış için exit):");
        //     girilenDeger=Console.ReadLine();
        //     // if (girilenDeger!="exit")
        //     // {
        //     //     toplam+=Convert.ToInt32(girilenDeger);
                
        //     // }
        //     try
        //     {
        //         toplam+=Convert.ToInt32(girilenDeger);
        //     }
        //     catch (System.Exception)
        //     {
                
        //         Console.WriteLine(toplam);
        //         break;
        //     }
        //     sayac++;
            
        //}

        // klavydene exit yazılana kadar isim girilmesini isteyen uygulama
        //çözüm 1
        // string isim="";
        // while (isim!="exit")
        // {
        //     Console.WriteLine("isim giriniz");
        //     isim=Console.ReadLine();
            
        // }
        // Console.WriteLine("program sona erdi");

        //çözüm 2
        // string isim;
        // do
        // {
        //     Console.WriteLine("isim giriniz");
        //     isim=Console.ReadLine();
        // } while (isim!="exit");
        // {
        //     Console.WriteLine("program sona erdi");
        // }
            

            //klavyeden exit yazılana kadar sayı almya devam eden ve  bu sayıların toplamını exit yazılınca ekrana yazan program do while ile
        
        // string girilenDeger;
        // int sayac=1;
        // int toplam=0;

        // do
        // {
        //     Console.WriteLine($"{sayac}. sayıyı giriniz:");
        //     girilenDeger=Console.ReadLine();
        //     if (girilenDeger!="exit")
        //     {
        //          toplam+=Convert.ToInt32(girilenDeger);
        //     }
           
        // } 
        // while (girilenDeger!="exit");
        // {
        //     Console.WriteLine(toplam);
        // }

        // Random rastgele=new Random();
        // int rastgeleSayi=rastgele.Next();
        // Console.WriteLine(rastgeleSayi);
        // int rastgeleSayi2=rastgele.Next(100);//0 ile 100 arasında rastgele sayı üretir 0 dahil 100 dahil değildir.
        // Console.WriteLine(rastgeleSayi2);
        // int rastgeleSayi3=rastgele.Next(1000,2000);//1000-2000 arasında rastgele sayı üretir ama 1000 dahil 2000 dahil değildir.
        // Console.WriteLine(rastgeleSayi3);

        // OYUNUMUZUN SENARYOSU:::Uygulamanın rastgele üreteceği bir sayıyı kullanıcının tahmin etmesini isteyeceğiz.
        // Rastgele üretilecek olan sayı 1-11 arasında olsun.
        //Kullanıcı rastgele olan sayıdan küçük ya da büyük bir sayı girdiğinde kullanııya uygun bir şekilde mesaj verilsin.
        //Doğru sayıyı tahmin edene kadar uygulama çalışsın.

        // Random rnd=new Random();
        // int uretilenSayi=rnd.Next(1,101);
        // Console.WriteLine($"hile::{uretilenSayi}");
        // Console.WriteLine("****************");
        // int tahminEdilenSayi;
        // do
        // {
        //     Console.Write("Tahmininizi giriniz..(1 ile 100 arasında)");
        //     tahminEdilenSayi=Convert.ToInt32(Console.ReadLine());
        //     if (tahminEdilenSayi>uretilenSayi)
        //     {
        //         Console.WriteLine("büyük bir değer girdiniz daha küçük bir değer girerek yeniden deneyiniz.");
        //     }
        //     else if(tahminEdilenSayi<uretilenSayi)
        //     {
        //         Console.WriteLine("küçük bir değer girdiniz daha büyük bir değer girerek yeniden deneyiniz.");
                
        //     }
        //     else
        //     {
        //         Console.WriteLine("tebrikler kazandınız");
        //     }
        // } 
        // while (tahminEdilenSayi!=uretilenSayi);

        //oyuna ek olarak.::::
        //Kullanıcı doğru sayıyıy tahmin ettiyse ya da 5 hakkını kullandıysa uygulama sona ersin

        // Random rnd=new Random();
        // int uretilenSayi=rnd.Next(1,101);
        // Console.WriteLine($"hile::{uretilenSayi}");
        // Console.WriteLine("****************");
        // int hak=1;
        // int haksiniri=5;
        // int tahminEdilenSayi;
        // do
        // {
           
        //     Console.Write($"{hak}. Tahmininizi giriniz..(1 ile 100 arasında)(Kalan Hakkınız: {haksiniri-hak+1})");
        //     tahminEdilenSayi=Convert.ToInt32(Console.ReadLine());
        //         if(hak==haksiniri && uretilenSayi!=tahminEdilenSayi)
        //         {
        //             System.Console.WriteLine(  "kaybettiniz" );
        //             break;
        //         }
            
        //         if (tahminEdilenSayi>uretilenSayi)
        //         {
        //             Console.WriteLine("büyük bir değer girdiniz daha küçük bir değer girerek yeniden deneyiniz.");
        //         }
        //         else if(tahminEdilenSayi<uretilenSayi)
        //         {
        //             Console.WriteLine("küçük bir değer girdiniz daha büyük bir değer girerek yeniden deneyiniz.");
                    
        //         }
        //         else
        //         {
        //             Console.WriteLine("tebrikler kazandınız");
        //         }
            
        //          hak++;
                  
        // } 

        // while (tahminEdilenSayi!=uretilenSayi && hak<=haksiniri);

        //----------------üstteki örneğin değişik versiyonu

        string mesaj="";

        Random rnd=new Random();
        int uretilenSayi=rnd.Next(1,101);
        Console.WriteLine($"hile::{uretilenSayi}");
        Console.WriteLine("****************");
        int hak=1;
        int haksiniri=5;
        int tahminEdilenSayi;
        do
        {
            Console.Write($"{hak}. Tahmininizi giriniz..(1 ile 100 arasında)(Kalan Hakkınız: {haksiniri-hak+1})");
            tahminEdilenSayi=Convert.ToInt32(Console.ReadLine());
            if (tahminEdilenSayi>uretilenSayi)
            {
                mesaj="büyük girdin";
            }
            else if(tahminEdilenSayi<uretilenSayi)
            {
                mesaj="küçük girdin";
            }
            if (tahminEdilenSayi!=uretilenSayi)
            {
                
                hak++;
                if (hak<=haksiniri)
                {
                    System.Console.WriteLine(mesaj);
                    
                }
            }


        } while (tahminEdilenSayi!=uretilenSayi && hak<=haksiniri);
        mesaj=tahminEdilenSayi==uretilenSayi ?"kazandınız":"kaybettiniz";
        Console.WriteLine(mesaj);
        // üstteki if de aynı alttaki if de aynı
        // if (tahminEdilenSayi==uretilenSayi)
        // {
        //     System.Console.WriteLine(  "kazandınız");
            
        // }
        // else
        // {
        //     System.Console.WriteLine(  "kaybettiniz");
        // }
        //eğer program bu satıra gelmişse ya doğru tahminde bulunulmuştur yada hak sona gelmiştir.
        

        



        
    }
}
