using Microsoft.Data.Sqlite;
using Proje05_KatmanlıMimariMenu.DataAccessLayer.Entities;
namespace Proje05_KatmanlıMimariMenu.DataAccessLayer
{
    public class SqliteProductDAL : IProductDAL
    {
        private SqliteConnection GetSqliteConnection()
        {
            string connectionString="Data Source=northwind.db";
            SqliteConnection sqliteConnection=new SqliteConnection(connectionString);
            return sqliteConnection;
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
           List<Product>products=new List<Product>();
           using (var connection=GetSqliteConnection())
           {
                try
                {
                    connection.Open();
                    string queryString="Select ProductId,ProductName,UnitPrice,UnitsInStock from products";
                    SqliteCommand sqliteCommand=new SqliteCommand(queryString,connection);
                    SqliteDataReader sqliteDataReader=sqliteCommand.ExecuteReader();
                    while (sqliteDataReader.Read())
                    {
                        products.Add(new Product(){
                            Id=int.Parse(sqliteDataReader["ProductId"].ToString()),
                            Name=sqliteDataReader["ProductName"].ToString(),
                            Price=decimal.Parse(sqliteDataReader["UnitPrice"].ToString()),
                            Stock=int.Parse(sqliteDataReader["UnitsInStock"].ToString())


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
           return products;


        }

        public Product GetByIdProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategories(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}