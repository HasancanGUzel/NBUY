using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.Entity
{
    public class Kategori // KitabeviApp.Web içindeki models klasöründe bulunuyorlardı bizde katmanlı mimari yapısına uyarlamak için models leri entity klasörüne taşıdık
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
    }
}