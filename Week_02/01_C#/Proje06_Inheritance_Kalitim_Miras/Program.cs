namespace Proje06_Inheritance_Kalitim_Miras
{
    class Person // bir class istenilidği kadar class a miras verebilir.
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual void Intro()// virtual keywordu bu metodun miras alınan classlarda override (ezilmesine)izin verir.
        {
            Console.WriteLine($"First Name={this.FirstName}, LastName={this.LastName}");
        }

    }
    class Writer:Person
    {
        public string BookName { get; set; }
    }
    class Teacher:Person
    {
        public string Branch { get; set; }
    }

    class Student:Person // studen sınıfını person sınıfından kalıtım aldırdık yani person sınıfında firstname ve lastname studen sınıfında tanımlamadığımız halde kalıtım aldığımız için kullanabiliriz.
        // bir class sadece tek bir classtan miras alabilir (ama soyutlama(interface) ile bir çok sınıftan miras alabilirs)
       
    {
        public int StudentNumber { get; set; }
        public override void Intro()// bu metodun miras alınan sınıftaki versiyonunu ezip yok sayıp yerine bu metodu kabul eder.
        {
            Console.WriteLine($"First Name={this.FirstName}, LastName={this.LastName}, StudentNumber={this.StudentNumber}");

        }
    }
    class a
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
    class b : a
    {
        public int MyProperty3 { get; set; }
        public int MyProperty4 { get; set; }

    }
    class c : b
    {
        public int MyProperty5 { get; set; }
        public int MyProperty6 { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Student student = new Student();
            student.FirstName = "kemal";
            student.LastName = "kapucu";
            student.StudentNumber = 125;
            student.Intro();
            

            //bir teacher tanımla ve içini doldur
            Teacher teacher = new Teacher();
            teacher.FirstName = "AHMET";
            teacher.LastName = "mehmet";
            teacher.Branch = "matematik";
            teacher.Intro();

            Person person1 = new Student();// person studen olarak tanımlanabilriken
            //Student studen1 = new Person();//studen person olarak tanımlanamıyor. 





            Console.ReadLine();
        }
    }
}