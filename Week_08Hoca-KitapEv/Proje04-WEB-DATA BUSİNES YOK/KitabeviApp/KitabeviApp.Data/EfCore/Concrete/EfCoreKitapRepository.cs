using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Data.EfCore.Abstract;
using KitabeviApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Data.EfCore.Concrete
{
    public class EfCoreKitapRepository : IKitapRepository
    {
        public void KitapEkle(Kitap kitap)
        {
            using (var context = new KitabeviContext())
            {
                context.Kitaplar.Add(kitap);
                context.SaveChanges();
                
            }
        }

        public Kitap KitapGet(int id)
        {
             using (var context=new KitabeviContext())
           {
                return context.Kitaplar.Find(id);
           }
        }

        public void KitapGuncelle(Kitap kitap)
        {
             using (var context = new KitabeviContext())
            {
                context.Kitaplar.Update(kitap);
                context.SaveChanges();
                
            }
        }

        public List<Kitap> KitapListele(int? id = null)
        {
            using (var context = new KitabeviContext()) // context den kiatbeviContext nesne türetiyoruz ve geriye Kategorileri tablosunu gönderiyoruz
            {
               
                if (id == null) // burası kategori ıd si boş ise yaptık
                {
                    return  context
                        .Kitaplar // kitaplar tablosundaki tüm veriler içinde dönücek ama biz kategori id ve yazar id yerine adlarını getirmek isitoyurz
                        .Include(k => k.Kategori) // bunun için entity içindeki Kitap entity mizde sürekli dönücek id si eşit olanı ad olarak getiricek
                        .Include(k => k.Yazar)
                        .ToList();
                }
                else
                {
                    return  context
                        .Kitaplar
                        .Where(c => c.KategoriId == id)
                        .Include(k => k.Kategori)
                        .Include(k => k.Yazar)
                        .ToList();
                }
               
            }
        }

        public void KitapSil(Kitap kitap)
        {
             using (var context = new KitabeviContext())
            {
                context.Kitaplar.Remove(kitap);
                context.SaveChanges();
                
            }
        }
    }
}