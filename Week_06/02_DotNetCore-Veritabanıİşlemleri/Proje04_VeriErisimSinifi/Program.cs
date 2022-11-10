using System.Data.SqlClient;
namespace Proje04_VeriErisimSinifi;
class Program
{
    static void Main(string[] args)
    {
        int secim;

        do
        {
            System.Console.WriteLine("1-Product list");
            System.Console.WriteLine("2-Customer list");
            System.Console.WriteLine("0-exit");
            System.Console.WriteLine("Lütfen seçiminizi giriniz");
            secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                ProductList();


            }
            else if (secim == 2)
            {
                // CustomerList();
               

            }
            else if(secim!=0)
            {
                System.Console.WriteLine("lütfen geçerli bir seçim giriniz");
            }Console.ReadLine();
        }  while (secim!=0);


       




    }

    static void ProductList()
    {
        // var sqlProductDAL=new SqlProductDAL();  // GetAllProducts medotudnu kullanabilmek için classımızdan nesne ürettik
        // // List<Product> products=GetAllProducts(); //eski kodumuz böylelydi ama  GetAllProducts bu metod clasımızın içindeydi ve aşşğıdaki gibi çağırdık
        // List<Product> products=sqlProductDAL.GetAllProducts();   // bu sql clası için

        var sqliteProductDAL = new SqliteProductDAL(); // buda sqlite clası için
        List<Product> products = sqliteProductDAL.GetAllProducts();
        foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, -Name:{product.Name}, -Price:{product.Price}, -Stock:{product.Stock}");
        }
    }

    // static void CustomerList()
    // {
    //      List<Customer> customers=GetAllCustomers();  
    //     foreach (var customer in customers)
    //     {
    //         System.Console.WriteLine($"Id:{customer.Id}, Name:{customer.Contact}, Price:{customer.Company}, Title:{customer.Title}");
    //     }
    // }



    //-------------Products için veritabanı--------------------
    //   static List<Product> GetAllProducts()  
    //     {
    // bunun içeriğini interface de oluşturduğumuz metoda aldık
    //     }



    #region customer
    //---------------CUSTOMER İÇİN VERİTABANI
    // static List<Customer> GetAllCustomers()  
    // {
    //     List<Customer>customers =new List<Customer>();
    //     using (var connection = GetSqlConnection())
    //     {
    //         try
    //         {
    //             connection.Open();
    //             string queryString="select CustomerID,CompanyName,ContactName,ContactTitle from Customers";
    //             SqlCommand sqlCommand =new SqlCommand(queryString,connection);
    //             SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
    //             while (sqlDataReader.Read())
    //             {
    //                 customers.Add(new Customer(){ 
    //                     Id=sqlDataReader["CustomerID"].ToString(),  
    //                     Contact=sqlDataReader["CompanyName"].ToString(),
    //                     Company=sqlDataReader["ContactName"].ToString(),
    //                     Title=sqlDataReader["ContactTitle"].ToString()
    //                 });
    //             }
    //             sqlDataReader.Close();
    //         }
    //         catch (Exception)
    //         {
    //             System.Console.WriteLine("bir sorun oluştu");
    //         }
    //         finally
    //         {
    //             connection.Close();
    //         }
    //     }
    //     return customers;
    // }


    #endregion



}
