using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class Book : IHasIdentity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> authors { get; set; }
        public int PublisherrId { get; set; }
        public Publisherr publisherr { get; set; }
        public DateTime PublishDate { get; set; }
        public int ISBN { get; set; }
        public List<Category> categories { get; set; }

    }
}
