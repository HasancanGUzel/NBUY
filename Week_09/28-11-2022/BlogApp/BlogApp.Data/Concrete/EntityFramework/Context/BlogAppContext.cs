using BlogApp.Data.Concrete.EntityFramework.Mappings;
using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EntityFramework.Context
{
    public class BlogAppContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OFVK2FD;Integrated Security=True;Database=BlogAppDb;TrustServerCertificate=True;");
            #region MyRegion
            //EntityFrameworkCore 7 ile SqlServer veri tabanına bağlantı ile ilgili önemli bir değişiklik olmuştur.
            // Bu da güvenlik amacıyla doğrulanmış sertifika gereksinimidir. Bunu ifade eden TrustServerCertificate özelliği,
            // böyle bir sertifika yoksa true ye çekilmelidir. Çünkü default olarak false dir. False iken maalesef veritabanına
            // bağlansa bile izin vermez
            #endregion
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());//article map ile yazılanların burada geçerli olmasını sağlar
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
