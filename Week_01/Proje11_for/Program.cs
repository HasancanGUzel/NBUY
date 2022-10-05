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

            int sonuc = 0;
            int tek = 0;
            for (int j = 0; j <= 10; j++)
            {
                if (j % 2 == 0)
                {
                    sonuc += j;
                    
                }
                else
                {
                    tek += j;
                    
                }
                
            }
            Console.WriteLine("tek toplam=={0}, çift toplam {1}", tek, sonuc);
        }
    }
}