namespace Proje07_Constructor_Methods
{

    class Person
    {
        public Person()// constructor metot !!!!KURAL!!! constructor metotların tipi olmaz
        {
            // Her class ın default olarak boş bir metodu vardır ama implicittir yani örtülü gizlidir. Şu anda biz kendimizi bir constructor method yazdık.
            // her clasın boş defaul constructuru vardır fakat biz bir tane constructor tanımlarsak ve onu overload edersek parametresiz olan constructuru silsek artık tek bir constructor vardır ve default olarak başka yoktur.
            // cosntructor method ilgili clastan new keyword ile yeni bir nesne yaratıldığı esnda çalışacak kodları barındırı.
            // yani bu classtan bir nesne üretildiği anda buradaki kodlar çalışır
            Console.WriteLine("merhaba ben person şu an yaratıldım");
        }
        // constructor metotlar miras verilen sınıfta aynı şekilde kullanılmaz sadece tanımlanan classta kullanılır. bunun için miras verilen sınıfında kendi şiçinde constructor metot tanımlaması lazım.
        
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Student:Person
    {
        public Student(string firstName , string lastName, int studenNumber): base(firstName,lastName)
        {
            //student constructurundaki parametreler ile person cosntrundaki parametrelerin adı aynı olmak zorunda değil

            //FirstName = firstName;
            //LastName = lastName;
            ////biz main de Student dan ürettiğimiz student1 nesnesindeki isim ve soyisim değerlerini burda etkisiz hale getirdiğimiz için Miraas aldığımız Person clasına göndermek istiyorsak studen daki cosntructurun parametrelerinin yanına :base yazıp studen constructurundaki parametreleri Person clasına göndermemiz lazım. ve böyle yaptığımız zaman önceden parametresiz Person constructoru çalışırken :base yaptıktan sonra Persondaki parametreli constructor çalışır ve ekrana console.write içindeki bilgiyi yazmaz.


            StudentNumber = studenNumber;
        }
        public int StudentNumber { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person1 = new Person();
            //Person person2 = new Person("hasan", "güzel");
            //Console.WriteLine(person2.FirsName+ "   " +person2.LastName);

            Student studen1 = new Student("ahmet","can",545);
            Console.WriteLine(studen1.FirsName+" "+studen1.LastName+" "+studen1.StudentNumber);
            Console.ReadKey();
        }
    }
}