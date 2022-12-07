using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface ICategoryService // kategoriye özgü ve bütün generic metotları yazmam lazım generic repository ve category repository den geldi.
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>>GetAllAsync();
        Task CreateAsync(Category category);
        void Update(Category category);
        void Delete(Category category);

        Category GetByIdWithProduct();
    }
}
