using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje05_KatmanlıMimari.DataAccessLayer;
using Proje05_KatmanlıMimari.DataAccessLayer.Entities;

namespace Proje05_KatmanlıMimari.BusinessLayer
{  //bu 'server' katmanımız bizim 3 katmanımız var arayüz, data ve server; arayüz producları listele dediği zaman arayüz direk datayla yani(dataaccesslayer) iletişime geçmiyor businesslayer ile iletişime geçiyor ve busineslayer data ile iletişime geçip bize ordaki verileri getiriyor
    public class CustomerManager
    {
        private readonly ICustomerDAL _customerDAL;
        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL=customerDAL; // private olaak tanımladığımız bunun içine dışarıdan gelen productDAL içindeki veriyi koy
        }
        public void CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomer()
        {
            return _customerDAL.GetAll(); //ana sayfamızdan yani  arayüzden aldığımız veriyi ve hangi veritabanı seçildikten sonra _productDAL içine attıımız veriyi geri döndürüyoruz
        }

        public Customer GetByIdCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
