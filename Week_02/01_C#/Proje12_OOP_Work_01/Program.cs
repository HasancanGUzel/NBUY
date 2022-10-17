namespace Proje12_OOP_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Ogrenci> ogrenci1 = new List<Ogrenci>() { };
            //List<Ogrenci> ogrenci2= new List<Ogrenci>() { };
            //List<Ogrenci> ogrenci3= new List<Ogrenci>() { };
            //List<Ogrenci> ogrenci4= new List<Ogrenci>() { };
            //List<Ogrenci> ogrenci5= new List<Ogrenci>() { };
            //List<Ogrenci> ogrenci6 = new List<Ogrenci>() { };

            //List<Aciklama> bolum1 = new List<Aciklama>() { };
            //List<Aciklama> bolum2 = new List<Aciklama>() { };


            List<Aciklama> aciklamaaa = new List<Aciklama>()
            {
                for (int i = 0; i < 2; i++)
            {

            }
                new Aciklama(){Id=1,Ad=Console.ReadLine(),Aciklamaa=Console.ReadLine(),aciklama=new List<Ogrenci>()
                {
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int.Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int .Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int .Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                }

                },
                 new Aciklama(){Id=1,Ad= Console.ReadLine(),Aciklamaa=Console.ReadLine(),aciklama=new List<Ogrenci>()
                {
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int .Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int .Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                    new Ogrenci(){Id=1,Ad=Console.ReadLine(),Soyad=Console.ReadLine(),OgrNo=int .Parse(Console.ReadLine()),Yas=int .Parse(Console.ReadLine())},
                }

                }
                   };
            foreach (var cıktı in aciklamaaa)
            {
                Console.WriteLine($"{cıktı.Id}::category={cıktı.Aciklamaa}");
                foreach (var product in cıktı.aciklama)
                {
                    Console.WriteLine($"\t ıd:{product.Id}-product ad:{product.Ad}-Product soyad{product.Soyad}");
                }
            }
       



        }
    }
}