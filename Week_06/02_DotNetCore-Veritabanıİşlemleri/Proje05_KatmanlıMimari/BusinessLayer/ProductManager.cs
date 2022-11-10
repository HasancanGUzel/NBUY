using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje05_KatmanlıMimari.DataAccessLayer;
using Proje05_KatmanlıMimari.DataAccessLayer.Entities;

namespace Proje05_KatmanlıMimari.BusinessLayer
{  //bu 'server' katmanımız bizim 3 katmanımız var arayüz, data ve server; arayüz producları listele dediği zaman arayüz direk datayla yani(dataaccesslayer) iletişime geçmiyor businesslayer ile iletişime geçiyor ve busineslayer data ile iletişime geçip bize ordaki verileri getiriyor
    public class ProductManager
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL=productDAL; // private olaak tanımladığımız bunun içine dışarıdan gelen productDAL içindeki veriyi koy
        }
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _productDAL.GetAllProducts(); //ana sayfamızdan yani  arayüzden aldığımız veriyi ve hangi veritabanı seçildikten sonra _productDAL içine attıımız veriyi geri döndürüyoruz
        }

        public Product GetByIdProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategories(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
