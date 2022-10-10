using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje02_Methods
{
    //public static class MethodOverload
    public  class MethodOverload // bu sınıfı static tanımlamaz isem program cs sınıfında nesne tanımlamak zorundayım ama program cs. sınıfı adının yanında static yazmasada gizli statictir.
    {
        public void DenemeMetodu()
        {
            Console.WriteLine("merhaba");
            //Program.Topla(3,5);////program cs den topla metodunu çağırdım
        }
        public int Topla(int sayi1, int sayi2,int sayi3=0)
         //sayi3 0 yapmammım sebebi program cs de bu metodu çağırdığımız zaman adam 3 sayı değilde 2 sayı girmek isterse 3.sayı zorunlu olmadığını gösteriyor
        {
            int toplam = sayi1 + sayi2+sayi3;
            return toplam;
        }
        public int Topla(int[]sayilar) // aynı isimde method tanımlarsak parantez içi üsttekinden farklı olması lazım buna overload denir
        
        {
            int sonuc=sayilar.Sum();
            return sonuc;
        }

        //gönderilen üç sayı arasında istersem toplama, istersem çarpma yapsın
        public int Islem(bool islemturu, int s1, int s2, int s3 = 0)//bool islemturu aşağıda kontrol ettirip true ise topla false ise çarp yapabiliriz eğer bool islemturu sonda olsaydı s3=0 yanında bool islemturu=true veya bool islemturu =false yapmamız lazımdı.
        {

            return 0;
            
        }

    }
}
