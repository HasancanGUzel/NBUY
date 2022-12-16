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
    public class ShopAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopAppContext(DbContextOptions<ShopAppContext> dbContextOptions) : base(dbContextOptions)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=ShoppingApp.db");
               // artık bağlantıyı burada değilde program.cs de yaptık ve oraya bağlantıyı  appsettings deb aldık
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
        }
    }
}
