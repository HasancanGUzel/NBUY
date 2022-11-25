using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKategoriRepository:IGenericRepository<Kategori>// burada IGenericRepository den hangi tür alýcaðýný belirttik Burdaki Kategori Entity olan onu belirrtik
    {
      //Burada implemente etik ama gözükmüyor fakat iþlevi var CLASS gibi gözükmüyor
    }
}