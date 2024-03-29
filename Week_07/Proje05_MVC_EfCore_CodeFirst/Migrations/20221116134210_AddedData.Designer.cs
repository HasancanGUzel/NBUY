﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje05_MVC_EfCore_CodeFirst.Models;

#nullable disable

namespace Proje05_MVC_EfCore_CodeFirst.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221116134210_AddedData")]
    partial class AddedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("Proje05_MVC_EfCore_CodeFirst.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Phones",
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Computers",
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Electronics",
                            Name = "Electronic"
                        });
                });

            modelBuilder.Entity("Proje05_MVC_EfCore_CodeFirst.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 34,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 35,
                            Name = "İzmir"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Çanakkale"
                        });
                });

            modelBuilder.Entity("Proje05_MVC_EfCore_CodeFirst.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Desc = "Güzel telefon",
                            Name = "Iphone13",
                            Price = 19000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Desc = "Güzel bilgisayar",
                            Name = "Del Xside",
                            Price = 15000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Desc = "Kamerası çok  güzel",
                            Name = "Samsung A-71",
                            Price = 17000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Desc = "Her yerde ses",
                            Name = "Piranha x-13",
                            Price = 1000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
