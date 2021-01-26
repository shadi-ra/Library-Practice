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
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        public BookCategoryController(LibraryDbContext libraryContext)
        {
            libraryContext = libraryContext;
        }

        public LibraryDbContext libraryContext { get; }


        [HttpPost]
        public int Register([FromBody] BookCategory input)
        {

            var lst = libraryContext.Books.Where(x => x.Id == input.BookId).FirstOrDefault();
            var lst1 = libraryContext.Categories.Where(x => x.Id == input.CategoryId).FirstOrDefault();

            if (lst == null && lst1 == null)
            {
                return 0;
            }

            libraryContext.BookCategorys.Add(input);
            libraryContext.SaveChanges();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }



        [HttpDelete]
        public void UnRegister([FromQuery] BookCategory input)
        {


            var lst = libraryContext.Books.Where(x => x.Id == input.BookId).FirstOrDefault();
            var lst1 = libraryContext.Categories.Where(x => x.Id == input.CategoryId).FirstOrDefault();

            if (lst == null && lst1 == null)
            {
                return;
            }

            libraryContext.BookCategorys.Remove(input);
            libraryContext.SaveChanges();

        }
        [HttpPut]

        public int Update([FromBody] BookCategory input)
        {
            var lst = libraryContext.BookCategorys.FirstOrDefault(x => x.Id == input.Id);
            libraryContext.BookCategorys.Update(input);
            libraryContext.SaveChanges();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }
        [HttpGet]
        public List<BookCategory> GeAall()
        {
            return libraryContext.BookCategorys.ToList();
        }

    }
}
