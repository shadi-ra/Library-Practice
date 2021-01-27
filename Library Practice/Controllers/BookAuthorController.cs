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
        private readonly LibraryDbContext libraryContext;
        private readonly IRepository<BookAuthor> repository;
        public BookAuthorController(LibraryDbContext libraryContext, IRepository<BookAuthor> repository)
        {
           this.libraryContext = libraryContext;
            this.repository = repository;
        }

       


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
        public int UnRegister([FromQuery] int id)
        {


            var lst = libraryContext.BookAuthors.Where(x => x.Id == id).FirstOrDefault();


            if (lst == null )
            {
                return 0 ;
            }

            repository.Delete(id);
           repository.Save();
            return id;

        }
        [HttpPut]

        public int Update([FromBody] BookAuthor input)
        {
            repository.Update(input);
            repository.Save();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }
        [HttpGet]
        public List<BookAuthor> GeAall()
        {
            return repository.GetAll();
        }


    }
}
