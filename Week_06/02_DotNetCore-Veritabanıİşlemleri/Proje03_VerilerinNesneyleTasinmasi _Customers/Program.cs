using System.Data.SqlClient;
namespace Proje03_VerilerinNesneyleTasinmasi_Customers;
class Program
{
    static void Main(string[] args)
    {
        List<Customer> customers=GetAllCustomers();  // bunun yerine  ---var customers=GetAllCustomers(); ------ yazabiliriz
        foreach (var customer in customers)
        {
            System.Console.WriteLine($"Id:{customer.Id}, Name:{customer.Contact}, Price:{customer.Company}, Title:{customer.Title}");
        }
        // customer listesini ekrana yazın
    }

    static List<Customer> GetAllCustomers()  //products listesi döndürücez o yüzden product clasında tanımladık string , int vs yazamıyoruz
    {
        List<Customer>customers =new List<Customer>();
        using (var connection = GetSqlConnection())
        {
            try
            {
                connection.Open(); // bağlantıyı açtık
                string queryString="select CustomerID,CompanyName,ContactName,ContactTitle from Customers";//sorgumuzu yazdık
                SqlCommand sqlCommand =new SqlCommand(queryString,connection);// ve sorguya görec
                SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();// sqlCommand değerini execute yani çalıştırdık
                while (sqlDataReader.Read())
                {
                    customers.Add(new Customer(){ // veritabanında gelen veriyi product dan tanımladığımız products nesnesine atıyoruz
                        Id=sqlDataReader["CustomerID"].ToString(),  // veritabanında gelen veriyi ilk önce stringe çeviriyoruz çünkü obje değerinde sonra product sınfıımızdaki değerlere göre dönüştürüyoruz
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


    static SqlConnection GetSqlConnection() //SqlConnection tipinde metot tanımladık ve geriye  sqlConnection bunu döndürdük
    {
        string connectionString ="Server=DESKTOP-OFVK2FD; Database=Northwind; User=sa; Pwd=123";
        SqlConnection  sqlConnection=new SqlConnection(connectionString);
        return sqlConnection;

      
    }
}
