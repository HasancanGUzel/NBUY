using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje01.efcore;

namespace Proje01
{

        class CustomerModel
        {
            public string? CustomerId { get; set; }
            public string? CompanyName { get; set; }
            public string? ContactName { get; set; }
            public string? City { get; set; }
            public int OrderCount { get; set; }
            public List<OrderModel> Orders { get; set; }//OrderModel tipinde liste oluşturduk çünkü 94.satırda orders içine orderModel dan türettiğimiz nesneyi attık OrderCount ları hesaplayabilmem için satışları lazım ve satışları buraya listeye atıcaz
        }
        class OrderModel
        {
            public int OrderId { get; set; }
            public DateTime? ShippedDate { get; set; }
            public decimal? Freight { get; set; }
        }



    public class MultiTable
    {
        public void MusteriSayisi()
        {
            // NorthwindContext context = new NorthwindContext(); //böylede olabilir
            var context = new NorthwindContext();
            var result =context.Customers.Count();
            Console.WriteLine(result);


        }
        public void SatisYapilanMüsteriler()
        {
            //gelen listede her customera ait Id, CompanyName, ContactName , City olacak
            var context=new NorthwindContext();
            var customers=context
                .Customers
                .Where(c=>c.Orders.Count()>0)
                .Select(c=>new CustomerModel(){
                    CustomerId=c.CustomerId,  // CustomerModel prop larına veritabanından gelen verileri atıyoruz
                    CompanyName=c.CompanyName,
                    ContactName=c.ContactName,
                    City=c.City
                })
                .ToList();
                foreach (var c in customers)
                {
                    System.Console.WriteLine(c.CompanyName+" --"+c.ContactName+"--"+c.City);
                }

                System.Console.WriteLine("satış yapılan müşteri sayısı {0}",customers.Count);
        }

        //satış yapılmayan müşterileri listeleyin
        public void SatisYapilmayanMüsteriler()
        {
            //gelen listede her customera ait Id, CompanyName, ContactName , City olacak
            var context=new NorthwindContext();
            var customers=context
                .Customers
                .Where(c=>c.Orders.Count()==0)
                .Select(c=>new CustomerModel(){
                    CustomerId=c.CustomerId,  // CustomerModel prop larına veritabanından gelen verileri atıyoruz
                    CompanyName=c.CompanyName,
                    ContactName=c.ContactName,
                    City=c.City
                })
                .ToList();
                foreach (var c in customers)
                {
                    System.Console.WriteLine(c.CompanyName+" --"+c.ContactName+"--"+c.City);
                }

                System.Console.WriteLine("satış yapılmayan müşteri sayısı {0}",customers.Count);
        }
        public void MusteriSatisListesi()
        {
            var context =new NorthwindContext();
            var customers=context
                .Customers
                .Select(c=>new CustomerModel(){
                    CustomerId=c.CustomerId,
                    CompanyName=c.CompanyName,
                    ContactName=c.ContactName,
                    City=c.City,
                    OrderCount=c.Orders.Count(),// sıradaki müşteri için orders.countunu hesapladık ve OrdersCount a attık
                    Orders=c.Orders.Select(o=> new OrderModel(){
                        OrderId=o.OrderId,
                        ShippedDate=o.ShippedDate,
                        Freight=o.Freight
                    }).ToList()
                }).ToList();
                foreach (var c in customers)
                {
                    System.Console.WriteLine(c.CustomerId+"--"+c.CompanyName+" -- "+c.OrderCount);
                    foreach (var o in c.Orders)
                    {
                        System.Console.WriteLine("\t"+ o.OrderId+"-"+o.ShippedDate+"-"+o.Freight);
                    }
                    System.Console.WriteLine();
                }

        }
        


   
    }
}