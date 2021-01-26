using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.DTO
{
    public class SearchResponse
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
        public DateTime publishDate { get; set; }
        public string publisher { get; set; }
        public int ISBN { get; set; }

         
    }

    public class SearchListBookResponse
    {
        public List<SearchResponse> Books { get; set; }
    }
}
