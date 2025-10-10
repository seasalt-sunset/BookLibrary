using LibraryApp.Entities;
using LibraryApp.Infrastructure;
using LibraryApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Input
{
    public static class ModifyInput
    {
        public static void ModifyAuthor(LibraryAppDbContext context, Author? author = null)
        {
            while(author == null)
            {
                Console.WriteLine("Write the name of the author:");
                string authorName = Console.ReadLine();
                author = RepositoryMethods.FindAuthor(context, authorName);
                if(author==null) { Console.WriteLine("Name not found."); }
            }
            int choice = -1;
            do
            {
                Console.WriteLine("What do you wanna modify?");
                Console.WriteLine("1) Name");
                Console.WriteLine("2) BirthDate");
                Console.WriteLine("3) Nationality");
                Console.WriteLine("4) DeathDate");
                Console.WriteLine("5) Return to main menu");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Write the new name:");
                        string newName = Console.ReadLine();
                        author.Name = newName;
                        context.SaveChanges();
                        break;
                    case 2:
                        DateTime newBirthDate = new DateTime();
                        success = false;
                        while (!success)
                        {
                            Console.WriteLine("Write the new BirthDate (dd/MM/yyyy):");
                            string inputDate = Console.ReadLine();
                            success = DateTime.TryParse(inputDate, out newBirthDate);
                            if (!success) Console.WriteLine("Wrong input");
                        }
                        author.BirthDate = newBirthDate;
                        context.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Write the new Nationality");
                        string newNationality = Console.ReadLine();
                        author.Nationality = newNationality;
                        context.SaveChanges();
                        break;
                    case 4:
                        DateTime newDeathDate = new DateTime();
                        success = false;
                        while (!success)
                        {
                            Console.WriteLine("Write the new Death Date (dd/MM/yyyy):");
                            string inputDate = Console.ReadLine();
                            success = DateTime.TryParse(inputDate, out newDeathDate);
                            if (!success) Console.WriteLine("Wrong input");
                        }
                        author.DeathDate = newDeathDate;
                        context.SaveChanges();
                        break;
                    case 5:
                        break;
                }
            } while (choice != 5);
        }

        public static void ModifyBook(LibraryAppDbContext context, Book? book = null)
        {
            while(book == null)
            {
                Console.WriteLine("Write the book name");
                string bookName = Console.ReadLine();
                book = RepositoryMethods.FindBook(context, bookName);
                if(book==null) { Console.WriteLine("Book not found"); }
            }
            
            bool selected = false;
            int choice = 0;
            while (true)
            {
                Console.WriteLine("What do you wanna modify?:" +
                                    "1) Name" +
                                    "2) Genre" +
                                    "3) Publishing date" +
                                    "4) Number of pages" +
                                    "5) Author");
                selected = int.TryParse(Console.ReadLine(), out choice);
                if (choice >= 1 && choice <= 3) break;
            }
                
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Write the new name:");
                    book.Name = Console.ReadLine();
                    context.SaveChanges();
                    return;
                case 2:
                    Console.WriteLine("Write the new genre:");
                    book.Genre = Console.ReadLine();
                    context.SaveChanges();
                    break;
                case 3:
                    DateTime publishingDate = new DateTime();
                    bool success = false;
                    while (!success)
                    {
                        Console.WriteLine("Write the new publishing Date (dd/MM/yyyy):");
                        string inputDate = Console.ReadLine();
                        success = DateTime.TryParse(inputDate, out publishingDate);
                        if (!success) Console.WriteLine("Wrong input");
                    }
                    book.PublishingDate = publishingDate;
                    context.SaveChanges();
                    break;
                case 4:
                    int numberOfPages = -1;
                    bool succ = false;
                    while (!succ)
                    {
                        Console.WriteLine("Write the new number of page:");
                        string input = Console.ReadLine();
                        succ = int.TryParse(input, out numberOfPages);
                    }
                    book.NumberOfPages = numberOfPages;
                    context.SaveChanges();
                    break;
                case 5:
                    Console.WriteLine("Write the name of the author");
                    string inputAuthorName = Console.ReadLine();
                    Author? searchedAuthor = RepositoryMethods.FindAuthor(context, inputAuthorName);
                    if(searchedAuthor == null)
                    {
                        AddInput.AddAuthor(context, true, inputAuthorName);
                        searchedAuthor = RepositoryMethods.FindAuthor(context, inputAuthorName);
                    }
                    book.Author = searchedAuthor;
                    context.SaveChanges();
                    break;

            }

        }
    }
}
