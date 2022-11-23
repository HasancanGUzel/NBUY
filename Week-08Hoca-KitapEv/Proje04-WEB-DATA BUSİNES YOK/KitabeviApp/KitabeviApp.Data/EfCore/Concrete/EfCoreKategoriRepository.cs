using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Data.EfCore.Abstract;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Concrete
{
    public class EfCoreKategoriRepository:IKategoriRepository // IKategoriRepository türetiyoruz
    {
        
        public List<Kategori>KategoriListele()
        {
            using (var context = new KitabeviContext()) // context den kiatbeviContext nesne türetiyoruz ve geriye Kategorileri tablosunu gönderiyoruz
            {
                return context.Kategoriler.ToList();
            }
        }

        public void KategoriEkle(Kategori kategori)
        {
            using (var context =new KitabeviContext())
            {
                context.Kategoriler.Add(kategori);
                context.SaveChanges();
            }
        }

        public void KategoriGuncelle(Kategori kategori)
        {
            using (var context =new KitabeviContext())
            {
                context.Kategoriler.Update(kategori);
                context.SaveChanges();
            }
        }

        public void KategoriSil(Kategori kategori)
        {
            using (var context =new KitabeviContext())
            {
                context.Kategoriler.Remove(kategori);
                context.SaveChanges();
            }
        }

        public Kategori KategoriGet (int id)
        {
           using (var context=new KitabeviContext())
           {
             return context.Kategoriler.Find(id);
            

           }
        }
    }
}