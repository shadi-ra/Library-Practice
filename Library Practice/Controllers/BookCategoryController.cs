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
    public class BookCategoryController : ControllerBase
    {
        private readonly LibraryDbContext libraryContext;
        private readonly IRepository<BookCategory> repository;
        public BookCategoryController(LibraryDbContext libraryContext, IRepository<BookCategory> repository)
        {
            this.libraryContext = libraryContext;
            this.repository = repository;
        }




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
        public int UnRegister([FromQuery] int id)
        {


            var lst = libraryContext.BookCategorys.Where(x => x.Id == id).FirstOrDefault();


            if (lst == null)
            {
                return 0;
            }

            repository.Delete(id);
            repository.Save();
            return id;

        }
        [HttpPut]

        public int Update([FromBody] BookCategory input)
        {
            repository.Update(input);
            repository.Save();
            // mesle crtl s dar data base mibashad savechange
            return input.Id;

        }
        [HttpGet]
        public List<BookCategory> GeAall()
        {
            return repository.GetAll();
        }


    }
}
