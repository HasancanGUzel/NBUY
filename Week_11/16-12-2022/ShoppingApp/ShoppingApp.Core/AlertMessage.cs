using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    //uygulama içinde çeşitli durumlarda ihtiyaç uyacağımız duyduğumuz uyarı mesajları için kullanıclacak bir tip
    public class AlertMessage
    {
        public string Title { get; set; }//uyarı mesajının başlığı
        public string Message { get; set; }//uyarı mesajı
        public string AlertType { get; set; }//uyarı mesajının tipi görüünümü(sarı mavi kırmızı vs)
    }
}
