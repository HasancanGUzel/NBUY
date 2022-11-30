using BlogApp.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Utilities.Result.Abstract
{
    public interface IResult  // kayıt işlemi vs işlemlerde sonuç döndürmek yani kayıt başarılı ise baraşılır mesajı hatalıysa hata mesajı göndermek için
    {
        //ResultStatus bu adda tip tanımlıyoruz yani int string gibi ne döndüreceğimizi bilmediğimiz için kendimiz tip tanımlıyoruz
        public ResultStatus ResultStatus { get;} //ResultStatus.Error gibi kullanımı olucak
        public string Message { get;}//hata mesajlarını bununla taşıyacağız
        public Exception Exception { get;} // hataları exception bununla taşıyacağız
    }
}
