using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    public static class Jobs// Jobs ortak bir klasörümüz static tanımladık yani hiçbir yerde new yaparak nesne tanımlamaya gerek kalmaz
    {
        public static string InitUrl(string url) //burda biz yeni kategori eklediğimiz zaman bu kategoriye Url oluşturmak için bu metodu tanımladık
        {
            #region Açıklama
            /*bu metot kendisine gelen url değişkeni içindeki
         * 1)Latin alfabesine çevrilikrne problemçıkaran (İ-i,ı-i
gibi dönüştürmeleri yapacak
         *  2)Türkçe karekterleri yerine latin alfabesindeki karşılıklarını koyacak
         *  3)Boşlular yerine - koyacak
         *  4) Nokta(.) slash(/)gibi karakterleri kaldıracak
        */
            #endregion
            //gelen url verisini al şunlarla değiştir
            url=url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");

            url = url.ToLower();

            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ş", "s");
            url = url.Replace("ç", "c");
            url = url.Replace("ğ", "g");

            url = url.Replace(" ", "-");
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

            return url;

        }
    }
}
