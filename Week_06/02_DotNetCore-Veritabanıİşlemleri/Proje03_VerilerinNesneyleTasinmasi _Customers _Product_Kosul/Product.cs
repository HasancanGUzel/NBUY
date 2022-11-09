using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje03_VerilerinNesneyleTasinmasi_Customers_Product_Kosul
{
     public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  decimal Price { get; set; }
        public int Stock { get; set; }
    }
}