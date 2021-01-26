using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.Models;

namespace Library_Practice.DTO
{
    public class SearchRequest
    {
        public List<string> authors { get; set; }
        public List<string> categories { get; set; }
        public string publication { get; set; }
    }
}
