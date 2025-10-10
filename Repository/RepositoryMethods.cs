using LibraryApp.Entities;
using LibraryApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
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

        public static Book? FindBook(LibraryAppDbContext context, string bookName)
        {
            return context.Books.FirstOrDefault(book => book.Name == bookName);
        }

        public static void RemoveAuthor(LibraryAppDbContext context, Author author)
        {
            var existingAuthor = context.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId)
                context.Authors.Remove(existingAuthor);
        }

        public static void RemoveBook(LibraryAppDbContext context, Book book)
        {
            var existingBook = context.Books.FirstOrDefault(b => b.BookId == book.BookId);
                context.Books.Remove(existingBook);
        }
    }
}
