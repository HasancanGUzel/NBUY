using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Abstract
{
    public interface IEntityBase // burada tüm kullanıcağımız sınıflarda vs ortak olan özellikleri için kullandık Id için bunu oluşturmaya fazla gerek yoktu fakat ileriyi düşünerek başka ortak özellik olursa burda tanımlamamız yeterli olucak sonra ilgili entitiy de impelemnte edicez
    {
        public int Id { get; set; }
    }
}
