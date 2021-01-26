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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> repository;
        public CategoryController(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Category GetCategory([FromQuery] int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return repository.GetAll();
            repository.Save();
        }

        [HttpPost]
        public int InsertCategory([FromBody] Category input)
        {
            repository.Insert(input);
            repository.Save();
            return input.Id;
        }
        [HttpPut]
        public void Update([FromBody] Category input)
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
