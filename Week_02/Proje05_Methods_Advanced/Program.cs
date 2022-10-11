namespace Proje05_Methods_Advanced
{
    internal class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Intro()
            {
                return $"ad: {this.Name}, Yaş:{this.CalculateAge()}";// burdaki this.name class person içindeki name değil  main içindeki tanımladığım nesnelerin name i
            }
            private int CalculateAge()
            {
                return DateTime.Now.Year - this.Year;
            }
        }
            
        static void Main(string[] args)
        {
            Person person1 = new Person() {Name = "engin", Year = 1991};
            Person person2 = new Person() { Name = "umay", Year = 1972 };
            Person person3 = new Person() { Name = "ahmet", Year = 1975 };
            Person person4 = new Person() { Name = "mehmet", Year = 1963 };
            
            Console.WriteLine(person3.Intro());
            // TÜM kişilerin intro bilgilerini ekrana yazdırın.
            Person[] persons ={ person1, person2, person3,person4 };
            foreach (var person in persons)
            {
                Console.WriteLine(person.Intro());
            }
            Console.ReadLine();

            //C# DA HER ŞEY BİR  NESNEDİR!!!!



        }
    }
}