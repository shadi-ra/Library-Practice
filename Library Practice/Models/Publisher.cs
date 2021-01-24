using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class Publisher:IHasIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> book { get; set; }
    }
}
