using LibraryApp.DTOs;
using LibraryApp.Entities;
using LibraryApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository
{
    public static class RepositoryMethods
    {
        public static void AddAuthor (LibraryAppDbContext context, Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public static void AddBook(LibraryAppDbContext context, Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public static Author? FindAuthor(LibraryAppDbContext context, string authorName)
        {
            return context.Authors.FirstOrDefault(author => author.Name == authorName);
        }

        public static Author? FindAuthorIncludeBooks(LibraryAppDbContext context, string authorName)
        {
            return context.Authors.Include(author => author.Books)
                .FirstOrDefault(author => author.Name == authorName);
        }

        public static List<Author> FindAllAuthors(LibraryAppDbContext context)
        {
            return context.Authors.Include(a => a.Books).ToList();
        }

        public static List<Book> FindAllBooks(LibraryAppDbContext context)
        {
            return context.Books.Include(b => b.Author).ToList();
        }

        public static List<AuthorExport> GetAuthorsExport(LibraryAppDbContext context)
        {
            var authors = context.Authors.Select(a => new AuthorExport()
            {
                AuthorId = a.AuthorId,
                Name = a.Name,
                BirthDate = a.BirthDate,
                Nationality = a.Nationality,
                DeathDate = a.DeathDate
            }).ToList();

            return authors;
        }


        public static List<BookExport> GetBooksExport(LibraryAppDbContext context)
        {
            var authors = context.Books.Select(b => new BookExport()
            {
                BookId = b.BookId,
                Name = b.Name,
                Genre = b.Genre,
                PublishingDate = b.PublishingDate,
                NumberOfPages = b.NumberOfPages,
                AuthorId = b.AuthorId
            }).ToList();

            return authors;
        }

        public static void ImportAuthors(LibraryAppDbContext context, IEnumerable<AuthorExport> authors)
        {
            foreach (var author in authors)
            {
                var entry = new Author()
                {
                    AuthorId = author.AuthorId,
                    Name = author.Name,
                    BirthDate = author.BirthDate,
                    Nationality = author.Nationality,
                    DeathDate = author.DeathDate,
                    Books = new List<Book>()
                };
                context.Authors.Add(entry);
            }
            context.SaveChanges();
        }

        public static void ImportBooks(LibraryAppDbContext context, IEnumerable<BookExport> books)
        {
            foreach(var book in books)
            {
                var entry = new Book()
                {
                    BookId = book.BookId,
                    Name = book.Name,
                    Genre = book.Genre,
                    PublishingDate = book.PublishingDate,
                    NumberOfPages = book.NumberOfPages,
                    AuthorId = book.AuthorId
                };
                if(context.Authors.Select(a => a.AuthorId).Contains(book.AuthorId))
                {
                    context.Books.Add(entry);
                }
            }
            context.SaveChanges();
        }

        public static Book? FindBook(LibraryAppDbContext context, string bookName)
        {
            return context.Books.FirstOrDefault(book => book.Name == bookName);
        }

        public static Book? FindBookIncludeAuthor(LibraryAppDbContext context, string bookName)
        {
            return context.Books.Include(book => book.Author)
                .FirstOrDefault(book => book.Name == bookName);
        }

        public static void RemoveAuthor(LibraryAppDbContext context, Author author)
        {
            var existingAuthor = context.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
            context.Authors.Remove(existingAuthor);

            context.SaveChanges();
        }

        public static void RemoveBook(LibraryAppDbContext context, Book book)
        {
            var existingBook = context.Books.FirstOrDefault(b => b.BookId == book.BookId);
            context.Books.Remove(existingBook);

            context.SaveChanges();
        }
    }
}
