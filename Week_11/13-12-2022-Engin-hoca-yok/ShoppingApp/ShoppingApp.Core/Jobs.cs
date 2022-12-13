using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    public static class Jobs
    {
        public static string InitUrl(string url)
        {
            #region Açıklamalar
            /*Bu metot kendisine gelen url değişkenin içindeki
             * 1) Latin alfabesine çevrilirken problem çıkaran İ-i, ı-i gibi
             * dönüştürmeleri yapacak.
             * 2) Diğer Türkçe karakterlerin yerine latif alfabesindeki karşılıklarını koyacak.
             * 3) Boşluklar yerine - koyacak
             * 4) Nokta(.), slash(/) gibi karakterleri kaldıracak.
             */
            #endregion
            #region SorunluKarakterlerDüzeltiliyor
            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");
            #endregion
            #region KüçükHarfeDönüştürülüyor
            url = url.ToLower();
            #endregion
            #region TürkçeKarakterlerDönüştürülüyor
            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ş", "s");
            url = url.Replace("ç", "c");
            url = url.Replace("ğ", "g");
            #endregion
            #region BoşluklarTireİleDeğiştiriliyor
            url = url.Replace(" ", "-");
            #endregion
            #region SorunluKarakterlerKaldırılıyor
            url = url.Replace(".", "");
            url = url.Replace("/", "");
            url = url.Replace("\"", "");
            url = url.Replace("'", "");
            url = url.Replace("(", "");
            url = url.Replace(")", "");
            url = url.Replace("[", "");
            url = url.Replace("]", "");
            url = url.Replace("{", "");
            url = url.Replace("}", "");
            #endregion
            return url;
        }

        public static string UploadImage(IFormFile image)
        {

            //burada  FileStream kullanabilmek için eklenti indirdik üstüne tıklayınca otomatik olarak çıktı
             // uzantısı    using Microsoft.AspNetCore.Http; bu şekilde


            var extension=Path.GetExtension(image.FileName); // image i buraya yolladık ve imagein FileName ini yakaladık
            var randomName=$"{Guid.NewGuid()}{extension}";//rastgele değer üreticek 40 karakterden extension ekleme nedenizmi  guid ratgele isim üreticek extensionda sonuna png ekini eklicek yukarıdan geldi.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", randomName);
            //Directory.GetCurrentDirectory() sitenin ana route dizinni alıyor htttp://localhost:5001/ gibi ismini veriyor
            //"wwwroot/images"===   buda htttp://localhost:5001/ "wwwroot/images"/ yapar
            // randomName buda yarattığımız rastgele ismi koyar.
            //sonuç olarak     htttp://localhost:5001/"wwwroot/images"/asdasdalkdjalkdj.png gibi
            using (var stream=new FileStream(path,FileMode.Create))// bu satır cretae ediyor ve streame atıyor
            {
                image.CopyTo(stream);//
            }
            return randomName;
        }
    }
}
