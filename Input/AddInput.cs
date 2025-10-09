using LibraryApp.Entities;
using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LibraryApp.Input
{
    public static class AddInput
    {
        public static void AddAuthor(LibraryAppDbContext context, bool added = false, string name = null)
        {
            string choice = "";
            DateTime date = new DateTime();
            DateTime deathTemp = new DateTime();
            Console.WriteLine("Write the name of the author");
            name = Console.ReadLine();
            Console.WriteLine("Write the birth date of the author (dd/MM/yyyy)");
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out date);
                if (!success) { Console.WriteLine("Wrong input"); }
            }
            Console.WriteLine("Write the nationality");
            string nationality = Console.ReadLine();
            Console.WriteLine("What's its death date? (dd/MM/yyyy) (Leave empty if he's still breathing)");
            success = false;
            while (!success)
            {
                string input = Console.ReadLine();
                if (input == "") break;
                success = DateTime.TryParse(Console.ReadLine(), out deathTemp);
            }
            DateTime? deathDate = success ? deathTemp : null;

            var author = new Author()
            {
                Name = name,
                BirthDate = date,
                Nationality = nationality,
                DeathDate = deathDate,
                Books = new List<Book>()
            };
            // METODO PER AGG AL DATABASE
            if (added)
            {
                return;
            }
            while(choice!= "y" && choice!= "n")
            {
                added = false;
                
                if (added)
                {
                    Console.WriteLine("Do you want to add another book?");
                }
                else
                { 
                    Console.WriteLine("Do you want to add a book? (y/n)");
                }
                choice = Console.ReadLine();
                if(choice != "y" && choice != "n") Console.WriteLine("Wrong input.");
                if(choice == "y")
                {

                    AddBook(context, name);
                }
            }
        }

        public static void AddBook(LibraryAppDbContext context, string authorName = null)
        {
            Console.WriteLine("Write the name of the book");
            string name = Console.ReadLine();
            Console.WriteLine("Write the genre of the book");
            string genre = Console.ReadLine();
            Console.WriteLine("Write the publishing date (dd/MM/yyyy)");
            bool success = false;
            DateTime publishingDate = new DateTime();
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out publishingDate);
                if (!success) { Console.WriteLine("Wrong input"); }
            }
            Console.WriteLine("Write the number of pages");
            int numberOfPages = 0;
            success = false;
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out numberOfPages);
                if (!success) { Console.WriteLine("Wrong input"); }
            }
            if(authorName == null)
            {
                Console.WriteLine("Write the name of the author:");
                authorName = Console.ReadLine();
                AddAuthor(context, true, authorName);
            }

            Author authorSearched;//AGG METODO PER CERCARE SE L'AUTORE ESISTE IN DATABASE

            var book = new Book
            {
                Name = name,
                Genre = genre,
                PublishingDate = publishingDate,
                NumberOfPages = numberOfPages != 0 ? numberOfPages : null,
                AuthorId = authorSearched.AuthorId,
                Author = authorSearched
            };

            //AGG METODO PER AGG BOOK IN DATABASE




        }

    }
}
