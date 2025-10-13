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
    public static class ViewInput
    {
        public static void ViewAuthor(LibraryAppDbContext context, Author? author = null)
        {
            string authorName = "";
            while (author == null)
            {
                Console.WriteLine("What's the author's name that you're looking for?");
                authorName = Console.ReadLine();
                author = RepositoryMethods.FindAuthor(context, authorName);
                if (author == null) { Console.WriteLine("\nAuthor not found.\n"); }
            }
            var bookList = author.Books.ToList();
            Console.WriteLine();
            Console.WriteLine($"Author: {author.Name}");
            Console.WriteLine($"Birth date: {author.BirthDate}");
            Console.WriteLine($"Nationality: {author.Nationality}");
            Console.WriteLine($"Death date: {author.DeathDate}");
            Console.WriteLine($"Book list:");
            ViewAuthorBooks(context, author);
        }

        public static void ViewAuthorBooks(LibraryAppDbContext context, Author author)
        {
            foreach(var book in author.Books)
            {
                
                Console.WriteLine($"Name: {book.Name}\tGenre: {book.Genre}\tRelease date: {book.PublishingDate}\tAuthor: {book.Author.Name}");
            }
            Console.WriteLine();
        }

        public static void ViewAllAuthors(LibraryAppDbContext context)
        {
            var allAuthors = RepositoryMethods.FindAllAuthors(context);

            foreach(var author in allAuthors)
            {
                ViewAuthor(context, author);
            }
        }

        public static void ViewBook(LibraryAppDbContext context, Book? book = null)
        {
            string bookName = "";
            while (book == null)
            {
                Console.WriteLine("What's the name of the book that you're looking for?");
                bookName = Console.ReadLine();
                book = RepositoryMethods.FindBook(context, bookName);
                if(book == null) { Console.WriteLine("\nBook not found.\n"); }
            }

            Console.WriteLine($"Book: {book.Name}");
            Console.WriteLine($"Genre: {book.Genre}");
            Console.WriteLine($"Release date: {book.PublishingDate}");
            Console.WriteLine($"Author: {book.Author.Name}");
            Console.WriteLine($"Number of pages: {book.NumberOfPages}");
            Console.WriteLine();
        }

        public static void ViewAllBooks(LibraryAppDbContext context)
        {
            var allBooks = RepositoryMethods.FindAllBooks(context);

            foreach (var book in allBooks)
            {
                ViewBook(context, book);
            }
        }




    }
}
