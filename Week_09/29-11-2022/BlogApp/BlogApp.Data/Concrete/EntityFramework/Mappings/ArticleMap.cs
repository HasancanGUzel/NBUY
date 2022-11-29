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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            #region Açıklama
            //Burada efcore tarafından default convetion yöntemiyle kendiliğinden gerçekleşen bazı ayarları el ile yapıyor olacağız.Bu daha profesyonel sürüdürülebilir genişletilebilir uygulamalar yapmak için tercih edilen bir yoldur.
            #endregion
            //haskey article builderına primery key tanımlıyor
            builder.HasKey(a => a.Id);//primary key shared içindeki abstract içindeki entity içindeki Id
            builder.Property(a=>a.Id).ValueGeneratedOnAdd();//yeni veri eklendiğinde Id yi 1-1 artırıyoruz parantez içine yazacağımız değere göre kaç kaç arttığı değişir
            builder.Property(a => a.Title).IsRequired();//zorunlu(varsayılan true zorunlu) burdaki title Entity içindeki Article içindeki Title ama üstteki Id shared yani hepsinde Id olduğu için miras aldırmıştık
            builder.Property(a => a.Title).HasMaxLength(100);//Title veritabanında 100 karakterden oluşucak

            builder.Property(a => a.Content).IsRequired();
            builder.Property(a=>a.Content).HasColumnType("NVARCHAR(MAX)");//kolon tipini belirleyip ne kadar uzunlukta olduğunu belirledik.

            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);//resim yolunun uzunluğunu belirledik

            builder.Property(a => a.Date).IsRequired();

            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a=>a.SeoAuthor).HasMaxLength(50);

            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(150);

            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);

            builder.Property(a => a.ViewsCount).IsRequired();

            builder.Property(a => a.CommentCount).IsRequired();

            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);

            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);


            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.IsDeleted).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne(c => c.Category)
                .WithMany(a=>a.Articles)
                .HasForeignKey(a=>a.CategoryId);// tablolar arasındaki bire çok ilişki tanımladık bir tarafı Category bunu Article entitisindeki Category ile yazdık çok kısmı Articles ise Category entitisindeki Articles den aldık.Foreign key i de Article entisindeki tanımlı olan CategoryId
            //YANİ YUKARIDAKİ bir categorynin birden çok article olabilir ama bir articl ın bir categorysi olabilir

            builder.HasOne(u => u.User)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");//burada BlogAppContext de verdiğimiz ismi orada istemiyorsak buradan istediğimiz ismi verebiliriz.


            //ilk article verileri

            builder.HasData(
                new Article
                {
                    Id=1,
                    CategoryId=1,
                    UserId=1,
                    Title="C# 11.0 Yenilikleri",
                    Content= "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail="default.jpg",
                    SeoDescription= "C# 11.0 Yenilikleri",
                    SeoTags="C# , C# 11.0, Dotnet 6, Donet 7, Dotnet Core",
                    SeoAuthor="Deniz Gezen",
                    ViewsCount=116,
                    CommentCount=1,
                    Date=DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreated",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitiailCreated",
                    ModifiedDate = DateTime.Now,
                    Note = "C# 11.0 Yenilikleri .",
                },

                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    UserId = 1,
                    Title = "Modern Javascript ",
                    Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                    Thumbnail = "default.jpg",
                    SeoDescription = "Modern Javascript",
                    SeoTags = "EGMA Script 6, map,filter,raduce,arow",
                    SeoAuthor = "Deniz Gezen",
                    ViewsCount = 193,
                    CommentCount = 1,
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreated",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitiailCreated",
                    ModifiedDate = DateTime.Now,
                    Note = "Modern Javascript.",
                },

                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    UserId = 2,
                    Title = "React Component Yapısı",
                    Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                    Thumbnail = "default.jpg",
                    SeoDescription = "React Component Yapısı",
                    SeoTags = "React ,REACT JS,COMPONENET, STATE,CLASS COMPONENET, FUNCTİN COMPONENT",
                    SeoAuthor = "Yusuf Onan",
                    ViewsCount = 226,
                    CommentCount = 1,
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreated",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitiailCreated",
                    ModifiedDate = DateTime.Now,
                    Note = "React Component Yapısı.",
                });

            





        }
    }
}
