using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class ProductCategory // hangi ürün hangi kategoriden onu tutmak için
    {
        //normalde entityframeworkde primary key ıd olması lazım ama burda oluşturmakdık ama ileride nasıl olucağını görücez.
        // bu product ve category tablosu için çoka çok tablosu
        // yani bir product birden fazla categoryde olabilir
        // bir categoryde birden fazla prodcut olabilir
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
