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
        Task<List<Product>> GetProductsByCategoryAsync(string category);
        Task<List<Product>> GetHomePageProductsAsync();
        Task<Product> GetProductDetailsByUrlAsync(string productUrl);
        Task<List<Product>> GetProductsWithCategories();
        Task<Product> GetProductWithCategories(int id);// bu metodu ürünleri güncelle diyince o ürüne göre kategorileri getirmek için

        Task CreateProductAsync(Product product, int[] selectedCategoryIds); // metodun imzasını tanımladık ve buraya  business deki IproductService ve Productmanager daki metotlara göre geldi veriler geldi

        Task UpdateProductAsync(Product product, int[] selectedCategoryIds);

    }
}
