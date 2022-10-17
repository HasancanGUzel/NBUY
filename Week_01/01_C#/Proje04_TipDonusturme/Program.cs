namespace Proje04_TipDonusturme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //byte a = 5;
            //short b = 10;
            //sbyte c = -30;//byte negatif değer almaz 0-255 arası ama sbyate negatif değer alır -127 ile 128 arasında
            //int d = a + b + c;// implicit convert - örtülü dönüştürme
            //Console.WriteLine($"sonuç(d)={d}");

            //string metin = "NBUY";
            //char karakter = 'k';
            //object e = metin + karakter + d;//değişkenlerin tipini ayırt etmeksizin yan yana yazmaya yarar object yerine int yazsaydık hata verirdi.()()()örtülü dönüşüm implicit convert
            //Console.WriteLine($"object={e}");

            // byte a = 155;
            // byte b = 101;
            //// byte c = a+b;//kabul etmez byte değeri 255 tir ama sonuç 256== bu çalışmadan hata verir
            // //byte c=Convert.ToByte(a+b); // explicit convert - bilinçli dönüşüm çalışana kadar hata vermez ama çalıştıktan sonra hata verir
            // //Console.WriteLine($"sonuç: {c}");
            // byte d = (byte)(a + b);// sonucu byte döüştürüp çıkan sonucun 8 bitlik kısmını alıyor yazdırıryor.
            // Console.WriteLine($"sonuç: {d}");

            //int a = 513;
            //byte b = (byte)a;
            //Console.WriteLine(b);

            byte a = 155;
            byte b = 111;// byte değerlerinin toplamını int ile tanıladığım değişkene atıyorum onu ekrana yazdırıyorum.
            int c = a + b;
            Console.WriteLine(c);

            

       
           


        }
    }
}