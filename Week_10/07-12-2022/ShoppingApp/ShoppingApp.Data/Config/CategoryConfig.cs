using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        // oluşucak veritabanında category tablosununun bu özellikler olucak diyoruz
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);//primary key burası olucak
            builder.Property(c => c.Id).ValueGeneratedOnAdd();// id nin 1 den başlayıp 1er 1 er artmasını sağlar

            builder.Property(c => c.Name)
                .IsRequired()//Zorunlu alan dedik
                .HasMaxLength(50);// buda uzunluğu

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.Url)
               .IsRequired()
               .HasMaxLength(250);

            builder.ToTable("Categories");// buda veritabanında hangi isimle tablo oluşacaksa o ismi verebilizi ama zaten biz ShoppAppContext aynı ismi vermiştik burda farklı isim verebiliriz.

            builder.HasData( // burda tabloya şimdilik veri ekliyoruz
                new Category // burda Category entitmizdeki proplarına veri ekliyoruz.
                {
                    Id = 1,
                    Name = "Telefon",
                    Description = "Telefonlar bu kategoride bulunmaktadır",
                    Url = "telefon"
                },
                new Category // burda Category entitmizdeki proplarına veri ekliyoruz.
                {
                    Id = 2,
                    Name = "Elektronik",
                    Description = "Elektornik ürünler bu kategoride bulunmaktadır",
                    Url = "elektronik"
                },
                new Category // burda Category entitmizdeki proplarına veri ekliyoruz.
                {
                    Id = 3,
                    Name = "Bilgisayar",
                    Description = "Bilgisayarlar bu kategoride bulunmaktadır",
                    Url = "bilgisayar"
                },
                new Category // burda Category entitmizdeki proplarına veri ekliyoruz.
                {
                    Id = 4,
                    Name = "Beyaz Eşya",
                    Description = "Beyaz Eşyalar bu kategoride bulunmaktadır",
                    Url = "beyaz-esya"
                }
                );

        }
    }
}
