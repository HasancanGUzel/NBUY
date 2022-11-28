using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);//primary key

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c=>c.Name).IsRequired().HasMaxLength(70);

            builder.Property(c=>c.Description).HasMaxLength(50);

            builder.Property(c=>c.CreatedByName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.ModifiedByName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CreatedDate).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.IsActive).IsRequired();

            builder.Property(c => c.IsDeleted).IsRequired();

            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Categories");

            //ilk category verileri ekleniyor

            builder.HasData(
                new Category
                {
                    Id= 1,
                    Name="C#",
                    Description="C# programlama dili ile ilgili makaleler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreated",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitiailCreated",
                    ModifiedDate = DateTime.Now,
                    Note = "user Kullanıcısı .",
                },

                 new Category
                 {
                     Id = 2,
                     Name = "Javascript",
                     Description = "javascript programlama dili ile ilgili makaleler",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreated",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitiailCreated",
                     ModifiedDate = DateTime.Now,
                     Note = "Javascript Kullanıcısı .",
                 },
                  new Category
                  {
                      Id = 3,
                      Name = "React",
                      Description = "React js programlama dili ile ilgili makaleler",
                      IsActive = true,
                      IsDeleted = false,
                      CreatedByName = "InitialCreated",
                      CreatedDate = DateTime.Now,
                      ModifiedByName = "InitiailCreated",
                      ModifiedDate = DateTime.Now,
                      Note = " React js Kullanıcısı .",
                  }
                );

        }
    }
}
