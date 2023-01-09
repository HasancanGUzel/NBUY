//using Solid04_LiskovsSubstitution.Before;
using Solid04_LiskovsSubstitution.After;

namespace Solid04_LiskovsSubstitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Before
            //Guvercin guvercin = new Guvercin();
            //Console.WriteLine(guvercin.UcmaMesafesi); 
            //Penguen penguen = new Penguen();
            //Console.WriteLine(penguen.UcmaMesafesi);
            //Kus[] kuslar = { new Guvercin(), new Penguen(), new Serce() };
            //foreach (var kus in kuslar)
            //{
            //    Console.WriteLine(kus.UcmaMesafesi);
            //}
            #endregion
            #region After
            Kus[] kuslar = { new Guvercin(), new Penguen() };
            foreach (var kus in kuslar)
            {
                Console.WriteLine(kus.UcmaMesafesi());
            }
            #endregion
            Console.ReadLine();
        }
    }
}