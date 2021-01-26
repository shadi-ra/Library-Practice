﻿using System;
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
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> repository;
        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Author GetAuthor([FromQuery] int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Author> GetAllAuthor()
        {
            return repository.GetAll();
        }

        [HttpPost]
        public int InsertAuthor([FromBody ] Author input)
        {
            repository.Insert(input);
            return input.Id;
        }
        [HttpPut]
        public void Update([FromBody] Author input)
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
