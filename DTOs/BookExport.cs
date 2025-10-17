using LibraryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryApp.DTOs
{
    public class BookExport
    {
        public int BookId { get; set; }

        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime PublishingDate { get; set; }
        public int? NumberOfPages { get; set; }
        public int AuthorId { get; set; }
    }
}
