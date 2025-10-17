using LibraryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DTOs
{
    public class AuthorExport
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
