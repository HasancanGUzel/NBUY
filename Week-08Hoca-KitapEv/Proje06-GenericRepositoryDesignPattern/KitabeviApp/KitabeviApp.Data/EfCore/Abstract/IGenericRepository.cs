using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IGenericRepository<T>//BURDAKİ T bizim data daki abstract içinde bulunan  Diğerinterfaclaerin hangisini olduğunu algılıcak
    {
        T Getir(int id);
        List<T> Listele();
        void Ekle(T varlik);
        void Guncelle(T varlik);
        void Sil(T varlik);
    }
}
