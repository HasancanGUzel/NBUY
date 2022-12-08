using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        //Producta özgü memberlar burada olacak.(property, field, method...)ü
        //Örneğin aşağıdakiler gibi:
        Task<List<Product>> GetProductsByCategoryAsync(string category); // hangi kategoriye tıklandığı zaman o kategorinin productları gelicek o yüzden bu metodu tanımladık
        Task<List<Product>> GetHomePageProductsAsync();
    }
}
