using System.Data.SqlClient;
using Proje05_KatmanlıMimariMenu.BusinessLayer;
using Proje05_KatmanlıMimariMenu.DataAccessLayer; //IproductDAL ayrı bir klasöre koyduk DataAccessLayer onun için bunu tanımladık
using Proje05_KatmanlıMimariMenu.DataAccessLayer.Entities; // products ve custmer için yaptık bunuda dataaccesslayer içinedeki entites klasörüne almıştık
namespace Proje05_KatmanlıMimariMenu;
class Program
{
   static void Main(string[] args)
    {
        int secim;
        do
        {
            Console.Clear();
            System.Console.WriteLine("Choose Database");
            System.Console.WriteLine("1-MsSql");
            System.Console.WriteLine("2-Sqlite");
            System.Console.WriteLine("0-exit");
            System.Console.WriteLine("Lütfen seçiminizi giriniz");
            secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                Menu(secim); 
            }
            else if (secim == 2)
            {
                Menu(secim);
            }
            else if(secim!=0)
            {
                System.Console.WriteLine("lütfen geçerli bir seçim giriniz");
            }Console.ReadLine();
        }  while (secim!=0);

    }



    static void Menu(int dbType) // bu menüyü sqlite içinde yapacağımız için genel metod olarak kullanıp mssql ve sqlite içinde kullanıcaz
    {
        Console.Clear();
        string dbName=dbType==1 ?"MsSql":"Sqlite"; // metodun içindeki gelen veriyi eğer 1 ise MsSql 2 ise Sqlite olarak dbName içine attık
        System.Console.WriteLine($"By{dbName} Database - Northwind"); // ve dbName kullanarak buraya hangi veritabanına geldiğini belirttik
        System.Console.WriteLine("-----------------------------");
        System.Console.WriteLine("1-Product List");
        System.Console.WriteLine("2-Customer List");
        System.Console.Write("Seçiminizi yapınız:");
        int secim = int.Parse(Console.ReadLine());
        if (secim==1)// seçilen veritabanı içindeki product list veya customer list hangisini seçiceksek onu seçtik ve seçim içine attık 
        {
            if (dbType==1) // dbType yani metdoun içindeki değer 1 ise MsSql içindeki productları listelicek
            {
                ProductList(new SqlProductDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
            }
            else // dbType yani metdoun içindeki değer 2 ise Sqlite içindeki productları listelicek
            {
                ProductList(new SqliteProductDAL());
            }
            
        }
        else if (secim==2) 
        {
            if (dbType==1) // dbType yani metdoun içindeki değer 1 ise MsSql içindeki Customer listelicek
            {
                 CustomerList(new SqlCustomerDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
            }
            else // dbType yani metdoun içindeki değer 2 ise Sqlite içindeki Customer listelicek
            {
                CustomerList(new SqliteCustomerDAL());
            }
           
        }
    }
  
    // static void MsSqlMenu() // bu menüyü sqlite içinde yapacağımız için genel metod "Menu" adında olarak kullanıp mssql ve sqlite içinde kullanıcaz
    // {
    //     Console.Clear();
    //     System.Console.WriteLine("By MsSql Database - Northwind");
    //     System.Console.WriteLine("-----------------------------");
    //     System.Console.WriteLine("1-Product List");
    //     System.Console.WriteLine("2-Customer List");
    //     System.Console.Write("Seçiminizi yapınız:");
    //     int secim = int.Parse(Console.ReadLine());
    //     if (secim==1)
    //     {
    //         ProductList(new SqlProductDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
    //     }
    //     else if (secim==2)
    //     {
    //         CustomerList(new SqlCustomerDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
    //     }
    // }
    static void ProductList(IProductDAL productDAL) // metodumuzu parametreli yaptığımız için IProductDAL türünde veri gelicek dedim ve nesneyi productDAL nesnesiyle aldım
    {
        
        var productManager=new ProductManager(productDAL); // metodun içindeki nesneyi burda productmanager nesnesine aktardım
        List<Product>products=productManager.GetAllProducts();
        foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, -Name:{product.Name}, -Price:{product.Price}, -Stock:{product.Stock}");
        }
    }

     static void CustomerList(ICustomerDAL customerDAL)// metodumuzu parametreli yaptığımız için ICustomerDAL türünde veri gelicek dedim veo nesneyi customerDAL nesnesiyle aldım
    {
         var customerManager=new CustomerManager(customerDAL);  // metodun içindeki nesneyi burda customermanager nesnesine aktardım
        List<Customer>customers=customerManager.GetAllCustomer();
        foreach (var customer in customers)
        {
            System.Console.WriteLine($"Id:{customer.Id}, Name:{customer.Contact}, Price:{customer.Company}, Title:{customer.Title}");
        }
    }

   
 






}
