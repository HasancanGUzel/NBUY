namespace Proje12_OOP_Work_01_HocaCozum
{
    interface IBase 
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
    class Bolum : IBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; }
    }
    class Ogrenci : IBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int OgrNo { get; set; }
        public int Yas { get; set; }
    }
    internal class Program
    {
        static string GirisYap(string baslik)
        {
            Console.Write(baslik);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<Bolum>bolumler=new List<Bolum>();
           
            for (int i = 0; i < 2; i++)
            {
                Bolum bolum = new Bolum();                
                bolum.Id = int.Parse(GirisYap($"{i+1}Bolum Id"));        //shift+alt tuşu        
                bolum.Ad = GirisYap($"{i + 1}Bolum Adı");
                bolum.Aciklama = GirisYap($"{i + 1}Bolum Aciklama");
                //Console.Write($"{i+1}.bölüm ıd:");
                //bolum.Id = int.Parse(Console.ReadLine());//metot tanımlamadan önce böyle yaptık
                //Console.Write($"{i + 1}.bölümün adı:");
                //bolum.Ad = Console.ReadLine();
                //Console.Write($"{i + 1}.bölümün açıklaması:");
                //bolum.Aciklama = Console.ReadLine();
                List<Ogrenci> ogrenciler = new List<Ogrenci>();
                for (int j = 0; j < 3; j++)
                {
                    Ogrenci ogrenci = new Ogrenci();
                    Console.Write($"{j + 1}.Öğrenci Id:");
                    ogrenci.Id = int.Parse(Console.ReadLine());
                    Console.Write($"{j + 1}.Öğrenci NUMARASI:");
                    ogrenci.OgrNo = int.Parse(Console.ReadLine());
                    Console.Write($"{j + 1}.Öğrenci adı:");
                    ogrenci.Ad = Console.ReadLine();
                    Console.Write($"{j + 1}.Öğrenci soyad:");
                    ogrenci.Soyad = Console.ReadLine();
                    Console.Write($"{j + 1}.Öğrenci yası:");
                    ogrenci.Yas = int.Parse(Console.ReadLine());
                    ogrenciler.Add(ogrenci);

                }
                bolum.Ogrenciler = ogrenciler;
                bolumler.Add(bolum);

            }
            foreach (var bolum in bolumler)
            {
                Console.WriteLine($"Bölüm Id={bolum.Id}-Bölüm adı={bolum.Ad}--Bölüm açıklaması={bolum.Aciklama}");
                foreach (var ogrenci in bolum.Ogrenciler)
                {
                    Console.WriteLine($"Öğrenci ıd=={ogrenci.Id}--Öğrenci numarası{ogrenci.OgrNo}--Öğrenci ad soyad{ogrenci.Ad} {ogrenci.Soyad}-öğrenci yas={ogrenci.Yas}");
                }
            }



            Console.ReadKey();
            
        }
    }
}