using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class BookCategory:IHasIdentity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }
        public Category Category { get; set; }
        public Book Book { get; set; }
    }
}
