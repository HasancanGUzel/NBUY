using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

using Proje05_KatmanlıMimari.DataAccessLayer.Entities;

namespace Proje05_KatmanlıMimari.DataAccessLayer
{
    public interface ICustomerDAL
    {
        void Create(Customer customer);      
        List<Customer> GetAll();           
        Customer GetById(int id);
        void Update(Customer customer);     
        void Delete(int id);              

       

    }
}