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
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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

            Console.WriteLine("\nImport completed!\n");
        }

        public static void ReadFromJson(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            string authorsJson = File.ReadAllText(pathAuthors);
            var authors = JsonConvert.DeserializeObject<List<AuthorExport>>(authorsJson);
            RepositoryMethods.ImportAuthors(context, authors);

            string booksJson = File.ReadAllText(pathBooks);
            var books = JsonConvert.DeserializeObject<List<BookExport>>(booksJson);
            RepositoryMethods.ImportBooks(context, books);

            Console.WriteLine("\nImport completed!\n");
        }

        public static void ReadFromXml(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            XmlSerializer xmlAuthors = new XmlSerializer(typeof(List<AuthorExport>));

            using(FileStream reader = new FileStream(pathAuthors, FileMode.Open, FileAccess.Read))
            {
                var authors = (IEnumerable<AuthorExport>) xmlAuthors.Deserialize(reader);
                RepositoryMethods.ImportAuthors(context, authors);
            }

            XmlSerializer xmlBooks = new XmlSerializer(typeof(List<BookExport>));

            using (FileStream reader = new FileStream(pathBooks, FileMode.Open, FileAccess.Read))
            {
                var books = xmlBooks.Deserialize(reader) as IEnumerable<BookExport>;
                RepositoryMethods.ImportBooks(context, books);
            }

            Console.WriteLine("\nImport completed!\n");
        }
    }
}
