using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proje05_MVC_EfCore_CodeFirst.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } // buradaki Categories şimdi oluşturacağımız tablonun adı
        public DbSet<Product> Products { get; set; } // buradaki Products da tablonun adı
        public DbSet<City> Cities { get; set; }// buradaki Cities da tablonun adı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // DbContext de bulunna metodu ovverride ederek ezdik ve DbContextOptionsBuilder den üretilen optionsBuilder nesnesine sqlite olacak şekilde First.db veritabanını kullan diyoruz
        {
            optionsBuilder.UseSqlite("Data Source=First.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(//category tablom şunları içericek diyoruz
                    new Category() { Id = 1, Name = "Phone", Desc = "Phones" },
                    new Category() { Id = 2, Name = "Computer", Desc = "Computers" },
                    new Category() { Id = 3, Name = "Electronic", Desc = "Electronics" }
                );
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { Id = 1, Name = "Iphone13", Desc = "Güzel telefon", Price = 19000, CategoryId = 1 },
                    new Product() { Id = 2, Name = "Del Xside", Desc = "Güzel bilgisayar", Price = 15000, CategoryId = 2 },
                    new Product() { Id = 3, Name = "Samsung A-71", Desc = "Kamerası çok  güzel", Price = 17000, CategoryId = 1 },
                    new Product() { Id = 4, Name = "Piranha x-13", Desc = "Her yerde ses", Price = 1000, CategoryId = 3 }
                );
            modelBuilder.Entity<City>()
                .HasData(
                    new City() { Id = 34, Name = "İstanbul" },
                    new City() { Id = 35, Name = "İzmir" },
                    new City() { Id = 17, Name = "Çanakkale" }
                );
        }



    }
}