using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.DataBase;
using Library_Practice.Models;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        public BookAuthorController(LibraryDbContext libraryContext)
        {
            libraryContext = libraryContext;
        }

        public LibraryDbContext libraryContext { get; }


        [HttpPost]
        public int Register([FromBody] BookAuthor input)
        {

            var lst = libraryContext.Books.Where(x => x.Id == input.BookId).FirstOrDefault();
            var lst1 = libraryContext.Authors.Where(x => x.Id == input.AuthorId).FirstOrDefault();

            if (lst == null && lst1 == null)
            {
                return 0;
            }

            libraryContext.BookAuthors.Add(input);
            libraryContext.SaveChanges();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }



        [HttpDelete]
        public void UnRegister([FromQuery] BookAuthor input)
        {


            var lst = libraryContext.Books.Where(x => x.Id == input.BookId).FirstOrDefault();
            var lst1 = libraryContext.Authors.Where(x => x.Id == input.AuthorId).FirstOrDefault();

            if (lst == null && lst1 == null)
            {
                return ;
            }

            libraryContext.BookAuthors.Remove(input);
            libraryContext.SaveChanges();

        }
        [HttpPut]

        public int Update([FromBody] BookAuthor input)
        {
            var lst = libraryContext.BookAuthors.FirstOrDefault(x => x.Id == input.Id);
            libraryContext.BookAuthors.Update(input);
            libraryContext.SaveChanges();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }
        [HttpGet]
        public List<BookAuthor> GeAall()
        {
            return libraryContext.BookAuthors.ToList();
        }


    }
}
