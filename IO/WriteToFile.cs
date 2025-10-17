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

namespace LibraryApp.IO
{
    public static class WriteToFile
    {

        public static void WriteToCsv(LibraryAppDbContext context, string pathAuthors, string pathBooks)
        {
            using (StreamWriter writerAuthors = new StreamWriter(pathAuthors))
            using (CsvWriter csvAuthors = new CsvWriter(writerAuthors, CultureInfo.InvariantCulture))
            {
                var allAuthors = RepositoryMethods.GetAuthorsExport(context);
                csvAuthors.WriteRecords(allAuthors);
            }

            using (StreamWriter writerBooks = new StreamWriter(pathBooks))
            using (CsvWriter csvBooks = new CsvWriter(writerBooks, CultureInfo.InvariantCulture))
            {
                var allBooks = RepositoryMethods.GetBooksExport(context);
                csvBooks.WriteRecords(allBooks);
            }

        }

        public static void WriteToJson(LibraryAppDbContext context, string path, string pathBooks)
        {

        }

        public static void WriteToXml(LibraryAppDbContext context, string path, string pathBooks)
        {

        }
    }
}
