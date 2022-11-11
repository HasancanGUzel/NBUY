using System.Data.SqlClient;
using Proje.BusinessLayer;
using Proje.DataAccessLayer; //IproductDAL ayrı bir klasöre koyduk DataAccessLayer onun için bunu tanımladık
using Proje.DataAccessLayer.Entities; // products ve custmer için yaptık bunuda dataaccesslayer içinedeki entites klasörüne almıştık
namespace Proje;
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
        if (dbType==1)
        {
            System.Console.WriteLine("3-search product by id");
            System.Console.WriteLine("4-Filter product by category Id");
            System.Console.WriteLine("5-Filter product by category Name");
        }
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
        else if(secim==3)
        {
            if (dbType==1)
            {
                ProductSearch(new SqlProductDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
            }
            else
            {
                
            }
        }
         else if(secim==4)
        {
            if (dbType==1)
            {
                ProductFilterByCategoryId(new SqlProductDAL());// buraya metodu parametreli yaptığımız için içine hangi veri göndereceğimizi seçtik ve burda sql tablosunu gönderdik
            }
            else
            {
                
            }
        }
    }
  
    static void ProductFilterByCategoryId(IProductDAL productDAL)
    {
        var productManager=new ProductManager(productDAL);
        System.Console.WriteLine("Enter category Id:");
        int catId=int.Parse(Console.ReadLine());
        List<Product>products=productManager.GetProductsByCategoryId(catId);
        // System.Console.WriteLine(products.Count());
        if (products.Count>0) // GetProductsByCategoryId dan gelen categorimiz 0 ise bizim list emiz 0 değeri olucak yani products0 bizde bunu kontrol ettik
        {
            foreach (var product in products)
        {
            System.Console.WriteLine($"Id:{product.Id}, -Name:{product.Name}, -Price:{product.Price}, -Stock:{product.Stock}");
        }
        }
        else
        {
            System.Console.WriteLine("Aradığınız kategoride ürün yoktur");
        }
         
    }
  static void ProductSearch(IProductDAL productDAL) // metodumuzu parametreli yaptığımız için IProductDAL türünde veri gelicek dedim ve nesneyi productDAL nesnesiyle aldım
  {
    var productManager=new ProductManager(productDAL); // metodun içindeki nesneyi burda productmanager nesnesine aktardım
    System.Console.Write("Enter Id:");
    int id=int.Parse(Console.ReadLine());
    Product product=productManager.GetByIdProduct(id); //buraya iyi bak evde çlış güzel yaz Product manager clasımızıdaki getbyIDProduct ile id yi  product nesnesine aktarıyoruz
    if (product!=null) // id null değil ise yani veritabanında 78 id miz var 80 yazarsak çalışmaz lese kısmı çalışır
    {
       System.Console.WriteLine($"Id:{product.Id}, -Name:{product.Name}, -Price:{product.Price}, -Stock:{product.Stock}");
        
    }
    else
    {
        
        System.Console.WriteLine("No product");
    }
      Console.ReadLine();
  }
   
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
