﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingApp.Data.Concrete.EfCore.Contexts;

#nullable disable

namespace ShoppingApp.Data.Migrations
{
    [DbContext(typeof(ShopAppContext))]
    partial class ShopAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b1507e7d-8ea8-4785-8575-e9617c5ea30c",
                            RoleId = "efd91364-c621-4921-8108-8885940f47c5"
                        },
                        new
                        {
                            UserId = "7364fe28-75cb-4ded-9f2d-df344deda93a",
                            RoleId = "8201ec98-f692-44fa-8e3d-7eaf8fdcba68"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = "b1507e7d-8ea8-4785-8575-e9617c5ea30c"
                        },
                        new
                        {
                            Id = 2,
                            UserId = "7364fe28-75cb-4ded-9f2d-df344deda93a"
                        });
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.CardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("ProductId");

                    b.ToTable("CardItems");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Telefonlar bu kategoride bulunmaktadır.",
                            Name = "Telefon",
                            Url = "telefon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Elektronik ürünler bu kategoride bulunmaktadır.",
                            Name = "Elektronik",
                            Url = "elektronik"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bilgisayarlar bu kategoride bulunmaktadır.",
                            Name = "Bilgisayar",
                            Url = "bilgisayar"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Beyaz eşyalar bu kategoride bulunmaktadır.",
                            Name = "Beyaz Eşya",
                            Url = "beyaz-esya"
                        });
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "efd91364-c621-4921-8108-8885940f47c5",
                            Description = "Admin rolü",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8201ec98-f692-44fa-8e3d-7eaf8fdcba68",
                            Description = "User rolü",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b1507e7d-8ea8-4785-8575-e9617c5ea30c",
                            AccessFailedCount = 0,
                            Adress = "Çek cd. Senet sk.Fatura ap.",
                            City = "İstanbul",
                            ConcurrencyStamp = "99345f52-7069-45f5-81f5-d16400068f70",
                            DateOfBirth = new DateTime(1998, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Deniz",
                            Gender = "Kadın",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAENmbH7vniPvYyFhAK+kPfTZN5xOoi2yPhMsgHe7yFTwd4D21STklefpCsN948aGnTg==",
                            PhoneNumber = "5555555555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cf4e4a62-727d-440d-8119-8d30d0e85d95",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "7364fe28-75cb-4ded-9f2d-df344deda93a",
                            AccessFailedCount = 0,
                            Adress = "Akasya cd. Orkide sk.Gül ap.",
                            City = "İzmir",
                            ConcurrencyStamp = "fb202063-ffe5-4d47-a577-8649e0ad039e",
                            DateOfBirth = new DateTime(1985, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Kemal",
                            Gender = "Erkek",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAEAv3yjpyVpMrw1F1a2hiwPzigk/hhFSKyMh5K0SZVLJ34vHAswCQ9AJbRMwVh28/1Q==",
                            PhoneNumber = "44444444444",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fd1bb907-e614-43dc-b76f-fad00dc60fd2",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("date('now')");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kamerası son teknoloji!",
                            ImageUrl = "1.png",
                            IsApproved = true,
                            IsHome = true,
                            Name = "Samsung S20",
                            Price = 24500m,
                            Url = "samsung-s20"
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kamerası son teknoloji, 5G!",
                            ImageUrl = "2.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Samsung S21",
                            Price = 34500m,
                            Url = "samsung-s21"
                        },
                        new
                        {
                            Id = 3,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Güzel bir telefon",
                            ImageUrl = "3.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Iphone 13",
                            Price = 21500m,
                            Url = "iphone-13"
                        },
                        new
                        {
                            Id = 4,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kamerası son teknoloji!",
                            ImageUrl = "4.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Iphone 14 Pro",
                            Price = 34500m,
                            Url = "iphone-14-pro"
                        },
                        new
                        {
                            Id = 5,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kamerası son teknoloji!",
                            ImageUrl = "5.png",
                            IsApproved = false,
                            IsHome = true,
                            Name = "IPad 12",
                            Price = 4500m,
                            Url = "ipad-12"
                        },
                        new
                        {
                            Id = 6,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "1.5 metre",
                            ImageUrl = "15.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Type C Usb Bağlantı Kablosu",
                            Price = 400m,
                            Url = "type-c-usb-baglanti-kablosu"
                        },
                        new
                        {
                            Id = 7,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Tam otomatik çamaşır makinesi",
                            ImageUrl = "20.png",
                            IsApproved = true,
                            IsHome = true,
                            Name = "Vestel CM123",
                            Price = 9500m,
                            Url = "vestel-cm123"
                        },
                        new
                        {
                            Id = 8,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Köpüklü Türk kahvesi keyfi",
                            ImageUrl = "16.png",
                            IsApproved = true,
                            IsHome = true,
                            Name = "Arçelik Türk Kahvesi Makinesi TK8",
                            Price = 24500m,
                            Url = "arcelik-turk-kahvesi-makinesi-tk8"
                        },
                        new
                        {
                            Id = 9,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "M2 işlemcinin gücü",
                            ImageUrl = "17.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Macbook Air M2",
                            Price = 29500m,
                            Url = "macbook-air-m2"
                        },
                        new
                        {
                            Id = 10,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I9 işlemci",
                            ImageUrl = "21.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Asus Tulpar G45",
                            Price = 26500m,
                            Url = "asus-tulpar-g45"
                        },
                        new
                        {
                            Id = 11,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İş için ideal",
                            ImageUrl = "22.png",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Lenovo K234",
                            Price = 19000m,
                            Url = "lenovo-k234"
                        },
                        new
                        {
                            Id = 12,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Derin donduruculu",
                            ImageUrl = "19.png",
                            IsApproved = false,
                            IsHome = false,
                            Name = "Samsung NF34 Buzdolabı",
                            Price = 13000m,
                            Url = "samsung-nf34-buzdolabi"
                        });
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Card", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.CardItem", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Card", "Card")
                        .WithMany("CardItems")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingApp.Entity.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Order", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.OrderItem", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Order", "Order")
                        .WithMany("OrderItams")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingApp.Entity.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.ProductCategory", b =>
                {
                    b.HasOne("ShoppingApp.Entity.Concrete.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingApp.Entity.Concrete.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Card", b =>
                {
                    b.Navigation("CardItems");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Order", b =>
                {
                    b.Navigation("OrderItams");
                });

            modelBuilder.Entity("ShoppingApp.Entity.Concrete.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
