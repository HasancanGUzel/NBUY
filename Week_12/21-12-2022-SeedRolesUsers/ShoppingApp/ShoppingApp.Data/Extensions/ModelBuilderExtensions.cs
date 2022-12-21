using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder) // bunu biz shoppappcontextde  modelbuilder. dediğimizde metot olarak oluşturuyoruz progrmaın başlangıcında admin ve user oluşturmak için
        {

            #region Rol bilgileri
            //rol bilgileri oluşturulup ekleniyor
            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Name="Admin",
                    Description="Admin Rolü",
                    NormalizedName="ADMIN"
                },
                  new Role
                {
                    Name="User",
                    Description="User Rolü",
                    NormalizedName="USER"
                },
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region  Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Deniz",
                    LastName="Admin",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Gender="Kadın",
                    DateOfBirth=new DateTime(1998,5,19),
                    Email="admin@gmail.com",
                    NormalizedEmail="ADMIN@GMAIL.COM",
                    EmailConfirmed=true
                },

                new User
                {
                    FirstName="Kemal",
                    LastName="User",
                    UserName="user",
                    NormalizedUserName="USER",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1985,10,29),
                    Email="user@gmail.com",
                    NormalizedEmail="USER@GMAIL.COM",
                    EmailConfirmed=true
                },
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Parola İşlemleri
            var passwordHasher=new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");//admin için

            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");//user için
            #endregion

            #region KUllanıcı Rol atama işlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles.First(r=>r.Name=="Admin").Id // ilk  karşılaştığın admin rolü nü bana getir dedik
                },
                 new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id // ilk  karşılaştığın user rolü nü bana getir dedik
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

        }
    }
}
