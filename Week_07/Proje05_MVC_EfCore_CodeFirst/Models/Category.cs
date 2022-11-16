using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje05_MVC_EfCore_CodeFirst.Models
{
    public class Category // veritabanında oluşturacağım categories tablosundaki kolonlara karşılık gelen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}