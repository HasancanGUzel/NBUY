using System.Data.SqlClient;
namespace Proje04_VeriErisimSinifi;
class Program
{
    static void Main(string[] args)
    {
        int secim;
        do
        {
            Console.Clear();
            System.Console.WriteLine("1-Product list");
            System.Console.WriteLine("2-Customer list");
            System.Console.WriteLine("0-exit");
            System.Console.WriteLine("Lütfen seçiminizi giriniz");
            secim=int.Parse(Console.ReadLine());
            if (secim==1)
            {
                ProductList();   
            }
            else if(secim==2)
            {
                CustomerList();
            }
            else if(secim!=0)
            {
                System.Console.WriteLine("lütfen geçerli bir seçim giriniz");
            }
                Console.ReadLine();
        } while (secim!=0);
      
    }

    static void ProductList()
    {
        List<Product> products=GetAllProducts(); 
        
        foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Price{product.Price}, Stock{product.Stock}");
        }
    }

    static void CustomerList()
    {
         List<Customer> customers=GetAllCustomers();  
        foreach (var customer in customers)
        {
            System.Console.WriteLine($"Id:{customer.Id}, Name:{customer.Contact}, Price:{customer.Company}, Title:{customer.Title}");
        }
    }



//-------------Products için veritabanı--------------------
  static List<Product> GetAllProducts()  
    {
        List<Product>products =new List<Product>(); 
        using (var connection = GetSqlConnection())
        {
            try
            {
                connection.Open(); 
                string queryString="select ProductId,ProductName,UnitPrice,UnitsInStock from Products";
                SqlCommand sqlCommand =new SqlCommand(queryString,connection);
                SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    products.Add(new Product(){ 
                        Id=int.Parse(sqlDataReader[0].ToString()),  
                        Name=sqlDataReader[1].ToString(),
                        Price=decimal.Parse(sqlDataReader[2].ToString()),
                        Stock=int.Parse(sqlDataReader[3].ToString())
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




        //---------------CUSTOMER İÇİN VERİTABANI
    static List<Customer> GetAllCustomers()  
    {
        List<Customer>customers =new List<Customer>();
        using (var connection = GetSqlConnection())
        {
            try
            {
                connection.Open();
                string queryString="select CustomerID,CompanyName,ContactName,ContactTitle from Customers";
                SqlCommand sqlCommand =new SqlCommand(queryString,connection);
                SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    customers.Add(new Customer(){ 
                        Id=sqlDataReader["CustomerID"].ToString(),  
                        Contact=sqlDataReader["CompanyName"].ToString(),
                        Company=sqlDataReader["ContactName"].ToString(),
                        Title=sqlDataReader["ContactTitle"].ToString()
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
        return customers;
    }


    static SqlConnection GetSqlConnection() 
    {
        string connectionString ="Server=DESKTOP-OFVK2FD; Database=Northwind; User=sa; Pwd=123";
        SqlConnection  sqlConnection=new SqlConnection(connectionString);
        return sqlConnection;

      
    }
}
