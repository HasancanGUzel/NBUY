using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IYazarRepository
    {
        List<Yazar>YazarListele();// geriye Yazar türünde veri döndüreceğimiz için Yazar türünde List tanımlıyoruz
        void YazarEkle(Yazar yazar);
        void YazarGuncelle(Yazar yazar);
        void YazarSil(Yazar yazar);
        Yazar YazarGet(int id);// Yazar türünde tek bir veri döndürüyor bizde böyle yazdık bunu Yazar silin get metodunda kullandım
        
    }
}