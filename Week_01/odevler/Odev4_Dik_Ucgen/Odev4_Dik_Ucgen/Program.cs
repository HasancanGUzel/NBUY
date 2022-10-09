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
            Console.Write("Yüksekliği giriniz");
            int yuksek = int.Parse(Console.ReadLine());
            Console.Write("Taban giriniz");
            int taban = int.Parse(Console.ReadLine());
            for (int i = 0; i < yuksek; i++)
            {

                for (int j = 0; j <= taban; j++)
                {
                    Console.Write("*");
                }
                taban -= 2;



                Console.WriteLine();
            }





        }
    }
}