using LibraryApp.Infrastructure;
using LibraryApp.UI;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using LibraryAppDbContext context = new LibraryAppDbContext();
                UserInterface ui = new UserInterface(context);
                ui.start();

            }
            catch(Exception e)
            {
                Console.WriteLine($"Error!!!!!!!! {e.Message}");
            }
        }
    }
}
