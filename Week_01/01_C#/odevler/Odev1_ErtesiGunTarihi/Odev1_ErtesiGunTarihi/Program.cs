namespace Odev1_ErtesiGunTarihi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------OOOOOODEEEEEEVVVVVVV---------------

            // ertesi günün tarihi bulup ekrana yazdıran program yazınız.
            DateTime bugun = DateTime.Now;
            int day = bugun.Day + 1;
            int yil = bugun.Year;
            int ay = bugun.Month;
            DateTime sonuc = new DateTime(yil, ay, day);
            Console.WriteLine(sonuc.ToLongDateString());
        }
    }
}