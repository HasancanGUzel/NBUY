using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Business.Abstract;
using KitabeviApp.Data.EfCore.Concrete;
using KitabeviApp.Entity;

namespace KitabeviApp.Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        public void KategoriEkle(Kategori kategori)
        {
            var kategoriRepository = new EfCoreKategoriRepository();
            kategoriRepository.KategoriEkle(kategori);
        }

        public Kategori KategoriGet(int id)
        {
            var kategoriRepository = new EfCoreKategoriRepository();
            return kategoriRepository.KategoriGet(id);
        }

        public void KategoriGuncelle(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> KategoriListele()
        {
            var kategoriRepository=new EfCoreKategoriRepository();
            return kategoriRepository.KategoriListele();
        }

        public void KategoriSil(Kategori kategori)
        {
            throw new NotImplementedException();
        }
    }
}