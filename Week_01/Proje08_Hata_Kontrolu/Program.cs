namespace Proje08_Hata_Kontrolu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("1.sayıyı giriniz: ");
                int sayi1 = int.Parse(Console.ReadLine());
                Console.WriteLine("2.sayıyı giriniz: ");
                int sayi2 = int.Parse(Console.ReadLine());
                int sonuc = sayi1 / sayi2;
                Console.WriteLine("sonuc=={0}", sonuc);
            }

            catch (DivideByZeroException hata1)
            {
                Console.WriteLine("0 a bölünme hatası {0}", hata1);
            }
            //catch (DivideByZeroException)// yanına hata mesajını verdirmeyebiliriz
            //{
            //    Console.WriteLine("0 a bölünme hatası");
            //}
            catch (OverflowException)
            {
                Console.WriteLine("haddinden fazla sayı girdiniz");
            }

            catch (Exception hata)// birçok catch bloğu varsa en alta yazılır.
            {
                Console.WriteLine("bilinmeyen bir hata oluştu==== {0}", hata);
                Console.WriteLine("----------------------------");
                Console.WriteLine("hata mesajı==  " + hata.Message);//hata mesajını içeriğini verir.
            }
           
            finally//try catch programlarından hangisi çalışırsa çalışsın her halükarda çalışmasını istediğimiz kodlar çalışır.
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("program sona ermiştir");
            }

        }
    }
}