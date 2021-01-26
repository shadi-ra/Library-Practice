using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.DataBase;
using Library_Practice.Models;
using Library_Practice.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Library_Practice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Publisherr>, EfRepository<Publisherr>>();
            services.AddTransient<IRepository<Author>, EfRepository<Author>>();
            services.AddTransient<IRepository<Book>, EfRepository<Book>>();
            services.AddTransient<IRepository<Category>, EfRepository<Category>>();
            services.AddScoped<IRepository<BookCategory>, EfRepository<BookCategory>>();
            services.AddScoped<IRepository<BookAuthor>, EfRepository<BookAuthor>>();
            services.AddDbContext<LibraryDbContext>(o =>
            { o.UseSqlServer(Configuration.GetConnectionString("LibraryDbConections")); });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
