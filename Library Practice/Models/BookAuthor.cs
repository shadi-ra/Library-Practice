using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class BookAuthor:IHasIdentity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public List<Author> authors   { get; set; }
        public List<Book> books { get; set; }
    }
}
