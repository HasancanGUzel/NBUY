using Proje01;
using Proje01.efcore;

var mt =new MultiTable();//MultiTable classı nı kullabilmek için nesne ürettik
// mt.MusteriSayisi();// ürettiğimiz nesne ile o clasın metodunu çağırdık
// mt.SatisYapilanMüsteriler();
// mt.SatisYapilmayanMüsteriler();
mt.MusteriSatisListesi();


















// NorthwindContext context = new NorthwindContext();
//customer listesi alıyor
// List<Customer> customers=context.Customers.ToList();// northwind içindeki Customers a eriştik ve onun içindeki verileri tolist ile getirdik
// foreach(var customer in customers)
// {
//     Console.WriteLine(customer.CompanyName+" "+customer.ContactName);
// }

//london da yaşayan customerların listesi
// List<Customer>customers=context.Customers.Where(c=>c.City=="London").ToList();//where koşul cümlemiz yani 'c' customerları temsil ediyor herhangi birşey yazabilirdik ok işareti yaptık ve c.city yani custormalrın city si London mu dedik london olanları to list ile customers listemize attık
// foreach(var customer in customers)
// {
//     Console.WriteLine(customer.CompanyName+" ----- "+customer.City);// yukarıda customarların tüm bilgileri geldi biz burada sadece 2 sini gösterdik
// }
// Console.WriteLine("Bitti");

//londonda yaşayan customerların sadece companyname ve contactname lerini getirelim
// var customers=context //buraya list<customer> yapmadık yapamazdık çünkü select de sadece 3 kolon getirdik ve o kolona bakarak Customer diyemeyiz
//     .Customers
//     .Select(c=>new{c.CompanyName,c.ContactName,c.City})
//     .Where(c=>c.City=="London")
//     .ToList();
// foreach(var customer in customers)
// {
//     Console.WriteLine(customer.CompanyName+" ----- "+customer.City+"---------"+customer.ContactName);
// }
// Console.WriteLine("Bitti");


//londonda yaşayan customerların sadece companyname ve contactname lerini getirelim
//nesne kullanarak


// List<CustomerModel> customers=context //üstteki örnekte var ile yapmıştık şimdi var yerine list ile yapmak isteseydik aşşığıda oluşturduğumuz clasımız var ver propertieslerimiz var ve onun adında list oluşturduk
//     .Customers
//     .Select(c=>new CustomerModel()
//     {
//         CompanyName=c.CompanyName, //veritabanından çektiğimiz verileri customermodelin propertieslerine karşılık gelenlere attık
//         ContactName=c.ContactName,
//         City=c.City
//     })
//     .Where(c=>c.City=="London")
//     .ToList();
// foreach(var customer in customers)
// {
//     Console.WriteLine(customer.CompanyName+" ----- "+customer.City+"---------"+customer.ContactName);
// }
// Console.WriteLine("Bitti");

//class CustomerModel
// {
//     public string? CompanyName{get;set;}
//     public string? ContactName{get;set;}
//     public string? City{get;set;}
// }

// beverages kategorisindeki ürünlerin listesini getir
// var beveragesProducts=context
//     .Products
//     .Where(p=>p.Category.CategoryName=="Beverages")
//     .ToList();

// foreach(var p in beveragesProducts)
// {
//     Console.WriteLine(p.ProductName+" --"+p.Category.CategoryName);
// }


// supplier tablosundaki germanyde yaşayanlar
// var SupplierGer=context
//     .Suppliers
//     .Where(S=>S.Country=="Germany")
//     .ToList();

// foreach(var s in SupplierGer)
// {
//     Console.WriteLine(s.CompanyName);
// }


//nancy adlı çalışnanın yaptığı satışlar
// var ordersOfNancy=context   
//     .Orders
//     .Where(o=>o.Employee.FirstName=="Nancy" && o.ShipCountry=="Brazil")
//     .ToList();
// foreach(var o in ordersOfNancy)
// {
//     Console.WriteLine(o.OrderId);
// }
// Console.WriteLine("toplam satış sayısı {0}",ordersOfNancy.Count());


//productları ıd ye göre büyükten küçüğe sıralı bir şekilde sıralayalım
// var products =context
//     .Products
//     .OrderByDescending(p=>p.ProductId)//büyükten üçüğe sıraladık
//     .ToList();

// foreach (var p in products)
// {
//     System.Console.WriteLine(p.ProductId+" ---"+p.ProductName);
// }

//en son satılan 5 ürünü listeleyelim
// var products =context
//     .Products
//     .OrderByDescending(p=>p.ProductId)//büyükten üçüğe sıraladık
//     .Take(5)//ilk 5 kaydı gösteriri sql deki TOP gibi
//     .ToList();

// foreach (var p in products)
// {
//     System.Console.WriteLine(p.ProductId+" ---"+p.ProductName);
// }

