using System.Data.SqlClient;
using Proje.DataAccessLayer.Entities;
namespace Proje.DataAccessLayer
{
    public class SqlProductDAL : IProductDAL
    {
        private SqlConnection GetSqlConnection()
        {
            string connectionString = "Server=DESKTOP-OFVK2FD; Database=Northwind; User=sa; Pwd=123";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;


        }
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    string queryString = "select ProductId,ProductName,UnitPrice,UnitsInStock from Products";
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        products.Add(new Product()
                        {
                            Id = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = decimal.Parse(sqlDataReader[2].ToString()),
                            Stock = int.Parse(sqlDataReader[3].ToString())
                        });
                    }
                    sqlDataReader.Close();
                }
                catch (Exception)
                {
                    System.Console.WriteLine("bir sorun oluştu");
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = null; // product adını stack de tanımlıyoruz aşşağıda nesneyi üretiyoruz
            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    string queryString = $"Select ProductId,ProductName,UnitPrice,UnitsInStock from Products Where ProductId={id}";
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows) //hasrows satır varsa demek yani aradığımız Id yoksa boşa dönememsi için
                    {
                        sqlDataReader.Read();
                        product = new Product() // produtc nesnesini burada üretiyoruz
                        {
                            Id = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = decimal.Parse(sqlDataReader[2].ToString()),
                            Stock = int.Parse(sqlDataReader[3].ToString())
                        };
                    }
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);

                }
                finally
                {
                    connection.Close();
                }
            }
            return product;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategories(string categoryName)
        {
             List<Product> products = new List<Product>();
            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    string queryString = $"select ProductId,ProductName,UnitPrice,UnitsInStock from Products P INNER JOIN Customer C on P.CategoryId=C.CategoryId    Where C.CategoryName='{categoryName}'";
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        products.Add(new Product()
                        {
                            Id = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = decimal.Parse(sqlDataReader[2].ToString()),
                            Stock = int.Parse(sqlDataReader[3].ToString())
                        });
                    }
                    sqlDataReader.Close();
                }
                catch (Exception)
                {
                    System.Console.WriteLine("bir sorun oluştu");
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public List<Product> GetProductsByCategoriesId(int id)
        {
            List<Product> products = new List<Product>();
            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    string queryString = $"select ProductId,ProductName,UnitPrice,UnitsInStock from Products Where CategoryId={id}";
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        products.Add(new Product()
                        {
                            Id = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = decimal.Parse(sqlDataReader[2].ToString()),
                            Stock = int.Parse(sqlDataReader[3].ToString())
                        });
                    }
                    sqlDataReader.Close();
                }
                catch (Exception)
                {
                    System.Console.WriteLine("bir sorun oluştu");
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }
    }
}