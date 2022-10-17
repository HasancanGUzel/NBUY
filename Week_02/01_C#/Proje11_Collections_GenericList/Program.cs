using System.Xml.Linq;

namespace Proje11_Collections_GenericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region giriş konularımız
            List<int> sayilar = new List<int>();//list<> yapısı olduğu için generic <> olduğu herşey generictir.
            sayilar.Add(12);
            sayilar.Add(120);
            sayilar.Add(69);
            sayilar.Add(28);
            sayilar.Add(366);

            List<string> isimler = new List<string>();
            isimler.Add("ahmet");
            isimler.Add("mehmet");
            isimler.Add("ayşe");

            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("*************");
            foreach (var isim in isimler)
            {
                Console.WriteLine(isim);
            }
            sayilar.Sort();
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }

            #endregion

            #region uzun yazımı
            // Product product1 = new Product(){Id = 1,Name = "bilgisayar",Price = 2800};
            // Product product2 = new Product(){Id = 2,Name = "masa",Price = 5000};
            // Product product3 = new Product()
            // {
            //     Id = 3,
            //     Name = "sandalye",
            //     Price = 8000,
            // };

            //// List<Product> products = new List<Product>() { product1, product2, product3 };//alttaki satırla aynı işi görüyor biraz kısası
            // List<Product> products = new List<Product>();
            // products.Add(product1);
            // products.Add(product2);
            // products.Add(product3);
            #endregion
            //List<Product> products = new List<Product>()// üstteki "UZUN YAZIMI REGİONU" ile aynı hiçbir farkı yok sadece product1, product 2 nesen tanımlamadık ve direk listeye attık.
            //{
            //    new Product(){Id=1,Name="telefon",Price=19000},
            //    new Product(){Id=2,Name="masa",Price=5000},
            //    new Product(){Id=3,Name="sandalye",Price=8000}

            //};
            ////foreach (var product in products)
            ////{
            ////    Console.WriteLine($"name:{product.Name},price:{product.Price}");
            ////}


            #region First Sample
            ////yeni liste yaratın adı da newProducts olsun içine tıpkı yukarıdaki gibi 3 yeni ürün bilgisi girin.

            //List<Product> newProducts = new List<Product>()
            //{
            //    new Product(){Id=4,Name="monitör",Price=15852},
            //    new Product(){Id=5,Name="mouse",Price=123645},
            //    new Product(){Id=6,Name="klavye",Price=158521}

            //};
            ////newProducts içindeki productları products içine ekleyeceğiz
            //products.AddRange(newProducts);
            ////foreach (var product in products)
            ////{
            ////    Console.WriteLine($"name:{product.Name},price:{product.Price}");
            ////}
            ////products.ForEach(p => { 
            ////    Console.WriteLine($"name:{p.Name},price:{p.Price}");
            ////    Console.WriteLine();
            ////});
            //int elemanSayisi=products.Count;//bu count() yok method değil bu sınıfa özgü count bu
            //products.Insert(0, new Product() { Id = 21, Name = "gözlük", Price = 1200 });
            //products.InsertRange(3, newProducts);
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"name:{product.Name},price:{product.Price}");
            //}



            //List<Product> products = new List<Product>()
            //{
            //    new Product(){Id=4,Name="monitör",Price=15852},
            //    new Product(){Id=5,Name="mouse",Price=123645},
            //    new Product(){Id=6,Name="klavye",Price=158521}

            //};
            //ProductModel productModel = new ProductModel()
            //{
            //    Id = 1,
            //    CategoryName="firs category",
            //    Products=products
            //};

            //Console.WriteLine(productModel.CategoryName);

            //foreach (var product in productModel.Products)
            //{
            //    Console.WriteLine($"\t{product.Name}");
            //}
            #endregion


            //içinde 3 adet ProdutcModel tipinde veri barındıran bir list oluşturun
            // her bir ProductModel içinde ise Products özelliğine 3 er adet Product koyun.

            List<ProductModel> productModels = new List<ProductModel>()
            {
                new ProductModel(){Id=1,CategoryName="bilgisayar",Products=new List<Product>()
                {
                    new Product(){Id=1,Name="ürün1",Price=500},
                    new Product(){Id=2,Name="ürün2",Price=500},
                    new Product(){Id=3,Name="ürün3",Price=500},
                }

                },
                  new ProductModel(){Id=11,CategoryName="sandalye",Products=new List<Product>()
                {
                    new Product(){Id=4,Name="ürün11",Price=1500},
                    new Product(){Id=5,Name="ürün12",Price=1500},
                    new Product(){Id=6,Name="ürün13",Price=1500},
                }

                },
                    new ProductModel(){Id=21,CategoryName="masa",Products=new List<Product>()
                {
                    new Product(){Id=7,Name="ürün21",Price=2500},
                    new Product(){Id=8,Name="ürün22",Price=2500},
                    new Product(){Id=9,Name="ürün23",Price=2500},
                }

                }
            };
            foreach (var productmodel in productModels)
            {
                Console.WriteLine($"{productmodel.Id}::category={productmodel.CategoryName}");
                foreach (var product in productmodel.Products)
                {
                    Console.WriteLine($"\t productId:{product.Id}-product name:{product.Name}-Product price{product.Price}");
                }
            }











            Console.ReadKey();

        }

    }
}