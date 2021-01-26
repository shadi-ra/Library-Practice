using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.DTO;
using Library_Practice.Models;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> bookRepository;

        private readonly IRepository<BookCategory> bookCategoryRepository;

        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Publisherr> publisherRepository;
        private readonly IRepository<BookAuthor> BookAuthorRepository;

        public BookController(IRepository<Book> bookRepository, IRepository<BookCategory> bookCategoryRepository
            , IRepository<Category> categoryRepository
            , IRepository<Author> authorRepository
            , IRepository<Publisherr> publisherRepository, IRepository<BookAuthor> BookAuthorRepository)
        {
            this.categoryRepository = categoryRepository;
            this.bookRepository = bookRepository;
            this.bookCategoryRepository = bookCategoryRepository;
            this.authorRepository = authorRepository;
            this.publisherRepository = publisherRepository;
            this.BookAuthorRepository = BookAuthorRepository;
        }

        [HttpGet]
        public Book GetBook([FromQuery] int id)
        {
            return bookRepository.Get(id);
        }
        [HttpGet]
        public List<Book> GetAllBook()
        {
            return bookRepository.GetAll();
        }

        [HttpPost]
        public int InsertBook([FromBody] Book input)
        {
            bookRepository.Insert(input);
            bookRepository.Save();
            return input.Id;

        }
        [HttpPost]
        public SearchListBookResponse Search([FromBody] SearchRequest input)
        {
           

            int publisherId = 0;
            var categoryIds = categoryRepository.GetAll().Where(x => input.categories.Contains(x.Name)).Select(x => x.Id).ToList();

            var authorIds = authorRepository.GetAll().Where(x => input.authors.Contains(x.FullName)).Select(x => x.Id).ToList();

            var publisher = publisherRepository.GetAll().Where(x => x.Name == input.publication).FirstOrDefault();
            if (publisher != null)
            {
                publisherId = publisher.Id;
            }


            var bookId1 = bookCategoryRepository.GetAll().Where(x => categoryIds.Contains(x.CategoryId)).Select(x => x.BookId).ToList();

            var bookId2 = BookAuthorRepository.GetAll().Where(x => authorIds.Contains(x.AuthorId)).Select(x => x.BookId).ToList();

            bookId1.AddRange(bookId2);

            List<Book> books = new List<Book>();
            if (bookId1.Count != 0)
            {
                books = bookRepository.GetAll().Where(x => bookId1.Contains(x.Id)).ToList();
            }
            if (publisherId != 0)
            {
                var books1 = bookRepository.GetAll().Where(x => bookId1.Contains(x.Id) && x.PublisherrId == publisherId).ToList();
                books.AddRange(books1);
            }

            if (books.Count != 0) 
            {
               var resp = books.Select(x => new SearchResponse()
                {
                    title = x.Title,
                    authors = x.BookAuthors.Select(x => x.Author.FullName).ToList(),
                    publishDate = x.PublishDate,
                    publisher = x.publisherr.Name,
                    ISBN = x.ISBN
                }).ToList();

                return new SearchListBookResponse() { Books = resp };
            }
            return null;
      
        }
        [HttpPut]
        public void Update([FromBody] Book input)
        {
            bookRepository.Update(input);
            bookRepository.Save();
        }
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            bookRepository.Delete(id);
            bookRepository.Save();

        }

    }
}
