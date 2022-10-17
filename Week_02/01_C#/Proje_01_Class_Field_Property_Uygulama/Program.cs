namespace Proje_01_Class_Field_Property_Uygulama
{
    internal class Program
    {

        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }




        }


        static void Main(string[] args)
        {
            //bir product clasımız olacak  içinde name price description
            //istenildiği kadar product bilgisinin girilmesini sağlayacağız
            //kaç adet product bilgisi girileceğini kullanıcı belirlesin
            //product ekleme işi bitince eklenmiş productlar listelensin.

            //Console.Write("kaç adet ürün gireceksiniz");
            //int adet=int.Parse(Console.ReadLine());
            //Product[] products= new Product[adet];
            //Product product;
            //for (int i = 0; i < adet; i++)
            //{
            //    product = new Product();

            //    Console.WriteLine("product name:");
            //    product.Name = Console.ReadLine();

            //    Console.WriteLine("product price");
            //    product.Price = decimal.Parse(Console.ReadLine());

            //    Console.WriteLine("product description");
            //    product.Description=Console.ReadLine();

            //    products[i] = product;
            //}
            //Console.WriteLine("Product Name:\t Product Price\t Product Description");
            //foreach (var prd in products)
            //{
            //    Console.WriteLine($"{prd.Name}\t{prd.Price}\t{prd.Description}");
            //}

            #region Rastgeledgerureterek
            Product[] products = new Product[5];
            Product product;
            string[] pro = {"Galaxy a50","HP Notebook","macbook air m2","iphone 14 plus","LG 27 monitör"};
            string[] desc = {"iyi","güzel","kötü","şaşırtıcı","heyecan verici"};
            Random rnd=new Random();
            Console.WriteLine("zam oranını giriniz");
            decimal oran=decimal.Parse(Console.ReadLine());
            decimal[]eskifiyat=new decimal[5];
            
            for (int i = 0; i < 5; i++)
            {
                
                product = new Product()
                {
                    Name = pro[rnd.Next(0, 5)],
                    Description = desc[rnd.Next(0, 5)],
                    Price = rnd.Next(100, 1000)

                };
                eskifiyat[i] = product.Price;
                product.Price = product.Price * (1 + (oran / 100));
                products[i] = product;
                
            }
            Console.WriteLine("Product name".PadRight(20) + "eski fiyat".PadRight(15) + "Product Price".PadRight(15) + "Product Description");
            Console.WriteLine();
            int j = 0;
            foreach (var prd in products)
            {
                Console.WriteLine($"{prd.Name.PadRight(20)}{eskifiyat[j].ToString().PadRight(15)}{prd.Price.ToString().PadRight(15)}{prd.Description}");
                j++;
            }
            
            //pad.right yazıyı veya rakamı sola yaslar ve sağa doğru istediğimiz karakter de boşluk bırakır
            //pad.left yazyı veya rakamı sağa yaslar ve sola doğru istediğimiz karakter de boşluk bırakır.
            #endregion

        }


    }
}