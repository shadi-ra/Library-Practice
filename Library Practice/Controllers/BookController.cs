using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.DTO;
using Library_Practice.Models;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> repository;
        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Book GetBook([FromQuery] int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Book> GetAllBook()
        {
            return repository.GetAll();
        }

        [HttpPost]
        public int InsertBook([FromBody] Book input)
        {
            repository.Insert(input);
            repository.Save();
            return input.Id;

        }
        [HttpPost]
        public List<Book> Search([FromBody] SearchRequest input)
        {
            var lst = repository.GetAll();
         

            if (input.authors == null)
            {
                return null;
            }

            if (input.categories == null)
            {
                return null;
            }
            if (input.publication == null)
            {
                return null;
            }

            foreach (var item in lst)
            {
                for (int i = 0; i < i; i++)
                {
                    var lst1 = item.authors.Where(x => x.FullName == input.authors[i]).Select(x => x.FullName);

                }
                for (int i = 0; i < input.categories.Count; i++)
                {
                    var lst1 = item.categories.Where(x => x.Name == input.categories[i]);
                }
                var lst3 = item.publisherr.Name == input.publication;

            }


        }
        [HttpPut]
        public void Update([FromBody] Book input)
        {
            repository.Update(input);
            repository.Save();
        }
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();

        }

    }
}
