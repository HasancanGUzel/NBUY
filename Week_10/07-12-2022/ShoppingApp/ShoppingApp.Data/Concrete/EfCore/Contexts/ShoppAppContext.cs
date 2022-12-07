using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Config;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Contexts
{

    //buraya geçmeden önce  data katmanının dependencies ine nuget packages eklemek gerek biz  Microsoft.EntityFrameworkCore.Design bunu ve  Microsoft.EntityFrameworkCore.Sqlite bunu ekledik
    public class ShoppAppContext:DbContext  // bizim data katamnımızdaki CONCRETE dosyamızda  farklı farklı veritabnlarıdan çalışılabilri diye oluştururldu yani bizim EfCore dosyasının  içindeki Contexts dosyası sadece sqlite bağlanıyor
    {
        public DbSet<Category> Categories { get; set; } // burada biz Category entitimizden veritabanına propları oluşturmak için  Categories adında tablo oluşturduk
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ShoppingApp.db"); // burada veritabanı bağlantımızı yapıyoruz ve  ShoppingApp.db bu adda veritabanı yoksa otomatik bu adda veritabanı açıcak olsaydı bunu açıcaktı
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurasyonlarımızı uygulucaz yani Blog App deki gibi articlemap ayrı klasörden bağlantı yapıcaz
            //burada Config klasöründeki classlaı ekliyoruz
            // bunu yapmamızdaki amaç burda da yapabiliridk ama burada fazla yer kaplıyor ayrı bir kalsörde tutup burada çağırıyoruz.
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
        }

    }
}
