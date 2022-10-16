namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] random = { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","r","s","t","u","v","y","z","0","1","2","3","4","5","6","7","8","9",".",",","-","+"};
            Random rnd = new Random();
            string sonuc = "";
            for (int i = 0; i < 6; i++)
            {
                sonuc += random[rnd.Next(random.Length)];
                
            }
            Console.WriteLine(sonuc);
        }
    }
}