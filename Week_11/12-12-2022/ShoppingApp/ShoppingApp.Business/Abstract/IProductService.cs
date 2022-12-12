using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task CreateProductAsyn(Product product, int[] selectedCategoryIds); // buraya gelen  productController dan gelen 62. satırdaki Product türünde veri geldiği için product ı öylr tanımladık ve productAddDto.SelectedCategoryIds bu veride int dizisi olduğu için böyle tanımladık
        void Update(Product product);
        Task UpdateProductAsync (Product product, int[] selectedCategoryIds);
        void Delete(Product product);
        Task<List<Product>> GetProductsByCategoryAsync(string category);
        Task<List<Product>> GetHomePageProductsAsync();
        Task<Product> GetProductDetailsByUrlAsync(string productUrl);
        Task<List<Product>> GetProductsWithCategories();
        Task<Product> GetProductWithCategories(int id);
    }
}