//fiyatı 10 ile 20 arasında olan ürünlerin adını ve fiyatını getirip listeleyelim,fiyata göre küçükten büyüğe sıralayalım
// var products =context
//     .Products
//     // .Select(p=>new{ // select satırını yazmadığımız zaman bütün kolonları arkada getiriyordu ve biz içinde çağırıyorduk şimdi ise select ile hangi kolonları getireceğimizi seçiyoruz fazla olan kolonları getirmiyoruz bizim işimize yarayan kolonları getirdik
//     //     p.ProductName, // select where den öncede olur whereden sonrada olur
//     //     p.UnitPrice   // fakat burada unitPrice yazmasak yani sadece product name ni istesek where koşulu hata verirdi o yüzden duruma göre aşşağıda kullanmak gerekebilir
//     // })
//     .Where(p=>p.UnitPrice>=10 && p.UnitPrice<=20)  
//      .Select(p=>new{ // select satırını yazmadığımız zaman bütün kolonları arkada getiriyordu ve biz içinde çağırıyorduk şimdi ise select ile hangi kolonları getireceğimizi seçiyoruz fazla olan kolonları getirmiyoruz bizim işimize yarayan kolonları getirdik
//         p.ProductName,
//         p.UnitPrice
//     })
//      .OrderBy(p=>p.UnitPrice)// küçükten büyüğe sıraladık
//     .ToList();//execute eden kısım burası

// foreach (var p in products)
// {
//     System.Console.WriteLine(p.ProductName+" --->"+p.UnitPrice);
// }


//beverages kategorsiindeki ortalama fiyatını ekrana yazdıralım
// var ortalama=context
//     .Products
//     .Where(p=>p.Category.CategoryName=="Beverages")
//     .Average(p=>p.UnitPrice);//ortalamayı alır

//   System.Console.WriteLine("Beverages fiyat ortalaması {0}",ortalama);  


// //Beverages kategorisindeki ürün adedi
// var adet=context
//     .Products
//     // .Where(p=>p.Category.CategoryName=="Beverages")
//     // .Count();
//     .Count(p=>p.Category.CategoryName=="Beverages"); // üstteki 2 satırın aynısı ama kısası where gerek yok

//   System.Console.WriteLine("Beverages  kategorsiindeki adet {0}",adet);  

//Beverages ve condiments kategorilerinde toplam kaç adet ürün vardır
// var adet=context
//     .Products
//     .Where(p=>p.Category.CategoryName=="Beverages" || p.Category.CategoryName=="Condiments")
//     .Count();

//   System.Console.WriteLine("Beverages  kategorsiindeki adet {0}",adet);  


//adının içinde tofu geçenleri listeleyelim
//   var products=context
//     .Products
//     .Where(p=>p.ProductName.Contains("tofu"))
//     .ToList();
// foreach (var p in products)
// {
//     System.Console.WriteLine(p.ProductName);
// }


//en ucuz ve en pahalı ürün hangileri
// var minPrice=context.Products.Min(p=>p.UnitPrice);
// var maxPrice=context.Products.Max(p=>p.UnitPrice);

// var minProduct=context
//     .Products
//     .Where(p=>p.UnitPrice==minPrice)
//     .Select(p=>new{
//         p.ProductName,
//         p.UnitPrice
//     }).FirstOrDefault();// bunun yerine to list yazsaydık console.write içinde yazmamız zordu veya döngü yapıp yazdırmamız gerekirdi ama biz bir değer döndürüceğimiz için FirstOrDefault bu değişkeni kullandık
// // eğer aynı fiyatta birden fazla değer olsaydı tolist kullanmamız daha mantıklı çünkü  FirstOrDefault bu değişken yukarıdan karşılaştığı il değeri getirir
// System.Console.WriteLine($"MinPrice {minPrice} -->Product:{minProduct.ProductName}{minProduct.UnitPrice}");


// var maxProduct=context
//   .Products
//   .Where(a=>a.UnitPrice==maxPrice)
//   .Select(b=>new{ // buralarda a veya b nin hiçbir önemi yok istediğimiz ismi verebilriz
//     b.ProductName,
//     b.UnitPrice
//   }).FirstOrDefault();

// System.Console.WriteLine($"MaxPrice {maxPrice} -->Product:{maxProduct.ProductName}{maxProduct.UnitPrice}");



// en ucuz ve en pahalı ürün hangileri
// var minPrice = context.Products.Min(p => p.UnitPrice);
// var maxPrice = context.Products.Max(p => p.UnitPrice);

// var minProduct = context
//     .Products
//     .Where(p => p.UnitPrice == minPrice)
//     .Select(p => new
//     {
//         p.ProductName
//     }).ToList();// yukarıdaki örnek gibi ama bizim min ve max fiyatlarımız 1 den fazlaydı bu yüzden to list kullnarak foreach ile hepsini yazıdrdık
// foreach (var min in minProduct)
// {
//     System.Console.WriteLine($"MinPrice {minPrice} -->Product:{min.ProductName}");

// }

// var maxProduct = context
//   .Products
//   .Where(a => a.UnitPrice == maxPrice)
//   .Select(b => new
//   {
//       b.ProductName
//   }).ToList(); // yukarıdaki örnek gibi ama bizim min ve max fiyatlarımız 1 den fazlaydı bu yüzden to list kullnarak foreach ile hepsini yazıdrdık

// foreach (var max in maxProduct)
// {
//     System.Console.WriteLine($"MaxPrice {maxPrice} -->Product:{max.ProductName}");

// }






