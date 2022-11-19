using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje06_ModelBinding_Form.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool IsApproved { get; set; }
        
    }
}