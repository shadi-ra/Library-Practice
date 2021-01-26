using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Library_Practice.Models;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherrController : ControllerBase
    {
        private readonly IRepository<Publisherr> repository;
        public PublisherrController(IRepository<Publisherr> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Publisherr GetPublisherr([FromQuery] int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Publisherr> GetAllPublisherr()
        {
            return repository.GetAll();
        }

        [HttpPost]
         public void  InsertPublisherr([FromBody] Publisherr input)
        {
            
            repository.Insert(input);
            repository.Save();
                                                   
        }
        [HttpPut]
        public void Update([FromBody] Publisherr input)
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
