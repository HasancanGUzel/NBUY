namespace Proje05_MetinselMetotlar;
class Program
{
    static void Main(string[] args)
    {
        //bu projede metinsel işlmelere dair bazı metotlar öğreneceğiz

        //string metin = "Wissen Akademie";
        //int uzunluk = metin.Length;
        ////Console.WriteLine($"uzunluk: {uzunluk}");
        //Console.WriteLine($"{metin} metni {uzunluk} karakterdir");

        //string metin = "WİSSEN";
        //string kucukMetin = metin.ToLower();// metini küçük harflere dönüştürür
        //Console.WriteLine(kucukMetin);
        //string buyukMetin=kucukMetin.ToUpper();// metini büyük harfe dönüştürür
        //Console.WriteLine(buyukMetin);


        //string m1 = "Wissen";
        //string m2 = "Wissen Akademia";
        //int sonuc=String.Compare(m1, m2);// stringin ""S"" si büyük değer tipi değildir iki metini karşılaştırıp 1. ve 2. metine göre -1  0 ve 1 değerini döndrüyor
        //Console.WriteLine(sonuc);


        //Console.WriteLine("1.değeri giriniz");
        //string m1 =Console.ReadLine();
        //Console.WriteLine("2. değeri giriniz");
        //string m2 =Console.ReadLine();
        //int sonuc=String.Compare(m1,m2);
        //if (sonuc == 1)
        //{
        //    Console.WriteLine("1.değer daha büyüktür");
        //}
        //else if (sonuc == -1)
        //{
        //    Console.WriteLine("2.değer daha büyüktür");
        //}
        //else if (sonuc==0)
        //{
        //    Console.WriteLine("girilen iki metin birbiririne eşittir");
        //}


        /*
        string m1 = "işkur";
        string m2 = "eğitimleri";
        string m3 = "wissen";
        //string sonuc = m1 + m2+m3;
        string sonuc = String.Concat(m1 + m2+m3);//metinleri birleştirmeye yarar.
        Console.WriteLine(sonuc);
        */

        //string ad = "Hasan";
        //int yas = 22;
        //string okul = "BAU";
        //Console.WriteLine($"Benim Adım {ad} {yas} yaşındayım. okuduğum okulun adı {okul}");
        //Console.WriteLine("benim adım "+ ad +"," + yas+" yaşındayım. okuduğum okul "+okul);
        //string sonuc = String.Concat("benim adım  "  + ad+ "," +  yas + "," +  " yaşındayım okuduğum okul "  + okul);
        //Console.WriteLine(sonuc);

        //string metin = "Merhaba. Bu hafta eğitime başladık.";
        //Console.WriteLine("hangi metini bulmak istiyorsunuz");
        //string m1=Console.ReadLine();
        //bool sonuc = metin.Contains(m1);//contains istedeğimiz kelimeyi metnin içinde varmı yokmu
        //if (sonuc == true)
        //{
        //    Console.WriteLine("bu metin bulunmaktadır metin==" + m1);
        //}
        //else
        //{
        //    Console.WriteLine("metin bulunmamaktadır==" + m1);
        //}
        ////Console.WriteLine(sonuc);

        //string adres = "selami ali mh. Can sk. no:6 kadıköy / istanbul";
        //bool sonuc = adres.EndsWith("istanbul");//endswith sonu ne ile bitiyorsa onu gösterir.
        //bool sonuc2 = adres.StartsWith("istanbul");//starswith başlangıcı ne ile başlıyorsa onu gösterir
        //Console.WriteLine(sonuc);
        //Console.WriteLine(sonuc2);

        // indexof adres içindeki bir harfin kaçıncı sırada olduğunu bulmak için kullanılır

        //string aranacakIfade = "c";
        //int siraNo = adres.ToLower().IndexOf(aranacakIfade.ToLower());
        //Console.WriteLine($"c harfi {adres} içerisinde {siraNo} sıradadır");

        //string metin = "Wissen Akademie";
        //Console.WriteLine($"metnin ilk hali:{metin}");
        //Console.WriteLine($"Akademie metni silindikten sonraji hali:{metin.Remove(7)}");// metin de 7. karakterden başlayıp sonrasını komple siliyor

        //Console.WriteLine($"Aka ifadesi silindikten sonraki hali:{metin.Remove(7,3)}");// metinde 7. karekterden başlayıp belirlediğimiz index kadar siliyor.


        //string urunAd = "Iphone 13 Pro";
        ////iphone-13-pro döüştürücez.
        ////string sonuc = (urunAd.Replace(" ","-")).ToLower();// string null olabilir amam char içi boş olamaz.
        //string sonuc = urunAd.ToLower().Replace(" ", "-");// üstteki satırla aynı daha sadesi.
        //Console.WriteLine("yeni metin={0}",sonuc);//Console.WriteLine($"yeni metin=={sonuc}"); aynı sonucu verir.
        //string sonuc2 = urunAd.Replace("Iphone", "Samsung");
        //Console.WriteLine("ynei metin={0}",sonuc2);












    }
}
