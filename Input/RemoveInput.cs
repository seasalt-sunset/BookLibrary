using LibraryApp.Infrastructure;
using LibraryApp.Repository;
using LibraryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Input
{
    public static class RemoveInput
    {
        public static void RemoveAuthor(LibraryAppDbContext context)
        {
            Author author = null;
            string authorName = "";
            while (author == null)
            {
                Console.WriteLine("Write the name of the author you want to remove:");
                authorName = Console.ReadLine();
                author = RepositoryMethods.FindAuthor(context, authorName);
                if(author == null) Console.WriteLine("\nAuthor not found.\n");
            }
            RepositoryMethods.RemoveAuthor(context, author);
            Console.WriteLine("\nAuthor removed.\n");
        }

        public static void RemoveBook(LibraryAppDbContext context)
        {
            Book book = null;
            string bookName = "";

            while (book == null)
            {
                Console.WriteLine("Write the name of the book you want to remove:");
                bookName = Console.ReadLine();
                book = RepositoryMethods.FindBook(context, bookName);
                if(book == null) Console.WriteLine("\nBook not found.\n");
            }
            RepositoryMethods.RemoveBook(context, book);
            Console.WriteLine("\nBook removed.\n");
        }

        public static void RemoveAllAuthors(LibraryAppDbContext context)
        {
            var authors = RepositoryMethods.FindAllAuthors(context);

            foreach (var author in authors)
            {
                RepositoryMethods.RemoveAuthor(context, author);
            }
            Console.WriteLine("\nAll authors and books removed.\n");
        }

        public static void RemoveAllBooks(LibraryAppDbContext context)
        {
            var books = RepositoryMethods.FindAllBooks(context);

            foreach(var book in books)
            {
                RepositoryMethods.RemoveBook(context, book);
                Console.WriteLine("\nAll books removed.\n");
            }
        }
    }
}
