using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>// bir interface başka bir interface den miras almasını söylersek onu implemnte etmeye gerek yok 
    {
        //category özgü memberlar burada olacak(property field method)
        //örneğin aşağdakiler gibi
        Category GetByIdProducts();
 
    }
}
