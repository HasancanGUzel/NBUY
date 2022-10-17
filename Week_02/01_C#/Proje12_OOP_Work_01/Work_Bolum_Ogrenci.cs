using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje12_OOP_Work_01
{
    public class Bolum
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        
    }
    public class Aciklama :Bolum
    {
        public string Aciklamaa { get; set; }
        public List<Ogrenci> aciklama { get; set; }
    }
    public class Ogrenci : Bolum
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int OgrNo { get; set; }
        public int Yas { get; set; }
        
    }





}
