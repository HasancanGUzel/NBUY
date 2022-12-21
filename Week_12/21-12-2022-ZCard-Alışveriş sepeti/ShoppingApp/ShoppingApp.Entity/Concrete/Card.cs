using ShoppingApp.Entity.Abstract;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Card : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }// bu card sepet kime ait tutmak için
        public User User{ get; set; } // user bilgileri için
        public List<CardItem>CardItems { get; set; } // bir cardın içinde birden fazla cardıtem olabilir onu tutmak için

    }
}
