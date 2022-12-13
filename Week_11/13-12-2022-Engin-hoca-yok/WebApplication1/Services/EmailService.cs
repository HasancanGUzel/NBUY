namespace WebApplication1.Services
{
    public class EmailService
    {
        public void Send(string to,string message,string topic)
        {
            Console.WriteLine($"{to}-{topic} {message}");
        }
    }
}
