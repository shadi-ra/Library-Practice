using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class Category:IHasIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}
