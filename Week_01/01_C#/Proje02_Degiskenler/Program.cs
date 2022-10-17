namespace Proje02_Degiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             1) bir değişkene isim verirken alfa numerik karakterler kullanılmaz(alt tire( _ )hariç)
             2) türkçe karakter kullanılmaz
             3) özel ya ca ayrılmış sözcükler kullanılmaz (static vb.)
             4) Değişken isimleri küçük büyük harf duyarlıdır.
             5) ctrl+k+c komut satırı oluşturur
             6) ctrl+k+u komut satırını kaldırır.
            

            string adsoyad;
            string Adsoyad;
            string AdSoyad;
            string ad;
            string adSoyad; //tercih edilen değişken tanımlama "CAMELCASE" yapısı kullanılır.
            
            string adSoyad;
            adSoyad = "mehmet";
            Console.WriteLine(adSoyad);
            Console.WriteLine("adSoyad");

            \n alt satıra geçmek için
            \t  tab tuşu gibi yazıları ileri atıyor boşluk bırakma işine yarıyor.


            int yas;
            yas = 19;
            Console.WriteLine(yas);

            string adSoyad = "ahmet candan";
            Console.WriteLine(adSoyad);
            Console.WriteLine("adı:" + adSoyad + "  yaşı:" + yas);


            */
            //tam sayı
            int sayi1 = 45;
            byte sayi2 = 255;// byte veri tipi maximum 255 değerini tutar çünkü 1 byte 8 bittir. 8 bitte 255 sayısına tekamül ediyor
            //Console.WriteLine(byte.MinValue + "----" + byte.MaxValue);//byte. max ve min değeri.
            //Console.WriteLine(int.MinValue + "----" + int.MaxValue);//int max ve min değeri.
            long sayi3=125458498513;//64 bit değere sahip.
            //string sayi4 = "15";
            //Console.WriteLine(sayi4+2);//sayi4 değerinin yaına 2 değerini ekler çıktısı ==152 olur.

            // ondalıklı sayılar
            float a = 10.5f;//floatta sonuna f koymak zorundayız
            double b = 20.6;// sonuna d koymak zounlu deil fakat koyabiliriz.20.6d olabilir.
            decimal c = 100.65m;//decimalda sonuna m koymak zorundayız.

            //karakter ve metin
            string name = "hasancan";
            char cinsiyet = 'e';// tek tırnak ve içerisinde tek karakter tutar.

            //mantıksal
            bool evliMi = true;











        }
    }
}