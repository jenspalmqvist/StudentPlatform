using Microsoft.EntityFrameworkCore;
using StudentPlatform.API.Models;

namespace StudentPlatform.API.Data 
{
    public class Context : DbContext 
    {
        // Our DbSet properties tells the context (which talks to the database)
        // which tables exist, DbSet is a type which comes from Entity Framework
        // and defines a tables structure from the class we specify 
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=StudentPlatform;Trusted_Connection=True;Trust Server Certificate=Yes");
        }
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

        public Context()
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudentPlatform;Trusted_Connection=True;Trust Server Certificate=Yes");
            }
        }
        
    }
}