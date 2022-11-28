using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKitapRepository
    {
        List<Kitap>KitapListele(int? id = null);// geriye Kitap türünde veri döndüreceğimiz için Kitap üründe List tanımlıyoruz
        void KitapEkle(Kitap kitap);
        void KitapGuncelle(Kitap kitap);
        void KitapSil(Kitap kitap);
        Kitap KitapGet(int id);// Kitap türünde tek bir veri döndürüyor bizde böyle yazdık bunu Kitap silin get metodunda kullandım

        
    }
}