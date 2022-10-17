using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje09_Interface
{

    public interface IGeneral
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        
        
    }

    public interface IGeneral2:IGeneral
    {
        public string NameToUpper();
    }
    // NameToUpper kullanacak
    public class Product : IGeneral2
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public string NameToUpper()
        {
            throw new NotImplementedException();
        }
    }
    public class Category : IGeneral2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public string NameToUpper()
        {
            throw new NotImplementedException();
        }
    }

    public class Departman : IGeneral
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Employee : IGeneral
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
