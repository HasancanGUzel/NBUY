using System.Data.SqlClient;
using Proje05_KatmanlıMimari.BusinessLayer;
using Proje05_KatmanlıMimari.DataAccessLayer; //IproductDAL ayrı bir klasöre koyduk DataAccessLayer onun için bunu tanımladık
using Proje05_KatmanlıMimari.DataAccessLayer.Entities; // products ve custmer için yaptık bunuda dataaccesslayer içinedeki entites klasörüne almıştık
namespace Proje05_KatmanlıMimari;
class Program
{
   static void Main(string[] args)
    {
        int secim;
        do
        {
            Console.Clear();
            System.Console.WriteLine("1-ProductList");
            System.Console.WriteLine("2-cUSTOMER LİST");
            System.Console.WriteLine("0-exit");
            System.Console.WriteLine("Lütfen seçiminizi giriniz");
            secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                ProductList();
            }
            else if (secim == 2)
            {
                CustomerList();
            }
            else if(secim!=0)
            {
                System.Console.WriteLine("lütfen geçerli bir seçim giriniz");
            }Console.ReadLine();
        }  while (secim!=0);

    }
  
    static void ProductList()
    {
        
        var productManager=new ProductManager(new SqliteProductDAL());  // server(businesslayer) ile iletişime geçiyor ve ProductManager contructor metodunu çalıştırıyor yani burdaparantez içine hangi veritabanıyla iletişime geçeceksek onu yazıyoruz ve bu contructor metotla iletişime geçip orda metodun parametresi olan productDAL içine aktarıyoruz  o da veriyi _productDAl içine atıyor sonra o veriyi hangi işlemi yapıcaksak o metodun içinde geri döndürüyoruz 
        List<Product>products=productManager.GetAllProducts();
        foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, -Name:{product.Name}, -Price:{product.Price}, -Stock:{product.Stock}");
        }
    }




    
     static void CustomerList()
    {
         var customerManager=new CustomerManager(new SqlCustomerDAL());  // server(businesslayer) ile iletişime geçiyor ve CustomerManager contructor metodunu çalıştırıyor yani burdaparantez içine hangi veritabanıyla iletişime geçeceksek onu yazıyoruz ve bu contructor metotla iletişime geçip orda metodun parametresi olan customerDAL içine aktarıyoruz  o da veriyi _customerDAl içine atıyor sonra o veriyi hangi işlemi yapıcaksak o metodun içinde geri döndürüyoruz 
        List<Customer>customers=customerManager.GetAllCustomer();
        foreach (var customer in customers)
        {
            System.Console.WriteLine($"Id:{customer.Id}, Name:{customer.Contact}, Price:{customer.Company}, Title:{customer.Title}");
        }
    }

   
 






}
