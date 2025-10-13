using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LibraryApp.Input;

namespace LibraryApp.UI
{
    public class UserInterface
    {
        public LibraryAppDbContext context { get;}

        public UserInterface (LibraryAppDbContext context)
        {
            this.context = context;
        }

        public void start()
        {
            while(true)
            {
                EnumMenu choice = Menu();
                switch(choice)
                {
                    case EnumMenu.AddAuthor:
                        AddInput.AddAuthor(context);
                        break;
                    case EnumMenu.AddBook:
                        AddInput.AddBook(context);
                        break;
                    case EnumMenu.ModifyAuthor:
                        ModifyInput.ModifyAuthor(context);
                        break;
                    case EnumMenu.ModifyBook:
                        ModifyInput.ModifyBook(context);
                        break;
                    case EnumMenu.ViewAuthor:
                        break;
                    case EnumMenu.ViewBook:
                        break;
                    case EnumMenu.ViewAllAuthors:
                        break;
                    case EnumMenu.ViewAllBooks:
                        break;
                    case EnumMenu.ViewAll:
                        break;
                    case EnumMenu.RemoveAuthor:
                        break;
                    case EnumMenu.RemoveBook:
                        break;
                }
            }
           
        }

        public EnumMenu Menu()
        {
            Console.WriteLine("Welcome to The Broken Library. Pick your poison:");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Modify");
            Console.WriteLine("3) View");
            Console.WriteLine("4) View All");
            Console.WriteLine("5) Remove");
            Console.WriteLine("6) Exit");

            int number = ReadNumber(1, 6);
            EnumMenu choice;

            switch(number)
            {
                case 1:
                    Console.WriteLine("Do you want to add an author (press 1) or a book (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.AddAuthor : EnumMenu.AddBook;
                    break;
                case 2:
                    Console.WriteLine("Do you want to modify an author (press 1) or a book (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.ModifyAuthor : EnumMenu.ModifyBook;
                    break;
                case 3:
                    Console.WriteLine("Do you want to view the details of an author (press 1) or of a book (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.ViewAuthor : EnumMenu.ViewBook;
                    break;
                case 4:
                    Console.WriteLine("Do you want to view all the authors (press 1), all the books (press 2) or both (press 3)?");
                    number = ReadNumber(1, 3);
                    choice = number == 1 ? EnumMenu.ViewAllAuthors : number == 2 ? EnumMenu.ViewAllBooks : EnumMenu.ViewAll;
                        break;
                case 5:
                    Console.WriteLine("Do you want to remove an author (press 1) or a book (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.RemoveAuthor : EnumMenu.RemoveBook;
                    break;
                default:
                    choice = EnumMenu.Exit;
                    break;

            }
            return choice;
        }

        public int ReadNumber(int min, int max)
        {
            while(true)
            {
                bool parsed = false;
                int number = -1;
                string input = Console.ReadLine();
                parsed = int.TryParse(input, out number);
                if (parsed)
                {
                    return number;
                }
                if (!parsed || (number < min && number > max)) Console.WriteLine("Inserisci il valore corretto.");
            }
        }
    }
}
