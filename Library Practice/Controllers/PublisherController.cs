using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IRepository<Publisher> repository;
        public PublisherController(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Publisher GetPublisher([FromQuery] int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Publisher> GetAllPublisher()
        {
            return repository.GetAll();
        }

        [HttpPost]
         public void  InsertPublisher([FromBody] Publisher publisher)
        {
            repository.Insert(publisher);
           
        }
        [HttpPut]
        public void Update([FromBody] Publisher input)
        {
            repository.Update(input);
        }
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            repository.Delete(id);

        }

    }
}
