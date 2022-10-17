namespace Odev2_1_100_ArasıOrt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ödev1: 1-100 arasındaki sayıların ortalamasını bulduran program
            int toplam = 0;
            double ort = 0;
            double ort2=0;
            for (int i = 1; i <= 100; i++)
            {
                toplam += i;
                ort2 = toplam / 2;
                Console.WriteLine($"Sayı = {i} = {i}.sayıda ortalama = {ort2}");
            }
            ort = toplam / 2;
            Console.WriteLine("1-100 arasındaki sayıların ortalaması == {0}",ort);
        }
    }
}