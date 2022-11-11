using Microsoft.Data.Sqlite;
using Proje05_KatmanlıMimariMenu.DataAccessLayer.Entities;
namespace Proje05_KatmanlıMimariMenu.DataAccessLayer
{
    public class SqliteCustomerDAL : ICustomerDAL
    {
        private SqliteConnection GetSqliteConnection()
        {
            string connectionString="Data Source=northwind.db";
            SqliteConnection sqliteConnection=new SqliteConnection(connectionString);
            return sqliteConnection;
        }
      

        public List<Customer> GetAll()
        {
           List<Customer>customers=new List<Customer>();
           using (var connection=GetSqliteConnection())
           {
                try
                {
                    connection.Open();
                     string queryString = "select CustomerID,CompanyName,ContactName,ContactTitle from Customers";
                    SqliteCommand sqliteCommand=new SqliteCommand(queryString,connection);
                    SqliteDataReader sqliteDataReader=sqliteCommand.ExecuteReader();
                    while (sqliteDataReader.Read())
                    {
                        customers.Add(new Customer(){ 
                        Id=sqliteDataReader["CustomerID"].ToString(),  
                        Contact=sqliteDataReader["CompanyName"].ToString(),
                        Company=sqliteDataReader["ContactName"].ToString(),
                        Title=sqliteDataReader["ContactTitle"].ToString()


                        });
                    }
                    sqliteDataReader.Close();
                }
                catch (Exception)
                {
                    System.Console.WriteLine("bir hata oluştu");
                }
                finally
                {
                    connection.Close();
                }
           }
           return customers;


        }

        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }


        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}