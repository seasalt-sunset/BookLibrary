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
using LibraryApp.IO;

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
                        ViewInput.ViewAuthor(context);
                        break;
                    case EnumMenu.ViewBook:
                        ViewInput.ViewBook(context);
                        break;
                    case EnumMenu.ViewAllAuthors:
                        ViewInput.ViewAllAuthors(context);
                        break;
                    case EnumMenu.ViewAllBooks:
                        ViewInput.ViewAllBooks(context);
                        break;
                    case EnumMenu.RemoveAuthor:
                        RemoveInput.RemoveAuthor(context);
                        break;
                    case EnumMenu.RemoveBook:
                        RemoveInput.RemoveBook(context);
                        break;
                    case EnumMenu.RemoveAllAuthors:
                        RemoveInput.RemoveAllAuthors(context);
                        break;
                    case EnumMenu.RemoveAllBooks:
                        RemoveInput.RemoveAllBooks(context);
                        break;
                    case EnumMenu.WriteToFile:
                        InputOutput.ChooseFormat(context, ReadOrWrite.Write);
                        break;
                    case EnumMenu.ReadFromFile:
                        InputOutput.ChooseFormat(context, ReadOrWrite.Read);
                        break;
                    case EnumMenu.Exit:
                        return;
                    case EnumMenu.WrongInput:
                        Console.WriteLine("Wrong input.");
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
            Console.WriteLine("6) Remove All");
            Console.WriteLine("7) Export library to file");
            Console.WriteLine("8) Import library from file");
            Console.WriteLine("9) Exit");

            int number = ReadNumber(1, 6);
            EnumMenu choice = 0;

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
                    Console.WriteLine("Do you want to view all the authors (press 1) or all the books (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.ViewAllAuthors : EnumMenu.ViewAllBooks;
                    break;
                case 5:
                    Console.WriteLine("Do you want to remove an author (press 1) or a book (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.RemoveAuthor : EnumMenu.RemoveBook;
                    break;
                case 6:
                    Console.WriteLine("Do you want to remove all Authors and their books (press 1) or only the books (press 2)?");
                    number = ReadNumber(1, 2);
                    choice = number == 1 ? EnumMenu.RemoveAllAuthors : EnumMenu.RemoveAllBooks;
                    break;
                case 7:
                    choice = EnumMenu.WriteToFile;
                    break;
                case 8:
                    choice = EnumMenu.ReadFromFile;
                    break;
                case 9:
                    choice = EnumMenu.Exit;
                    break;
                default:
                    Console.WriteLine("\nWrong input.\n");
                    choice = EnumMenu.WrongInput;
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
