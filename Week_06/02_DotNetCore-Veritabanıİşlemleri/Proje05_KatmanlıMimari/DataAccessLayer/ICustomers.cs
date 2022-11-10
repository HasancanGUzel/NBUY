using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

using Proje05_KatmanlıMimari.DataAccessLayer.Entities;

namespace Proje05_KatmanlıMimari.DataAccessLayer
{
    public interface ICustomers
    {
        void CreateProduct(Customer customer);      //C-reate
        List<Product> GetAllCustomers();           //R-ead
        Product GetByIdCustomer(int id);
        void UpdateCustomer(Customer customer);     //U-pdate
        void DeleteProduct(int id);              //D-elete

        List<Product>GetProductsByCategories(string categoryName);

    }
}