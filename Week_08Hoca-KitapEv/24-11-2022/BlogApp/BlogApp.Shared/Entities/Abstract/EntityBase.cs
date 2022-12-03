using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; // eğer bir değer girilmez ise otomatik değer atıyoruz. Developer isterse başka tarih yazabilmesi için virtual yaptık
        public virtual DateTime ModifiedDate { get; set;}=DateTime.Now;
        public virtual string CreatedByName { get; set; }
        public virtual string ModeifiedByName { get; set; }
        public bool IsDeleted { get; set; } = false; // bunuda silindiğinde veritabanından tam silinmedi falan
        public bool IsActive { get; set; } = true; // bunu varsayılan olarak active olması için true verdik

    }
}
