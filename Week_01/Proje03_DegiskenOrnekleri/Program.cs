namespace Proje03_DegiskenOrnekleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int sayi1 = 120;
            int sayi2 = 110;
            Console.WriteLine(sayi1+ "\n"+ sayi2);// sayi1 ve sayi2 değişkenini tek cw de alt satıra geçerek yazma

            Console.WriteLine($"sayi1: {sayi1} \nsayi2: {sayi2}");//$ sayi1 ve sayi2 yi aynı tırnak içinde yazmaya yarıyor.

            Console.WriteLine(sayi1+sayi2);// int değer olduğu için topluyor

            Console.WriteLine(sayi1.ToString()+sayi2.ToString());//sayi1 ve sayi2 yi stringe çevirdik yan yana yazdı

            string sayi3 = "110";
            int sayi4 = 120;

            Console.WriteLine(sayi3+sayi4);//işleme girenlerden biri string ise artıyı toplama değilde birleştirme için kullanır.

            Console.WriteLine(Convert.ToInt32(sayi3)+Convert.ToInt32(sayi4));//sayi3 ve sayi4 stringdi ve biz yan yana değilde toplamk istiyorduk bu yüzden int e çevrdik.

            */
            //double sayi1 = 0.1;  Console.WriteLine(sayi1+sayi2); sonucu 8 çıkmaz 0.7999999 gibi çıkar  ve                        Console.WriteLine((sayi1+sayi2)==sayi3); buda eşit çıkmaz bunu için ya                          decimal ya da float kullanırız çünkü double hassas değil
            //double sayi2 = 0.7;
            //double sayi3 = 0.8;

            float sayi1 = 0.1f;
            float sayi2 = 0.7f;
            float sayi3 = 0.8f;
            Console.WriteLine(sayi1);
            Console.WriteLine(sayi2);
            Console.WriteLine(sayi3);

            Console.WriteLine(sayi1+sayi2);
            Console.WriteLine((sayi1+sayi2)==sayi3);




        }
    }
}