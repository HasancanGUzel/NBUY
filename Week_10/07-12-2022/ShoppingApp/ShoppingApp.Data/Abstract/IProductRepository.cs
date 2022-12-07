using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IProductRepository:IRepository<Product> // bir interface başka bir interface den miras almasını söylersek onu implemnte etmeye gerek yok 
       
    {
        //producta özgü memberlar burada olacak(property field method)
        //örneğin aşağdakiler gibi
        List<Product> GetProductsByCategory();
        List<Product> GetHomePagePrdocut();
    }
}
