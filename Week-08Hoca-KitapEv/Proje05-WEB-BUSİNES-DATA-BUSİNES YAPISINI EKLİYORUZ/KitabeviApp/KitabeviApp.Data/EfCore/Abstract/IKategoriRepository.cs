using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKategoriRepository
    {
        List<Kategori>KategoriListele();// geriye Kategori türünde veri döndüreceğimiz için Kategori üründe List tanımlıyoruz
        void KategoriEkle(Kategori kategori);
         void KategoriGuncelle(Kategori kategori);
         void KategoriSil(Kategori kategori);
         Kategori KategoriGet(int id); // Kateori türünde tek bir veri döndürüyor bizde böyle yazdık bunu Kategori silin get metodunda kullandım
    }
}