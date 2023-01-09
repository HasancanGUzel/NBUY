using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid01_SingleResponsibility.Before
{
    public class Customer
    {
        void Login(string userName, string password)
        {
            //login işlemleri ile ilgili
        }

        void Register(string userName, string password, string email)
        {
            //regiter ile ilgili kodlar
            SendMail("Kaydınız başarı ile gerçekleşti");
        }
        void SendMail(string text)
        {
            //mail gönderme işlemleri
        }
    }
}
