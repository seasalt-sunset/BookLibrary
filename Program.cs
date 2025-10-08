using LibraryApp.Infrastructure;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using LibraryAppDbContext context = new LibraryAppDbContext();

            }
            catch(Exception e)
            {
                Console.WriteLine($"Errore!!!!!!!! {e.Message}");
            }
        }
    }
}
