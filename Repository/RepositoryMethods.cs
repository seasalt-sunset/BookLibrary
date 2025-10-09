using LibraryApp.Entities;
using LibraryApp.Infrastructure;
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
    }
}
