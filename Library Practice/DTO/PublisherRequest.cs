using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.DTO
{
    public class PublisherRequest
    {
        public string publication { get; set; }
        public List<string> book { get; set; }
        public List<string> Author { get; set; }
    }
}
