using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete.Identity
{
    public class User:IdentityUser // normalde Identity paketini kurunca user role vs otomatik entity oluşuyordu ama biz user içine ek olacak şekilde özellik ekleyeceksek kendimiz entity tanımlıyoruz ve paketle birlikte yüklenen entity den miras aldırıyoruz.
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
