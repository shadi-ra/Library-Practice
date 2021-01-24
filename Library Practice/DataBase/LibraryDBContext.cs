using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Practice.DataBase
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategorys { get; set; }
        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>(x => x.ToTable("Book"));
            modelbuilder.Entity<Author>(x => x.ToTable("Author"));
            modelbuilder.Entity<Category>(x => x.ToTable("Category"));
            modelbuilder.Entity<Publisher>(x => x.ToTable("Publisher"));
            modelbuilder.Entity<BookAuthor>(x => x.ToTable("BookAuthor"));
            modelbuilder.Entity<BookCategory>(x => x.ToTable("BookCategory"));
        }
    }
}
