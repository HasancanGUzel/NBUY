using ShoppingApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Category : IEntityBase  // yaptığımız uygulamadaki entity leri oluşturuyoruz burada Category oluşturduk ve IEntityBase den ortak olan özellikleri olan ıd yi buraya yerleştiridk
    { 
        // Category entity mizin   hangi özellikleri olucak tanımladık
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }  // yani burada  ProductCategory entitymizde bir category birden fazla product içerebilir  için  ProductCategory clasından properties stanımladık
    }
}
