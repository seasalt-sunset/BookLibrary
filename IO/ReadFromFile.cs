using CsvHelper;
using LibraryApp.Entities;
using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using LibraryApp.Repository;
using LibraryApp.DTOs;

namespace LibraryApp.IO
{
    public static class ReadFromFile
    {
        public static void ReadFromCsv(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            using (StreamReader readerAuthor = new StreamReader(pathAuthors))
            using (CsvReader csvAuthor = new CsvReader(readerAuthor, CultureInfo.InvariantCulture))
            {
                var authors = csvAuthor.GetRecords<AuthorExport>().ToList();
                RepositoryMethods.ImportAuthors(context, authors);
            }

            using (StreamReader readerBook = new StreamReader(pathBooks))
            using (CsvReader csvBook = new CsvReader(readerBook, CultureInfo.InvariantCulture))
            {
                var books = csvBook.GetRecords<BookExport>().ToList();
                RepositoryMethods.ImportBooks(context, books);
            }
        }

        public static void ReadFromJson(LibraryAppDbContext context, string path, string pathBooks)
        {

        }

        public static void ReadFromXml(LibraryAppDbContext context, string path, string pathBooks)
        {

        }
    }
}
