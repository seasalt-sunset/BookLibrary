using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public DateTime? DeathDate { get; set; }
        public List<Book> Books { get; set; }

    }
}
