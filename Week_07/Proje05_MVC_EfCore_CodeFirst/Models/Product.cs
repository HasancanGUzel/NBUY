using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje05_MVC_EfCore_CodeFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }// Category türünde yani tablomuzun türünde Category adında kolon tanımladık
        // kategori Id si ne ise o Id ye karşılık gelen ismi yazdırmak için

    }
}