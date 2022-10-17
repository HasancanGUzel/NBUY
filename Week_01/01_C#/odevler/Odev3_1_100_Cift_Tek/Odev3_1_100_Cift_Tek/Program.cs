namespace Odev3_1_100_Cift_Tek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ödev2: 1-100 arasındaki çift tek ve 5 in katı olan sayıların adetleri ve toplamlarını ekrana yazdrıan program.
            int tek = 0;
            int tekadet = 0;
            int cift = 0;
            int ciftadet = 0;
            int kat5 = 0;
            int katadet = 0;
            for (int i = 1; i <=5; i++)
            {
                if (i % 2 == 0 && i % 5 == 0)
                {

                    cift += i;
                    ciftadet++;
                    kat5 += i;
                    katadet++;
                }
                else if (i % 2 == 0)
                {
                    cift += i;
                    ciftadet++;
                }
                else if (i % 2 == 1 && i % 5 == 0)
                {
                    tek += i;
                    tekadet++;
                    kat5 += i;
                    katadet++;
                }
                else if (i%5==0)
                {
                    kat5 += i;
                    katadet++;
                }
                
                else if (i%2==1)
                {
                    tek += i;
                    tekadet++;
                }
            }
            Console.WriteLine("Çift sayıların toplamı == {0} ve çift sayıların adedi == {1}",cift,ciftadet);
            Console.WriteLine("Tek sayıların toplamı == {0} ve Tek sayıların adedi == {1}",tek,tekadet);
            Console.WriteLine("5 in katı sayıların toplamı == {0} ve 5 in katı sayıların adedi =={1}",kat5,katadet);

        }
    }
}