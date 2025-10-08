using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.UI
{
    public class UserInterface
    {
        public LibraryAppDbContext context { get; set; }

        public UserInterface (LibraryAppDbContext context)
        {
            this.context = context;
        }

        public void start()
        {
           
        }

        public int Menu()
        {
            int number = 0;
            bool parsed = false;

            Console.WriteLine("Welcome to The Broken Library. Pick your poison:");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Modify");
            Console.WriteLine("3) View");
            Console.WriteLine("4) View All");
            Console.WriteLine("5) Remove");
            Console.WriteLine("6) Exit");

                

            switch(number)
            {
                case 1:
                    Console.WriteLine("Do you want to add an author (press 1) or a book (press 2)?");
                    break;
                case 2:
                    Console.WriteLine("Do you want to modify an author (press 1) or a book (press 2)?");
                    break;
                case 3:
                    Console.WriteLine("Do you want to view the details of an author (press 1) or of a book (press 2)?");
                    break;
                case 4:
                    Console.WriteLine("Do you want to view all the authors (press 1), all the books (press 2) or both (press 3)?");
                    break;
                case 5:
                    Console.WriteLine("Do you want to remove an author (press 1) or a book (press 2)?");
                    break;

            }
        }

        public int ReadNumber(int min, int max)
        {
            while(true)
            {
                bool parsed = false;
                int number = -1;
                string input = Console.ReadLine();
                parsed = int.TryParse(input, out number);
                if (parsed) return number;
                if (!parsed || (number < min && number > max)) Console.WriteLine("Inserisci il valore corretto.");
            }
        }
    }
}
