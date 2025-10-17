using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime PublishingDate { get; set; }
        public int? NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
