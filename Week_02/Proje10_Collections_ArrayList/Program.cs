using System.Collections;

namespace Proje10_Collections_ArrayList
{
    internal class Program
    {

        static void Yazdir(ArrayList List)
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            ArrayList sayilar = new ArrayList() { 54, 12, 66, 34, 19 };
            Yazdir(sayilar);
            Console.WriteLine("********");

            //for (int i = 0; i < sayilar.Count; i++)
            //{
            //    Console.WriteLine(sayilar[i]);
            //}
            sayilar.Sort();
            Yazdir(sayilar);
            Console.WriteLine("********");
            sayilar.Reverse();
            Yazdir(sayilar);


            //ya da bu kullanılabilir üstteki for la aynı daha kısa kullanışlı
            //foreach (var sayi in sayilar)
            //{
            //    Console.WriteLine(sayi);
            //}











            //ArrayList myList=new ArrayList();// veri tipi tanımlamayız yani her indeksine farklı veri tipleri ekleyebiliriz yani 0 indekse string 1. indekse sayı vs gibi ekleyebiliriz.
            //myList.Add(120);
            //myList.Add("120");
            //myList.Add("zeynep");
            //myList.Add(11.55);
            //myList.Add(DateTime.Now);
            //myList.Add(true);

            //myList.Insert(1, "yeni eleman");// ınsert arraylistte veriyi kaçıncı index ekleyemeye yarar.

            //ArrayList addedList = new ArrayList() { "ayşen umay","fercan sercan","kazım kolkanat"};
            //myList.InsertRange(4, addedList);// sonradan oluşturduğumuz addedList deki verileri mylist e eklemek için InsertRange kullanırız ve mylist teki istedğimiz yere ekliyoruz
            //myList.AddRange(addedList);//addrange ise eklemek istediğimiz addedlist i eski listemizin sonuna ekler.
            //myList.Remove("120");// listenin içinden istediğimiz veriyi ismiyle silebilirirz.
            //myList.RemoveAt(0);// isim değilde index ini girerekde silebiliriz.
            //myList.RemoveRange(3, 2);// removerange ise kaçıncı indexten başlayarak kaç tane sileceğimizi belirleriz.

            //foreach (var item in myList)
            //{
            //    Console.WriteLine(item);
            //}

            //if (myList.Contains("zeynep")==true)
            //{
            //    Console.WriteLine("zeynep listede mevcut");
            //}
            //else
            //{
            //    Console.WriteLine("acil zeynep'e haber ver listede yok");
            //}
            //Console.WriteLine();
            //Console.WriteLine(myList[3]);

            Console.ReadKey();
        }
    }
}