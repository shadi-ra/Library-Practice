using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Models
{
   public interface IHasIdentity
    {
        int Id { get; set; }
    }
}
