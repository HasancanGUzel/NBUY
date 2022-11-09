using System.Data.SqlClient;
namespace Proje03_VerilerinNesneyleTasinmasi;
class Program
{
    static void Main(string[] args)
    {
        List<Product> products=GetAllProducts(); // product sınıfından list tanımlıyoruz ve içindeki verileri ekrana yazıyoruz
        // bunun yerine  --- var products=GetAllProducts(); ------ yazabiliriz
        foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Price{product.Price}, Stock{product.Stock}");
        }
        
    }

    static List<Product> GetAllProducts()  //products listesi döndürücez o yüzden product clasında tanımladık string , int vs yazamıyoruz
    //burada product tanımlamıyoruz prdouct tipinde değer tutan list tanımlıyoruz
    {
        List<Product>products =new List<Product>(); //  product sınfııdan list oluşturyoruz ve veritabanında çektiğimiz verileri burada tutuyoruz
        using (var connection = GetSqlConnection())
        {
            try
            {
                connection.Open(); // bağlantıyı açtık
                string queryString="select ProductId,ProductName,UnitPrice,UnitsInStock from Products";//sorgumuzu yazdık
                SqlCommand sqlCommand =new SqlCommand(queryString,connection);// ve sorguya görec
                SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();// sqlCommand değerini execute yani çalıştırdık
                while (sqlDataReader.Read())
                {
                    products.Add(new Product(){ // veritabanında gelen veriyi product dan tanımladığımız products nesnesine atıyoruz
                        Id=int.Parse(sqlDataReader[0].ToString()),  // veritabanında gelen veriyi ilk önce stringe çeviriyoruz çünkü obje değerinde sonra product sınfıımızdaki değerlere göre dönüştürüyoruz
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


    static SqlConnection GetSqlConnection() //SqlConnection tipinde metot tanımladık ve geriye  sqlConnection bunu döndürdük
    {
        string connectionString ="Server=DESKTOP-OFVK2FD; Database=Northwind; User=sa; Pwd=123";
        SqlConnection  sqlConnection=new SqlConnection(connectionString);
        return sqlConnection;

      
    }
}
