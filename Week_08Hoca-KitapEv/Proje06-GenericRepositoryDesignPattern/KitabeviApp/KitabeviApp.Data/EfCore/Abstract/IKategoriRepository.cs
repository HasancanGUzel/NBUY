using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKategoriRepository:IGenericRepository<Kategori>// burada IGenericRepository den hangi t�r al�ca��n� belirttik Burdaki Kategori Entity olan onu belirrtik
    {
      //Burada implemente etik ama g�z�km�yor fakat i�levi var CLASS gibi g�z�km�yor
    }
}