using LibraryApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Web;
using CsvHelper;
using System.Globalization;
using LibraryApp.Repository;
using LibraryApp.Infrastructure;
using System.Xml.Serialization;
using LibraryApp.Entities;
using LibraryApp.DTOs;
using Newtonsoft.Json;

namespace LibraryApp.IO
{
    public static class WriteToFile
    {

        public static void WriteToCsv(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            WriteToCsvAuthors(context, pathAuthors);
            WriteToCsvBooks(context, pathBooks);
        }
        
        public static void WriteToCsvAuthors(LibraryAppDbContext context, string pathAuthors)
        {
            using (StreamWriter writerAuthors = new StreamWriter(pathAuthors))
            using (CsvWriter csvAuthors = new CsvWriter(writerAuthors, CultureInfo.InvariantCulture))
            {
                var allAuthors = RepositoryMethods.GetAuthorsExport(context);
                csvAuthors.WriteRecords(allAuthors);
            }

            Console.WriteLine("\nExport of authors completed!\n");
        }

        public static void WriteToCsvBooks(LibraryAppDbContext context, string pathBooks)
        {
            using (StreamWriter writerBooks = new StreamWriter(pathBooks))
            using (CsvWriter csvBooks = new CsvWriter(writerBooks, CultureInfo.InvariantCulture))
            {
                var allBooks = RepositoryMethods.GetBooksExport(context);
                csvBooks.WriteRecords(allBooks);
            }

            Console.WriteLine("\nExport of books completed!\n");
        }

        public static void WriteToJson(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            

            

            Console.WriteLine("\nExport completed!\n");

        }

        public static void WriteToJsonAuthors(LibraryAppDbContext context, string pathAuthors)
        {
            var authors = RepositoryMethods.GetAuthorsExport(context);
            string authorsJson = JsonConvert.SerializeObject(authors);
            File.WriteAllText(pathAuthors, authorsJson);

            Console.WriteLine("\nExport of authors completed!\n");
        }
        public static void WriteToJsonBooks(LibraryAppDbContext context, string pathBooks)
        {
            var books = RepositoryMethods.GetBooksExport(context);
            string booksJson = JsonConvert.SerializeObject(books);
            File.WriteAllText(pathBooks, booksJson);

            Console.WriteLine("\nExport of books completed!\n");
        }

        public static void WriteToXml(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            WriteToXmlAuthors(context, pathAuthors);
            WriteToXmlBooks(context, pathBooks);
        }

        public static void WriteToXmlAuthors(LibraryAppDbContext context, string pathAuthors)
        {
            XmlSerializer xmlAuthors = new XmlSerializer(typeof(List<AuthorExport>));

            using (FileStream writer = new FileStream(pathAuthors, FileMode.Create, FileAccess.Write))
            {
                var authors = RepositoryMethods.GetAuthorsExport(context);
                xmlAuthors.Serialize(writer, authors);
            }

            Console.WriteLine("\nExport of authors completed!\n");
        }
        public static void WriteToXmlBooks(LibraryAppDbContext context, string pathBooks)
        {
            XmlSerializer xmlBooks = new XmlSerializer(typeof(List<BookExport>));

            using (FileStream writer = new FileStream(pathBooks, FileMode.Create, FileAccess.Write))
            {
                var books = RepositoryMethods.GetBooksExport(context);
                xmlBooks.Serialize(writer, books);
            }

            Console.WriteLine("\nExport of books completed!\n");
        }
    }
}
