using System.Runtime;

namespace Odev4_Dik_Ucgen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ödev3:Aşağıdaki yüksekliği 5 tabanı 9 birim olan yıldızlardan oluşan dik üçgeni çizdiren program.
            /*
             * *
             * ***
             * *****
             * *******
             * *********
             */

            int sayac = 1;
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < sayac; j++)
                {
                    Console.Write("*");

                }
                sayac += 2;
                Console.WriteLine();
            }

            //Console.Write("Yüksekliği giriniz");
            //int yuksek = int.Parse(Console.ReadLine());// klavyeden girilerek istenilen değeregöre ters üçgen yapımı.
            //Console.Write("Taban giriniz");
            //int taban = int.Parse(Console.ReadLine());
            //for (int i =0; i < yuksek; i++)
            //{

            //    for (int j = 1; j <= taban; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    taban -= 2;   
            //}







        }
    }
}