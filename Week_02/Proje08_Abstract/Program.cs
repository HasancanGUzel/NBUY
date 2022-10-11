using System.ComponentModel;
using System.Reflection;

namespace Proje08_Abstract
{
    abstract class Person// abstract classtan nesne üretemeyiz bizim Person clasımız abstract olduğu için persondan nesne tanımlayamayız.
    {

        //ctor da constructor tanımlar
        public Person(string firstName,string lastName)
        {
            FirstName = firstName;  
            LastName = lastName;
            Console.WriteLine("person is created");
        }
        public string FirstName { get; set; }//prop yazınca propterties tanımlarız
        public string LastName { get; set; }

        public void Greeting()
        {
            Console.WriteLine("I am a person");
        }
        //public Intro()
        //{
        //    Console.WriteLine($"fistname = {FirstName}, lastname = {LastName}");
        // bunu miras verdiğimiz sınıflarda kullanmak istediğimizde o sınfıın özelliklerini eklememiz gerekiyordu ve bu Personda bulunan ıntro metodu gereksizdi biz bunun için abstract olarak Intro tanımladık ve içi boş,,,, ve bu metodu abstract tanımladığımız için her miras verdiğimiz sınfılarda kullanmak zorundayız.......bunu virtual olarakda yapabiliriz fakat içi doluydu. 

        //}
        public abstract void Intro();//person clasını miras alan class larda Intro zorunlu olmalı 
        //ve Intro yu abstract yaptığımız için Person clasınıda abstrcat yapmamız lazım.
        
    }
    
    class Student:Person
    {
        public Student(string firstName, string lastName,int studenNumber):base(firstName, lastName)
        {
            StudentNumber=studenNumber;
            Console.WriteLine("student is created");
        }
        public int StudentNumber { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"fistname = {FirstName}, lastname = {LastName},studentnumber={StudentNumber}");
        }
    }
    class Teacher:Person
    {
        public Teacher(string firstName, string lastName, string branch) : base(firstName, lastName)
        {
            FirstName=firstName;
            LastName=lastName;
            Branch = branch;
            Console.WriteLine("teacher is created");
        }
        public string Branch { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"fistname = {FirstName}, lastname = {LastName},branch={Branch}");

        }

        public void Teach()
        {
            Console.WriteLine("hi ı am a teaching");
        }
      
    }
    class Writer : Person
    {
        public Writer(string firstName, string lastName, string bookName):base(firstName, lastName)
        {
            FirstName= firstName;
            LastName = lastName;
            BookName = bookName;
            Console.WriteLine("writer is created");
        }
        public string BookName { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"fistname= {FirstName}, lastname = {LastName},Book name={BookName}");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student studen1 = new Student("ayşe", "umay", 101);
            studen1.Greeting();
            studen1.Intro();// istemediğimiz halde persondaki ıntro çalışıyor.
            Console.WriteLine();

            Teacher teacher1 = new Teacher("maria", "canan", "fizik");
            teacher1.Greeting();
            teacher1.Intro();// istemediğimiz halde persondaki ıntro çalışıyor.
            teacher1.Teach();
            Console.WriteLine();

            Writer writer1 = new Writer("math", "haig", "gece yarısı");
            writer1.Greeting();
            writer1.Intro();
            Console.WriteLine();

            //Person person1 = new Person("halil", "mahmut");// abstract classtan nesne üretemeyiz bizim Person clasımız abstract olduğu için persondan nesne tanımlayamayız.




            Console.ReadKey();
        }
    }
}