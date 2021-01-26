using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
