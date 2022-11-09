using System.Data.SqlClient;

namespace P01_SqlBaglantiOlusturma;
class Program
{
    static void Main(string[] args)
    {
       
        GetSqlConnection();
        
    }

    static void GetSqlConnection()
    {
        // 1.adım Connection String oluşturalım ve bağlantı açalım          
        //  @kaçış işareti
        // şu servere "DESKTOP-OFVK2FD" bağlan ve şu database  "Northwind" bağlan
        string connectionString="Server=DESKTOP-OFVK2FD;Database=Northwind;User Id=sa;Password=123";
        using (var connection=new SqlConnection(connectionString))
        {
            // connection nesnesi sadece bu skopda yaşayıp scope bitişinde bellekten kaldırılmış olacak
            try
            {
                connection.Open();
                 Console.WriteLine("bağlantı sağlandı");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
