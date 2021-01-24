using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
    public class Author:IHasIdentity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
