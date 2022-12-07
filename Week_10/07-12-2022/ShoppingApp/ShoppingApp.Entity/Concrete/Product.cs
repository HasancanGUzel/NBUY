using ShoppingApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Product : IEntityBase  // yaptığımız uygulamadaki entity leri oluşturuyoruz burada product oluşturduk ve IEntityBase den ortak olan özellikleri olan ıd yi buraya yerleştiridk
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public decimal? Price { get; set; } // nulabble yapar , ürünün fiyatı 0 olma ihtimaline karşı
        public string Description { get; set; }
        public string ImageUrl { get; set; }// kullancı product girerken  sunucumuzadaki resmin yolunu tutmak için 
        public string Url { get; set; }
        public bool IsHome { get; set; }// anasayfa ürünümü değilmi için
        public bool IsApproved { get; set; } // onaylımı değilmi için
        public DateTime DateAdded { get; set; } // productın eklenme tarihi için 

        public List<ProductCategory> ProductCategories { get; set; } // yani burada  ProductCategory entitymizde bir product birden fazla categoryde olabildiği için  ProductCategory clasından properties stanımladık
    }
}
