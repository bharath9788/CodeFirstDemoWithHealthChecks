using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubjectField Field { get; set; }
        public float Price { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Subject> Subjects { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Subject> Subjects { get; set; }
    }

    public enum SubjectField
    {
        Engineering = 1,
        Medical = 2,
        Commerce = 3
    }

    public class BookDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

       // private readonly IConfiguration _configuration;

        //public string conString
        //{
        //    get
        //    {
        //        return this.conString;
        //    }
        //    set => this.conString = _configuration.GetValue<string>("db_settings:connection_string");
        //}

        public BookDbContext()
            : base("Server=localhost;Database=vul_master;Trusted_Connection=True")
        {

        }
    }
}
