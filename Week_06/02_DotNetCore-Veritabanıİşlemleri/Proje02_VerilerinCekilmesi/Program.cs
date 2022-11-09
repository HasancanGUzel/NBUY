using System.Data.SqlClient;
namespace Proje02_VerilerinCekilmesi;
class Program
{
    static void Main(string[] args)
    {
        GetSqlConnection();
    }

    static void GetSqlConnection()
    {
        string connectionString ="Server=DESKTOP-OFVK2FD; Database=Northwind; User Id=sa; Password=123";
        using (var connection = new SqlConnection(connectionString))
        {
            // connection nesnesi sadece bu skopda yaşayıp scope bitişinde bellekten kaldırılmış olacak
            try
            {
                connection.Open();
                Console.WriteLine("bağlantı sağlandı");
                string queryString = "select * from Products";
                SqlCommand sqlCommand = new SqlCommand(queryString, connection); // bu satır üstteki satırdaki kodun komududnu veriyor
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(); // buda komudu alarak çalştırıyor okuyor
                int sayac = 1;
                while (sqlDataReader.Read()) // döngü harici yazsaydık sadece 1 veriyi döndürürdü
                {
                    System.Console.WriteLine($" Sıra:{sayac} - Name:{sqlDataReader[1]} - Price:{sqlDataReader[5]}"); // 1.sütun ve 5 .sütunudaki verileri getirdi
                    sayac++;
                }
                sqlDataReader.Close(); // kapattık

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
